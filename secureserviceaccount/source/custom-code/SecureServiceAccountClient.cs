/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Secure Service Account
 * Operations to manage Service accounts and keys.   A service account is an identity that an application can use to make requests to other services without a user authorizing the requests. A service account is identified by a unique email address and has an Autodesk ID.  A service account has one or more private keys. A private key is generated through an asymmetric cryptography algorithm; the paired public key is stored by Autodesk Identity.  An application can use a service account's private key to generate a JWT token. The JWT token provides proof of implicit authentication and authorization for this service account; an application can exchange it for a three-legged access token for the service service.
 *
 * Contact: aps.help@autodesk.com
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


using System;
using System.Collections.Generic;
using System.Net.Http;
using Autodesk.SDKManager;
using Autodesk.SecureServiceAccount.Http;
using Autodesk.SecureServiceAccount.Model;

namespace Autodesk.SecureServiceAccount
{
    /// <summary>
    /// Represents a collection of functions to interact with the SecureServiceAccount API endpoints.
    /// </summary>
    public class SecureServiceAccountClient : BaseClient
    {
        /// <summary>
        /// Gets the instance of the IAccountManagementApi interface.
        /// </summary>
        public IAccountManagementApi AccountManagementApi { get; }
        /// <summary>
        /// Gets the instance of the IExchangeTokenApi interface.
        /// </summary>
        public IExchangeTokenApi ExchangeTokenApi { get; }
        /// <summary>
        /// Gets the instance of the IKeyManagementApi interface.
        /// </summary>
        public IKeyManagementApi KeyManagementApi { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SecureServiceAccountClient"/> class.
        /// </summary>
        /// <param name="sdkManager">The SDK manager.</param>
        /// <param name="authenticationProvider">The authentication provider.</param>
        public SecureServiceAccountClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default)
            : base(authenticationProvider)
        {
            if (sdkManager == null)
            {
                sdkManager = SdkManagerBuilder.Create().Build();
            }
            this.AccountManagementApi = new AccountManagementApi(sdkManager);
            this.ExchangeTokenApi = new ExchangeTokenApi(sdkManager);
            this.KeyManagementApi = new KeyManagementApi(sdkManager);
        }


        #region AccountManagementApi

        /// <summary>
        /// Create Service Account
        /// </summary>
        /// <remarks>
        ///Creates a service account. Only a server-to-server application can own service accounts.
        ///
        ///An application can have up to 10 service accounts at any given time.
        ///
        ///Upon a successful response, the operation returns the service account ID and email address.
        /// </remarks>
        /// <param name="createServiceAccountPayload">
        /// The payload containing the details for the service account to be created.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccount></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccount> CreateServiceAccountAsync(CreateServiceAccountPayload createServiceAccountPayload, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.CreateServiceAccountAsync(createServiceAccountPayload, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Delete Service Account
        /// </summary>
        /// <remarks>
        ///Deletes an existing service account. When a service account is deleted, all associated keys will also be deleted.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.DeleteServiceAccountAsync(serviceAccountId, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Enable Service Account
        /// </summary>
        /// <remarks>
        ///Enables a service account.
        ///
        ///This operation allows enabling a service account that is in a deactivated state.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccountDetails></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccountDetails> EnableServiceAccountAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.EnableDisableServiceAccountAsync(serviceAccountId, new EnableDisableServiceAccountPayload { Status = Status.ENABLED }, accessToken, throwOnError);
            return response.Content;
        }



