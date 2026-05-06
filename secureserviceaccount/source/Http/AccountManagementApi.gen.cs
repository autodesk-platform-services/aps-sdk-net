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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using Autodesk.Forge.Core;
using Autodesk.SecureServiceAccount.Client;
using Autodesk.SecureServiceAccount.Model;
using Microsoft.Extensions.Logging;


namespace Autodesk.SecureServiceAccount.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAccountManagementApi
    {
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="createServiceAccountPayload">
        /// The payload containing the details for the service account to be created.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccount&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<ServiceAccount>> CreateServiceAccountAsync(CreateServiceAccountPayload createServiceAccountPayload, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Delete Service Account
        /// </summary>
        /// <remarks>
        ///Deletes an existing service account. When a service account is deleted, all associated keys will also be deleted.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountAsync(string serviceAccountId, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Enable or Disable Service Account
        /// </summary>
        /// <remarks>
        ///Enables or disables a service account.
        ///
        ///When a service account is disabled state, it loses its capability to manage its service account key. 
        ///Assertions signed by the key will be treated as invalid.
        ///
        ///This operation allows enabling a service account that is in a deactivated state.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="enableDisableServiceAccountPayload">
        /// The payload containing the details for enabling or disabling the service account.
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccountDetails&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<ServiceAccountDetails>> EnableDisableServiceAccountAsync(string serviceAccountId, EnableDisableServiceAccountPayload enableDisableServiceAccountPayload, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Service Account
        /// </summary>
        /// <remarks>
        ///Retrieves the details for a service account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccountDetails&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<ServiceAccountDetails>> GetServiceAccountAsync(string serviceAccountId, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get All Service Accounts
        /// </summary>
        /// <remarks>
        ///Retrieves all service accounts associated with an application.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="accessToken">
        ///An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        ///Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccounts&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<ServiceAccounts>> GetAllServiceAccountsAsync(string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AccountManagementApi : IAccountManagementApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManagementApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public AccountManagementApi(SDKManager.SDKManager sdkManager)
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
            else if (value is IList)
            {
                if (value is List<string>)
                {
                    dictionary.Add(name, String.Join(" ", (List<string>)value));
                }
                else
                {
                    List<string> concatenatedList = new List<string>();
                    foreach (var x in (IList)value)
                    {
                        var type = x.GetType();
                        var memberInfos = type.GetMember(x.ToString());
                        var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                        var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                        concatenatedList.Add(((EnumMemberAttribute)valueAttributes[0]).Value);
                    }
                    dictionary.Add(name, String.Join(" ", concatenatedList));
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
        /// Create Service Account
        /// </summary>
        /// <remarks>
        ///Creates a service account. Only a server-to-server application can own service accounts.
        ///
        ///An application can have up to 10 service accounts at any given time.
        ///
        ///Upon a successful response, the operation returns the service account ID and email address.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="createServiceAccountPayload">
        /// The payload containing the details for creating the service account.
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccount&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<ServiceAccount>> CreateServiceAccountAsync(CreateServiceAccountPayload createServiceAccountPayload, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateServiceAccountAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/service-accounts",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(createServiceAccountPayload); // http body (model) parameter

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
                        throw new SecureServiceAccountApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ServiceAccount>(response, default(ServiceAccount));
                }
                logger.LogInformation($"Exited from CreateServiceAccountAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ServiceAccount>(response, await LocalMarshalling.DeserializeAsync<ServiceAccount>(response.Content));

            }
        }
        /// <summary>
        /// Delete Service Account
        /// </summary>
        /// <remarks>
        ///Deletes an existing service account. When a service account is deleted, all associated keys will also be deleted.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountAsync(string serviceAccountId, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteServiceAccountAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/service-accounts/{serviceAccountId}",
                        routeParameters: new Dictionary<string, object> {
                            { "serviceAccountId", serviceAccountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Method = new HttpMethod("DELETE");

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
                        throw new SecureServiceAccountApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteServiceAccountAsync with response statusCode: {response.StatusCode}");
                return response;

            }
        }


        /// <summary>
        /// Enable or Disable Service Account
        /// </summary>
        /// <remarks>
        ///Enables or disables a service account.
        ///
        ///When a service account is disabled state, it loses its capability to manage its service account key. 
        ///Assertions signed by the key will be treated as invalid.
        ///
        ///This operation allows enabling a service account that is in a deactivated state.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="enableDisableServiceAccountPayload">
        /// The payload containing the details for enabling or disabling the service account.
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccountDetails&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<ServiceAccountDetails>> EnableDisableServiceAccountAsync(string serviceAccountId, EnableDisableServiceAccountPayload enableDisableServiceAccountPayload, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into EnableDisableServiceAccountAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/service-accounts/{serviceAccountId}",
                        routeParameters: new Dictionary<string, object> {
                            { "serviceAccountId", serviceAccountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(enableDisableServiceAccountPayload); // http body (model) parameter

                request.Method = new HttpMethod("PATCH");

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
                        throw new SecureServiceAccountApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ServiceAccountDetails>(response, default(ServiceAccountDetails));
                }
                logger.LogInformation($"Exited from EnableDisableServiceAccountAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ServiceAccountDetails>(response, await LocalMarshalling.DeserializeAsync<ServiceAccountDetails>(response.Content));

            }
        }


        /// <summary>
        /// Get Service Account
        /// </summary>
        /// <remarks>
        ///Retrieves the details for a service account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="serviceAccountId">
        ///The Autodesk ID of the service account
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ServiceAccountDetails&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<ServiceAccountDetails>> GetServiceAccountAsync(string serviceAccountId, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetServiceAccountAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/service-accounts/{serviceAccountId}",
                        routeParameters: new Dictionary<string, object> {
                            { "serviceAccountId", serviceAccountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

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
                        throw new SecureServiceAccountApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ServiceAccountDetails>(response, default(ServiceAccountDetails));
                }
                logger.LogInformation($"Exited from GetServiceAccountAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ServiceAccountDetails>(response, await LocalMarshalling.DeserializeAsync<ServiceAccountDetails>(response.Content));

            }
        }

        /// <summary>
        /// Get All Service Accounts
        /// </summary>
        /// <remarks>
        ///Retrieves all service accounts associated with an application.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse&lt;ServiceAccounts&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<ServiceAccounts>> GetAllServiceAccountsAsync(string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetAllServiceAccountsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/service-accounts",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

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
                        throw new SecureServiceAccountApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ServiceAccounts>(response, default(ServiceAccounts));
                }
                logger.LogInformation($"Exited from GetAllServiceAccountsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ServiceAccounts>(response, await LocalMarshalling.DeserializeAsync<ServiceAccounts>(response.Content));

            }
        }
    }
}
