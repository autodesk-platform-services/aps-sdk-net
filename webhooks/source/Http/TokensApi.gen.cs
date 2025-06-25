/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined. You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project. Below is quick summary of this workflow: 1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
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
using Autodesk.Webhooks.Model;
using Autodesk.Webhooks.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Webhooks.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITokensApi
    {
        /// <summary>
        /// Create Secret Token
        /// </summary>
        /// <remarks>
        ///Sets a secret token to verify the authenticity of webhook payloads. 
///
///When a webhook event occurs, the service calculates a hash signature using the token and includes it in the event notification. The receiving application listening at the callback URL can verify the payload's integrity by comparing the calculated signature to the one received.
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secret token for all webhooks owned by the calling user
///
///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
///
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="tokenPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Token&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Token>> CreateTokenAsync (XAdsRegion? xAdsRegion= null, Region? region= null, TokenPayload tokenPayload= default(TokenPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Delete Secret Token
        /// </summary>
        /// <remarks>
        ///Removes an existing secret token from the webhooks impacted by this operation. 
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
///
///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteTokenAsync (XAdsRegion? xAdsRegion= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update Secret Token
        /// </summary>
        /// <remarks>
        ///Replaces an existing secret token with a new one. 
///
///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
///
///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
///
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="tokenPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> PutTokenAsync (XAdsRegion? xAdsRegion= null, Region? region= null, TokenPayload tokenPayload= default(TokenPayload),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TokensApi : ITokensApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokensApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public TokensApi(SDKManager.SDKManager sdkManager)
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
        /// Create Secret Token
        /// </summary>
        /// <remarks>
        ///Sets a secret token to verify the authenticity of webhook payloads. 
///
///When a webhook event occurs, the service calculates a hash signature using the token and includes it in the event notification. The receiving application listening at the callback URL can verify the payload's integrity by comparing the calculated signature to the one received.
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secret token for all webhooks owned by the calling user
///
///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
///
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="tokenPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Token&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Token>> CreateTokenAsync (XAdsRegion? xAdsRegion= null,Region? region= null,TokenPayload tokenPayload= default(TokenPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateTokenAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/tokens",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(tokenPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
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
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Token>(response, default(Token));
                }
                logger.LogInformation($"Exited from CreateTokenAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Token>(response, await LocalMarshalling.DeserializeAsync<Token>(response.Content));

            } // using
        }
        /// <summary>
        /// Delete Secret Token
        /// </summary>
        /// <remarks>
        ///Removes an existing secret token from the webhooks impacted by this operation. 
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
///
///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTokenAsync (XAdsRegion? xAdsRegion= null,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteTokenAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/tokens/@me",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
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
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteTokenAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Update Secret Token
        /// </summary>
        /// <remarks>
        ///Replaces an existing secret token with a new one. 
///
///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
///
///The webhooks affected by this operation are determined by the type of access token you use.
///
///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
///
///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
///
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///- `CAN` - Data center dedicated to serve the Canada region.
///- `DEU` - Data center dedicated to serve the Germany region.
///- `IND` - Data center dedicated to serve the India region.
///- `JPN` - Data center dedicated to serve the Japan region.
///- `GBR` - Data center dedicated to serve the United Kingdom region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="tokenPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PutTokenAsync (XAdsRegion? xAdsRegion= null,Region? region= null,TokenPayload tokenPayload= default(TokenPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PutTokenAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/tokens/@me",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(tokenPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
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
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from PutTokenAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
    }
}