        /// <summary>
        /// Disables a service account.
        /// </summary>
        /// <remarks>
        /// Disables a service account.
        ///
        ///When a service account is disabled state, it loses its capability to manage its service account key. 
        ///Assertions signed by the key will be treated as invalid.
        ///
        /// </remarks>
        /// <param name="serviceAccountId">The Autodesk ID of the service account.</param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)</param>
        /// <param name="throwOnError">Indicates whether to throw an exception on error. (optional)</param>
        /// <returns>Task of ServiceAccountDetails</returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccountDetails> DisableServiceAccountAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.EnableDisableServiceAccountAsync(serviceAccountId, new EnableDisableServiceAccountPayload { Status = Status.DISABLED }, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Get Service Account
        /// </summary>
        /// <remarks>
        ///Retrieves the details for a service account.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccountDetails></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccountDetails> GetServiceAccountAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.GetServiceAccountAsync(serviceAccountId, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Get All Service Accounts
        /// </summary>
        /// <remarks>
        ///Retrieves all service accounts associated with an application.
        /// </remarks>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccounts></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccounts> GetAllServiceAccountsAsync(string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.AccountManagementApi.GetAllServiceAccountsAsync(accessToken, throwOnError);
            return response.Content;
        }

        #endregion AccountManagementApi

        #region ExchangeTokenApi

        /// <summary>
        /// Exchanging JWT assertion for token
        /// </summary>
        /// <remarks>
        ///Returns a three-legged access token for the JWT assertion you provide in the request body. See the Developer's Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
        ///
        ///This operation is only for confidential clients. It requires Basic Authorization (client_id, client_secret). Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
        /// </remarks>
        /// <param name="grantType">
        ///
        /// </param>
        /// <param name="assertion">
        ///The value of the JWT assertion.
        /// </param>
        /// <param name="clientId">
        ///This attribute is optional; it serves as an additional option where the client can either use the authorization header or opt to send this information in the body. (optional)
        /// </param>
        /// <param name="clientSecret">
        ///This attribute is optional; it serves as an additional option where the client can either use the authorization header or opt to send this information in the body. (optional)
        /// </param>
        /// <param name="scope">
        ///This is a space-delimited list of scopes. The scope in the token endpoint request body should be a subset of or the same as the scope specified in the assertion. If the scope is not present, then the returned access token will have the same scope as the assertion. (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ExchangeJwtToken></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ExchangeJwtToken> ExchangeJwtAssertionAsync(string assertion, string clientId, string clientSecret, List<Scopes> scope = default(List<Scopes>), GrantType grantType = GrantType.UrnIetfParamsOauthGrantTypeJwtBearer, bool throwOnError = true)
        {
            var response = await this.ExchangeTokenApi.ExchangeJwtAssertionAsync(assertion: assertion, grantType: grantType, clientId: clientId, clientSecret: clientSecret, scope: scope, throwOnError: throwOnError);
            return response.Content;
        }

        #endregion ExchangeTokenApi

        #region KeyManagementApi

        /// <summary>
        /// Create Keys
        /// </summary>
        /// <remarks>
        ///Creates a service account key. 
        ///
        ///A service account key is a public-private key pair, generated using RSA with a key length of 2048 bits by the Identity Authorization Service (AuthZ).
        ///
        ///The private key is returned once during its creation. AuthZ only stores the public key.
        ///
        ///A service account can have up to 3 keys at any given time.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccountPrivateKey></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccountPrivateKey> CreateServiceAccountKeyAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.KeyManagementApi.CreateServiceAccountKeyAsync(serviceAccountId, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Delete key
        /// </summary>
        /// <remarks>
        ///Deletes an existing key.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="keyId">
        ///The ID of the private key
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountKeyAsync(string serviceAccountId, string keyId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.KeyManagementApi.DeleteServiceAccountKeyAsync(serviceAccountId, keyId, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Enables a service account key.
        /// </summary>
        /// <remarks>
        ///Enables a service account key.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="keyId">
        ///The ID of the private key
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<HttpResponseMessage> EnableServiceAccountKeyAsync(string serviceAccountId, string keyId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.KeyManagementApi.EnableDisableServiceAccountKeyAsync(serviceAccountId, keyId, new EnableDisableServiceAccountKeyPayload { Status = Status.ENABLED }, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Disables a service account key.
        /// </summary>
        /// <remarks>
        /// Disables a service account key.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="keyId">
        ///The ID of the private key
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DisableServiceAccountKeyAsync(string serviceAccountId, string keyId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.KeyManagementApi.EnableDisableServiceAccountKeyAsync(serviceAccountId, keyId, new EnableDisableServiceAccountKeyPayload { Status = Status.DISABLED }, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Get All Keys
        /// </summary>
        /// <remarks>
        ///Lists all keys associated with the service account. This operation will only return key metadata, not the private or public key.
        /// </remarks>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ServiceAccountKeys></returns>
        /// <exception cref="SecureServiceAccountApiException">Thrown when fails to make API call</exception>
        public async System.Threading.Tasks.Task<ServiceAccountKeys> GetAllServiceAccountKeysAsync(string serviceAccountId, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.KeyManagementApi.GetAllServiceAccountKeysAsync(serviceAccountId, accessToken, throwOnError);
            return response.Content;
        }

        #endregion KeyManagementApi
    }
}
