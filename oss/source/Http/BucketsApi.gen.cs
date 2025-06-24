/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    public interface IBucketsApi
    {
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="policyKey">
        ///
        /// </param>
        /// <param name="xAdsRegion">
        ///Specifies where the bucket containing the object is stored. Possible values are:
        ///
        ///- `US` : (Default) Data center for the US region.
        ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
        ///- `AUS` : (Beta) Data center for Australia.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR` : Data centre for the United Kingdom region.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Bucket&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Bucket>> CreateBucketAsync(CreateBucketsPayload policyKey, Region xAdsRegion, string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to delete.
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync(string bucketKey, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Bucket Details
        /// </summary>
        /// <remarks>
        ///Returns detailed information about the specified bucket.
        ///
        ///**Note:** Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to query.
        /// </param>
        /// <returns>Task of ApiResponse&lt;Bucket&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Bucket>> GetBucketDetailsAsync(string bucketKey, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List Buckets
        /// </summary>
        /// <remarks>
        ///Returns a list of buckets owned by the application. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">
        ///Specifies where the bucket containing the object is stored. Possible values are:
        ///
        ///- `US` : (Default) Data center for the US region.
        ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
        ///- `AUS` : (Beta) Data center for Australia.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR` : Data centre for the United Kingdom region.
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
        /// <returns>Task of ApiResponse&lt;Buckets&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Buckets>> GetBucketsAsync(Region? region = null, int? limit = default(int?), string startAt = default(string), string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class BucketsApi : IBucketsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BucketsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public BucketsApi(SDKManager.SDKManager sdkManager)
        {
            this.Service = sdkManager.ApsClient.Service;
            this.logger = sdkManager.Logger;
        }
        private void SetQueryParameter(string name, object value, Dictionary<string, object> dictionary)
        {
            if (value is Enum)
            {
                var type = value.GetType();
                var memberInfos = type.GetMember(value.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (valueAttributes.Length > 0)
                {
                    dictionary.Add(name, ((EnumMemberAttribute)valueAttributes[0]).Value);
                }
            }
            else if (value is int)
            {
                if ((int)value > 0)
                {
                    dictionary.Add(name, value);
                }
            }
            else
            {
                if (value != null)
                {
                    dictionary.Add(name, value);
                }
            }
        }
        private void SetHeader(string baseName, object value, HttpRequestMessage req)
        {
            if (value is DateTime)
            {
                if ((DateTime)value != DateTime.MinValue)
                {
                    req.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                }
            }
            else
            {
                if (value != null)
                {
                    if (!string.Equals(baseName, "Content-Range"))
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
        public ForgeService Service { get; set; }

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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="policyKey">
        ///
        /// </param>
        /// <param name="xAdsRegion">
        ///Specifies where the bucket containing the object is stored. Possible values are:
        ///
        ///- `US` : (Default) Data center for the US region.
        ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
        ///- `AUS` : (Beta) Data center for Australia.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR` : Data centre for the United Kingdom region.
        ///
        ///**Note:** Beta features are subject to change. Please do not use in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Bucket&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Bucket>> CreateBucketAsync(CreateBucketsPayload policyKey, Region xAdsRegion , string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateBucketAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/oss/v2/buckets",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(policyKey); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
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
                    }
                    catch (HttpRequestException ex)
                    {
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
        /// Delete Bucket
        /// </summary>
        /// <remarks>
        ///Deletes the specified bucket. Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error. 
        ///
        ///The initial processing of a bucket deletion request can be time-consuming. So, we recommend only deleting buckets containing a few objects, like those typically used for acceptance testing and prototyping. 
        ///
        ///**Note:** Bucket keys will not be immediately available for reuse. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to delete.
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteBucketAsync(string bucketKey, string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
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
                    }
                    catch (HttpRequestException ex)
                    {
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
        /// Get Bucket Details
        /// </summary>
        /// <remarks>
        ///Returns detailed information about the specified bucket.
        ///
        ///**Note:** Only the application that owns the bucket can call this operation. All other applications that call this operation will receive a "403 Forbidden" error. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="bucketKey">
        ///The bucket key of the bucket to query.
        /// </param>
        /// <returns>Task of ApiResponse&lt;Bucket&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Bucket>> GetBucketDetailsAsync(string bucketKey, string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
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
                    }
                    catch (HttpRequestException ex)
                    {
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
        /// List Buckets
        /// </summary>
        /// <remarks>
        ///Returns a list of buckets owned by the application. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">
        ///Specifies where the bucket containing the object is stored. Possible values are:
        ///
        ///- `US` : (Default) Data center for the US region.
        ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
        ///- `AUS` : (Beta) Data center for Australia.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR` : Data centre for the United Kingdom region.
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
        /// <returns>Task of ApiResponse&lt;Buckets&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Buckets>> GetBucketsAsync(Region? region = null, int? limit = default(int?), string startAt = default(string), string accessToken = null, bool throwOnError = true)
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
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/OSS/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
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
                    }
                    catch (HttpRequestException ex)
                    {
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
    }
}
