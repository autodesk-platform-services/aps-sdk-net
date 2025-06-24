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
    public interface IDerivativesApi
    {
        /// <summary>
        /// Fetch Derivative Download URL
        /// </summary>
        /// <remarks>
        ///Returns a download URL and a set of signed cookies, which lets you securely download the derivative specified by the `derivativeUrn` URI parameter. The signed cookies have a lifetime of 6 hours. You can use range headers with the returned download URL to download the derivative in chunks, in parallel.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Use the [Fetch Manifest operation](/en/docs/model-derivative/v2/reference/http/manifest/urn-manifest-GET/)to obtain the URNs of derivatives for the specified source design.
        /// </param>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="minutesExpiration">
        ///Specifies how many minutes the signed cookies should remain valid. Default value is 360 minutes. The value you specify must be lower than the default value for this parameter. If you specify a value greater than the default value, the Model Derivative service will return an error with an HTTP status code of `400`. (optional)
        /// </param>
        /// <param name="responseContentDisposition">
        ///The value that must be specified as the `response-content-disposition` query string parameter with the download URL. Must begin with `attachment`. This value defaults to the default value corresponding to the derivative/file. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;DerivativeDownload&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<DerivativeDownload>> GetDerivativeUrlAsync(string derivativeUrn, string urn, int? minutesExpiration = default(int?), string responseContentDisposition = default(string), Region? region = null, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Check Derivative Details
        /// </summary>
        /// <remarks>
        ///Returns information about the specified derivative.
        ///
        ///Use this operation to determine the total content length of a derivative before you download it. If the derivative is large, you can choose to download the derivative in chunks, by specifying a chunk size using the `Range` header parameter.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Check the manifest of the source design to get the URNs of the derivatives available for download.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> HeadCheckDerivativeAsync(string urn, string derivativeUrn, Region? region = null, string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class DerivativesApi : IDerivativesApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivativesApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public DerivativesApi(SDKManager.SDKManager sdkManager)
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
        /// Fetch Derivative Download URL
        /// </summary>
        /// <remarks>
        ///Returns a download URL and a set of signed cookies, which lets you securely download the derivative specified by the `derivativeUrn` URI parameter. The signed cookies have a lifetime of 6 hours. You can use range headers with the returned download URL to download the derivative in chunks, in parallel.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Use the [Fetch Manifest operation](/en/docs/model-derivative/v2/reference/http/manifest/urn-manifest-GET/)to obtain the URNs of derivatives for the specified source design.
        /// </param>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="minutesExpiration">
        ///Specifies how many minutes the signed cookies should remain valid. Default value is 360 minutes. The value you specify must be lower than the default value for this parameter. If you specify a value greater than the default value, the Model Derivative service will return an error with an HTTP status code of `400`. (optional)
        /// </param>
        /// <param name="responseContentDisposition">
        ///The value that must be specified as the `response-content-disposition` query string parameter with the download URL. Must begin with `attachment`. This value defaults to the default value corresponding to the derivative/file. (optional)
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;DerivativeDownload&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<DerivativeDownload>> GetDerivativeUrlAsync(string derivativeUrn, string urn, int? minutesExpiration = default(int?), string responseContentDisposition = default(string), Region? region = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetDerivativeUrlAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("minutes-expiration", minutesExpiration, queryParam);
                SetQueryParameter("response-content-disposition", responseContentDisposition, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/modelderivative/v2/designdata/{urn}/manifest/{derivativeUrn}/signedcookies",
                        routeParameters: new Dictionary<string, object> {
                            { "derivativeUrn", derivativeUrn},
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
                    return new ApiResponse<DerivativeDownload>(response, default(DerivativeDownload));
                }
                logger.LogInformation($"Exited from GetDerivativeUrlAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<DerivativeDownload>(response, await LocalMarshalling.DeserializeAsync<DerivativeDownload>(response.Content));

            } // using
        }
        /// <summary>
        /// Check Derivative Details
        /// </summary>
        /// <remarks>
        ///Returns information about the specified derivative.
        ///
        ///Use this operation to determine the total content length of a derivative before you download it. If the derivative is large, you can choose to download the derivative in chunks, by specifying a chunk size using the `Range` header parameter.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="urn">
        ///The URL-safe Base64 encoded URN of the source design.
        /// </param>
        /// <param name="derivativeUrn">
        ///The URL-encoded URN of the derivative. Check the manifest of the source design to get the URNs of the derivatives available for download.
        /// </param>
        /// <param name="region">
        ///Specifies the data center where the manifest and derivatives of the specified source design are stored. Possible values are:
        ///
        ///- `US` - (Default) Data center for the US region.
        ///- `EMEA` - Data center for the European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments. (optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> HeadCheckDerivativeAsync(string urn, string derivativeUrn, Region? region = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into HeadCheckDerivativeAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/modelderivative/v2/designdata/{urn}/manifest/{derivativeUrn}",
                        routeParameters: new Dictionary<string, object> {
                            { "urn", urn},
                            { "derivativeUrn", derivativeUrn},
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

                request.Method = new HttpMethod("HEAD");

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
                    return response;
                }
                logger.LogInformation($"Exited from HeadCheckDerivativeAsync with response statusCode: {response.StatusCode}");
                return response;
            } // using
        }
    }
}
