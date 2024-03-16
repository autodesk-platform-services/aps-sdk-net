using Autodesk.Forge.Core;
using System;
using System.Net.Http;
using Autodesk.Oss.Http;
using Autodesk.Oss.Model;
using Autodesk.Oss.Client;
using System.Threading;
using System.Threading.Tasks;

namespace Autodesk.Oss
{

    public class OssClient
    {
        public IOSSApi OSSApi { get; }

        public OSSFileTransfer oSSFileTransfer { get; set; } 

        public OssClient(SDKManager.SDKManager sdkManager)
        {
            this.OSSApi = new OSSApi(sdkManager);
            this.oSSFileTransfer = new OSSFileTransfer(new FileTransferConfigurations(3) ,null);

        }


        public async System.Threading.Tasks.Task<ObjectDetails> Upload(string bucketKey, string objectKey, string sourceToUpload, string accessToken, CancellationToken cancellationToken, string projectScope = "", string requestIdPrefix = "", IProgress<int> progress = null)
        {
        var response = await this.oSSFileTransfer.Upload( bucketKey,  objectKey, sourceToUpload,  accessToken,  cancellationToken,  projectScope , requestIdPrefix ,  progress );
        var apiResponse = new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));
        return apiResponse.Content;
        }
        public async Task Download(string bucketKey, string objectKey,string filePath,string accessToken,CancellationToken cancellationToken,string projectScope = "",string requestIdPrefix = "",IProgress<int> progress = null)
        {
            await this.oSSFileTransfer.Download(bucketKey,objectKey,filePath,accessToken,cancellationToken,projectScope,requestIdPrefix,progress);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Instructs OSS to complete the object creation process for numerous objects after their bytes have been uploaded directly to S3. An object will not be accessible until you complete the object creation process, either with this endpoint or the single Complete Upload endpoint. This endpoint accepts batch sizes of up to 25. Any larger and the request will fail.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects, each of which represents an upload to complete. (optional)</param>
        /// <returns>Task of ApiResponse<BatchcompleteuploadResponse></returns>

        public async System.Threading.Tasks.Task<BatchcompleteuploadResponse> BatchCompleteUploadAsync(string bucketKey, BatchcompleteuploadObject requests = default(BatchcompleteuploadObject), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.BatchCompleteUploadAsync(bucketKey, requests, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets one or more signed URLs to download objects. The signed URLs can be used to download the objects directly from S3, skipping OSS servers. Be aware that expiration time for the signed URL(s) is just 60 seconds. So, a request to the URL(s) must begin within 60 seconds; the transfer of the data can exceed 60 seconds. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects representing each request for a signed download URL.</param>/// <param name="publicResourceFallback">Indicates that for each requested object, OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse<Batchsigneds3downloadResponse></returns>

        public async System.Threading.Tasks.Task<Batchsigneds3downloadResponse> BatchSignedS3DownloadAsync(string bucketKey, Batchsigneds3downloadObject requests, bool? publicResourceFallback = default(bool?), int? minutesExpiration = default(int?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.BatchSignedS3DownloadAsync(bucketKey, requests, publicResourceFallback, minutesExpiration, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Requests a batch of S3 signed URL with which to upload multiple objects or chunks of multiple objects. As with the Batch Get Download URL endpoint, the requests within the batch are evaluated independently and individual requests can be rejected even if the overall request returns a 200 response code. You can request a maximum of 25 URLs in a single request.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="useAcceleration">Whether or not to generate an accelerated signed URL (ie: URLs of the form ...s3-accelerate.amazonaws.com... vs ...s3.amazonaws.com...). When not specified, defaults to true. Providing non-boolean values will result in a 400 error. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="requests">An array of objects, each of which represents a signed URL / URLs to retrieve. (optional)</param>
        /// <returns>Task of ApiResponse<Batchsigneds3uploadResponse></returns>

        public async System.Threading.Tasks.Task<Batchsigneds3uploadResponse> BatchSignedS3UploadAsync(string bucketKey, bool? useAcceleration = default(bool?), int? minutesExpiration = default(int?), Batchsigneds3uploadObject requests = default(Batchsigneds3uploadObject), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.BatchSignedS3UploadAsync(bucketKey, useAcceleration, minutesExpiration, requests, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Instructs OSS to complete the object creation process after the bytes have been uploaded directly to S3.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="contentType">Must be exactly &#x60;application/json&#x60;.</param>/// <param name="body"></param>/// <param name="xAdsMetaContentType">The Content-Type value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaContentDisposition">The Content-Disposition value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaContentEncoding">The Content-Encoding value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaCacheControl">The Cache-Control value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsUserDefinedMetadata">This parameter allows setting any custom metadata to be stored with the object, which can be retrieved later on download or when getting the object details. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CompleteSignedS3UploadAsync(string bucketKey, string objectKey, string contentType, Completes3uploadBody body, string xAdsMetaContentType = default(string), string xAdsMetaContentDisposition = default(string), string xAdsMetaContentEncoding = default(string), string xAdsMetaCacheControl = default(string), string xAdsUserDefinedMetadata = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.CompleteSignedS3UploadAsync(bucketKey, objectKey, contentType, body, xAdsMetaContentType, xAdsMetaContentDisposition, xAdsMetaContentEncoding, xAdsMetaCacheControl, xAdsUserDefinedMetadata, accessToken, throwOnError);
            return response;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Copies an object to another object name in the same bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="newObjName">URL-encoded Object key to use as the destination</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>
        /// <returns>Task of ApiResponse<ObjectDetails></returns>

        public async System.Threading.Tasks.Task<ObjectDetails> CopyToAsync(string bucketKey, string objectKey, string newObjName, string xAdsAcmNamespace = default(string), string xAdsAcmCheckGroups = default(string), string xAdsAcmGroups = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.CopyToAsync(bucketKey, objectKey, newObjName, xAdsAcmNamespace, xAdsAcmCheckGroups, xAdsAcmGroups, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a bucket. Buckets are arbitrary spaces created and owned by applications. Bucket keys are globally unique across all regions, regardless of where they were created, and they cannot be changed. The application creating the bucket is the owner of the bucket. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; </param>/// <param name="policyKey">Length of time for objects in the bucket to exist; &#x60;transient&#x60; (24h),  &#x60;temporary&#x60; (30d), or &#x60;persistent&#x60; (until delete request). </param>
        /// <returns>Task of ApiResponse<Bucket></returns>

        public async System.Threading.Tasks.Task<Bucket> CreateBucketAsync(string xAdsRegion, CreateBucketsPayload policyKey, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.CreateBucketAsync(xAdsRegion, policyKey, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///  An application owning a bucket can use this method to grant access rights to other applications for the bucket. A successful response includes a list of all consumer keys that have been explicitly granted some level of access. Access rights sent in a request are merged with existing access rights already in place. If an application already has some access to the bucket, the new access value passed in will be applied, effectively acting as an overwrite. Note: there is a limit of 60 services that can be given access to a single bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="body">Body Structure</param>
        /// <returns>Task of ApiResponse<CreateObjectGrant></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint creates a signed URL that can be used to download an object within the specified expiration time. Be aware that if the object the signed URL points to is deleted or expires before the signed URL expires, then the signed URL will no longer be valid. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="access">Access for signed resource Acceptable values: &#x60;read&#x60;, &#x60;write&#x60;, &#x60;readwrite&#x60;. Default value: &#x60;read&#x60;  (optional, default to read)</param>/// <param name="useCdn">When this is provided, OSS will return a URL that does not point to https://developer.api.autodesk.com.... , but instead points towards an alternate domain. A client can then interact with this public resource exactly as they would for a classic public resource in OSS, i.e. make a GET request to download an object or a PUT request to upload an object. (optional)</param>/// <param name="createSignedResource"> (optional)</param>
        /// <returns>Task of ApiResponse<CreateObjectSigned></returns>

        public async System.Threading.Tasks.Task<CreateObjectSigned> CreateSignedResourceAsync(string bucketKey, string objectKey, string access = null, bool? useCdn = default(bool?), CreateSignedResource createSignedResource = default(CreateSignedResource), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.CreateSignedResourceAsync(bucketKey, objectKey, access, useCdn, createSignedResource, accessToken, throwOnError);
            return response.Content;
        }/// <summary>
         /// 
         /// </summary>
         /// <remarks>
         /// Delete the bucket with the specified key
         /// </remarks>
         /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="bucketKey">URL-encoded bucket key</param>

         /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync(string bucketKey, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.DeleteBucketAsync(bucketKey, accessToken, throwOnError);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deletes an object from the bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded key of the bucket containing the object.</param>/// <param name="objectKey">URL-encoded key of the object to delete.</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteObjectAsync(string bucketKey, string objectKey, string xAdsAcmNamespace = default(string), string xAdsAcmCheckGroups = default(string), string xAdsAcmGroups = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.DeleteObjectAsync(bucketKey, objectKey, xAdsAcmNamespace, xAdsAcmCheckGroups, xAdsAcmGroups, accessToken, throwOnError);
            return response;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a signed URL. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSignedResourceAsync(string hash, string region = null, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.DeleteSignedResourceAsync(hash, region, accessToken, throwOnError);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the details about the specified bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>
        /// <returns>Task of ApiResponse<Bucket></returns>

        public async System.Threading.Tasks.Task<Bucket> GetBucketDetailsAsync(string bucketKey, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.GetBucketDetailsAsync(bucketKey, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the buckets owned by the application. This endpoint supports pagination. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="startAt">Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse<Buckets></returns>

        public async System.Threading.Tasks.Task<Buckets> GetBucketsAsync(string region = null, int? limit = default(int?), string startAt = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.GetBucketsAsync(region, limit, startAt, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns object details in JSON format.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="with">Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;, &#x60;userDefinedMetadata&#x60;  (optional)</param>
        /// <returns>Task of ApiResponse<ObjectFullDetails></returns>

        public async System.Threading.Tasks.Task<ObjectFullDetails> GetObjectDetailsAsync(string bucketKey, string objectKey, DateTime? ifModifiedSince = default(DateTime?), string xAdsAcmNamespace = default(string), string xAdsAcmCheckGroups = default(string), string xAdsAcmGroups = default(string), string with = null, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.GetObjectDetailsAsync(bucketKey, objectKey, ifModifiedSince, xAdsAcmNamespace, xAdsAcmCheckGroups, xAdsAcmGroups, with, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// List objects in a bucket. It is only available to the bucket creator.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="beginsWith">Provides a way to filter the based on object key name (optional)</param>/// <param name="startAt">Key to use as an offset to continue pagination. This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse<BucketObjects></returns>

        public async System.Threading.Tasks.Task<BucketObjects> GetObjectsAsync(string bucketKey, int? limit = default(int?), string beginsWith = default(string), string startAt = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.GetObjectsAsync(bucketKey, limit, beginsWith, startAt, accessToken, throwOnError);
            return response.Content;
        } /// <summary>
          /// 
          /// </summary>
          /// <remarks>
          /// Download an object using a signed URL.
          /// </remarks>
          /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
          /// <param name="hash">Hash of signed resource</param>/// <param name="range">A range of bytes to download from the specified object. (optional)</param>/// <param name="ifNoneMatch">The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="acceptEncoding">When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  (optional)</param>/// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition HTTP header you expect to receive. If the parameter is not provided, the value associated with the object is used. (optional)</param>/// <param name="responseContentType">Value of the Content-Type HTTP header you expect to receive in the download response. (optional)</param>
          /// <returns>Task of ApiResponse<System.IO.Stream></returns>

        public async System.Threading.Tasks.Task<System.IO.Stream> GetSignedResourceAsync(string hash, string range = default(string), string ifNoneMatch = default(string), DateTime? ifModifiedSince = default(DateTime?), string acceptEncoding = default(string), string region = null, string responseContentDisposition = default(string), string responseContentType = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.GetSignedResourceAsync(hash, range, ifNoneMatch, ifModifiedSince, acceptEncoding, region, responseContentDisposition, responseContentType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns an empty response body and a 200 response code if the object exists.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="with">Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;  (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> HeadObjectDetailsAsync(string bucketKey, string objectKey, DateTime? ifModifiedSince = default(DateTime?), string xAdsAcmNamespace = default(string), string xAdsAcmCheckGroups = default(string), string xAdsAcmGroups = default(string), string with = null, string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.HeadObjectDetailsAsync(bucketKey, objectKey, ifModifiedSince, xAdsAcmNamespace, xAdsAcmCheckGroups, xAdsAcmGroups, with, accessToken, throwOnError);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Upload an object to this bucket using the body of a POST request, as multipart form data. If during the upload, OSS determines that the combination of bucket key + object key already exists, then the uploaded content will overwrite the existing object. Even if it is possible to upload multiple files in the same request, it is better to create one request for each and paralellize the uploads.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="contentLength">Indicates the size of the request body. Since the multipart type is complex, this is usually computed after building the body and getting its length.</param>/// <param name="xAdsObjectName">The key of the object being uploaded. Must be URL-encoded, and it must be 3-1024 characters including any UTF-8 encoding for foreign character support. If an object with this key already exists in the bucket, the object will be overwritten.</param>/// <param name="xAdsObjectSize">The size in bytes of the file to upload.</param>/// <param name="contentType">Must be the multipart type followed by the boundary used; example: &#39;multipart/form-data, boundary&#x3D;AaB03x&#39;. (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="xAdsMetaCacheControl">The value of this header will be stored with the uploaded object. The value will be used as the &#39;Cache-Control&#39; header in the response when the object is downloaded. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PostUploadAsync(string bucketKey, int? contentLength, string xAdsObjectName, decimal? xAdsObjectSize, string contentType = default(string), string xAdsAcmNamespace = default(string), string xAdsAcmCheckGroups = default(string), string xAdsAcmGroups = default(string), string xAdsMetaCacheControl = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.PostUploadAsync(bucketKey, contentLength, xAdsObjectName, xAdsObjectSize, contentType, xAdsAcmNamespace, xAdsAcmCheckGroups, xAdsAcmGroups, xAdsMetaCacheControl, accessToken, throwOnError);
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to a download an object directly from S3, bypassing OSS servers. This signed URL expires in 60 seconds, so the request must begin within that time frame; the actual data transfer can take longer. Note that resumable uploads store each chunk individually; after the upload completes, an async process merges all the chunks and creates the definitive OSS file. If you request a signed URL before the async process completes, the response returns a map of S3 URLs, one per chunk; the key is the byte range of the total file to which the chunk corresponds. If you need a single URL in the response, you can use OSS signed resource functionality by setting the &#39;public-resource-fallback&#39; query parameter to true. Lastly, note that ranged downloads can be used with the returned URL.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="ifNoneMatch">If the value of this header matches the ETag of the object, an entity will not be returned from the server; instead a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="responseContentType">Value of the Content-Type header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition header that the client expects to receive. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseCacheControl">Value of the Cache-Control header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="publicResourceFallback">Indicates that OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="useCdn">This will generate a CloudFront URL for the S3 object. (optional)</param>/// <param name="redirect">Generates a HTTP redirection response (Temporary Redirect 307​) using the generated URL. (optional)</param>
        /// <returns>Task of ApiResponse<Signeds3downloadResponse></returns>

        public async System.Threading.Tasks.Task<Signeds3downloadResponse> SignedS3DownloadAsync(string bucketKey, string objectKey, string ifNoneMatch = default(string), DateTime? ifModifiedSince = default(DateTime?), string xAdsAcmScopes = default(string), string responseContentType = default(string), string responseContentDisposition = default(string), string responseCacheControl = default(string), bool? publicResourceFallback = default(bool?), int? minutesExpiration = default(int?), bool? useCdn = default(bool?), bool? redirect = default(bool?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.SignedS3DownloadAsync(bucketKey, objectKey, ifNoneMatch, ifModifiedSince, xAdsAcmScopes, responseContentType, responseContentDisposition, responseCacheControl, publicResourceFallback, minutesExpiration, useCdn, redirect, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to upload an object in a single request, or an array of signed URLs with which to upload an object in multiple parts.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="parts">For a multipart upload, the number of chunk upload URLs to return. If X is provided, the response will include chunk URLs from 1 to X. If none provided, the response will include only a single URL with which to upload an entire object. (optional)</param>/// <param name="firstPart">Index of first part in the parts collection. (optional)</param>/// <param name="uploadKey">The identifier of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. This must match the &#x60;uploadKey&#x60; returned by a previous call to this endpoint where the client requested more than one part URL. If none provided, OSS will initiate a new upload entirely. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse<Signeds3uploadResponse></returns>

        public async System.Threading.Tasks.Task<Signeds3uploadResponse> SignedS3UploadAsync(string bucketKey, string objectKey, string xAdsAcmScopes = default(string), int? parts = default(int?), int? firstPart = default(int?), string uploadKey = default(string), int? minutesExpiration = default(int?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.SignedS3UploadAsync(bucketKey, objectKey, xAdsAcmScopes, parts, firstPart, uploadKey, minutesExpiration, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Upload an object using a signed URL. If the signed resource is available and its expiration period is valid, you can overwrite the existing object via a signed URL upload using the &#39;access&#39; query parameter with value &#39;write&#39; or &#39;readwrite&#39;.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="contentLength">Indicates the size of the request body.</param>/// <param name="body">The object to upload.</param>/// <param name="contentType">The MIME type of the object to upload; can be any type except &#39;multipart/form-data&#39;. This can be omitted, but we recommend adding it. (optional)</param>/// <param name="contentDisposition">The suggested default filename when downloading this object to a file after it has been uploaded. (optional)</param>/// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="ifMatch">If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional)</param>
        /// <returns>Task of ApiResponse<ObjectDetails></returns>

        public async System.Threading.Tasks.Task<ObjectDetails> UploadSignedResourceAsync(string hash, int? contentLength, System.IO.Stream body, string contentType = default(string), string contentDisposition = default(string), string xAdsRegion = null, string ifMatch = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.OSSApi.UploadSignedResourceAsync(hash, contentLength, body, contentType, contentDisposition, xAdsRegion, ifMatch, accessToken, throwOnError);
            return response.Content;
        }
    }


}
