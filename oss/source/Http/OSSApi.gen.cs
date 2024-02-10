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
using Autodesk.Forge.Core;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using Autodesk.Oss.Model;
using Autodesk.Oss.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Oss.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOSSApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Instructs OSS to complete the object creation process for numerous objects after their bytes have been uploaded directly to S3. An object will not be accessible until you complete the object creation process, either with this endpoint or the single Complete Upload endpoint. This endpoint accepts batch sizes of up to 25. Any larger and the request will fail.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects, each of which represents an upload to complete. (optional)</param>
        /// <returns>Task of ApiResponse&#60;BatchcompleteuploadResponse&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<BatchcompleteuploadResponse>> BatchCompleteUploadAsync (string bucketKey, BatchcompleteuploadObject requests= default(BatchcompleteuploadObject),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets one or more signed URLs to download objects. The signed URLs can be used to download the objects directly from S3, skipping OSS servers. Be aware that expiration time for the signed URL(s) is just 60 seconds. So, a request to the URL(s) must begin within 60 seconds; the transfer of the data can exceed 60 seconds. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects representing each request for a signed download URL.</param>/// <param name="publicResourceFallback">Indicates that for each requested object, OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Batchsigneds3downloadResponse&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Batchsigneds3downloadResponse>> BatchSignedS3DownloadAsync (string bucketKey, Batchsigneds3downloadObject requests, bool? publicResourceFallback= default(bool?), int? minutesExpiration= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Requests a batch of S3 signed URL with which to upload multiple objects or chunks of multiple objects. As with the Batch Get Download URL endpoint, the requests within the batch are evaluated independently and individual requests can be rejected even if the overall request returns a 200 response code. You can request a maximum of 25 URLs in a single request.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="useAcceleration">Whether or not to generate an accelerated signed URL (ie: URLs of the form ...s3-accelerate.amazonaws.com... vs ...s3.amazonaws.com...). When not specified, defaults to true. Providing non-boolean values will result in a 400 error. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="requests">An array of objects, each of which represents a signed URL / URLs to retrieve. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Batchsigneds3uploadResponse&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Batchsigneds3uploadResponse>> BatchSignedS3UploadAsync (string bucketKey, bool? useAcceleration= default(bool?), int? minutesExpiration= default(int?), Batchsigneds3uploadObject requests= default(Batchsigneds3uploadObject),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Instructs OSS to complete the object creation process after the bytes have been uploaded directly to S3.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="contentType">Must be exactly &#x60;application/json&#x60;.</param>/// <param name="body"></param>/// <param name="xAdsMetaContentType">The Content-Type value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaContentDisposition">The Content-Disposition value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaContentEncoding">The Content-Encoding value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsMetaCacheControl">The Cache-Control value for the uploaded object to record within OSS. (optional)</param>/// <param name="xAdsUserDefinedMetadata">This parameter allows setting any custom metadata to be stored with the object, which can be retrieved later on download or when getting the object details. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CompleteSignedS3UploadAsync (string bucketKey, string objectKey, string contentType, Completes3uploadBody body, string xAdsMetaContentType= default(string), string xAdsMetaContentDisposition= default(string), string xAdsMetaContentEncoding= default(string), string xAdsMetaCacheControl= default(string), string xAdsUserDefinedMetadata= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Copies an object to another object name in the same bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="newObjName">URL-encoded Object key to use as the destination</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> CopyToAsync (string bucketKey, string objectKey, string newObjName, string xAdsAcmNamespace= default(string), string xAdsAcmCheckGroups= default(string), string xAdsAcmGroups= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a bucket. Buckets are arbitrary spaces created and owned by applications. Bucket keys are globally unique across all regions, regardless of where they were created, and they cannot be changed. The application creating the bucket is the owner of the bucket. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; </param>/// <param name="policyKey">Length of time for objects in the bucket to exist; &#x60;transient&#x60; (24h),  &#x60;temporary&#x60; (30d), or &#x60;persistent&#x60; (until delete request). </param>
        /// <returns>Task of ApiResponse&#60;Bucket&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Bucket>> CreateBucketAsync (string xAdsRegion, CreateBucketsPayload policyKey,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint creates a signed URL that can be used to download an object within the specified expiration time. Be aware that if the object the signed URL points to is deleted or expires before the signed URL expires, then the signed URL will no longer be valid. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="access">Access for signed resource Acceptable values: &#x60;read&#x60;, &#x60;write&#x60;, &#x60;readwrite&#x60;. Default value: &#x60;read&#x60;  (optional, default to read)</param>/// <param name="useCdn">When this is provided, OSS will return a URL that does not point to https://developer.api.autodesk.com.... , but instead points towards an alternate domain. A client can then interact with this public resource exactly as they would for a classic public resource in OSS, i.e. make a GET request to download an object or a PUT request to upload an object. (optional)</param>/// <param name="createSignedResource"> (optional)</param>
        /// <returns>Task of ApiResponse&#60;CreateObjectSigned&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<CreateObjectSigned>> CreateSignedResourceAsync (string bucketKey, string objectKey, string access= null, bool? useCdn= default(bool?), CreateSignedResource createSignedResource= default(CreateSignedResource),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete the bucket with the specified key
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync (string bucketKey,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deletes an object from the bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded key of the bucket containing the object.</param>/// <param name="objectKey">URL-encoded key of the object to delete.</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteObjectAsync (string bucketKey, string objectKey, string xAdsAcmNamespace= default(string), string xAdsAcmCheckGroups= default(string), string xAdsAcmGroups= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete a signed URL. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteSignedResourceAsync (string hash, string region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the details about the specified bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>
        /// <returns>Task of ApiResponse&#60;Bucket&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Bucket>> GetBucketDetailsAsync (string bucketKey,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the buckets owned by the application. This endpoint supports pagination. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="startAt">Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse&#60;Buckets&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Buckets>> GetBucketsAsync (string region= null, int? limit= default(int?), string startAt= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns object details in JSON format.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="with">Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;, &#x60;userDefinedMetadata&#x60;  (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectFullDetails&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ObjectFullDetails>> GetObjectDetailsAsync (string bucketKey, string objectKey, DateTime? ifModifiedSince= default(DateTime?), string xAdsAcmNamespace= default(string), string xAdsAcmCheckGroups= default(string), string xAdsAcmGroups= default(string), string with= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// List objects in a bucket. It is only available to the bucket creator.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="beginsWith">Provides a way to filter the based on object key name (optional)</param>/// <param name="startAt">Key to use as an offset to continue pagination. This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse&#60;BucketObjects&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<BucketObjects>> GetObjectsAsync (string bucketKey, int? limit= default(int?), string beginsWith= default(string), string startAt= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Download an object using a signed URL.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="range">A range of bytes to download from the specified object. (optional)</param>/// <param name="ifNoneMatch">The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="acceptEncoding">When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  (optional)</param>/// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition HTTP header you expect to receive. If the parameter is not provided, the value associated with the object is used. (optional)</param>/// <param name="responseContentType">Value of the Content-Type HTTP header you expect to receive in the download response. (optional)</param>
        /// <returns>Task of ApiResponse&#60;System.IO.Stream&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetSignedResourceAsync (string hash, string range= default(string), string ifNoneMatch= default(string), DateTime? ifModifiedSince= default(DateTime?), string acceptEncoding= default(string), string region= null, string responseContentDisposition= default(string), string responseContentType= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns an empty response body and a 200 response code if the object exists.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="with">Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;  (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> HeadObjectDetailsAsync (string bucketKey, string objectKey, DateTime? ifModifiedSince= default(DateTime?), string xAdsAcmNamespace= default(string), string xAdsAcmCheckGroups= default(string), string xAdsAcmGroups= default(string), string with= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Upload an object to this bucket using the body of a POST request, as multipart form data. If during the upload, OSS determines that the combination of bucket key + object key already exists, then the uploaded content will overwrite the existing object. Even if it is possible to upload multiple files in the same request, it is better to create one request for each and paralellize the uploads.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="contentLength">Indicates the size of the request body. Since the multipart type is complex, this is usually computed after building the body and getting its length.</param>/// <param name="xAdsObjectName">The key of the object being uploaded. Must be URL-encoded, and it must be 3-1024 characters including any UTF-8 encoding for foreign character support. If an object with this key already exists in the bucket, the object will be overwritten.</param>/// <param name="xAdsObjectSize">The size in bytes of the file to upload.</param>/// <param name="contentType">Must be the multipart type followed by the boundary used; example: &#39;multipart/form-data, boundary&#x3D;AaB03x&#39;. (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="xAdsMetaCacheControl">The value of this header will be stored with the uploaded object. The value will be used as the &#39;Cache-Control&#39; header in the response when the object is downloaded. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> PostUploadAsync (string bucketKey, int? contentLength, string xAdsObjectName, decimal? xAdsObjectSize, string contentType= default(string), string xAdsAcmNamespace= default(string), string xAdsAcmCheckGroups= default(string), string xAdsAcmGroups= default(string), string xAdsMetaCacheControl= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to a download an object directly from S3, bypassing OSS servers. This signed URL expires in 60 seconds, so the request must begin within that time frame; the actual data transfer can take longer. Note that resumable uploads store each chunk individually; after the upload completes, an async process merges all the chunks and creates the definitive OSS file. If you request a signed URL before the async process completes, the response returns a map of S3 URLs, one per chunk; the key is the byte range of the total file to which the chunk corresponds. If you need a single URL in the response, you can use OSS signed resource functionality by setting the &#39;public-resource-fallback&#39; query parameter to true. Lastly, note that ranged downloads can be used with the returned URL.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="ifNoneMatch">If the value of this header matches the ETag of the object, an entity will not be returned from the server; instead a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="responseContentType">Value of the Content-Type header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition header that the client expects to receive. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseCacheControl">Value of the Cache-Control header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="publicResourceFallback">Indicates that OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="useCdn">This will generate a CloudFront URL for the S3 object. (optional)</param>/// <param name="redirect">Generates a HTTP redirection response (Temporary Redirect 307​) using the generated URL. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Signeds3downloadResponse&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Signeds3downloadResponse>> SignedS3DownloadAsync (string bucketKey, string objectKey, string ifNoneMatch= default(string), DateTime? ifModifiedSince= default(DateTime?), string xAdsAcmScopes= default(string), string responseContentType= default(string), string responseContentDisposition= default(string), string responseCacheControl= default(string), bool? publicResourceFallback= default(bool?), int? minutesExpiration= default(int?), bool? useCdn= default(bool?), bool? redirect= default(bool?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to upload an object in a single request, or an array of signed URLs with which to upload an object in multiple parts.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="parts">For a multipart upload, the number of chunk upload URLs to return. If X is provided, the response will include chunk URLs from 1 to X. If none provided, the response will include only a single URL with which to upload an entire object. (optional)</param>/// <param name="firstPart">Index of first part in the parts collection. (optional)</param>/// <param name="uploadKey">The identifier of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. This must match the &#x60;uploadKey&#x60; returned by a previous call to this endpoint where the client requested more than one part URL. If none provided, OSS will initiate a new upload entirely. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Signeds3uploadResponse&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Signeds3uploadResponse>> SignedS3UploadAsync (string bucketKey, string objectKey, string xAdsAcmScopes= default(string), int? parts= default(int?), int? firstPart= default(int?), string uploadKey= default(string), int? minutesExpiration= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Upload an object using a signed URL. If the signed resource is available and its expiration period is valid, you can overwrite the existing object via a signed URL upload using the &#39;access&#39; query parameter with value &#39;write&#39; or &#39;readwrite&#39;.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="contentLength">Indicates the size of the request body.</param>/// <param name="body">The object to upload.</param>/// <param name="contentType">The MIME type of the object to upload; can be any type except &#39;multipart/form-data&#39;. This can be omitted, but we recommend adding it. (optional)</param>/// <param name="contentDisposition">The suggested default filename when downloading this object to a file after it has been uploaded. (optional)</param>/// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="ifMatch">If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> UploadSignedResourceAsync (string hash, int? contentLength, System.IO.Stream body, string contentType= default(string), string contentDisposition= default(string), string xAdsRegion= null, string ifMatch= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Resumable upload for signed URLs.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of the signed resource</param>/// <param name="contentRange">Byte range of a segment being uploaded</param>/// <param name="sessionId">Unique identifier of a session of a file being uploaded</param>/// <param name="body">The chunk to upload.</param>/// <param name="contentType">The MIME type of the object to upload; can be any type except &#39;multipart/form-data&#39;. This can be omitted, but we recommend adding it. (optional)</param>/// <param name="contentDisposition">The suggested default filename when downloading this object to a file after it has been uploaded. (optional)</param>/// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> UploadSignedResourcesChunkAsync (string hash, string contentRange, string sessionId, System.IO.Stream body, string contentType= default(string), string contentDisposition= default(string), string xAdsRegion= null,  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OSSApi : IOSSApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OSSApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public OSSApi(SDKManager.SDKManager sdkManager)
        {
            this.Service = sdkManager.ApsClient.Service;
            this.logger = sdkManager.Logger;
        }
        private void SetQueryParameter(string name, object value, Dictionary<string, object> dictionary)
        {
            if(value is Enum)
            {
                var type = value.GetType();
                var memberInfos = type.GetMember(value.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if(valueAttributes.Length > 0)
                {
                    dictionary.Add(name, ((EnumMemberAttribute)valueAttributes[0]).Value);
                }
            }
            else if(value is int)
            {
                if((int)value > 0)
                {
                    dictionary.Add(name, value);
                }
            }
            else
            {
                if(value != null)
                {
                    dictionary.Add(name, value);
                }
            }
        }
        private void SetHeader(string baseName, object value, HttpRequestMessage req)
        {
                if(value is DateTime)
                {
                    if((DateTime)value != DateTime.MinValue)
                    {
                        req.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                    }
                }
                else
                {
                    if (value != null)
                    {
                        if(!string.Equals(baseName, "Content-Range"))
                        {
                            req.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                        }
                        else
                        {
                            req.Content.Headers.Add(baseName, LocalMarshalling.ParameterToString(value));
                        }
                    }
                }

        }

        /// <summary>
        /// Gets or sets the ApsConfiguration object
        /// </summary>
        /// <value>An instance of the ForgeService</value>
        public ForgeService Service {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Instructs OSS to complete the object creation process for numerous objects after their bytes have been uploaded directly to S3. An object will not be accessible until you complete the object creation process, either with this endpoint or the single Complete Upload endpoint. This endpoint accepts batch sizes of up to 25. Any larger and the request will fail.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects, each of which represents an upload to complete. (optional)</param>
        /// <returns>Task of ApiResponse&#60;BatchcompleteuploadResponse&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<BatchcompleteuploadResponse>> BatchCompleteUploadAsync (string bucketKey,BatchcompleteuploadObject requests= default(BatchcompleteuploadObject), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into BatchCompleteUploadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/batchcompleteupload",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(requests); // http body (model) parameter



                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<BatchcompleteuploadResponse>(response, default(BatchcompleteuploadResponse));
                }
                logger.LogInformation($"Exited from BatchCompleteUploadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<BatchcompleteuploadResponse>(response, await LocalMarshalling.DeserializeAsync<BatchcompleteuploadResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets one or more signed URLs to download objects. The signed URLs can be used to download the objects directly from S3, skipping OSS servers. Be aware that expiration time for the signed URL(s) is just 60 seconds. So, a request to the URL(s) must begin within 60 seconds; the transfer of the data can exceed 60 seconds. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="requests">An array of objects representing each request for a signed download URL.</param>/// <param name="publicResourceFallback">Indicates that for each requested object, OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Batchsigneds3downloadResponse&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Batchsigneds3downloadResponse>> BatchSignedS3DownloadAsync (string bucketKey,Batchsigneds3downloadObject requests,bool? publicResourceFallback= default(bool?),int? minutesExpiration= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into BatchSignedS3DownloadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("public-resource-fallback", publicResourceFallback, queryParam);
                SetQueryParameter("minutesExpiration", minutesExpiration, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/batchsigneds3download",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(requests); // http body (model) parameter



                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Batchsigneds3downloadResponse>(response, default(Batchsigneds3downloadResponse));
                }
                logger.LogInformation($"Exited from BatchSignedS3DownloadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Batchsigneds3downloadResponse>(response, await LocalMarshalling.DeserializeAsync<Batchsigneds3downloadResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Requests a batch of S3 signed URL with which to upload multiple objects or chunks of multiple objects. As with the Batch Get Download URL endpoint, the requests within the batch are evaluated independently and individual requests can be rejected even if the overall request returns a 200 response code. You can request a maximum of 25 URLs in a single request.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="useAcceleration">Whether or not to generate an accelerated signed URL (ie: URLs of the form ...s3-accelerate.amazonaws.com... vs ...s3.amazonaws.com...). When not specified, defaults to true. Providing non-boolean values will result in a 400 error. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="requests">An array of objects, each of which represents a signed URL / URLs to retrieve. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Batchsigneds3uploadResponse&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Batchsigneds3uploadResponse>> BatchSignedS3UploadAsync (string bucketKey,bool? useAcceleration= default(bool?),int? minutesExpiration= default(int?),Batchsigneds3uploadObject requests= default(Batchsigneds3uploadObject), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into BatchSignedS3UploadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("useAcceleration", useAcceleration, queryParam);
                SetQueryParameter("minutesExpiration", minutesExpiration, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/batchsigneds3upload",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(requests); // http body (model) parameter



                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Batchsigneds3uploadResponse>(response, default(Batchsigneds3uploadResponse));
                }
                logger.LogInformation($"Exited from BatchSignedS3UploadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Batchsigneds3uploadResponse>(response, await LocalMarshalling.DeserializeAsync<Batchsigneds3uploadResponse>(response.Content));

            } // using
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
        public async System.Threading.Tasks.Task<HttpResponseMessage> CompleteSignedS3UploadAsync (string bucketKey,string objectKey,string contentType,Completes3uploadBody body,string xAdsMetaContentType= default(string),string xAdsMetaContentDisposition= default(string),string xAdsMetaContentEncoding= default(string),string xAdsMetaCacheControl= default(string),string xAdsUserDefinedMetadata= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CompleteSignedS3UploadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3upload",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(body); // http body (model) parameter


                SetHeader("Content-Type", contentType, request);
                SetHeader("x-ads-meta-Content-Type", xAdsMetaContentType, request);
                SetHeader("x-ads-meta-Content-Disposition", xAdsMetaContentDisposition, request);
                SetHeader("x-ads-meta-Content-Encoding", xAdsMetaContentEncoding, request);
                SetHeader("x-ads-meta-Cache-Control", xAdsMetaCacheControl, request);
                SetHeader("x-ads-user-defined-metadata", xAdsUserDefinedMetadata, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from CompleteSignedS3UploadAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Copies an object to another object name in the same bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="newObjName">URL-encoded Object key to use as the destination</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> CopyToAsync (string bucketKey,string objectKey,string newObjName,string xAdsAcmNamespace= default(string),string xAdsAcmCheckGroups= default(string),string xAdsAcmGroups= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CopyToAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/copyto/{newObjName}",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                            { "newObjName", newObjName},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-acm-namespace", xAdsAcmNamespace, request);
                SetHeader("x-ads-acm-check-groups", xAdsAcmCheckGroups, request);
                SetHeader("x-ads-acm-groups", xAdsAcmGroups, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("PUT");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ObjectDetails>(response, default(ObjectDetails));
                }
                logger.LogInformation($"Exited from CopyToAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a bucket. Buckets are arbitrary spaces created and owned by applications. Bucket keys are globally unique across all regions, regardless of where they were created, and they cannot be changed. The application creating the bucket is the owner of the bucket. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; </param>/// <param name="policyKey">Length of time for objects in the bucket to exist; &#x60;transient&#x60; (24h),  &#x60;temporary&#x60; (30d), or &#x60;persistent&#x60; (until delete request). </param>
        /// <returns>Task of ApiResponse&#60;Bucket&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Bucket>> CreateBucketAsync (string xAdsRegion,CreateBucketsPayload policyKey, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateBucketAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(policyKey); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "bucket:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Bucket>(response, default(Bucket));
                }
                logger.LogInformation($"Exited from CreateBucketAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Bucket>(response, await LocalMarshalling.DeserializeAsync<Bucket>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint creates a signed URL that can be used to download an object within the specified expiration time. Be aware that if the object the signed URL points to is deleted or expires before the signed URL expires, then the signed URL will no longer be valid. A successful call to this endpoint requires bucket owner access.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="access">Access for signed resource Acceptable values: &#x60;read&#x60;, &#x60;write&#x60;, &#x60;readwrite&#x60;. Default value: &#x60;read&#x60;  (optional, default to read)</param>/// <param name="useCdn">When this is provided, OSS will return a URL that does not point to https://developer.api.autodesk.com.... , but instead points towards an alternate domain. A client can then interact with this public resource exactly as they would for a classic public resource in OSS, i.e. make a GET request to download an object or a PUT request to upload an object. (optional)</param>/// <param name="createSignedResource"> (optional)</param>
        /// <returns>Task of ApiResponse&#60;CreateObjectSigned&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<CreateObjectSigned>> CreateSignedResourceAsync (string bucketKey,string objectKey,string access= null,bool? useCdn= default(bool?),CreateSignedResource createSignedResource= default(CreateSignedResource), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateSignedResourceAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("access", access, queryParam);
                SetQueryParameter("useCdn", useCdn, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/signed",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(createSignedResource); // http body (model) parameter



                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<CreateObjectSigned>(response, default(CreateObjectSigned));
                }
                logger.LogInformation($"Exited from CreateSignedResourceAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<CreateObjectSigned>(response, await LocalMarshalling.DeserializeAsync<CreateObjectSigned>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete the bucket with the specified key
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync (string bucketKey, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteBucketAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "bucket:delete ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("DELETE");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteBucketAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
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
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteObjectAsync (string bucketKey,string objectKey,string xAdsAcmNamespace= default(string),string xAdsAcmCheckGroups= default(string),string xAdsAcmGroups= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteObjectAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-acm-namespace", xAdsAcmNamespace, request);
                SetHeader("x-ads-acm-check-groups", xAdsAcmCheckGroups, request);
                SetHeader("x-ads-acm-groups", xAdsAcmGroups, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("DELETE");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteObjectAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
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
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSignedResourceAsync (string hash,string region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteSignedResourceAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/signedresources/{hash}",
                        routeParameters: new Dictionary<string, object> {
                            { "hash", hash},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("DELETE");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteSignedResourceAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the details about the specified bucket.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>
        /// <returns>Task of ApiResponse&#60;Bucket&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Bucket>> GetBucketDetailsAsync (string bucketKey, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetBucketDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/details",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "bucket:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Bucket>(response, default(Bucket));
                }
                logger.LogInformation($"Exited from GetBucketDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Bucket>(response, await LocalMarshalling.DeserializeAsync<Bucket>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This endpoint will return the buckets owned by the application. This endpoint supports pagination. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="startAt">Key to use as an offset to continue pagination This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse&#60;Buckets&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Buckets>> GetBucketsAsync (string region= null,int? limit= default(int?),string startAt= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetBucketsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("startAt", startAt, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "bucket:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Buckets>(response, default(Buckets));
                }
                logger.LogInformation($"Exited from GetBucketsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Buckets>(response, await LocalMarshalling.DeserializeAsync<Buckets>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns object details in JSON format.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">URL-encoded object name</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="xAdsAcmNamespace">This header is used to let the OSS Api Proxy know if ACM is used to authorize access to the given object. If this authorization is used by your service, then you must provide the name of the namespace you want to validate access control policies against. (optional)</param>/// <param name="xAdsAcmCheckGroups">Informs the OSS Api Proxy know if your service requires ACM authorization to also validate against Oxygen groups. If so, you must pass this header with a value of &#39;true&#39;. Otherwise, the assumption is that checking authorization against Oxygen groups is not required. (optional)</param>/// <param name="xAdsAcmGroups">Use this header to pass the Oxygen groups you want the OSS Api Proxy to use for group validation for the given user in the OAuth2 token. (optional)</param>/// <param name="with">Extra information in details; multiple uses are supported Acceptable values: &#x60;createdDate&#x60;, &#x60;lastAccessedDate&#x60;, &#x60;lastModifiedDate&#x60;, &#x60;userDefinedMetadata&#x60;  (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectFullDetails&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ObjectFullDetails>> GetObjectDetailsAsync (string bucketKey,string objectKey,DateTime? ifModifiedSince= default(DateTime?),string xAdsAcmNamespace= default(string),string xAdsAcmCheckGroups= default(string),string xAdsAcmGroups= default(string),string with= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetObjectDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("with", with, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/details",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("If-Modified-Since", ifModifiedSince, request);
                SetHeader("x-ads-acm-namespace", xAdsAcmNamespace, request);
                SetHeader("x-ads-acm-check-groups", xAdsAcmCheckGroups, request);
                SetHeader("x-ads-acm-groups", xAdsAcmGroups, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ObjectFullDetails>(response, default(ObjectFullDetails));
                }
                logger.LogInformation($"Exited from GetObjectDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ObjectFullDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectFullDetails>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// List objects in a bucket. It is only available to the bucket creator.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="limit">Limit to the response size, Acceptable values: 1-100 Default &#x3D; 10  (optional, default to 10)</param>/// <param name="beginsWith">Provides a way to filter the based on object key name (optional)</param>/// <param name="startAt">Key to use as an offset to continue pagination. This is typically the last bucket key found in a preceding GET buckets response  (optional)</param>
        /// <returns>Task of ApiResponse&#60;BucketObjects&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<BucketObjects>> GetObjectsAsync (string bucketKey,int? limit= default(int?),string beginsWith= default(string),string startAt= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetObjectsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("beginsWith", beginsWith, queryParam);
                SetQueryParameter("startAt", startAt, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<BucketObjects>(response, default(BucketObjects));
                }
                logger.LogInformation($"Exited from GetObjectsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<BucketObjects>(response, await LocalMarshalling.DeserializeAsync<BucketObjects>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Download an object using a signed URL.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="range">A range of bytes to download from the specified object. (optional)</param>/// <param name="ifNoneMatch">The value of this header is compared to the ETAG of the object. If they match, the body will not be included in the response. Only the object information will be included. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message body.  (optional)</param>/// <param name="acceptEncoding">When gzip is specified, a gzip compressed stream of the object’s bytes will be returned in the response. Cannot use “Accept-Encoding:gzip” with Range header containing an end byte range. End byte range will not be honored if “Accept-Encoding: gzip” header is used.  (optional)</param>/// <param name="region">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition HTTP header you expect to receive. If the parameter is not provided, the value associated with the object is used. (optional)</param>/// <param name="responseContentType">Value of the Content-Type HTTP header you expect to receive in the download response. (optional)</param>
        /// <returns>Task of ApiResponse&#60;System.IO.Stream&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetSignedResourceAsync (string hash,string range= default(string),string ifNoneMatch= default(string),DateTime? ifModifiedSince= default(DateTime?),string acceptEncoding= default(string),string region= null,string responseContentDisposition= default(string),string responseContentType= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetSignedResourceAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                SetQueryParameter("response-content-disposition", responseContentDisposition, queryParam);
                SetQueryParameter("response-content-type", responseContentType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/signedresources/{hash}",
                        routeParameters: new Dictionary<string, object> {
                            { "hash", hash},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Range", range, request);
                SetHeader("If-None-Match", ifNoneMatch, request);
                SetHeader("If-Modified-Since", ifModifiedSince, request);
                SetHeader("Accept-Encoding", acceptEncoding, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<System.IO.Stream>(response, default(System.IO.Stream));
                }
                logger.LogInformation($"Exited from GetSignedResourceAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<System.IO.Stream>(response, await LocalMarshalling.DeserializeAsync<System.IO.Stream>(response.Content));

            } // using
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
        public async System.Threading.Tasks.Task<HttpResponseMessage> HeadObjectDetailsAsync (string bucketKey,string objectKey,DateTime? ifModifiedSince= default(DateTime?),string xAdsAcmNamespace= default(string),string xAdsAcmCheckGroups= default(string),string xAdsAcmGroups= default(string),string with= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into HeadObjectDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("with", with, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/details",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("If-Modified-Since", ifModifiedSince, request);
                SetHeader("x-ads-acm-namespace", xAdsAcmNamespace, request);
                SetHeader("x-ads-acm-check-groups", xAdsAcmCheckGroups, request);
                SetHeader("x-ads-acm-groups", xAdsAcmGroups, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("HEAD");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from HeadObjectDetailsAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
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
        public async System.Threading.Tasks.Task<HttpResponseMessage> PostUploadAsync (string bucketKey,int? contentLength,string xAdsObjectName,decimal? xAdsObjectSize,string contentType= default(string),string xAdsAcmNamespace= default(string),string xAdsAcmCheckGroups= default(string),string xAdsAcmGroups= default(string),string xAdsMetaCacheControl= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PostUploadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Content-Type", contentType, request);
                SetHeader("Content-Length", contentLength, request);
                SetHeader("x-ads-object-name", xAdsObjectName, request);
                SetHeader("x-ads-object-size", xAdsObjectSize, request);
                SetHeader("x-ads-acm-namespace", xAdsAcmNamespace, request);
                SetHeader("x-ads-acm-check-groups", xAdsAcmCheckGroups, request);
                SetHeader("x-ads-acm-groups", xAdsAcmGroups, request);
                SetHeader("x-ads-meta-Cache-Control", xAdsMetaCacheControl, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from PostUploadAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to a download an object directly from S3, bypassing OSS servers. This signed URL expires in 60 seconds, so the request must begin within that time frame; the actual data transfer can take longer. Note that resumable uploads store each chunk individually; after the upload completes, an async process merges all the chunks and creates the definitive OSS file. If you request a signed URL before the async process completes, the response returns a map of S3 URLs, one per chunk; the key is the byte range of the total file to which the chunk corresponds. If you need a single URL in the response, you can use OSS signed resource functionality by setting the &#39;public-resource-fallback&#39; query parameter to true. Lastly, note that ranged downloads can be used with the returned URL.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="ifNoneMatch">If the value of this header matches the ETag of the object, an entity will not be returned from the server; instead a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="ifModifiedSince">If the requested object has not been modified since the time specified in this field, an entity will not be returned from the server; instead, a 304 (not modified) response will be returned without any message-body. (optional)</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="responseContentType">Value of the Content-Type header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseContentDisposition">Value of the Content-Disposition header that the client expects to receive. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="responseCacheControl">Value of the Cache-Control header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value corresponding to the object. (optional)</param>/// <param name="publicResourceFallback">Indicates that OSS should return an OSS Signed Resource if the object is unmerged, rather than a map of S3 signed URLs for the chunks of the object. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>/// <param name="useCdn">This will generate a CloudFront URL for the S3 object. (optional)</param>/// <param name="redirect">Generates a HTTP redirection response (Temporary Redirect 307​) using the generated URL. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Signeds3downloadResponse&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Signeds3downloadResponse>> SignedS3DownloadAsync (string bucketKey,string objectKey,string ifNoneMatch= default(string),DateTime? ifModifiedSince= default(DateTime?),string xAdsAcmScopes= default(string),string responseContentType= default(string),string responseContentDisposition= default(string),string responseCacheControl= default(string),bool? publicResourceFallback= default(bool?),int? minutesExpiration= default(int?),bool? useCdn= default(bool?),bool? redirect= default(bool?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into SignedS3DownloadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("response-content-type", responseContentType, queryParam);
                SetQueryParameter("response-content-disposition", responseContentDisposition, queryParam);
                SetQueryParameter("response-cache-control", responseCacheControl, queryParam);
                SetQueryParameter("public-resource-fallback", publicResourceFallback, queryParam);
                SetQueryParameter("minutesExpiration", minutesExpiration, queryParam);
                SetQueryParameter("useCdn", useCdn, queryParam);
                SetQueryParameter("redirect", redirect, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3download",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("If-None-Match", ifNoneMatch, request);
                SetHeader("If-Modified-Since", ifModifiedSince, request);
                SetHeader("x-ads-acm-scopes", xAdsAcmScopes, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Signeds3downloadResponse>(response, default(Signeds3downloadResponse));
                }
                logger.LogInformation($"Exited from SignedS3DownloadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Signeds3downloadResponse>(response, await LocalMarshalling.DeserializeAsync<Signeds3downloadResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a signed URL to upload an object in a single request, or an array of signed URLs with which to upload an object in multiple parts.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">URL-encoded bucket key</param>/// <param name="objectKey">The URL-encoded key of the object for which to create a signed URL.</param>/// <param name="xAdsAcmScopes">Optional OSS-compliant scope reference to increase bucket search performance (optional)</param>/// <param name="parts">For a multipart upload, the number of chunk upload URLs to return. If X is provided, the response will include chunk URLs from 1 to X. If none provided, the response will include only a single URL with which to upload an entire object. (optional)</param>/// <param name="firstPart">Index of first part in the parts collection. (optional)</param>/// <param name="uploadKey">The identifier of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. This must match the &#x60;uploadKey&#x60; returned by a previous call to this endpoint where the client requested more than one part URL. If none provided, OSS will initiate a new upload entirely. (optional)</param>/// <param name="minutesExpiration">The custom expiration time within the 1 to 60 minutes range, if not specified, default is 2 minutes. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Signeds3uploadResponse&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Signeds3uploadResponse>> SignedS3UploadAsync (string bucketKey,string objectKey,string xAdsAcmScopes= default(string),int? parts= default(int?),int? firstPart= default(int?),string uploadKey= default(string),int? minutesExpiration= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into SignedS3UploadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("parts", parts, queryParam);
                SetQueryParameter("firstPart", firstPart, queryParam);
                SetQueryParameter("uploadKey", uploadKey, queryParam);
                SetQueryParameter("minutesExpiration", minutesExpiration, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3upload",
                        routeParameters: new Dictionary<string, object> {
                            { "bucketKey", bucketKey},
                            { "objectKey", objectKey},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-acm-scopes", xAdsAcmScopes, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:create ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Signeds3uploadResponse>(response, default(Signeds3uploadResponse));
                }
                logger.LogInformation($"Exited from SignedS3UploadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Signeds3uploadResponse>(response, await LocalMarshalling.DeserializeAsync<Signeds3uploadResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Upload an object using a signed URL. If the signed resource is available and its expiration period is valid, you can overwrite the existing object via a signed URL upload using the &#39;access&#39; query parameter with value &#39;write&#39; or &#39;readwrite&#39;.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of signed resource</param>/// <param name="contentLength">Indicates the size of the request body.</param>/// <param name="body">The object to upload.</param>/// <param name="contentType">The MIME type of the object to upload; can be any type except &#39;multipart/form-data&#39;. This can be omitted, but we recommend adding it. (optional)</param>/// <param name="contentDisposition">The suggested default filename when downloading this object to a file after it has been uploaded. (optional)</param>/// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>/// <param name="ifMatch">If-Match header containing a SHA-1 hash of the bytes in the request body can be sent by the calling service or client application with the request. If present, OSS will use the value of If-Match header to verify that a SHA-1 calculated for the uploaded bytes server side matches what was sent in the header. If not, the request is failed with a status 412 Precondition Failed and the data is not written.  (optional)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> UploadSignedResourceAsync (string hash,int? contentLength,System.IO.Stream body,string contentType= default(string),string contentDisposition= default(string),string xAdsRegion= null,string ifMatch= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into UploadSignedResourceAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/signedresources/{hash}",
                        routeParameters: new Dictionary<string, object> {
                            { "hash", hash},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }


                request.Content = new StreamContent(body);

                SetHeader("Content-Type", contentType, request);
                SetHeader("Content-Length", contentLength, request);
                SetHeader("Content-Disposition", contentDisposition, request);
                SetHeader("x-ads-region", xAdsRegion, request);
                SetHeader("If-Match", ifMatch, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("PUT");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ObjectDetails>(response, default(ObjectDetails));
                }
                logger.LogInformation($"Exited from UploadSignedResourceAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Resumable upload for signed URLs.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hash">Hash of the signed resource</param>/// <param name="contentRange">Byte range of a segment being uploaded</param>/// <param name="sessionId">Unique identifier of a session of a file being uploaded</param>/// <param name="body">The chunk to upload.</param>/// <param name="contentType">The MIME type of the object to upload; can be any type except &#39;multipart/form-data&#39;. This can be omitted, but we recommend adding it. (optional)</param>/// <param name="contentDisposition">The suggested default filename when downloading this object to a file after it has been uploaded. (optional)</param>/// <param name="xAdsRegion">The region where the bucket resides Acceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60; Default is &#x60;US&#x60;  (optional, default to US)</param>
        /// <returns>Task of ApiResponse&#60;ObjectDetails&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ObjectDetails>> UploadSignedResourcesChunkAsync (string hash,string contentRange,string sessionId,System.IO.Stream body,string contentType= default(string),string contentDisposition= default(string),string xAdsRegion= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into UploadSignedResourcesChunkAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/signedresources/{hash}/resumable",
                        routeParameters: new Dictionary<string, object> {
                            { "hash", hash},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }


                request.Content = new StreamContent(body);

                SetHeader("Content-Type", contentType, request);
                SetHeader("Content-Range", contentRange, request);
                SetHeader("Content-Disposition", contentDisposition, request);
                SetHeader("x-ads-region", xAdsRegion, request);
                SetHeader("Session-Id", sessionId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("PUT");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new OssApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ObjectDetails>(response, default(ObjectDetails));
                }
                logger.LogInformation($"Exited from UploadSignedResourcesChunkAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ObjectDetails>(response, await LocalMarshalling.DeserializeAsync<ObjectDetails>(response.Content));

            } // using
        }
    }
}
