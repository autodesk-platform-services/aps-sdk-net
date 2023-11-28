using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Authentication.Http;
using Autodesk.Authentication.Model;
using Autodesk.Authentication.Client;
using System.Net.Http;
using System.Net.Cache;

namespace Autodesk.Authentication
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    /// 

    public class AuthenticationClient
    {
        public ITokenApi tokenApi { get; }
        public IUsersApi usersApi { get; }

        public AuthenticationClient(SDKManager.SDKManager sDKManager)
        {
            this.tokenApi = new TokenApi(sDKManager);
            this.usersApi = new UsersApi(sDKManager);
        }


        #region UsersApi
        /// <summary>
        /// GET User Info
        /// </summary>
        /// <remarks>
        /// Retrieves basic information for the given authenticated user. Only supports 3-legged access tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">YOUR_3_LEGGED_ACCESS_TOKEN </param>
        /// <returns>Task of ApiResponse<UserInfo></returns>

        public async System.Threading.Tasks.Task<UserInfo> GetUserInfoAsync(string authorization)
        {
            var response = await this.usersApi.GetUserinfoAsync(authorization);
            return response.Content;
        }

        #endregion UsersApi

        #region tokenapi

        /// <summary>
        /// GET 2 Legged token
        /// </summary>
        public async System.Threading.Tasks.Task<TwoLeggedToken> GetTwoLeggedTokenAsync(string clientId, string clientSecret, List<Scopes> scopes)
        {
            var clientIdSecret = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var strScopes = String.Join(" ", scopes.Select(x => Utils.GetEnumString(x)));
            var grantType = Utils.GetEnumString(GrantType.Client_credentials);
            var response = await this.tokenApi.FetchtokenAsync(authorization: clientIdSecret, scope: strScopes, grantType: grantType);
            return await LocalMarshalling.DeserializeAsync<TwoLeggedToken>(response.Content);

        }

        /// <summary>
        /// GET Auth Uri
        /// </summary>
        public string Authorize(string clientId, ResponseType responseType, string redirectUri, List<Scopes> scopes)
        {
            var strResponseType = Utils.GetEnumString(responseType);
            var strScopes = String.Join(" ", scopes.Select(x => Utils.GetEnumString(x)));
            return this.tokenApi.Authorize(clientId: clientId, redirectUri: redirectUri, responseType: strResponseType, scope: strScopes);
        }

        /// <summary>
        /// GET 3 Legged token
        /// </summary>
        public async System.Threading.Tasks.Task<ThreeLeggedToken> GetThreeLeggedTokenAsync(string clientId, string clientSecret, string code, string redirect_uri)
        {
            var clientIdSecret = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var grant_type = Utils.GetEnumString(GrantType.Authorization_code);
            var response = await this.tokenApi.FetchtokenAsync(authorization: clientIdSecret, code: code, grantType: grant_type, redirectUri: redirect_uri);
            return await LocalMarshalling.DeserializeAsync<ThreeLeggedToken>(response.Content);

        }

        /// <summary>
        /// GET Refresh token
        /// </summary>
        public async System.Threading.Tasks.Task<RefreshToken> GetRefreshTokenAsync(string clientId, string clientSecret, string refreshToken, List<Scopes> scopes = null)
        {
            var clientIdSecret = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var strScopes = String.Empty;
            if (scopes != null && scopes.Any())
            {
                strScopes = String.Join(" ", scopes.Select(x => Utils.GetEnumString(x)));
            }
            var grant_type = Utils.GetEnumString(GrantType.Refresh_token);
            var response = await this.tokenApi.FetchtokenAsync(authorization: clientIdSecret, scope: strScopes, grantType: grant_type, refreshToken: refreshToken);
            return await LocalMarshalling.DeserializeAsync<RefreshToken>(response.Content);
        }





        /// <summary>
        /// GET Keys
        /// </summary>
        public async System.Threading.Tasks.Task<Jwks> GetKeysAsync()
        {
            var response = await this.tokenApi.GetKeysAsync();
            return response.Content;
        }


        /// <summary>
        /// GET OIDC Specification
        /// </summary>
        /// <remarks>
        /// Openid-configuration is a Well-known URI Discovery Mechanism for the Provider Configuration URI and is defined in OpenID Connect (OIDC). Openid-configuration is a URI defined within OpenID Connect which provides configuration information about the Identity Provider (IDP).  This endpoint retrieves the metadata as a JSON listing of OpenID/OAuth endpoints, supported scopes and claims, public keys used to sign the tokens, and other details.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>

        public async System.Threading.Tasks.Task<OidcSpec> GetOidcSpecAsync()
        {
            var response = await this.tokenApi.GetOidcSpecAsync();
            return response.Content;
        }


        /// <summary>
        /// introspect
        /// </summary>
        /// <remarks>
        /// Examines an access token including the reference token and returns the status information of the tokens.  If the token is active, additional information is returned.  If the token is expired, invalid or revoked, it returns the response as status: inactive.
        /// </remarks>
        public async System.Threading.Tasks.Task<IntrospectToken> IntrospectTokenAsync(string token, string clientId, string clientSecret = default(string))
        {
            if (!string.IsNullOrEmpty(clientSecret))
            { // for private client
                var clientIdSecret = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                var response = await this.tokenApi.IntrospectTokenAsync( token,clientIdSecret, null);
                return response.Content;
            }
            else
            { // for public clients
                var response = await this.tokenApi.IntrospectTokenAsync(token,null, clientId);
                return response.Content;
            }
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
            return this.tokenApi.Logout(postLogoutRedirectUri);
        }


        /// <summary>
        /// revoke
        /// </summary>
        /// <remarks>
        /// This API endpoint takes an access token or refresh token and revokes it. Once the token is revoked, it becomes inactive and returns no body response.  A client can only revoke its own tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="token">The token to be revoked. (optional)</param>/// <param name="tokenTypeHint">Should be either &#39;access_token&#39;, &#39;refresh_token&#39; or &#39;device_secret&#39;. (optional)</param>/// <param name="clientId">This field is required for public client. (optional)</param>
        /// <returns>Task of ApiResponse<Object></returns>

        public async System.Threading.Tasks.Task<HttpResponseMessage> RevokeAsync(string token, string clientId, string clientSecret = default(string), TokenTypeHint tokenTypeHint = default(TokenTypeHint))
        {
            var token_type_hint = Utils.GetEnumString(tokenTypeHint);
            if (!string.IsNullOrEmpty(clientSecret))
            { // request is for private client 
                var clientIdSecret = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
                return await this.tokenApi.RevokeAsync(token, clientIdSecret, token_type_hint, null);
            }
            else
            { // request is for public client
                return await this.tokenApi.RevokeAsync(token, null, token_type_hint, clientId);

            }

            #endregion tokenapi
        }
    }
}