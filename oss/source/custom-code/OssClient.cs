using Autodesk.Forge.Core;
using System;
using System.Net.Http;
using Autodesk.Oss.Http;
using Autodesk.Oss.Model;
using Autodesk.Oss.Client;
using System.Threading;
using System.IO;
using Autodesk.SDKManager;

namespace Autodesk.Oss
{
    /// <summary>
    /// Represents the OSS client.
    /// </summary>
    public class OssClient : BaseClient
    {
        /// <summary>
        /// The API for interacting with Oss buckets.
        /// </summary>
        public BucketsApi bucketsApi { get; }
        /// <summary>
        /// The API for interacting with objects within Oss.
        /// </summary>
        public ObjectsApi objectsApi { get; }


        /// <summary>
        /// The OSS file transfer object.
        /// </summary>
        public OSSFileTransfer oSSFileTransfer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OssClient"/> class.
        /// </summary>
        /// <param name="sdkManager">The SDK manager.</param>
        /// <param name="authenticationProvider"></param>
        public OssClient( SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default): base(authenticationProvider)
        {
            if(sdkManager == null){
                sdkManager= SdkManagerBuilder.Create().Build();
            }
            this.bucketsApi = new BucketsApi(sdkManager);
            this.objectsApi = new ObjectsApi(sdkManager);
            this.oSSFileTransfer = new OSSFileTransfer(new FileTransferConfigurations(3),sdkManager,authenticationProvider);

        }

