/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using Autodesk.Authentication.SecureServiceAccount.Client;
using Autodesk.Authentication.SecureServiceAccount.Model;
using Autodesk.Forge.Core;
using Autodesk.SDKManager;
using Microsoft.Extensions.Logging;

namespace Autodesk.Authentication.SecureServiceAccount.Http;

/// <summary>
/// Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IAccountManagementApi
{
    /// <summary>
    /// Creates a service account.
    /// Only a server-to-server application can own service accounts.
    /// An application can have up to 10 service accounts at any given time.
    /// Upon a successful response, the operation returns the service account ID and email address.
    /// </summary>
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
    System.Threading.Tasks.Task<ApiResponse<ServiceAccountCreated>> CreateServiceAccountAsync(ServiceAccountCreatePayload serviceAccountCreatePayload = default(ServiceAccountCreatePayload), string accessToken = default(string), bool throwOnError = true);

    /// <summary>
    /// Deletes an existing service account.
    /// When a service account is deleted, all associated keys will also be deleted.
    /// </summary>
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
    System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceAccountAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true);

    /// <summary>
    /// Retrieves the details for a service account.
    /// </summary>
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
    System.Threading.Tasks.Task<ApiResponse<ServiceAccount>> GetServiceAccountAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true);

    /// <summary>
    /// Retrieves all service accounts associated with an application.
    /// </summary>
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
    System.Threading.Tasks.Task<ApiResponse<ServiceAccountsResponse>> GetServiceAccountsAsync(string accessToken = default(string), bool throwOnError = true);

    /// <summary>
    /// Enables or disables a service account.
    /// When a service account is in the disabled state, it loses its capability to manage its service account key.
    /// Assertions signed by the key will be treated as invalid.
    /// This operation allows enabling a service account that is in a disabled state.
    /// </summary>
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
    System.Threading.Tasks.Task<HttpResponseMessage> UpdateServiceAccountAsync(string serviceAccountId = default(string), ServiceAccountUpdatePayload serviceAccountUpdatePayload = default(ServiceAccountUpdatePayload), string accessToken = default(string), bool throwOnError = true);
}

