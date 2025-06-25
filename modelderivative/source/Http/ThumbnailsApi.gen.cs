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
    public interface IThumbnailsApi
    {
        /// <summary>
        /// Fetch Thumbnail
        /// </summary>
        /// <remarks>
        ///Downloads a thumbnail of the specified source design.
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
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data center for the Canada region.
        ///- `DEU` : Data center for the Germany region.
        ///- `IND` : Data center for the India region.
        ///- `JPN` : Data center for the Japan region.
        ///- `GBR`  : Data center for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="width">
        ///Width of thumbnail in pixels.  Possible values are: `100`, `200`, `400`  If `width` is omitted, but `height` is specified, `width` defaults to `height`. If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available. (optional)
        /// </param>
        /// <param name="height">
        ///Height of thumbnails. Possible values are: `100`, `200`, `400`.If `height` is omitted, but `width` is specified, `height` defaults to `width`.  If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;System.IO.Stream&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetThumbnailAsync(string urn, Region? region = null, Width? width = null, Height? height = null, string accessToken = null, bool throwOnError = true);
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
        /// Fetch Thumbnail
        /// </summary>
        /// <remarks>
        ///Downloads a thumbnail of the specified source design.
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
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data center for the Canada region.
        ///- `DEU` : Data center for the Germany region.
        ///- `IND` : Data center for the India region.
        ///- `JPN` : Data center for the Japan region.
        ///- `GBR`  : Data center for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <param name="width">
        ///Width of thumbnail in pixels.  Possible values are: `100`, `200`, `400`  If `width` is omitted, but `height` is specified, `width` defaults to `height`. If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available. (optional)
        /// </param>
        /// <param name="height">
        ///Height of thumbnails. Possible values are: `100`, `200`, `400`.If `height` is omitted, but `width` is specified, `height` defaults to `width`.  If both `width` and `height` are omitted, the server will return a thumbnail closest to `200`, if such a thumbnail is available (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;System.IO.Stream&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<System.IO.Stream>> GetThumbnailAsync(string urn, Region? region = null, Width? width = null, Height? height = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetThumbnailAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("width", width, queryParam);
                SetQueryParameter("height", height, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/modelderivative/v2/designdata/{urn}/thumbnail",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/MODEL DERIVATIVE/C#/2.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



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
                    return new ApiResponse<System.IO.Stream>(response, default(System.IO.Stream));
                }
                logger.LogInformation($"Exited from GetThumbnailAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<System.IO.Stream>(response, await LocalMarshalling.DeserializeAsync<System.IO.Stream>(response.Content));

            } // using
        }
    }
}
