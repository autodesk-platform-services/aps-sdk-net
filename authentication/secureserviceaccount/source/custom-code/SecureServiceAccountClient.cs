/* 
 * APS SDK
 *
 * Autodesk Platform Services contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication.SecureServiceAccount
 *
 * OAuth2 server-to-server account, key, and token management API.
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

using Autodesk.Authentication.SecureServiceAccount.Http;
using Autodesk.Authentication.SecureServiceAccount.Model;
using Autodesk.Forge.Core;
using Autodesk.SDKManager;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Autodesk.Authentication.SecureServiceAccount;

/// <summary>
/// Represents a collection of functions to interact with the API endpoints
/// </summary>
public class SecureServiceAccountClient : BaseClient
{
   /// <summary>
   /// Gets the service account management API instance.
   /// </summary>
   public IAccountManagementApi AccountManagementApi { get; }

   /// <summary>
   /// Gets the key management API instance.
   /// </summary>
   public IKeyManagementApi KeyManagementApi { get; }

   /// <summary>
   /// Gets the exchange token API instance.
   /// </summary>
   public IExchangeTokenApi ExchangeTokenApi { get; }

   /// <summary>
   /// Initializes a new instance of the <see cref="SecureServiceAccountClient"/> class.
   /// </summary>
   /// <param name="sdkManager">
   /// The SDK manager instance.
   /// </param>
   /// <param name="authenticationProvider">
   /// The authentication provider instance.
   /// </param>
   public SecureServiceAccountClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default)
      : base(authenticationProvider)
   {
      sdkManager ??= SdkManagerBuilder.Create().Build();

      AccountManagementApi = new AccountManagementApi(sdkManager);
      KeyManagementApi = new KeyManagementApi(sdkManager);
      ExchangeTokenApi = new ExchangeTokenApi(sdkManager);
   }

   #region AccountManagementApi

   /// <summary>
   /// Creates a service account.
   /// Only a server-to-server application can own service accounts.
   /// An application can have up to 10 service accounts at any given time.
   /// Upon a successful response, the operation returns the service account ID and email address.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountWrite"/>
   /// </remarks>
   /// <param name="serviceAccountCreatePayload">
   /// Describes the creation of the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="ServiceAccountCreated"/>&gt;&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ServiceAccountCreated> CreateServiceAccountAsync(ServiceAccountCreatePayload serviceAccountCreatePayload = default(ServiceAccountCreatePayload), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await AccountManagementApi.CreateServiceAccountAsync(serviceAccountCreatePayload: serviceAccountCreatePayload, accessToken: accessToken, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Deletes an existing service account.
   /// When a service account is deleted, all associated keys will also be deleted.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountWrite"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await AccountManagementApi.DeleteServiceAccountAsync(serviceAccountId: serviceAccountId, accessToken: accessToken, throwOnError: throwOnError);
      return response;
   }

   /// <summary>
   /// Retrieves the details for a service account.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountRead"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="ServiceAccount"/>&gt;&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ServiceAccount> GetServiceAccountAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await AccountManagementApi.GetServiceAccountAsync(serviceAccountId: serviceAccountId, accessToken: accessToken, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Retrieves all service accounts associated with an application.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountRead"/>
   /// </remarks>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="ServiceAccountsResponse"/>&gt;&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ServiceAccountsResponse> GetServiceAccountsAsync(string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await AccountManagementApi.GetServiceAccountsAsync(accessToken: accessToken, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Enables or disables a service account.
   /// When a service account is in the disabled state, it loses its capability to manage its service account key.
   /// Assertions signed by the key will be treated as invalid.
   /// This operation allows enabling a service account that is in a diabled state.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountWrite"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="serviceAccountUpdatePayload">
   /// Describes the updates to the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateServiceAccountAsync(string serviceAccountId = default(string), ServiceAccountUpdatePayload serviceAccountUpdatePayload = default(ServiceAccountUpdatePayload), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await AccountManagementApi.UpdateServiceAccountAsync(serviceAccountId: serviceAccountId, serviceAccountUpdatePayload: serviceAccountUpdatePayload, accessToken: accessToken, throwOnError: throwOnError);
      return response;
   }

   #endregion AccountManagementApi

   #region KeyManagementApi

   /// <summary>
   /// Creates a service account key.
   /// A service account key is a public-private key pair, generated using RSA with a key length of 2048 bits by the Identity Authorization Service(AuthZ).
   /// The private key is returned once during its creation.AuthZ only stores the public key.
   /// A service account can have up to 3 keys at any given time.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountKeyWrite"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="KeyCreated"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<KeyCreated> CreateKeyAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await KeyManagementApi.CreateKeyAsync(serviceAccountId: serviceAccountId, accessToken: accessToken, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Deletes an existing key.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountKeyWrite"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKeyAsync(string serviceAccountId = default(string), string keyId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await KeyManagementApi.DeleteKeyAsync(serviceAccountId: serviceAccountId, keyId: keyId, accessToken: accessToken, throwOnError: throwOnError);
      return response;
   }

   /// <summary>
   /// Lists all keys associated with the service account.
   /// This operation will only return key metadata, not the private or public key.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountKeyRead"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="KeysResponse"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<KeysResponse> GetKeysAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await KeyManagementApi.GetKeysAsync(serviceAccountId: serviceAccountId, accessToken: accessToken, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Enables or disables a service account key.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: <see cref="Scopes.ApplicationServiceAccountKeyWrite"/>
   /// </remarks>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="keyUpdatePayload">
   /// Describes the updates to the key.
   /// </param>
   /// <param name="accessToken">
   /// An access token obtained by a call to GetTwoLeggedTokenAsync().
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKeyAsync(string serviceAccountId = default(string), string keyId = default(string), KeyUpdatePayload keyUpdatePayload = default(KeyUpdatePayload), string accessToken = default(string), bool throwOnError = true)
   {
      if (string.IsNullOrEmpty(accessToken) && AuthenticationProvider == null)
      {
         throw new Exception("Please provide a valid access token or an authentication provider.");
      }
      else if (string.IsNullOrEmpty(accessToken))
      {
         accessToken = await AuthenticationProvider.GetAccessToken();
      }

      var response = await KeyManagementApi.UpdateKeyAsync(serviceAccountId: serviceAccountId, keyId: keyId, keyUpdatePayload: keyUpdatePayload, accessToken: accessToken, throwOnError: throwOnError);
      return response;
   }

   #endregion KeyManagementApi

   #region ExchangeTokenApi

   /// <summary>
   /// Returns a three-legged access token for the JWT assertion you provide in the request body.
   /// See the Developer’s Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
   /// This operation is only for confidential clients.
   /// It requires Basic Authorization (client_id, client_secret).
   /// Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
   /// </summary>
   /// <remarks>
   /// Required OAuth Scopes: None
   /// </remarks>
   /// <param name="authorization">
   /// Must be `Basic &lt;BASE64_ENCODED_STRING&gt;` where `&lt;BASE64_ENCODED_STRING&gt;` is the Base64 encoding of the concatenated string `&lt;CLIENT_ID&gt;:&lt;CLIENT_SECRET&gt;`.
   /// This parameter is required only if client_id and client_secret are not provided in the request body.
   /// (optional)
   /// </param>
   /// <param name="grantType">
   /// Must be `urn:ietf:params:oauth:grant-type:jwt-bearer`.
   /// </param>
   /// <param name="assertion">
   /// The value of the JWT assertion to exchange for a three-legged access-token. See JWT Assertions for instructions on how to generate a JWT assertion.
   /// </param>
   /// <param name="clientId">
   /// An additional option where the client can either use the authorization header or opt to send this information in the body.
   /// (optional)
   /// </param>
   /// <param name="clientSecret">
   /// An additional option where the client can either use the authorization header or opt to send this information in the body.
   /// (optional)
   /// </param>
   /// <param name="scopes">
   /// A URL-encoded space-delimited list of scopes.
   /// The scope in the token endpoint request body should be a subset of or the same as the scope specified in the assertion.
   /// If the scope is not present, then the returned access token will have the same scope as the assertion.
   /// (optional)
   /// </param>
   /// <param name="throwOnError">
   /// Indicates whether to throw an exception on error.
   /// (optional)
   /// </param>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ThreeLeggedToken"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ThreeLeggedToken> ExchangeJwtAssertionAsync(string authorization = default(string), GrantType? grantType = null, string assertion = default(string), string clientId = default(string), string clientSecret = default(string), List<Scopes> scopes = null, bool throwOnError = true)
   {
      var response = await ExchangeTokenApi.ExchangeJwtAssertionAsync(authorization: authorization, grantType: grantType, assertion: assertion, clientId: clientId, clientSecret: clientSecret, scopes: scopes, throwOnError: throwOnError);
      return response.Content;
   }

   /// <summary>
   /// Generates a JWT assertion which is a security token used to make verifiable claims about a subject.
   /// It is cryptographically signed to ensure authenticity and integrity.
   /// </summary>
   /// <param name="clientId">
   /// The Client ID of the calling application, as registered with APS.
   /// </param>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="privateKey">
   /// The RSA private key in PEM format (unencrypted PKCS#1 or PKCS#8).
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="scopes">
   /// A list of requested scopes.
   /// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
   ///</param>
   /// <param name="lifetimeSeconds">
   /// The token lifetime in seconds. Must be between 0 and 300 seconds (5 minutes).
   /// </param>
   /// <exception cref="ArgumentException">
   /// Thrown when required parameters are missing or empty.
   /// </exception>
   /// <exception cref="ArgumentOutOfRangeException">
   /// Thrown when <paramref name="lifetimeSeconds"/> is outside the allowed range of 0 to 300 seconds (5 minutes).
   /// </exception>
   /// <returns>
   /// <see cref="string"/>
   /// </returns>
   public string GenerateJwtAssertion(
      string clientId,
      string serviceAccountId,
      string privateKey,
      string keyId,
      List<Scopes> scopes,
      long lifetimeSeconds = 300)
   {
      if (string.IsNullOrWhiteSpace(clientId))
         throw new ArgumentException($"{nameof(clientId)} is required.", nameof(clientId));
      if (string.IsNullOrWhiteSpace(serviceAccountId))
         throw new ArgumentException($"{nameof(serviceAccountId)} is required.", nameof(serviceAccountId));
      if (string.IsNullOrWhiteSpace(privateKey))
         throw new ArgumentException($"{nameof(privateKey)} is required.", nameof(privateKey));
      if (string.IsNullOrWhiteSpace(keyId))
         throw new ArgumentException($"{nameof(keyId)} is required.", nameof(keyId));
      if (lifetimeSeconds < 0 || lifetimeSeconds > 300)
         throw new ArgumentOutOfRangeException(nameof(lifetimeSeconds), $"{nameof(lifetimeSeconds)} must be 0 to 300 seconds (5 minutes).");

      using var rsa = RSA.Create();
      rsa.ImportFromPem(privateKey.ToCharArray());

      RsaSecurityKey rsaKey = new(rsa)
      {
         KeyId = keyId,
      };

      List<Claim> claims =
      [
         new(JwtRegisteredClaimNames.Sub, serviceAccountId),
         new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
      ];

      foreach (var scope in scopes)
      {
         var memberInfo = typeof(Scopes).GetMember(scope.ToString()).FirstOrDefault();
         var attribute = Attribute.GetCustomAttributes(memberInfo, typeof(EnumMemberAttribute)).FirstOrDefault();
         claims.Add(new("scope", ((EnumMemberAttribute)attribute)?.Value));
      }

      var currentTime = DateTime.UtcNow;
      var expirationTime = currentTime.AddSeconds(lifetimeSeconds);

      SecurityTokenDescriptor securityTokenDescriptor = new()
      {
         Issuer = clientId,
         Audience = "https://developer.api.autodesk.com/authentication/v2/token",
         Subject = new ClaimsIdentity(claims),
         IssuedAt = currentTime,
         NotBefore = currentTime,
         Expires = expirationTime,
         SigningCredentials = new SigningCredentials(rsaKey, SecurityAlgorithms.RsaSha256)
      };

      return new JsonWebTokenHandler().CreateToken(securityTokenDescriptor);
   }

   /// <summary>
   /// Generates a JWT assertion which is a security token used to make verifiable claims about a subject.
   /// It is cryptographically signed to ensure authenticity and integrity.
   /// </summary>
   /// <param name="clientId">
   /// The Client ID of the calling application, as registered with APS.
   /// </param>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="privateKey">
   /// The stream of the RSA private key in PEM format (unencrypted PKCS#1 or PKCS#8).
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="scopes">
   /// A list of requested scopes.
   /// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
   ///</param>
   /// <param name="lifetimeSeconds">
   /// The token lifetime in seconds. Must be between 0 and 300 seconds (5 minutes).
   /// </param>
   /// <exception cref="ArgumentException">
   /// Thrown when required parameters are missing or empty.
   /// </exception>
   /// <exception cref="ArgumentOutOfRangeException">
   /// Thrown when <paramref name="lifetimeSeconds"/> is outside the allowed range of 0 to 300 seconds (5 minutes).
   /// </exception>
   /// <returns>
   /// <see cref="string"/>
   /// </returns>
   public string GenerateJwtAssertion(
      string clientId,
      string serviceAccountId,
      Stream privateKey,
      string keyId,
      List<Scopes> scopes,
      int lifetimeSeconds = 300)
   {
      if (privateKey is null || !privateKey.CanRead)
         throw new ArgumentException($"{nameof(privateKey)} must be a readable stream.", nameof(privateKey));

      if (privateKey.CanSeek && privateKey.Position != 0)
         privateKey.Seek(0, SeekOrigin.Begin);

      using StreamReader streamReader = new(privateKey, leaveOpen: true);
      string privateKeyPem = streamReader.ReadToEnd();

      return GenerateJwtAssertion(clientId, serviceAccountId, privateKeyPem, keyId, scopes, lifetimeSeconds);
   }

   #endregion ExchangeTokenApi

}