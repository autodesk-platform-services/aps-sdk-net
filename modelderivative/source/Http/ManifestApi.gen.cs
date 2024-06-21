/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Use the Model Derivative API to translate designs from one CAD format to another. You can also use this API to extract metadata from a model.
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
using Autodesk.ModelDerivative.Model;
using Autodesk.ModelDerivative.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.ModelDerivative.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IManifestApi
    {
        /// <summary>
        /// Delete Manifest
        /// </summary>
        /// <remarks>
        ///Deletes the manifest of the specified source design. It also deletes all derivatives (translated output files) generated from the source design. However, it does not delete the source design.
        ///
        ///**Note:** This operation is idempotent. So, if you call it multiple times, even when no manifest exists, will still return a successful response (200).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;DeleteManifest&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<DeleteManifest>> DeleteManifestAsync(string urn, Region? region = null, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Fetch Manifest
        /// </summary>
        /// <remarks>
        ///Retrieves the manifest of the specified source design.
        ///
        ///The manifest is a JSON file containing information about all the derivatives translated from the specified source design. It contains information such as the URNs of the derivatives, the translation status of each derivative, and much more.
        ///
        ///The first time you translate a source design, the Model Derivative service creates a manifest for that design. Thereafter, every time you translate that source design, even to a different format, the Model Derivative service updates the same manifest. It does not create a new manifest. Instead, the manifest acts like a central registry for all the derivatives of your source design created through the Model Derivative service.  
        ///
        ///When the Model Derivative service starts a translation job (as a result of a request you make using [Create Translation Job](/en/docs/model-derivative/v2/reference/http/jobs/job-POST/)), it keeps on updating the manifest at regular intervals. So, you can use the manifest to check the status and progress of each derivative that is being generated. When multiple derivatives have been requested each derivative may complete at a different time. So, each derivative has its own `status` attribute. The manifest also contains an overall `status` attribute. The overall `status` becomes `complete` when the `status` of all individual derivatives become complete.
        ///
        ///Once the translation status of a derivative is `complete` you can download the derivative.
        ///
        ///**Note:** You cannot download 3D SVF2 derivatives.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Manifest&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Manifest>> GetManifestAsync(string urn, string acceptEncoding = default(string), Region? region = null, string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ManifestApi : IManifestApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ManifestApi(SDKManager.SDKManager sdkManager)
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
        /// Delete Manifest
        /// </summary>
        /// <remarks>
        ///Deletes the manifest of the specified source design. It also deletes all derivatives (translated output files) generated from the source design. However, it does not delete the source design.
        ///
        ///**Note:** This operation is idempotent. So, if you call it multiple times, even when no manifest exists, will still return a successful response (200).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;DeleteManifest&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<DeleteManifest>> DeleteManifestAsync(string urn, Region? region = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteManifestAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/modelderivative/v2/designdata/{urn}/manifest",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/MODEL DERIVATIVE/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("region", region, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write data:read ");
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
                        throw new ModelDerivativeApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<DeleteManifest>(response, default(DeleteManifest));
                }
                logger.LogInformation($"Exited from DeleteManifestAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<DeleteManifest>(response, await LocalMarshalling.DeserializeAsync<DeleteManifest>(response.Content));

            } // using
        }
        /// <summary>
        /// Fetch Manifest
        /// </summary>
        /// <remarks>
        ///Retrieves the manifest of the specified source design.
        ///
        ///The manifest is a JSON file containing information about all the derivatives translated from the specified source design. It contains information such as the URNs of the derivatives, the translation status of each derivative, and much more.
        ///
        ///The first time you translate a source design, the Model Derivative service creates a manifest for that design. Thereafter, every time you translate that source design, even to a different format, the Model Derivative service updates the same manifest. It does not create a new manifest. Instead, the manifest acts like a central registry for all the derivatives of your source design created through the Model Derivative service.  
        ///
        ///When the Model Derivative service starts a translation job (as a result of a request you make using [Create Translation Job](/en/docs/model-derivative/v2/reference/http/jobs/job-POST/)), it keeps on updating the manifest at regular intervals. So, you can use the manifest to check the status and progress of each derivative that is being generated. When multiple derivatives have been requested each derivative may complete at a different time. So, each derivative has its own `status` attribute. The manifest also contains an overall `status` attribute. The overall `status` becomes `complete` when the `status` of all individual derivatives become complete.
        ///
        ///Once the translation status of a derivative is `complete` you can download the derivative.
        ///
        ///**Note:** You cannot download 3D SVF2 derivatives.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="acceptEncoding">
        ///A comma separated list of the algorithms you want the response to be encoded in, specified in the order of preference.  
        ///
        ///If you specify `gzip` or `*`, content is compressed and returned in gzip format. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `APAC` - (Beta) Data center for the Australia region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Manifest&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Manifest>> GetManifestAsync(string urn, string acceptEncoding = default(string), Region? region = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetManifestAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/modelderivative/v2/designdata/{urn}/manifest",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/MODEL DERIVATIVE/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Accept-Encoding", acceptEncoding, request);
                SetHeader("region", region, request);

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
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new ModelDerivativeApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Manifest>(response, default(Manifest));
                }
                logger.LogInformation($"Exited from GetManifestAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Manifest>(response, await LocalMarshalling.DeserializeAsync<Manifest>(response.Content));

            } // using
        }
    }
}