/// <summary>
/// Represents a collection of functions to interact with the API endpoints.
/// </summary>
public partial class AccountManagementApi : IAccountManagementApi
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountManagementApi"/> class using <see cref="SDKManager.SDKManager"/>.
    /// </summary>
    /// <param name="sdkManager">
    /// An instance of <see cref="SDKManager.SDKManager"/>.
    /// </param>
    public AccountManagementApi(SDKManager.SDKManager sdkManager)
    {
        Service = sdkManager.ApsClient.Service;
        _logger = sdkManager.Logger;
    }

    private static void SetQueryParameter(string name, object value, Dictionary<string, object> dictionary)
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

    private static void SetHeader(string baseName, object value, HttpRequestMessage request)
    {
        if (value is DateTime)
        {
            if ((DateTime)value != DateTime.MinValue)
            {
                request.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
            }
        }
        else
        {
            if (value != null)
            {
                if (!string.Equals(baseName, "Content-Range"))
                {
                    request.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                }
                else
                {
                    request.Content.Headers.Add(baseName, LocalMarshalling.ParameterToString(value));
                }
            }
        }

    }

    /// <summary>
    /// Gets or sets the <see cref="ApsConfiguration"/> object.
    /// </summary>
    /// <value>
    /// An instance of the <see cref="ForgeService"/>.
    /// </value>
    public ForgeService Service { get; set; }

    /// <summary>
    /// Creates a service account.
    /// Only a server-to-server application can own service accounts.
    /// An application can have up to 10 service accounts at any given time.
    /// Upon a successful response, the operation returns the service account ID and email address.
    /// </summary>
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
    public async System.Threading.Tasks.Task<ApiResponse<ServiceAccountCreated>> CreateServiceAccountAsync(ServiceAccountCreatePayload serviceAccountCreatePayload = default(ServiceAccountCreatePayload), string accessToken = default(string), bool throwOnError = true)
    {
        _logger.LogInformation($"Entered into {nameof(CreateServiceAccountAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
           Marshalling.BuildRequestUri("/authentication/v2/service-accounts",
              routeParameters: new Dictionary<string, object>
              {
              },
              queryParameters: queryParam
           );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
        }

        request.Content = Marshalling.Serialize(serviceAccountCreatePayload);

        request.Method = HttpMethod.Post;

        // Make the HTTP request.
        var response = await Service.Client.SendAsync(request);

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
            _logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
            return new ApiResponse<ServiceAccountCreated>(response, default(ServiceAccountCreated));
        }
        _logger.LogInformation($"Exited from {nameof(CreateServiceAccountAsync)} with response statusCode: {response.StatusCode}");
        return new ApiResponse<ServiceAccountCreated>(response, await LocalMarshalling.DeserializeAsync<ServiceAccountCreated>(response.Content));
    }

    /// <summary>
    /// Deletes an existing service account.
    /// When a service account is deleted, all associated keys will also be deleted.
    /// </summary>
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
        _logger.LogInformation($"Entered into {nameof(DeleteServiceAccountAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
            Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}",
                routeParameters: new Dictionary<string, object>
                {
                  { "serviceAccountId", serviceAccountId},
                },
                queryParameters: queryParam
            );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
        }

        request.Method = HttpMethod.Delete;

        // Make the HTTP request.
        var response = await Service.Client.SendAsync(request);

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
            _logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
            return response;
        }
        _logger.LogInformation($"Exited from {nameof(DeleteServiceAccountAsync)} with response statusCode: {response.StatusCode}");
        return response;
    }

    /// <summary>
    /// Retrieves the details for a service account.
    /// </summary>
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
    public async System.Threading.Tasks.Task<ApiResponse<ServiceAccount>> GetServiceAccountAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
    {
        _logger.LogInformation($"Entered into {nameof(GetServiceAccountAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
            Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}",
                routeParameters: new Dictionary<string, object>
                {
                  { "serviceAccountId", serviceAccountId},
                },
                queryParameters: queryParam
            );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
        }

        request.Method = HttpMethod.Get;

        // Make the HTTP request.
        var response = await Service.Client.SendAsync(request);

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
            _logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
            return new ApiResponse<ServiceAccount>(response, default(ServiceAccount));
        }
        _logger.LogInformation($"Exited from {nameof(GetServiceAccountAsync)} with response statusCode: {response.StatusCode}");
        return new ApiResponse<ServiceAccount>(response, await LocalMarshalling.DeserializeAsync<ServiceAccount>(response.Content));
    }

    /// <summary>
    /// Retrieves all service accounts associated with an application.
    /// </summary>
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
    public async System.Threading.Tasks.Task<ApiResponse<ServiceAccountsResponse>> GetServiceAccountsAsync(string accessToken = default(string), bool throwOnError = true)
    {
        _logger.LogInformation($"Entered into {nameof(GetServiceAccountsAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
            Marshalling.BuildRequestUri("/authentication/v2/service-accounts",
                routeParameters: new Dictionary<string, object>
                {
                },
                queryParameters: queryParam
            );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
        }

        request.Method = HttpMethod.Get;

        // Make the HTTP request.
        var response = await Service.Client.SendAsync(request);

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
            _logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
            return new ApiResponse<ServiceAccountsResponse>(response, default(ServiceAccountsResponse));
        }
        _logger.LogInformation($"Exited from {nameof(GetServiceAccountsAsync)} with response statusCode: {response.StatusCode}");
        return new ApiResponse<ServiceAccountsResponse>(response, await LocalMarshalling.DeserializeAsync<ServiceAccountsResponse>(response.Content));
    }

    /// <summary>
    /// Enables or disables a service account.
    /// When a service account is in the disabled state, it loses its capability to manage its service account key.
    /// Assertions signed by the key will be treated as invalid.
    /// This operation allows enabling a service account that is in a disabled state.
    /// </summary>
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
        _logger.LogInformation($"Entered into {nameof(UpdateServiceAccountAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
            Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}",
                routeParameters: new Dictionary<string, object>
                {
                  { "serviceAccountId", serviceAccountId},
                },
                queryParameters: queryParam
            );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(accessToken))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
        }

        request.Content = Marshalling.Serialize(serviceAccountUpdatePayload);

        request.Method = HttpMethod.Patch;

        // Make the HTTP request.
        var response = await Service.Client.SendAsync(request);

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
            _logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
            return response;
        }
        _logger.LogInformation($"Exited from {nameof(UpdateServiceAccountAsync)} with response statusCode: {response.StatusCode}");
        return response;
    }
}
