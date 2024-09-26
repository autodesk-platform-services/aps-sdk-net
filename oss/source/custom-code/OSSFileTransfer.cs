/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * oss
 *
 * The Object Storage Service (OSS) allows your application to download and upload raw files (such as PDF, XLS, DWG, or RVT) that are managed by the Data service.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Forge.Core;
using Autodesk.Oss.Http;
using Autodesk.Oss.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Oss
{
    static class Constants
    {
        public const int MaxRetry = 5;
        public const ulong ChunkSize = 5 * 1024 * 1024;
        public const int BatchSize = 25;
    }

    /// <summary>
    /// Custom code for upload/download
    /// </summary>
    public class OSSFileTransfer : IOSSFileTransfer
    {
        private ILogger _logger;
        private IFileTransferConfigurations _configuration;
        private ObjectsApi objectsApi;
        // private IAuthClient _authentication;
        private IAuthenticationProvider authProvider;

        private int _maxRetryOnTokenExpiry;
        private int _maxChunkCountAllowed;
        private int _maxRetryOnUrlExpiry;

        static ForgeService _forgeService;

        private readonly string _accessTokenExpiredMessage = "Access token provided is invalid or expired.";
        private readonly string _forbiddenMessage = "403 (Forbidden)";

        public OSSFileTransfer(IFileTransferConfigurations configuration,
            // IAuthClient authentication,
            SDKManager.SDKManager sdkManager,
            IAuthenticationProvider authenticationProvider = default,
            AdskEnvironment adskEnvironment = AdskEnvironment.Prd,
            ILogger logger = null)
        {
            //Commented out since Authentication is not implemented
            // if (authentication == null)
            // {
            //     throw new ArgumentNullException("IAuthentication");
            // }
            _forgeService = ForgeService.CreateDefault();
            _configuration = configuration;
            _logger = logger ?? NullLogger.Instance;
            objectsApi = new ObjectsApi(sdkManager);

            _maxChunkCountAllowed = _configuration.GetMaxChunkCountAllowed();
            _maxRetryOnUrlExpiry = _configuration.GetMaxRetryOnUrlExpiry();
            _maxRetryOnTokenExpiry = _configuration.GetMaxRetryOnTokenExpiry();

            if (authenticationProvider != null)
            {
                authProvider = authenticationProvider;
            }

            // _authentication = authentication;
        }

        private async Task<bool> IsFileSizeAllowed(Stream filePath)
        {
            return await Task.Run(() =>
            {

                long fileSize = filePath.Length;
                double numberOfChunks = CalculateNumberOfChunks((ulong)fileSize);
                if (numberOfChunks > this._maxChunkCountAllowed)
                {
                    return false;
                }
                return true;
            });
        }

        public async Task<HttpResponseMessage> Upload(
            string bucketKey,
            string objectKey,
            Stream sourceToUpload,
            string accessToken,
            CancellationToken cancellationToken,
            string requestIdPrefix = "",
            IProgress<int> progress = null)
        {
            var requestId = HandleRequestId(requestIdPrefix, bucketKey, objectKey);
            var retryCount = _configuration.GetRetryCount();

            _logger.LogDebug("{requestId} Config retry setting was: {retryCount}", requestId, retryCount);

            await ValidateFileSize(requestId, sourceToUpload);

            progress?.Report(1);
            ulong numberOfChunks = (ulong)CalculateNumberOfChunks((ulong)sourceToUpload.Length);
            ulong chunksUploaded = 0;

            long start = 0;
            List<string> uploadUrls = new List<string>();
            string uploadKey = null;

            _logger.LogInformation("{requestId} Total chunk to be uploaded: {numberOfChunks}", requestId, numberOfChunks);

            using (BinaryReader reader = new BinaryReader(sourceToUpload))
            {
                while (chunksUploaded < numberOfChunks)
                {
                    ThrowIfCancellationRequested(cancellationToken, requestId);

                    int attempts = 0;

                    long end = Math.Min((long)((chunksUploaded + 1) * Constants.ChunkSize), sourceToUpload.Length);
                    byte[] fileBytes = readFileBytes(reader, start, end);

                    var retryUrlExpiryCount = 0;

                    while (true)
                    {
                        ThrowIfCancellationRequested(cancellationToken, requestId);

                        attempts++;

                        _logger.LogInformation("{requestId} Uploading part {chunksUploaded}, attempt {attempts}", requestId, chunksUploaded + 1, attempts);

                        if (uploadUrls.Count == 0)
                        {
                            retryUrlExpiryCount++;

                            var (uploadUrlsResponse, currentAccessToken) = await GetUploadUrlsWithRetry(bucketKey, objectKey, (int)numberOfChunks, (int)chunksUploaded, uploadKey, accessToken, requestId);

                            uploadKey = uploadUrlsResponse.UploadKey;
                            uploadUrls = uploadUrlsResponse.Urls;

                            accessToken = currentAccessToken;
                        }

                        string currentUrl = uploadUrls[0];
                        uploadUrls.RemoveAt(0);
                        try
                        {
                            ThrowIfCancellationRequested(cancellationToken, requestId);

                            var responseBuffer = await UploadToURL(currentUrl, fileBytes);
                            int statusCode = (int)responseBuffer.StatusCode;

                            if (statusCode == (int)HttpStatusCode.Forbidden && retryUrlExpiryCount == _maxRetryOnUrlExpiry)
                            {
                                _logger.LogDebug("{requestId} URL can not be refreshed.", requestId);
                                throw new S3ServiceApiException($"{requestId} URL can not be refreshed", statusCode);
                            }

                            if (statusCode == (int)HttpStatusCode.Forbidden)
                            {
                                _logger.LogWarning("{requestId} 403, refreshing urls, attempt: {retryUrlExpiryCount}", requestId, retryUrlExpiryCount);
                                uploadUrls = new List<string>();
                                continue;
                            }

                            if (statusCode >= (int)HttpStatusCode.BadRequest)
                            {
                                throw new S3ServiceApiException($"{requestId} {responseBuffer.Content}", statusCode);
                            }

                            goto NextChunk;

                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message);
                            if (attempts == Constants.MaxRetry)
                            {
                                _logger.LogError("{requestId} Couldn't upload chunk after max retry of {maxRetry}", requestId, Constants.MaxRetry);
                                throw new S3ServiceApiException($"{requestId} {ex.Message}", 500);
                            }
                        }
                    }

                NextChunk:
                    chunksUploaded++;
                    start = end;

                    int percentCompleted = (int)(((double)chunksUploaded / (double)numberOfChunks) * 100);
                    progress?.Report(percentCompleted);

                    _logger.LogInformation("{requestId} Number of chunks uploaded : {chunksUploaded}", requestId, chunksUploaded);
                }
            }

            var completeResponse = await objectsApi.CompleteSignedS3UploadAsync(
                bucketKey: bucketKey,
                objectKey: objectKey,
                contentType: "application/json",
                body: new Completes3uploadBody()
                {
                    UploadKey = uploadKey
                },
                accessToken: accessToken);

            progress?.Report(100);
            return completeResponse;
        }

        private byte[] readFileBytes(BinaryReader reader, long start, long end)
        {
            double numberOfBytes = end - start;
            byte[] fileBytes = new byte[(int)numberOfBytes];

            reader.BaseStream.Seek(start, SeekOrigin.Begin);
            reader.Read(fileBytes, 0, (int)numberOfBytes);

            return fileBytes;
        }

        private async Task<(Signeds3uploadResponse, string)> GetUploadUrlsWithRetry(string bucketKey, string objectKey, int numberOfChunks, int chunksUploaded, string uploadKey, string accessToken, string requestId)
        {
            var attemptCount = 0;
            var parts = Math.Min(numberOfChunks - chunksUploaded, Constants.BatchSize);
            var firstPart = chunksUploaded + 1;

            do
            {
                _logger.LogInformation("{requestId} Refreshing URL attempt:{attemptCount}.", requestId, attemptCount);

                try
                {
                    var response = await objectsApi.SignedS3UploadAsync(
                          bucketKey: bucketKey,
                          objectKey: objectKey,
                          parts: parts,
                          firstPart: firstPart,
                          uploadKey: uploadKey,
                          accessToken: accessToken);

                    return (response.Content, accessToken);
                }
                catch (OssApiException e)
                {
                    if (e.Message.Contains(_accessTokenExpiredMessage))
                    {
                        attemptCount++;

                        // accessToken = _authentication.GetUpdatedAccessToken();
                        accessToken = await authProvider.GetAccessToken();
                        _logger.LogInformation("{requestId} Token expired. Trying to refresh", requestId);
                    }
                    else
                    {
                        _logger.LogWarning("{requestId} Error: {errorMessage}", requestId, e.Message);
                        throw e;
                    }
                }
            } while (attemptCount < _maxRetryOnTokenExpiry);

            throw new OssApiException($"{requestId} Error: Fail getting upload urls after maximum retry");
        }

        private double CalculateNumberOfChunks(ulong fileSize)
        {
            if (fileSize == 0)
            {
                return 1;
            }

            double numberOfChunks = (int)Math.Truncate((double)(fileSize / Constants.ChunkSize));
            if (fileSize % Constants.ChunkSize != 0)
            {
                numberOfChunks++;
            }

            return numberOfChunks;
        }

        private async Task<dynamic> UploadToURL(string url, byte[] buffer)
        {
            var client = new HttpClient();
            var httpContent = new ByteArrayContent(buffer);
            return await _forgeService.Client.PutAsync(url, httpContent);
        }

        public async Task<Stream> Download(string bucketKey, string objectKey,
            string accessToken,
            CancellationToken cancellationToken,
            string requestIdPrefix = "",
            IProgress<int> progress = null)
        {

            var requestId = HandleRequestId(requestIdPrefix, bucketKey, objectKey);

            progress?.Report(1);

            var response = await GetS3SignedDownloadUrlWithRetry(bucketKey, objectKey, accessToken, requestId);
            var fileSize = response.Content.Size;
            double numberOfChunks = CalculateNumberOfChunks((ulong)fileSize);
            double partsDownloaded = 0;
            double start = 0;

            MemoryStream memoryStream = new MemoryStream();
            {
                while (partsDownloaded < numberOfChunks)
                {
                    ThrowIfCancellationRequested(cancellationToken, requestId);
                    _logger.LogInformation("{requestId} Downloading part: {partsDownloaded}", requestId, partsDownloaded + 1);
                    double end = Math.Min((partsDownloaded + 1) * Constants.ChunkSize, fileSize.Value);

                    if (start == end)
                    {
                        break;
                    }

                    var attemptCount = 0;
                    while (attemptCount < _maxRetryOnUrlExpiry)
                    {
                        try
                        {
                            attemptCount++;
                            _logger.LogDebug("{requestId} Downloading file range : {start} - {end}", requestId, start, end);
                            await WriteToFileStreamFromUrl(memoryStream, response.Content.Url, start, end, requestId);
                            start = end + 1;
                            partsDownloaded++;
                            int percentCompleted = (int)(((double)partsDownloaded / (double)numberOfChunks) * 100);
                            progress?.Report(percentCompleted);
                            break;
                        }
                        catch (Exception ex) when (ex is HttpRequestException || ex is AggregateException)
                        {
                            if (attemptCount == _maxRetryOnUrlExpiry)
                            {
                                _logger.LogDebug(
                                "{requestId} Reached maximum retries. S3 signed Url can not be renewed.",
                                requestId);
                                memoryStream.Dispose();
                                throw new S3ServiceApiException($"{requestId} URL can not be renewed", (int)HttpStatusCode.InternalServerError);
                            }
                            if (!ex.Message.Contains(_forbiddenMessage))
                            {
                                _logger.LogDebug("{requestId} Error: {errorMessage}", requestId, ex.Message);
                                memoryStream.Dispose();
                                throw new S3ServiceApiException($"{requestId} Error {ex.Message}", (int)HttpStatusCode.InternalServerError);
                            }

                            _logger.LogInformation("{requestId} S3 signed Url is expired. Refreshing the Url", requestId);
                            response = await GetS3SignedDownloadUrlWithRetry(bucketKey, objectKey, accessToken, requestId);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError("{requestId} Error: {errorMessage}", requestId, ex.Message);
                            memoryStream.Dispose();
                            throw new FileTransferException($"{requestId} Error {ex.Message}");
                        }
                    }
                }
                return memoryStream;
            }
        }

        private async Task WriteToFileStreamFromUrl(Stream memoryStream, string contentUrl, double start, double end,
            string requestId)
        {
            _forgeService.Client.DefaultRequestHeaders.Add("Range", "bytes=" + start + "-" + end);
            var streamAsync = _forgeService.Client.GetByteArrayAsync(contentUrl);
            _forgeService.Client.DefaultRequestHeaders.Remove("Range");
            var available = streamAsync.Result.Length;
            await memoryStream.WriteAsync(streamAsync.Result, 0, available);
        }

        private string HandleRequestId(string parentRequestId, string bucketKey, string objectKey)
        {
            var requestId = !string.IsNullOrEmpty(parentRequestId) ? parentRequestId : Guid.NewGuid().ToString();
            requestId = requestId + ":" + GenerateSdkRequestId(bucketKey, objectKey);
            _forgeService.Client.DefaultRequestHeaders.Add("x-ads-request-id", requestId);
            return requestId;
        }

        private string GenerateSdkRequestId(string bucketKey, string objectKey)
        {
            return bucketKey + "/" + objectKey;
        }

        private async Task<ApiResponse<Signeds3downloadResponse>> GetS3SignedDownloadUrlWithRetry(string bucketKey, string objectKey,
          string accessToken, string requestId)
        {
            var attemptCount = 0;
            do
            {
                _logger.LogInformation(
                "{requestId} Get signed URL to download directly from S3 attempt: {attemptCount}", requestId,
                attemptCount);

                try
                {
                    var response = await objectsApi.SignedS3DownloadAsync(
                    bucketKey: bucketKey,
                    objectKey: objectKey,
                    accessToken: accessToken);

                    if (response.Content.Status != DownloadStatus.Complete)
                    {
                        _logger.LogError("{requestId} File not available for download yet.", requestId);
                        throw new OssApiException($"{requestId} File not available for download yet.");
                    }

                    return response;
                }
                catch (OssApiException ex)
                {
                    if (ex.Message.Contains(_accessTokenExpiredMessage))
                    {
                        attemptCount++;
                        // accessToken = _authentication.GetUpdatedAccessToken();
                        accessToken = await authProvider.GetAccessToken();
                        _logger.LogInformation("{requestId} Token expired. Trying to refresh", requestId);
                    }
                    else
                    {
                        _logger.LogError("{requestId} Error: {errorMessage}", requestId, ex.Message);
                        throw ex;
                    }
                }
            } while (attemptCount < _maxRetryOnTokenExpiry);

            throw new OssApiException($"{requestId} Failed to get download urls after maximum retry.");
        }

        private async Task ValidateFileSize(string requestId, Stream sourceToUpload)
        {
            var sizeAllowed = await IsFileSizeAllowed(sourceToUpload);
            if (!sizeAllowed)
            {
                throw new FileTransferException($"{requestId} File size too big to upload. Currently max file size allowed is {(double)_maxChunkCountAllowed * Constants.ChunkSize} bytes");
            }
        }

        // TODO - FORCE-4250, implement a templated validation layer
        private void ValidateProjectScopeName(string requestId, string projectScope)
        {
            string scopeRegex = "^([a-zA-Z0-9.\\-_]{3,50}(,?)){1,20}$";
            if (!(String.IsNullOrEmpty(projectScope) || Regex.Match(projectScope, scopeRegex).Success))
            {
                throw new FileTransferException($"{requestId} Parameter 'projectScope' doesn't pass regex test - user must submit a valid scope.");
            }
        }

        private void ThrowIfCancellationRequested(CancellationToken cancellationToken, string requestId)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("{requestId} Cancellation requested.", requestId);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
