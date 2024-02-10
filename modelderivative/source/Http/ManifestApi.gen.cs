/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Model Derivative Service Documentation
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
        /// Deletes the manifest and all its translated output files (derivatives). However, it does not delete the design source file.
        /// </summary>
        /// <remarks>
        /// Deletes the manifest and all its translated output files (derivatives). However, it does not delete the design source file. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>
        /// <returns>Task of ApiResponse&#60;DeleteManifest&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<DeleteManifest>> DeleteManifestAsync (string urn,  Region region = default,string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Fetch Manifest
        /// </summary>
        /// <remarks>
        /// Retrieves the manifest for the source design specified by the urn URI parameter. The manifest is a list containing information about the derivatives generated while translating a source file. The manifest contains information such as the URNs of the derivatives, the translation status of each derivative, and much more.  The URNs of the derivatives are used to download the generated derivatives by calling the GET /{urn}/manifest/{derivativeurn} endpoint.  Note: You cannot download 3D SVF2 derivatives.  The statuses are used to check whether the translation of the requested output files is complete. The output files produced by a translation job may complete at different times. Therefore, each output file can have a different status.  The first time you translate a source design, the Model Derivative service creates a manifest for that source design. Thereafter, every time you translate that source design, the Model Derivative service updates that manifest. It does not create a new manifest each time you initiate a translation job, even if you are translating to a different format.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>/// <param name="acceptEncoding">A comma separated list of the algorthms you want the response to be encoded in, specified in the order of preference.    If you specify &#x60;&#x60;gzip&#x60;&#x60; or &#x60;&#x60;*&#x60;&#x60;, the service uses the GZIP algorithm to encode the response.  (optional)</param>
        /// <returns>Task of ApiResponse&#60;Manifest&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Manifest>> GetManifestAsync (string urn, Region region = default,string acceptEncoding= default(string),  string accessToken = null, bool throwOnError = true);
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
        /// Deletes the manifest and all its translated output files (derivatives). However, it does not delete the design source file.
        /// </summary>
        /// <remarks>
        /// Deletes the manifest and all its translated output files (derivatives). However, it does not delete the design source file. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>
        /// <returns>Task of ApiResponse&#60;DeleteManifest&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<DeleteManifest>> DeleteManifestAsync (string urn,Region region = default, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteManifestAsync ");
             string regionPath = Utils.GetPathfromRegion(region);
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                     Marshalling.BuildRequestUri(regionPath +"{urn}/manifest",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/MODEL DERIVATIVE/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




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
                    } catch (HttpRequestException ex) {
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
        /// Retrieves the manifest for the source design specified by the urn URI parameter. The manifest is a list containing information about the derivatives generated while translating a source file. The manifest contains information such as the URNs of the derivatives, the translation status of each derivative, and much more.  The URNs of the derivatives are used to download the generated derivatives by calling the GET /{urn}/manifest/{derivativeurn} endpoint.  Note: You cannot download 3D SVF2 derivatives.  The statuses are used to check whether the translation of the requested output files is complete. The output files produced by a translation job may complete at different times. Therefore, each output file can have a different status.  The first time you translate a source design, the Model Derivative service creates a manifest for that source design. Thereafter, every time you translate that source design, the Model Derivative service updates that manifest. It does not create a new manifest each time you initiate a translation job, even if you are translating to a different format.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>/// <param name="acceptEncoding">A comma separated list of the algorthms you want the response to be encoded in, specified in the order of preference.    If you specify &#x60;&#x60;gzip&#x60;&#x60; or &#x60;&#x60;*&#x60;&#x60;, the service uses the GZIP algorithm to encode the response.  (optional)</param>
        /// <returns>Task of ApiResponse&#60;Manifest&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Manifest>> GetManifestAsync (string urn, Region region = default,string acceptEncoding= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetManifestAsync ");
             string regionPath = Utils.GetPathfromRegion(region);
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                   Marshalling.BuildRequestUri(regionPath + "{urn}/manifest",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/MODEL DERIVATIVE/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



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
                    } catch (HttpRequestException ex) {
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