        /// <summary>
        /// Upload a Stream.
        /// </summary>
        /// <remarks>
        /// Uploads a file by transparently handling operations like obtaining signed upload URLs, chunking large files for optimal transfer, and notifying OSS to assemble the uploaded parts.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="sourceToUpload">
        ///Stream of the of file to be uploded or 
        ///Path of the file to be uploaded  
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor cancellation requests.
        /// (optional)
        /// <param name="requestIdPrefix">
        /// (optional)
        /// A prefix to be added to the request ID.
        /// </param>
        /// <param name="progress">
        /// An IProgress object to report upload progress.
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Upload&gt;</returns>
        public async System.Threading.Tasks.Task<ObjectDetails> Upload(string bucketKey, string objectKey, Stream sourceToUpload, CancellationToken cancellationToken = default, string requestIdPrefix = "", IProgress<int> progress = null, string accessToken = default)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.oSSFileTransfer.Upload(bucketKey, objectKey, sourceToUpload, accessToken, cancellationToken, requestIdPrefix, progress);
            var apiResponse = new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));
            return apiResponse.Content;
        }
        /// <summary>
        /// Upload a File
        /// </summary>
        /// <remarks>
        /// Uploads a file by transparently handling operations like obtaining signed upload URLs, chunking large files for optimal transfer, and notifying OSS to assemble the uploaded parts.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        /// The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        /// The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="sourceToUpload">
        /// Stream of the of file to be uploaded or 
        /// Path of the file to be uploaded  
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor cancellation requests.
        /// (optional)
        /// </param>
        /// <param name="requestIdPrefix">
        /// A prefix to be added to the request ID.
        /// (optional)
        /// </param>
        /// <param name="progress">
        /// An IProgress object to report upload progress.
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Upload&gt;</returns>
        public async System.Threading.Tasks.Task<ObjectDetails> Upload(string bucketKey, string objectKey, string sourceToUpload, CancellationToken cancellationToken = default,  string requestIdPrefix = "", IProgress<int> progress = null, string accessToken = default)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }

            FileStream fileStream = File.OpenRead(sourceToUpload);
            var response = await this.oSSFileTransfer.Upload(bucketKey, objectKey, fileStream, accessToken, cancellationToken, requestIdPrefix, progress);
            var apiResponse = new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));
            return apiResponse.Content;
        }

        /// <summary>
        /// Dwonload a File
        /// </summary>
        /// <remarks>
        ///Downloads a file by transparently handling operations like obtaining signed download URLs and chunking large files for optimal transfer.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="filePath">
        /// The Path of the file to be downloaded.
        /// </param>
        /// <param name="cancellationToken">
        /// A token to monitor cancellation requests.
        /// (optional)
        /// </param>
        /// <param name="requestIdPrefix">
        /// A prefix to be added to the request ID.
        /// (optional)
        /// </param>
        /// <param name="progress">
        /// An IProgress object to report upload progress.
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Downlaod&gt;</returns>
        public async System.Threading.Tasks.Task Download(string bucketKey, string objectKey, string filePath, CancellationToken cancellationToken = default,  string requestIdPrefix = "", IProgress<int> progress = null,string accessToken = default)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            await this.oSSFileTransfer.Download(bucketKey, objectKey, filePath, accessToken, cancellationToken, requestIdPrefix, progress);
        }
        /// <summary>
        /// Complete Batch Upload to S3 Signed URLs
        /// </summary>
        /// <remarks>
        ///Requests OSS to start reconstituting the set of objects that were uploaded using signed S3 upload URLs. You must call this operation only after all the objects have been uploaded. 
        ///
        ///You can specify up to 25 objects in this operation. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="requests">
        /// The request payload for the Complete Batch Upload to S3 Signed URLs operation.
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;BatchcompleteuploadResponse&gt;</returns>
        public async System.Threading.Tasks.Task<BatchcompleteuploadResponse> BatchCompleteUploadAsync(string accessToken, string bucketKey, BatchcompleteuploadObject requests, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.BatchCompleteUploadAsync(bucketKey, requests, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Batch Generate Signed S3 Download URLs
        /// </summary>
        /// <remarks>
        ///Creates and returns signed URLs to download a set of objects directly from S3. These signed URLs expire in 2 minutes by default, but you can change this duration if needed.  You must start download the objects before the signed URLs expire. The download itself can take longer.
        ///
        ///Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="requests">
        /// The request payload for the Complete Batch S3 download operation.
        /// </param>
        /// <param name="publicResourceFallback">
        ///Specifies how to return the signed URLs, in case the object was uploaded in chunks, and assembling of chunks is not yet complete.
        ///
        ///- `true` : Return a single signed OSS URL.
        ///- `false` : (Default) Return multiple signed S3 URLs, where each URL points to a chunk. (optional)
        /// </param>
        /// <param name="minutesExpiration">
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
        ///
        ///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL. (optional)
        /// </param>
        /// <returns>Task of &lt;Batchsigneds3downloadResponse&gt;</returns>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        public async System.Threading.Tasks.Task<Batchsigneds3downloadResponse> BatchSignedS3DownloadAsync(string bucketKey, Batchsigneds3downloadObject requests, bool? publicResourceFallback = default(bool?), int? minutesExpiration = default(int?), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.BatchSignedS3DownloadAsync(bucketKey, requests, publicResourceFallback, minutesExpiration, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Batch Generate Signed S3 Upload URLs
        /// </summary>
        /// <remarks>
        ///Creates and returns signed URLs to upload a set of objects directly to S3. These signed URLs expire in 2 minutes by default, but you can change this duration if needed.  You must start uploading the objects before the signed URLs expire. The upload  itself can take longer.
        ///
        ///Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error.
        ///
        ///If required, you can request an array of signed URLs for each object, which lets you upload the objects in chunks. Once you upload all chunks you must call the [Complete Batch Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-batchcompleteupload-POST/) operation to indicate completion. This instructs OSS to assemble the chunks and reconstitute the object on OSS. You must call this operation even if you requested a single signed URL for an object.
        ///
        ///If an upload fails after the validity period of a signed URL has elapsed, you can call this operation again to obtain fresh signed URLs. However, you must use the same `uploadKey` that was returned when you originally called this operation. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="requests">
        /// The request payload for a Batch Generate Signed S3 Upload URLs operation.
        /// </param>
        /// <param name="useAcceleration">
        ///`true` : (Default) Generates a faster S3 signed URL using Transfer Acceleration.
        ///
        ///`false`: Generates a standard S3 signed URL. (optional)
        /// </param>
        /// <param name="minutesExpiration">
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
        ///
        ///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>      
        /// <returns>Task of &lt;Batchsigneds3uploadResponse&gt;</returns>

        public async System.Threading.Tasks.Task<Batchsigneds3uploadResponse> BatchSignedS3UploadAsync(string bucketKey, Batchsigneds3uploadObject requests , bool? useAcceleration = default(bool?), int? minutesExpiration = default(int?), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.BatchSignedS3UploadAsync(bucketKey, useAcceleration, minutesExpiration, requests, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Complete Upload to S3 Signed URL
        /// </summary>
        /// <remarks>
        ///Requests OSS to assemble and reconstitute the object that was uploaded using signed S3 upload URL. You must call this operation only after all parts/chunks of the object has been uploaded.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="contentType">
        ///Must be `application/json`.
        /// </param>
        /// <param name="body">
        /// The request payload for a Complete Upload to S3 Signed URL operation.
        /// </param>
        /// <param name="xAdsMetaContentType">
        ///The Content-Type value for the uploaded object to record within OSS. (optional)
        /// </param>
        /// <param name="xAdsMetaContentDisposition">
        ///The Content-Disposition value for the uploaded object to record within OSS. (optional)
        /// </param>
        /// <param name="xAdsMetaContentEncoding">
        ///The Content-Encoding value for the uploaded object to record within OSS. (optional)
        /// </param>
        /// <param name="xAdsMetaCacheControl">
        ///The Cache-Control value for the uploaded object to record within OSS. (optional)
        /// </param>
        /// <param name="xAdsUserDefinedMetadata">
        ///Custom metadata to be stored with the object, which can be retrieved later on download or when retrieving object details. Must be a JSON object that is less than 100 bytes. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CompleteSignedS3UploadAsync(string bucketKey, string objectKey, string contentType, Completes3uploadBody body, string xAdsMetaContentType = default(string), string xAdsMetaContentDisposition = default(string), string xAdsMetaContentEncoding = default(string), string xAdsMetaCacheControl = default(string), string xAdsUserDefinedMetadata = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.CompleteSignedS3UploadAsync(bucketKey, objectKey, contentType, body, xAdsMetaContentType, xAdsMetaContentDisposition, xAdsMetaContentEncoding, xAdsMetaCacheControl, xAdsUserDefinedMetadata, accessToken, throwOnError);
            return response;
        }

        /// <summary>
        /// Copy Object
        /// </summary>
        /// <remarks>
        ///Creates a copy of an object within the bucket.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="newObjName">
        ///A URL-encoded human friendly name to identify the copied object.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;ObjectDetails&gt;</returns>

        public async System.Threading.Tasks.Task<ObjectDetails> CopyToAsync(string bucketKey, string objectKey, string newObjName, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.CopyToAsync(bucketKey, objectKey, newObjName, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Create Bucket
        /// </summary>
        /// <remarks>
        ///Creates a bucket. 
        ///
        ///Buckets are virtual container within the Object Storage Service (OSS), which you can use to store and manage objects (files) in the cloud. The application creating the bucket is the owner of the bucket.
        ///
        ///**Note:** Do not use this operation to create buckets for BIM360 Document Management. Use [POST projects/{project_id}/storage](/en/docs/data/v2/reference/http/projects-project_id-storage-POST>) instead. For details, see [Upload Files to BIM 360 Document Management](/en/docs/bim360/v1/tutorials/document-management/upload-document).
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">
        ///Specifies where the bucket must be stored. Possible values are:
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>     
        /// <param name="bucketsPayload">
        /// The payload containing bucket creation details.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Bucket&gt;</returns>
        public async System.Threading.Tasks.Task<Bucket> CreateBucketAsync(Region xAdsRegion, CreateBucketsPayload bucketsPayload, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.bucketsApi.CreateBucketAsync(bucketsPayload, xAdsRegion, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Generate OSS Signed URL
        /// </summary>
        /// <remarks>
        ///Generates a signed URL that can be used to download or upload an object within the specified expiration time. If the object the signed URL points to is deleted or expires before the signed URL expires, the signed URL will no longer be valid.
        ///
        ///In addition to this operation that generates OSS signed URLs, OSS provides operations to generate S3 signed URLs. S3 signed URLs allow direct upload/download from S3 but are restricted to bucket owners. OSS signed URLs also allow upload/download and can be configured for access by other applications, making them suitable for sharing objects across applications.
        ///
        ///Only the application that owns the bucket containing the object can call this operation.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="createSignedResource">
        /// The request payload for the Generate OSS Signed URL operation.
        /// </param>
        /// <param name="access">
        /// Specifies the type of access for signed resource Possible values: read, write, readwrite Default value: read
        /// (optional)
        /// </param>
        /// <param name="useCdn">
        ///`true` : Returns a Cloudfront URL to the object instead of an Autodesk URL (one that points to a location on https://developer.api.autodesk.com). Applications can interact with the Cloudfront URL exactly like with any classic public resource in OSS. They can use GET requests to download objects or PUT requests to upload objects.
        ///
        ///`false` : (Default) Returns an Autodesk URL (one that points to a location on https://developer.api.autodesk.com) to the object. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>       
        /// <returns>Task of &lt;CreateObjectSigned&gt;</returns>

        public async System.Threading.Tasks.Task<CreateObjectSigned> CreateSignedResourceAsync(string bucketKey, string objectKey, CreateSignedResource createSignedResource, Access? access = null, bool? useCdn = default(bool?), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.CreateSignedResourceAsync(bucketKey, objectKey, access, useCdn, createSignedResource, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Delete Bucket
        /// </summary>
        /// <remarks>
        ///Deletes the specified bucket. Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error. 
        ///
        ///The initial processing of a bucket deletion request can be time-consuming. So, we recommend only deleting buckets containing a few objects, like those typically used for acceptance testing and prototyping. 
        ///
        ///**Note:** Bucket keys will not be immediately available for reuse. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to delete.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync(string bucketKey, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.bucketsApi.DeleteBucketAsync(bucketKey, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Delete Object
        /// </summary>
        /// <remarks>
        ///Deletes an object from the bucket.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteObjectAsync(string bucketKey, string objectKey,string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.DeleteObjectAsync(bucketKey, objectKey, accessToken, throwOnError);
            return response;

        }
        /// <summary>
        /// Delete Object Using Signed URL
        /// </summary>
        /// <remarks>
        ///Delete an object using an OSS signed URL to access it.
        ///
        ///Only applications that own the bucket containing the object can call this operation. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="hash">
        ///The ID component of the signed URL.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/) contains `hash` as a URI parameter.
        /// </param>
        /// <param name="region">
        ///Specifies where the bucket containing the object stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSignedResourceAsync(string hash, Region? region = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.DeleteSignedResourceAsync(hash, region, accessToken, throwOnError);
            return response;
        }
        /// <summary>
        /// Get Bucket Details
        /// </summary>
        /// <remarks>
        ///Returns detailed information about the specified bucket.
        ///
        ///**Note:** Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to query.
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// 
        /// </param>
        /// <returns>Task of &lt;Bucket&gt;</returns>

        public async System.Threading.Tasks.Task<Bucket> GetBucketDetailsAsync(string bucketKey, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.bucketsApi.GetBucketDetailsAsync(bucketKey, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Buckets
        /// </summary>
        /// <remarks>
        ///Returns a list of buckets owned by the application. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="region">
        ///Specifies where the bucket containing the object stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <param name="limit">
        ///The number of items you want per page.
        ///Acceptable values = 1-100. Default = 10. (optional, default to 10)
        /// </param>
        /// <param name="startAt">
        ///The ID of the last item that was returned in the previous result set.  It enables the system to return subsequent items starting from the next one after the specified ID. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Buckets&gt;</returns>
        public async System.Threading.Tasks.Task<Buckets> GetBucketsAsync(Region? region = null, int? limit = default(int?), string startAt = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.bucketsApi.GetBucketsAsync(region, limit, startAt, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Get Object Details
        /// </summary>
        /// <remarks>
        ///Returns detailed information about the specified object.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="ifModifiedSince">
        ///A timestamp in the HTTP date format (Mon, DD Month YYYY HH:MM:SS GMT). The requested data is returned only if the object has been modified since the specified timestamp. If not, a 304 (Not Modified) HTTP status is returned. (optional)
        /// </param>
        /// <param name="with">
        /// Specifies additional information to include in the response. Possible values: - `createdDate` - `lastAccessedDate` - `lastModifiedDate` - `userDefinedMetadata`
        /// (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;ObjectFullDetails&gt;</returns>
        public async System.Threading.Tasks.Task<ObjectFullDetails> GetObjectDetailsAsync(string bucketKey, string objectKey, DateTime? ifModifiedSince = default(DateTime?), With? with = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.GetObjectDetailsAsync(bucketKey, objectKey, ifModifiedSince, with, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Objects
        /// </summary>
        /// <remarks>
        ///Returns a list objects in the specified bucket. 
        ///
        ///Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="limit">
        ///The number of items you want per page.
        ///Acceptable values = 1-100. Default = 10. (optional, default to 10)
        /// </param>
        /// <param name="beginsWith">
        ///Filters the results by the value you specify. Only the objects with their `objectKey` beginning with the specified string are returned. (optional)
        /// </param>
        /// <param name="startAt">
        ///The ID of the last item that was returned in the previous result set.  It enables the system to return subsequent items starting from the next one after the specified ID. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;BucketObjects&gt;</returns>
        public async System.Threading.Tasks.Task<BucketObjects> GetObjectsAsync(string bucketKey, int? limit = default(int?), string beginsWith = default(string), string startAt = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.GetObjectsAsync(bucketKey, limit, beginsWith, startAt, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Download Object Using Signed URL
        /// </summary>
        /// <remarks>
        ///Downloads an object using an OSS signed URL.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/)  contains the `hash` URI parameter as well. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="hash">
        ///The ID component of the signed URL.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/) contains `hash` as a URI parameter.
        /// </param>
        /// <param name="range">
        ///The byte range to download, specified in the form `bytes=&lt;START_BYTE&gt;-&lt;END_BYTE&gt;`. (optional)
        /// </param>
        /// <param name="ifNoneMatch">
        ///The last known ETag value of the object. OSS returns the requested data  only if the `If-None-Match` header differs from the ETag value of the object on OSS, which indicates that the object on OSS is newer. If not, it returns a 304 "Not Modified" HTTP status. (optional)
        /// </param>
        /// <param name="ifModifiedSince">
        ///A timestamp in the HTTP date format (Mon, DD Month YYYY HH:MM:SS GMT). The requested data is returned only if the object has been modified since the specified timestamp. If not, a 304 (Not Modified) HTTP status is returned. (optional)
        /// </param>
        /// <param name="acceptEncoding">
        ///The compression format your prefer to receive the data. Possible values are:
        ///
        ///- `gzip` - Use the gzip format
        ///
        ///**Note:** You cannot use `Accept-Encoding:gzip` with a Range header containing an end byte range. OSS will not honor the End byte range if `Accept-Encoding: gzip` header is used. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies where the bucket containing the object stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <param name="responseContentDisposition">
        ///The value of the Content-Disposition header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Disposition header defaults to the value stored with OSS. (optional)
        /// </param>
        /// <param name="responseContentType">
        ///The value of the Content-Type header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Type header defaults to the value stored with OSS. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;System.IO.Stream&gt;</returns>
        public async System.Threading.Tasks.Task<System.IO.Stream> GetSignedResourceAsync(string hash, string range = default(string), string ifNoneMatch = default(string), DateTime? ifModifiedSince = default(DateTime?), string acceptEncoding = default(string), Region? region = null, string responseContentDisposition = default(string), string responseContentType = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.GetSignedResourceAsync(hash, range, ifNoneMatch, ifModifiedSince, acceptEncoding, region, responseContentDisposition, responseContentType, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Generate Signed S3 Download URL
        /// </summary>
        /// <remarks>
        ///Gets a signed URL to download an object directly from S3, bypassing OSS servers. This signed URL expires in 2 minutes by default, but you can change this duration if needed.  You must start the download before the signed URL expires. The download itself can take longer. If the download fails after the validity period of the signed URL has elapsed, you can call this operation again to obtain a fresh signed URL.
        ///
        ///Only applications that have read access to the object can call this operation.   
        ///
        ///You can use range headers with the signed download URL to download the object in chunks. This ability lets you download chunks in parallel, which can result in faster downloads.
        ///
        ///If the object you want to download was uploaded in chunks and is still assembling on OSS, you will receive multiple S3 URLs instead of just one. Each URL will point to a chunk. If you prefer to receive a single URL, set the `public-resource-fallback` query parameter to `true`. This setting will make OSS fallback to returning a single signed OSS URL, if assembling is still in progress. 
        ///
        ///In addition to this operation that generates S3 signed URLs, OSS provides an operation to generate OSS signed URLs. S3 signed URLs allow direct upload/download from S3 but are restricted to bucket owners. OSS signed URLs also allow upload/download and can be configured for access by other applications, making them suitable for sharing objects across applications.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="ifNoneMatch">
        ///The last known ETag value of the object. OSS returns the signed URL only if the `If-None-Match` header differs from the ETag value of the object on S3. If not, it returns a 304 "Not Modified" HTTP status. (optional)
        /// </param>
        /// <param name="ifModifiedSince">
        ///A timestamp in the HTTP date format (Mon, DD Month YYYY HH:MM:SS GMT). The signed URL is returned only if the object has been modified since the specified timestamp. If not, a 304 (Not Modified) HTTP status is returned. (optional)
        /// </param>
        /// <param name="xAdsAcmScopes">
        ///Optional OSS-compliant scope reference to increase bucket search performance (optional)
        /// </param>
        /// <param name="responseContentType">
        ///The value of the Content-Type header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Type header defaults to the value stored with OSS. (optional)
        /// </param>
        /// <param name="responseContentDisposition">
        ///The value of the Content-Disposition header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Disposition header defaults to the value stored with OSS. (optional)
        /// </param>
        /// <param name="responseCacheControl">
        ///The value of the Cache-Control header you want to receive when you download the object using the signed URL. If you do not specify a value, the Cache-Control header defaults to the value stored with OSS. (optional)
        /// </param>
        /// <param name="publicResourceFallback">
        ///Specifies how to return the signed URLs, in case the object was uploaded in chunks, and assembling of chunks is not yet complete.
        ///
        ///- `true` : Return a single signed OSS URL.
        ///- `false` : (Default) Return multiple signed S3 URLs, where each URL points to a chunk. (optional)
        /// </param>
        /// <param name="minutesExpiration">
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
        ///
        ///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL. (optional)
        /// </param>
        /// <param name="useCdn">
        ///`true` : Returns a URL that points to a CloudFront edge location.
        ///
        ///`false` : (Default) Returns a URL that points directly to the S3 object. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Signeds3downloadResponse&gt;</returns>
        public async System.Threading.Tasks.Task<Signeds3downloadResponse> SignedS3DownloadAsync(string bucketKey, string objectKey, string ifNoneMatch = default(string), DateTime? ifModifiedSince = default(DateTime?), string xAdsAcmScopes = default(string), string responseContentType = default(string), string responseContentDisposition = default(string), string responseCacheControl = default(string), bool? publicResourceFallback = default(bool?), int? minutesExpiration = default(int?), bool? useCdn = default(bool?), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.SignedS3DownloadAsync(bucketKey, objectKey, ifNoneMatch, ifModifiedSince, responseContentType, responseContentDisposition, responseCacheControl, publicResourceFallback, minutesExpiration, useCdn, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Generate Signed S3 Upload URL
        /// </summary>
        /// <remarks>
        ///Gets a signed URL to upload an object directly to S3, bypassing OSS servers. You can also request an array of signed URLs which lets you upload an object in chunks.
        ///
        ///This signed URL expires in 2 minutes by default, but you can change this duration if needed.  You must start the upload before the signed URL expires. The upload itself can take longer. If the upload fails after the validity period of the signed URL has elapsed, you can call this operation again to obtain a fresh signed URL (or an array of signed URLs as the case may be). However, you must use the same `uploadKey` that was returned when you originally called this operation. 
        ///
        ///Only applications that own the bucket can call this operation.
        ///
        ///**Note:** Once you upload all chunks you must call the [Complete Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-signeds3upload-POST/) operation to indicate completion. This instructs OSS to assemble the chunks and reconstitute the object on OSS. You must call this operation even when using a single signed URL. 
        ///
        ///In addition to this operation that generates S3 signed URLs, OSS provides an operation to generate OSS signed URLs. S3 signed URLs allow direct upload/download from S3 but are restricted to bucket owners. OSS signed URLs also allow upload/download and can be configured for access by other applications, making them suitable for sharing objects across applications.    
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket that contains the objects you are operating on.
        /// </param>
        /// <param name="objectKey">
        ///The URL-encoded human friendly name of the object.
        /// </param>
        /// <param name="parts">
        ///The number of parts you intend to chunk the object for uploading. OSS will return that many signed URLs, one URL for each chunk. If you do not specify a value you'll get only one URL to upload the entire object.              (optional)
        /// </param>
        /// <param name="firstPart">
        ///The index of the first chunk to be uploaded. (optional)
        /// </param>
        /// <param name="uploadKey">
        ///The `uploadKey` of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. If you do not specify a value, OSS will initiate a new upload entirely. (optional)
        /// </param>
        /// <param name="minutesExpiration">
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
        ///
        ///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL. (optional)
        /// </param>
        /// <param name="useAcceleration">
        ///`true` : (Default) Generates a faster S3 signed URL using Transfer Acceleration.
        ///
        ///`false`: Generates a standard S3 signed URL. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;Signeds3uploadResponse&gt;</returns>

        public async System.Threading.Tasks.Task<Signeds3uploadResponse> SignedS3UploadAsync(string bucketKey, string objectKey, int? parts = default(int?), int? firstPart = default(int?), string uploadKey = default(string), int? minutesExpiration = default(int?), bool? useAcceleration = default(bool?), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.SignedS3UploadAsync(bucketKey, objectKey, parts, firstPart, uploadKey, minutesExpiration, useAcceleration, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Replace Object Using Signed URL
        /// </summary>
        /// <remarks>
        ///Replaces an object that already exists on OSS, using an OSS signed URL. 
        ///
        ///The signed URL must fulfil the following conditions:
        ///
        ///- The signed URL is valid (it has not expired as yet).
        ///- It was generated with `write` or `readwrite` for the `access` parameter.
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="hash">
        ///The ID component of the signed URL.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/) contains `hash` as a URI parameter.
        /// </param>
        /// <param name="contentLength">
        ///The size of the data contained in the request body, in bytes.
        /// </param>
        /// <param name="body">
        ///The object to upload.
        /// </param>
        /// <param name="contentType">
        ///The MIME type of the object to upload; can be any type except 'multipart/form-data'. This can be omitted, but we recommend adding it. (optional)
        /// </param>
        /// <param name="contentDisposition">
        ///The suggested file name to use when this object is downloaded as a file. (optional)
        /// </param>
        /// <param name="xAdsRegion">
        ///Specifies where the bucket containing the object stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <param name="ifMatch">
        ///The current value of the `sha1` attribute of the object you want to replace. OSS checks the `If-Match` header against the `sha1` attribute of the object in OSS. If they match, OSS allows the object to be overwritten. Otherwise, it means that the object on OSS has been modified since you retrieved the `sha1` and the request fails. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;ObjectDetails&gt;</returns>

        public async System.Threading.Tasks.Task<ObjectDetails> UploadSignedResourceAsync(string hash, int? contentLength, System.IO.Stream body, string contentType = default(string), string contentDisposition = default(string), Region? xAdsRegion = null, string ifMatch = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.UploadSignedResourceAsync(hash, contentLength, body, contentType, contentDisposition, xAdsRegion, ifMatch, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Upload Object Using Signed URL
        /// </summary>
        /// <remarks>
        ///Performs a resumable upload using an OSS signed URL. Use this operation to upload an object in chunks.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/) contains the `hash` as a URI parameter. 
        /// </remarks>
        /// <exception cref="OssApiException">Thrown when fails to make API call</exception>
        /// <param name="hash">
        ///The ID component of the signed URL.
        ///
        ///**Note:** The signed URL returned by [Generate OSS Signed URL](/en/docs/data/v2/reference/http/signedresources-:id-GET/) contains `hash` as a URI parameter.
        /// </param>
        /// <param name="contentRange">
        ///The byte range to upload, specified in the form `bytes=&lt;START_BYTE&gt;-&lt;END_BYTE&gt;`.
        /// </param>
        /// <param name="sessionId">
        ///An ID to uniquely identify the file upload session.
        /// </param>
        /// <param name="body">
        ///The chunk to upload.
        /// </param>
        /// <param name="contentType">
        ///The MIME type of the object to upload; can be any type except 'multipart/form-data'. This can be omitted, but we recommend adding it. (optional)
        /// </param>
        /// <param name="contentDisposition">
        ///The suggested file name to use when this object is downloaded as a file. (optional)
        /// </param>
        /// <param name="xAdsRegion">
        ///Specifies where the bucket containing the object stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa.
        ///- `APAC` -  (Beta) Data center for Australia.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). 
        ///(optional)
        /// </param>
        /// <param name="throwOnError">
        /// Specifies whether to throw an error if the API call fails.
        /// (optional)
        /// </param>
        /// <returns>Task of &lt;ObjectDetails&gt;</returns>

        public async System.Threading.Tasks.Task<ObjectDetails> UploadSignedResourcesChunkAsync(string hash, string contentRange, string sessionId, System.IO.Stream body, string contentType = default(string), string contentDisposition = default(string), Region? xAdsRegion = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.objectsApi.UploadSignedResourcesChunkAsync(hash, contentRange, sessionId, body, contentType, contentDisposition, xAdsRegion, accessToken, throwOnError);
            return response.Content;
        }
    }


}
