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
    public interface IThumbnailsApi
    {
        /// <summary>
        /// Downloads the thumbnail for the source file.
        /// </summary>
        /// <remarks>
        /// Downloads the thumbnail for the source file.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>/// <param name="width">Width of thumbnail  Possible values: 100, 200, 400  If width is omitted, but height is specified, the implicit value for width will match height.  If both width and height are omitted, the server will return a thumbnail closest to a width of 200, if available. (optional)</param>/// <param name="height">Height of thumbnail  Possible values: 100, 200, 400  If height is omitted, but width is specified, the implicit value for height will match width.  If both width and height are omitted, the server will return a thumbnail closest to a width of 200, if available. (optional)</param>
        /// <returns>Task of ApiResponse<System.IO.Stream></returns>
        
        System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetThumbnailAsync (string urn, Width width,Height height, Region region = default,  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ThumbnailsApi : IThumbnailsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThumbnailsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ThumbnailsApi(SDKManager.SDKManager sdkManager)
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
        /// Downloads the thumbnail for the source file.
        /// </summary>
        /// <remarks>
        /// Downloads the thumbnail for the source file.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">The Base64 (URL Safe) encoded design URN</param>/// <param name="width">Width of thumbnail  Possible values: 100, 200, 400  If width is omitted, but height is specified, the implicit value for width will match height.  If both width and height are omitted, the server will return a thumbnail closest to a width of 200, if available. (optional)</param>/// <param name="height">Height of thumbnail  Possible values: 100, 200, 400  If height is omitted, but width is specified, the implicit value for height will match width.  If both width and height are omitted, the server will return a thumbnail closest to a width of 200, if available. (optional)</param>
        /// <returns>Task of ApiResponse<System.IO.Stream></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetThumbnailAsync (string urn,Width width = Width._200 ,Height height = Height._200, Region region = default,string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetThumbnailAsync ");
                string regionPath = Utils.GetPathfromRegion(region);
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("width", width, queryParam);
                SetQueryParameter("height", height, queryParam);
                request.RequestUri =
                   Marshalling.BuildRequestUri(regionPath + "{urn}/thumbnail",
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
                    return new ApiResponse<System.IO.Stream>(response, default(System.IO.Stream));
                }
                logger.LogInformation($"Exited from GetThumbnailAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<System.IO.Stream>(response, await LocalMarshalling.DeserializeAsync<System.IO.Stream>(response.Content));

            } // using
        }
    }
}
