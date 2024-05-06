/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
        /// Authorize User
        /// </summary>
        /// <remarks>
        ///Returns a browser URL to redirect an end user in order to acquire the user’s consent to authorize the application to access resources on their behalf.
        ///
        ///Invoking this operation is the first step in authenticating users and retrieving an authorization code grant. The authorization code that is generated remains valid for 5 minutes, while the ID token stays valid for 60 minutes. Any access tokens you obtain are valid for 60 minutes, and refresh tokens remain valid for 15 days.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        ///
        ///**Note:** This operation is intended for use with client-side applications only. It is not suitable for server-side applications.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="clientId">
        ///The Client ID of the calling application, as registered with APS.
        /// </param>
        /// <param name="responseType">
        ///The type of response you want to receive. Possible values are: 
        ///
        ///-  `code` - Authorization code grant.
        ///-  `id_token` - OpenID Connect ID token.
        /// </param>
        /// <param name="redirectUri">
        ///The URI that APS redirects users to after they grant or deny access permission to the application. Must match the Callback URL for the application as registered with APS.
        ///
        ///Must be specified as a URL-safe string. It can include query parameters or any other valid URL construct.
        /// </param>
        /// <param name="nonce">
        ///A random string that is sent with the request. APS passes back the same string to you so that you can verify whether you received the same string that you sent. This check mitigates token replay attacks (optional)
        /// </param>
        /// <param name="state">
        ///A URL-encoded random string. The authorization flow will pass the same string back to the Callback URL using the `state` query string parameter. This process helps ensure that the callback you receive is a response to what you originally requested. It prevents malicious actors from forging requests.
        ///
        ///The string can only contain alphanumeric characters, commas, periods, underscores, and hyphens.             (optional)
        /// </param>
        /// <param name="scope">
        ///A URL-encoded space-delimited list of requested scopes. See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
        ///
        ///The string you specify for this parameter must not exceed 2000 characters and it cannot contain more than 50 scopes.   (optional)
        /// </param>
        /// <param name="responseMode">
        ///Specifies how the authorization response should be returned. Valid values are:
        ///
        ///- `fragment` - Encode the response parameters in the fragment of the redirect URI. A fragment in a URI is the optional part of the URI that appears after a `#` symbol, which refers to a specific section within a resource. For example, `section` in `https://www.mysite.org/myresource#section`.
        ///- `form_post` - Embed the authorization response parameter in an HTML form.
        ///- `query` -  Embed the authorization response as a query string parameter of the redirect URI. 
        ///
        ///If `id_token` is stated as `response_type`,  only `form_post` is allowed as `response_mode`.' (optional)
        /// </param>
        /// <param name="prompt">
        ///Specifies how to prompt users for authentication. Possible values are: 
        ///
        ///- `login` : Always prompt the user for authentication, regardless of the state of the login session. 
        ///
        ///**Note:** If you do not specify this parameter, the system will not prompt the user for authentication as long as a login session is active. If a login session is not active, the system will prompt the user for authentication. (optional)
        /// </param>
        /// <param name="authoptions">
        ///A JSON object containing options that specify how to display the sign-in page. Refer the [Developer's Guide documentation on AuthOptions](/en/docs/oauth/v2/developers_guide/authoptions/) for supported values. (optional)
        /// </param>
        /// <param name="codeChallenge">
        ///A URL-encoded string derived from the code verifier sent in the authorization request with the Proof Key for Code Exchange (PKCE) grant flow. (optional)
        /// </param>
        /// <param name="codeChallengeMethod">
        ///The method used to derive the code challenge for the PKCE grant flow. Possible value is:
        ///
        ///- `S256`- Hashes the code verifier using the SHA-256 algorithm and then applies Base64 URL encoding. (optional)
        /// </param>
        /// <returns>string</returns>
        string Authorize(string clientId, string responseType, string redirectUri, string state = default(string), string nonce = default(string), string scope = null, string responseMode = default(string), string prompt = default(string), string authoptions = default(string), string codeChallenge = default(string), string codeChallengeMethod = default(string) /*string accessToken = null, bool throwOnError = true*/);
        /// <summary>
        /// Acquire Token
        /// </summary>
        /// <remarks>
        ///Returns an access token or refresh token.
        ///
        ///* If `grant_type` is `authorization_code`, returns a 3-legged access token for authorization code grant. 
        ///* If `grant_type` is `client_credentials`, returns a 2-legged access token for client credentials grant.
        ///* If `grant_type` is `refresh_token`, returns new access token using the refresh token provided in the request.
        ///
        ///Traditional Web Apps and Server-to-Server Apps should use the `Authorization` header with Basic Authentication for this operation. Desktop, Mobile, and Single-Page Apps should use `client_id` in the form body instead.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="grantType">
        /// (optional)
        /// </param>
        /// <param name="code">
        ///The authorization code that was passed to your application when the user granted access permission to your application. It was passed as the [code` query parameter to the redirect URI when you called `Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).   Required if `grant_type` is `authorization_code`.  (optional)
        /// </param>
        /// <param name="redirectUri">
        ///The URI that APS redirects users to after they grant or deny access permission to the application. Must match the Callback URL for the application registered with APS.   Required if `grant_type` is `authorization_code`.  (optional)
        /// </param>
        /// <param name="codeVerifier">
        ///A random URL-encoded string between 43 characters and 128 characters. In a PKCE grant flow, the authentication server uses this string to verify the code challenge that was passed when you called [Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).    Required if [grant_type` is `authorization_code` and `code_challenge` was specified when you called `Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).  (optional)
        /// </param>
        /// <param name="refreshToken">
        ///The refresh token used to acquire a new access token and a refresh token.  Required if `grant_type` is `refresh_token`.  (optional)
        /// </param>
        /// <param name="scope">
        /// (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>  
        /// <returns>Task ofHttpResponseMessage</returns>

        System.Threading.Tasks.Task<HttpResponseMessage> FetchTokenAsync(string authorization = default(string), string grantType = default, string code = default(string), string redirectUri = default(string), string codeVerifier = default(string), string refreshToken = default(string), string scope = null, string clientId = default(string),/* string accessToken = null,*/ bool throwOnError = true);
        /// <summary>
        /// Get JWKS
        /// </summary>
        /// <remarks>
        ///Returns a set of public keys in the JSON Web Key Set (JWKS) format.
        ///
        ///Public keys returned by this operation can be used to validate the asymmetric JWT signature of an access token without making network calls. It can be used to validate both two-legged access tokens and three-legged access tokens. 
        ///
        ///See the Developer's Guide topic on [Asymmetric Signing](/en/docs/oauth/v2/developers_guide/asymmetric-encryption/) for more information. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse&lt;Jwks&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Jwks>> GetKeysAsync(/*string accessToken = null*/ bool throwOnError = true);
        /// <summary>
        /// Get OIDC Specification
        /// </summary>
        /// <remarks>
        ///Returns an OpenID Connect Discovery Specification compliant JSON document. It contains a list of the OpenID/OAuth endpoints, supported scopes, claims, public keys used to sign the tokens, and other details.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse&lt;OidcSpec&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<OidcSpec>> GetOidcSpecAsync(/*string accessToken = null,*/ bool throwOnError = true);
        /// <summary>
        /// Introspect Token
        /// </summary>
        /// <remarks>
        ///Returns metadata about the specified access token or reference token.
        ///
        ///An application can only introspect its own tokens.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="token">
        ///The token to be introspected. (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;IntrospectToken&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<IntrospectToken>> IntrospectTokenAsync(string token, string authorization = default(string), string clientId = default(string), bool throwOnError = true);
        /// <summary>
        /// Logout
        /// </summary>
        /// <remarks>
        ///Signs out the currently authenticated user from the APS authorization server. Thereafter, this operation redirects the user to the `post_logout_redirect_uri`, or to the Autodesk Sign-in page when no `post_logout_redirect_uri` is provided.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="postLogoutRedirectUri">
        ///The URI to redirect your users to once logout is performed. If you do not specify this parameter your users are redirected to the Autodesk Sign-in page. 
        ///
        ///**Note:**  You must provide a redirect URI that is pre-registered with APS. This precaution is taken to prevent unauthorized applications from hijacking the logout process. (optional)
        /// </param>

        /// <returns>string</returns>
        string Logout(string postLogoutRedirectUri = default(string));
        /// <summary>
        /// Revoke Token
        /// </summary>
        /// <remarks>
        ///Revokes an active access token or refresh token.
        ///
        ///An application can only revoke its own tokens.
        ///
        ///This operation has a rate limit of 100 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="token">
        ///The token to be revoked.  
        /// </param>
        /// <param name="tokenTypeHint">
        ///
        /// </param>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>
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
        /// Authorize User
        /// </summary>
        /// <remarks>
        ///Displays a sign-in page where users of your application can authorize the application to access resources on their behalf.
        ///
        ///Invoking this operation is the first step in authenticating users and retrieving an authorization code grant. The authorization code that is generated remains valid for 5 minutes, while the ID token stays valid for 60 minutes. Any access tokens you obtain are valid for 60 minutes, and refresh tokens remain valid for 15 days.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        ///
        ///**Note:** This operation is intended for use with client-side applications only. It is not suitable for server-side applications.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="clientId">
        ///The Client ID of the calling application, as registered with APS.
        /// </param>
        /// <param name="responseType">
        ///The type of response you want to receive. Possible values are: 
        ///
        ///-  `code` - Authorization code grant.
        ///-  `id_token` - OpenID Connect ID token.
        /// </param>
        /// <param name="redirectUri">
        ///The URI that APS redirects users to after they grant or deny access permission to the application. Must match the Callback URL for the application as registered with APS.
        ///
        ///Must be specified as a URL-safe string. It can include query parameters or any other valid URL construct.
        /// </param>
        /// <param name="nonce">
        ///A random string that is sent with the request. APS passes back the same string to you so that you can verify whether you received the same string that you sent. This check mitigates token replay attacks (optional)
        /// </param>
        /// <param name="state">
        ///A URL-encoded random string. The authorization flow will pass the same string back to the Callback URL using the `state` query string parameter. This process helps ensure that the callback you receive is a response to what you originally requested. It prevents malicious actors from forging requests.
        ///
        ///The string can only contain alphanumeric characters, commas, periods, underscores, and hyphens.             (optional)
        /// </param>
        /// <param name="scope">
        ///A URL-encoded space-delimited list of requested scopes. See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
        ///
        ///The string you specify for this parameter must not exceed 2000 characters and it cannot contain more than 50 scopes.   (optional)
        /// </param>
        /// <param name="responseMode">
        ///Specifies how the authorization response should be returned. Valid values are:
        ///
        ///- `fragment` - Encode the response parameters in the fragment of the redirect URI. A fragment in a URI is the optional part of the URI that appears after a `#` symbol, which refers to a specific section within a resource. For example, `section` in `https://www.mysite.org/myresource#section`.
        ///- `form_post` - Embed the authorization response parameter in an HTML form.
        ///- `query` -  Embed the authorization response as a query string parameter of the redirect URI. 
        ///
        ///If `id_token` is stated as `response_type`,  only `form_post` is allowed as `response_mode`.' (optional)
        /// </param>
        /// <param name="prompt">
        ///Specifies how to prompt users for authentication. Possible values are: 
        ///
        ///- `login` : Always prompt the user for authentication, regardless of the state of the login session. 
        ///
        ///**Note:** If you do not specify this parameter, the system will not prompt the user for authentication as long as a login session is active. If a login session is not active, the system will prompt the user for authentication. (optional)
        /// </param>
        /// <param name="authoptions">
        ///A JSON object containing options that specify how to display the sign-in page. Refer the [Developer's Guide documentation on AuthOptions](/en/docs/oauth/v2/developers_guide/authoptions/) for supported values. (optional)
        /// </param>
        /// <param name="codeChallenge">
        ///A URL-encoded string derived from the code verifier sent in the authorization request with the Proof Key for Code Exchange (PKCE) grant flow. (optional)
        /// </param>
        /// <param name="codeChallengeMethod">
        ///The method used to derive the code challenge for the PKCE grant flow. Possible value is:
        ///
        ///- `S256`- Hashes the code verifier using the SHA-256 algorithm and then applies Base64 URL encoding. (optional)
        /// </param>
        /// <returns>string</returns>
        public string Authorize(string clientId, string responseType, string redirectUri, string state = default(string), string nonce = default(string), string scope = null, string responseMode = default(string), string prompt = default(string), string authoptions = default(string), string codeChallenge = default(string), string codeChallengeMethod = default(string) /*string accessToken = null, bool throwOnError = true*/)
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
        /// Acquire Token
        /// </summary>
        /// <remarks>
        ///Returns an access token or refresh token.
        ///
        ///* If `grant_type` is `authorization_code`, returns a 3-legged access token for authorization code grant. 
        ///* If `grant_type` is `client_credentials`, returns a 2-legged access token for client credentials grant.
        ///* If `grant_type` is `refresh_token`, returns new access token using the refresh token provided in the request.
        ///
        ///Traditional Web Apps and Server-to-Server Apps should use the `Authorization` header with Basic Authentication for this operation. Desktop, Mobile, and Single-Page Apps should use `client_id` in the form body instead.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="grantType">
        /// (optional)
        /// </param>
        /// <param name="code">
        ///The authorization code that was passed to your application when the user granted access permission to your application. It was passed as the [code` query parameter to the redirect URI when you called `Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).   Required if `grant_type` is `authorization_code`.  (optional)
        /// </param>
        /// <param name="redirectUri">
        ///The URI that APS redirects users to after they grant or deny access permission to the application. Must match the Callback URL for the application registered with APS.   Required if `grant_type` is `authorization_code`.  (optional)
        /// </param>
        /// <param name="codeVerifier">
        ///A random URL-encoded string between 43 characters and 128 characters. In a PKCE grant flow, the authentication server uses this string to verify the code challenge that was passed when you called [Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).    Required if [grant_type` is `authorization_code` and `code_challenge` was specified when you called `Authorize User](/en/docs/oauth/v2/reference/http/authorize-GET/).  (optional)
        /// </param>
        /// <param name="refreshToken">
        ///The refresh token used to acquire a new access token and a refresh token.  Required if `grant_type` is `refresh_token`.  (optional)
        /// </param>
        /// <param name="scope">
        /// (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>

        public async System.Threading.Tasks.Task<HttpResponseMessage> FetchTokenAsync(string authorization = default(string), string grantType = default, string code = default(string), string redirectUri = default(string), string codeVerifier = default(string), string refreshToken = default(string), string scope = null, string clientId = default(string),/* string accessToken = null,*/ bool throwOnError = true)
        {
            logger.LogInformation("Entered into FetchTokenAsync ");
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
        /// Get JWKS
        /// </summary>
        /// <remarks>
        ///Returns a set of public keys in the JSON Web Key Set (JWKS) format.
        ///
        ///Public keys returned by this operation can be used to validate the asymmetric JWT signature of an access token without making network calls. It can be used to validate both two-legged access tokens and three-legged access tokens. 
        ///
        ///See the Developer's Guide topic on [Asymmetric Signing](/en/docs/oauth/v2/developers_guide/asymmetric-encryption/) for more information. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse&lt;Jwks&gt;></returns>

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
        /// Get OIDC Specification
        /// </summary>
        /// <remarks>
        ///Returns an OpenID Connect Discovery Specification compliant JSON document. It contains a list of the OpenID/OAuth endpoints, supported scopes, claims, public keys used to sign the tokens, and other details.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        /// <returns>Task of ApiResponse&lt;OidcSpec&gt;></returns>

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
        /// Introspect Token
        /// </summary>
        /// <remarks>
        ///Returns metadata about the specified access token or reference token.
        ///
        ///An application can only introspect its own tokens.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="token">
        ///The token to be introspected. (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;IntrospectToken&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<IntrospectToken>> IntrospectTokenAsync(string token, string authorization = default(string), string clientId = default(string), /*string accessToken = null,*/ bool throwOnError = true)
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
        /// Logout
        /// </summary>
        /// <remarks>
        ///Signs out the currently authenticated user from the APS authorization server. Thereafter, this operation redirects the user to the `post_logout_redirect_uri`, or to the Autodesk Sign-in page when no `post_logout_redirect_uri` is provided.
        ///
        ///This operation has a rate limit of 500 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="postLogoutRedirectUri">
        ///The URI to redirect your users to once logout is performed. If you do not specify this parameter your users are redirected to the Autodesk Sign-in page. 
        ///
        ///**Note:**  You must provide a redirect URI that is pre-registered with APS. This precaution is taken to prevent unauthorized applications from hijacking the logout process. (optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
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
        /// Revoke Token
        /// </summary>
        /// <remarks>
        ///Revokes an active access token or refresh token.
        ///
        ///An application can only revoke its own tokens.
        ///
        ///This operation has a rate limit of 100 calls per minute.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="token">
        ///The token to be revoked.  
        /// </param>
        /// <param name="tokenTypeHint">
        ///
        /// </param>
        /// <param name="authorization">
        ///Must be `Bearer <BASE64_ENCODED_STRING>` where `<BASE64_ENCODED_STRING>` is the Base64 encoding of the concatenated string `<CLIENT_ID>:<CLIENT_SECRET>`.'
        ///
        ///**Note** This header is required only for Traditional Web Apps and Server-to-Server Apps. It is not required for Desktop, Mobile, and Single-Page Apps. (optional)
        /// </param>
        /// <param name="clientId">
        /// (optional)
        /// </param>
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
