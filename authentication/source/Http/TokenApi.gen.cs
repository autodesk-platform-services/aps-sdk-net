/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication
 *
 * OAuth2 token management APIs.
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
using Autodesk.Authentication.Model;
using Autodesk.Authentication.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Authentication.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITokenApi
    {
        /// <summary>
        /// authorize
        /// </summary>
        /// <remarks>
        /// To obtain an authorization code grant or id_token grant.  We rate limit this endpoint. When rate limit reached, then Apigee will throw HTTP 429 Too Many Requests error. See Forge docs on the rate limit: [Forge rate limit](https://forge.autodesk.com/en/docs/oauth/v2/developers_guide/rate-limiting/forge-rate-limits/)  Errors came from OKTA/PF directly.Please refer forge v2 api document for more details &lt;Link&gt;
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID.</param>/// <param name="responseType">Must be &#x60;code&#x60; for authorization code grant, &#x60;id_token&#x60; for an OpenID Connect ID token.</param>/// <param name="redirectUri">URL-encoded callback URL.</param>/// <param name="state">The payload that authorization flow will pass back verbatim in state query parameter to the callback URL. It can contain alphanumeric, comma, period, underscore, and hyphen characters.</param>/// <param name="nonce">A string value used to associate a Client session with an ID Token, and to mitigate replay attacks. Required if &#x60;response_type&#x60; is &#x60;id_token&#x60; or &#x60;token&#x60; (optional)</param>/// <param name="scope">URL-encoded, a space-delimited list of scopes. Supported values: 1. device_sso 2. All scopes mentioned in [Forge Developers Guide](https://forge.autodesk.com/en/docs/oauth/v3/developers_guide/scopes/) (optional)</param>/// <param name="responseMode">The mode of response for the supplied &#x60;response_type&#x60;. Supported values are &#x60;fragment&#x60;, &#x60;form_post&#x60; or &#x60;query&#x60;. &#x60;query&#x60; is not supported if the &#x60;response_type&#x60; is &#x60;token&#x60;. (optional)</param>/// <param name="prompt">Values supported: &#x60;login&#x60; and &#x60;none&#x60;. &#x60;login&#x60;: Always prompt the user for authentication, regardless of the login session. &#x60;prompt&#x60;: Do not prompt user for authentication. If user is not logged in, the calling application receives an error. (optional)</param>/// <param name="authoptions">A Json object carries information to Identity. (optional)</param>/// <param name="codeChallenge">A challenge for PKCE. The challenge is verified in the access token request. (optional)</param>/// <param name="codeChallengeMethod">Method used to derive the code challenge for PKCE. Must be S256 if &#x60;code_challenge&#x60; is present. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        string Authorize(string clientId, string responseType, string redirectUri, string state = default(string), string nonce = default(string), string scope = null, string responseMode = default(string), string prompt = default(string), string authoptions = default(string), string codeChallenge = default(string), string codeChallengeMethod = default(string), /*string accessToken = null,*/ bool throwOnError = true);
        /// <summary>
        /// token
        /// </summary>
        /// <remarks>
        /// Token endpoint returns access token and refresh token, depending on the request parameters.  The endpoint requires Basic Authorization for confidential clients. For public clients, the Authorization Header should not be in the header and &#x60;client_id&#x60; should be included in the form body.  * If &#x60;grant_type&#x60; is &#x60;authorization_code&#x60;, it returns 3-legged access token for authorization code grant.  * If &#x60;grant_type&#x60; is &#x60;client_credentials&#x60;, it returns 2-legged access token for client credentials grant. * If &#x60;grant_type&#x60; is &#x60;refresh_token&#x60;, it returns new access token by using the refresh token provided in the request. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">Must be in the form Basic ${Base64(&lt;client_id&gt;:&lt;client_secret&gt;)} (optional)</param>/// <param name="grantType"> (optional)</param>/// <param name="code">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; (optional)</param>/// <param name="redirectUri">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; (optional)</param>/// <param name="codeVerifier">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; and &#x60;code_challenge&#x60; was specified in /authorize request (optional)</param>/// <param name="refreshToken">Required if &#x60;grant_type&#x60; is &#x60;refresh_token&#x60; (optional)</param>/// <param name="scope"> (optional)</param>/// <param name="clientId">This field is required for public client (optional)</param>
        /// <returns>Task ofHttpResponseMessage</returns>

        System.Threading.Tasks.Task<HttpResponseMessage> FetchtokenAsync(string authorization = default(string), string grantType = default, string code = default(string), string redirectUri = default(string), string codeVerifier = default(string), string refreshToken = default(string), string scope = null, string clientId = default(string), /*string accessToken = null,*/ bool throwOnError = true);
        /// <summary>
        /// keys
        /// </summary>
        /// <remarks>
        /// To return JSON Web Key Set that used to validate JWT token.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse<Jwks></returns>

        System.Threading.Tasks.Task<ApiResponse<Jwks>> GetKeysAsync(/*string accessToken = null*/ bool throwOnError = true);
        /// <summary>
        /// GET OIDC Specification
        /// </summary>
        /// <remarks>
        /// Openid-configuration is a Well-known URI Discovery Mechanism for the Provider Configuration URI and is defined in OpenID Connect (OIDC). Openid-configuration is a URI defined within OpenID Connect which provides configuration information about the Identity Provider (IDP).  This endpoint retrieves the metadata as a JSON listing of OpenID/OAuth endpoints, supported scopes and claims, public keys used to sign the tokens, and other details.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse<OidcSpec></returns>

        System.Threading.Tasks.Task<ApiResponse<OidcSpec>> GetOidcSpecAsync(/*string accessToken = null,*/ bool throwOnError = true);
        /// <summary>
        /// introspect
        /// </summary>
        /// <remarks>
        /// Examines an access token including the reference token and returns the status information of the tokens.  If the token is active, additional information is returned.  If the token is expired, invalid or revoked, it returns the response as status: inactive.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">Must be in the form Basic ${Base64(&lt;client_id&gt;:&lt;client_secret&gt;)} (optional)</param>/// <param name="token"> (optional)</param>/// <param name="clientId"> (optional)</param>
        /// <returns>Task of ApiResponse<Introspecttoken></returns>

        System.Threading.Tasks.Task<ApiResponse<IntrospectToken>> IntrospectTokenAsync(string token, string authorization = default(string), string clientId = default(string), bool throwOnError = true);
        /// <summary>
        /// logout
        /// </summary>
        /// <remarks>
        /// This API endpoint logs a user out by removing their user browser session and redirects the user to the Autodesk login page.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="postLogoutRedirectUri">Location to redirect once the logout is performed. Note that the provided domain host should be in the allowed list. Contact #oxygen slack channel for more details. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        string Logout(string postLogoutRedirectUri = default(string));
        /// <summary>
        /// revoke
        /// </summary>
        /// <remarks>
        /// This API endpoint takes an access token or refresh token and revokes it. Once the token is revoked, it becomes inactive and returns no body response.  A client can only revoke its own tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="token">The token to be revoked. (optional)</param>/// <param name="tokenTypeHint">Should be either &#39;access_token&#39;, &#39;refresh_token&#39; or &#39;device_secret&#39;. (optional)</param>/// <param name="clientId">This field is required for public client. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>

        System.Threading.Tasks.Task<HttpResponseMessage> RevokeAsync(string token, string authorization = default(string), string tokenTypeHint = default(string), string clientId = default(string), bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class TokenApi : ITokenApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public TokenApi(SDKManager.SDKManager sdkManager)
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
        /// authorize
        /// </summary>
        /// <remarks>
        /// To obtain an authorization code grant or id_token grant.  We rate limit this endpoint. When rate limit reached, then Apigee will throw HTTP 429 Too Many Requests error. See Forge docs on the rate limit: [Forge rate limit](https://forge.autodesk.com/en/docs/oauth/v2/developers_guide/rate-limiting/forge-rate-limits/)  Errors came from OKTA/PF directly.Please refer forge v2 api document for more details &lt;Link&gt;
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="clientId">Client ID.</param>/// <param name="responseType">Must be &#x60;code&#x60; for authorization code grant, &#x60;id_token&#x60; for an OpenID Connect ID token.</param>/// <param name="redirectUri">URL-encoded callback URL.</param>/// <param name="state">The payload that authorization flow will pass back verbatim in state query parameter to the callback URL. It can contain alphanumeric, comma, period, underscore, and hyphen characters.</param>/// <param name="nonce">A string value used to associate a Client session with an ID Token, and to mitigate replay attacks. Required if &#x60;response_type&#x60; is &#x60;id_token&#x60; or &#x60;token&#x60; (optional)</param>/// <param name="scope">URL-encoded, a space-delimited list of scopes. Supported values: 1. device_sso 2. All scopes mentioned in [Forge Developers Guide](https://forge.autodesk.com/en/docs/oauth/v3/developers_guide/scopes/) (optional)</param>/// <param name="responseMode">The mode of response for the supplied &#x60;response_type&#x60;. Supported values are &#x60;fragment&#x60;, &#x60;form_post&#x60; or &#x60;query&#x60;. &#x60;query&#x60; is not supported if the &#x60;response_type&#x60; is &#x60;token&#x60;. (optional)</param>/// <param name="prompt">Values supported: &#x60;login&#x60; and &#x60;none&#x60;. &#x60;login&#x60;: Always prompt the user for authentication, regardless of the login session. &#x60;prompt&#x60;: Do not prompt user for authentication. If user is not logged in, the calling application receives an error. (optional)</param>/// <param name="authoptions">A Json object carries information to Identity. (optional)</param>/// <param name="codeChallenge">A challenge for PKCE. The challenge is verified in the access token request. (optional)</param>/// <param name="codeChallengeMethod">Method used to derive the code challenge for PKCE. Must be S256 if &#x60;code_challenge&#x60; is present. (optional)</param>

        /// <returns>string</returns>
        public string Authorize(string clientId, string responseType, string redirectUri, string state = default(string), string nonce = default(string), string scope = null, string responseMode = default(string), string prompt = default(string), string authoptions = default(string), string codeChallenge = default(string), string codeChallengeMethod = default(string), /*string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into AuthorizeAsync ");
            // ss manually added. This method does not call any rest endpoints.
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(clientId)) { SetQueryParameter("client_id", clientId, queryParam); }
                if (!string.IsNullOrEmpty(responseType)) { SetQueryParameter("response_type", responseType, queryParam); }
                if (!string.IsNullOrEmpty(redirectUri)) { SetQueryParameter("redirect_uri", redirectUri, queryParam); }
                if (!string.IsNullOrEmpty(nonce)) { SetQueryParameter("nonce", nonce, queryParam); }
                if (!string.IsNullOrEmpty(state)) { SetQueryParameter("state", state, queryParam); }
                if (!string.IsNullOrEmpty(scope)) { SetQueryParameter("scope", scope, queryParam); }
                if (!string.IsNullOrEmpty(responseMode)) { SetQueryParameter("response_mode", responseMode, queryParam); }
                if (!string.IsNullOrEmpty(prompt)) { SetQueryParameter("prompt", prompt, queryParam); }
                if (!string.IsNullOrEmpty(authoptions)) { SetQueryParameter("authoptions", authoptions, queryParam); }
                if (!string.IsNullOrEmpty(codeChallenge)) { SetQueryParameter("code_challenge", codeChallenge, queryParam); }
                if (!string.IsNullOrEmpty(codeChallengeMethod)) { SetQueryParameter("code_challenge_method", codeChallengeMethod, queryParam); }
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/authorize",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                Uri.TryCreate(this.Service.Client.BaseAddress, request.RequestUri, out Uri result);
                return result.AbsoluteUri;

            } // using
        }
        /// <summary>
        /// token
        /// </summary>
        /// <remarks>
        /// Token endpoint returns access token and refresh token, depending on the request parameters.  The endpoint requires Basic Authorization for confidential clients. For public clients, the Authorization Header should not be in the header and &#x60;client_id&#x60; should be included in the form body.  * If &#x60;grant_type&#x60; is &#x60;authorization_code&#x60;, it returns 3-legged access token for authorization code grant.  * If &#x60;grant_type&#x60; is &#x60;client_credentials&#x60;, it returns 2-legged access token for client credentials grant. * If &#x60;grant_type&#x60; is &#x60;refresh_token&#x60;, it returns new access token by using the refresh token provided in the request. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">Must be in the form Basic ${Base64(&lt;client_id&gt;:&lt;client_secret&gt;)} (optional)</param>/// <param name="grantType"> (optional)</param>/// <param name="code">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; (optional)</param>/// <param name="redirectUri">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; (optional)</param>/// <param name="codeVerifier">Required if &#x60;grant_type&#x60; is &#x60;authorization_code&#x60; and &#x60;code_challenge&#x60; was specified in /authorize request (optional)</param>/// <param name="refreshToken">Required if &#x60;grant_type&#x60; is &#x60;refresh_token&#x60; (optional)</param>/// <param name="scope"> (optional)</param>/// <param name="clientId">This field is required for public client (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>

        public async System.Threading.Tasks.Task<HttpResponseMessage> FetchtokenAsync(string authorization = default(string), string grantType = default, string code = default(string), string redirectUri = default(string), string codeVerifier = default(string), string refreshToken = default(string), string scope = null, string clientId = default(string),/* string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into FetchtokenAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/token",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");

                // *** ss manually added***                
                if (!string.IsNullOrEmpty(authorization))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authorization}");
                }
                // if(!string.IsNullOrEmpty(accessToken))
                // {
                //     request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                // }
                var formParams = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(grantType)) { formParams.Add("grant_type", grantType); }
                if (!string.IsNullOrEmpty(code)) { formParams.Add("code", code); }
                if (!string.IsNullOrEmpty(redirectUri)) { formParams.Add("redirect_uri", redirectUri); }
                if (!string.IsNullOrEmpty(codeVerifier)) { formParams.Add("code_verifier", codeVerifier); }
                if (!string.IsNullOrEmpty(refreshToken)) { formParams.Add("refresh_token", refreshToken); }
                if (!string.IsNullOrEmpty(scope)) { formParams.Add("scope", scope); }
                if (!string.IsNullOrEmpty(clientId)) { formParams.Add("client_id", clientId); }

                request.Content = new FormUrlEncodedContent(formParams);

                // SetHeader("Authorization", authorization, request);

                // *** --- ss *****
                // tell the underlying pipeline what scope we'd like to use

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
                        throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from FetchtokenAsync with response statusCode: {response.StatusCode}");
                return response;
                //return new ApiResponse<Object>(response, await LocalMarshalling.DeserializeAsync<Object>(response.Content));

            } // using
        }
        /// <summary>
        /// keys
        /// </summary>
        /// <remarks>
        /// To return JSON Web Key Set that used to validate JWT token.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse<Jwks></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Jwks>> GetKeysAsync(/*string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetKeysAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/keys",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");
                // if (!string.IsNullOrEmpty(accessToken))
                // {
                //     request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                // }

                // tell the underlying pipeline what scope we'd like to use

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
                        throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Jwks>(response, default(Jwks));
                }
                logger.LogInformation($"Exited from GetKeysAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Jwks>(response, await LocalMarshalling.DeserializeAsync<Jwks>(response.Content));

            } // using
        }
        /// <summary>
        /// GET OIDC Specification
        /// </summary>
        /// <remarks>
        /// Openid-configuration is a Well-known URI Discovery Mechanism for the Provider Configuration URI and is defined in OpenID Connect (OIDC). Openid-configuration is a URI defined within OpenID Connect which provides configuration information about the Identity Provider (IDP).  This endpoint retrieves the metadata as a JSON listing of OpenID/OAuth endpoints, supported scopes and claims, public keys used to sign the tokens, and other details.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse<OidcSpec></returns>

        public async System.Threading.Tasks.Task<ApiResponse<OidcSpec>> GetOidcSpecAsync(/*string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetOidcSpecAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/.well-known/openid-configuration",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");
                // if (!string.IsNullOrEmpty(accessToken))
                // {
                //     request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                // }




                // tell the underlying pipeline what scope we'd like to use

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
                        throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<OidcSpec>(response, default(OidcSpec));
                }
                logger.LogInformation($"Exited from GetOidcSpecAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<OidcSpec>(response, await LocalMarshalling.DeserializeAsync<OidcSpec>(response.Content));

            } // using
        }
        /// <summary>
        /// introspect
        /// </summary>
        /// <remarks>
        /// Examines an access token including the reference token and returns the status information of the tokens.  If the token is active, additional information is returned.  If the token is expired, invalid or revoked, it returns the response as status: inactive.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">Must be in the form Basic ${Base64(&lt;client_id&gt;:&lt;client_secret&gt;)} (optional)</param>/// <param name="token"> (optional)</param>/// <param name="clientId"> (optional)</param>
        /// <returns>Task of ApiResponse<Introspecttoken></returns>

        public async System.Threading.Tasks.Task<ApiResponse<IntrospectToken>> IntrospectTokenAsync(string token,string authorization = default(string),  string clientId = default(string), /*string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into IntrospectTokenAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/introspect",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");


                // *** ss - Manually added ***

                if (!string.IsNullOrEmpty(authorization))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authorization}");
                }

                // if (!string.IsNullOrEmpty(accessToken))
                // {
                //     request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                // }


                // request.Content = new StringContent(token);
                // request.Content = new StringContent(clientId);

                // SetHeader("Authorization", authorization, request);

                var formParams = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(token)) { formParams.Add("token", token); }
                if (!string.IsNullOrEmpty(clientId)) { formParams.Add("client_id", clientId); }

                request.Content = new FormUrlEncodedContent(formParams);

                // -- ss - end of Manual code

                // tell the underlying pipeline what scope we'd like to use

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
                        throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<IntrospectToken>(response, default(IntrospectToken));
                }
                logger.LogInformation($"Exited from IntrospectTokenAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<IntrospectToken>(response, await LocalMarshalling.DeserializeAsync<IntrospectToken>(response.Content));

            } // using
        }
        /// <summary>
        /// logout
        /// </summary>
        /// <remarks>
        /// This API endpoint logs a user out by removing their user browser session and redirects the user to the Autodesk login page.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="postLogoutRedirectUri">Location to redirect once the logout is performed. Note that the provided domain host should be in the allowed list. Contact #oxygen slack channel for more details. (optional)</param>
        /// <returns>Redirect uri/returns>
        public string Logout(string postLogoutRedirectUri = default(string))
        {
            logger.LogInformation("Entered into LogoutAsync ");
            using (var request = new HttpRequestMessage())
            {
                // *** This method has been manually modified, 
                //since it does not need to call a rest endpoint ***
                var queryParam = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(postLogoutRedirectUri)) { SetQueryParameter("post_logout_redirect_uri", postLogoutRedirectUri, queryParam); }
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/logout",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                Uri.TryCreate(this.Service.Client.BaseAddress, request.RequestUri, out Uri result);
                return result.AbsoluteUri;


            } // using
        }
        /// <summary>
        /// revoke
        /// </summary>
        /// <remarks>
        /// This API endpoint takes an access token or refresh token and revokes it. Once the token is revoked, it becomes inactive and returns no body response.  A client can only revoke its own tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="token">The token to be revoked. (optional)</param>/// <param name="tokenTypeHint">Should be either &#39;access_token&#39;, &#39;refresh_token&#39; or &#39;device_secret&#39;. (optional)</param>/// <param name="clientId">This field is required for public client. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>

        public async System.Threading.Tasks.Task<HttpResponseMessage> RevokeAsync(string token, string authorization = default(string), string tokenTypeHint = default(string), string clientId = default(string), bool throwOnError = true)
        {
            logger.LogInformation("Entered into RevokeAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/authentication/v2/revoke",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");

                // ss manually added

                if (!string.IsNullOrEmpty(authorization))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authorization}");
                }

                // if (!string.IsNullOrEmpty(accessToken))
                // {
                //     request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                // }


                // request.Content = new StringContent(token);
                // request.Content = new StringContent(tokenTypeHint);
                // request.Content = new StringContent(clientId);


                var formParams = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(token)) { formParams.Add("token", token); }
                if (!string.IsNullOrEmpty(tokenTypeHint)) { formParams.Add("token_type_hint", tokenTypeHint); }
                if (!string.IsNullOrEmpty(clientId)) { formParams.Add("client_id", clientId); }
                request.Content = new FormUrlEncodedContent(formParams);



                // ss - end of code block
                // tell the underlying pipeline what scope we'd like to use

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
                        throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from RevokeAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
    }
}
