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

using Autodesk.Authentication.SecureServiceAccount.Client;
using Autodesk.Authentication.SecureServiceAccount.Model;
using Autodesk.Forge.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Autodesk.Authentication.SecureServiceAccount.Http;

/// <summary>
/// Represents a collection of functions to interact with the API endpoints
/// </summary>
public interface IKeyManagementApi
{
   /// <summary>
   /// Creates a service account key.
   /// A service account key is a public-private key pair, generated using RSA with a key length of 2048 bits by the Identity Authorization Service(AuthZ).
   /// The private key is returned once during its creation.AuthZ only stores the public key.
   /// A service account can have up to 3 keys at any given time.
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
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="KeyCreated"/>&gt;&gt;
   /// </returns>
   System.Threading.Tasks.Task<ApiResponse<KeyCreated>> CreateKeyAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true);

   /// <summary>
   /// Deletes an existing key.
   /// </summary>
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
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   System.Threading.Tasks.Task<HttpResponseMessage> DeleteKeyAsync(string serviceAccountId = default(string), string keyId = default(string), string accessToken = default(string), bool throwOnError = true);

   /// <summary>
   /// Lists all keys associated with the service account.
   /// This operation will only return key metadata, not the private or public key.
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
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="KeysResponse"/>&gt;&gt;
   /// </returns>
   System.Threading.Tasks.Task<ApiResponse<KeysResponse>> GetKeysAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true);

   /// <summary>
   /// Deletes an existing key.
   /// </summary>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="keyUpdatePayload">
   /// Describes the updates to the key associated with the service account.
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
   System.Threading.Tasks.Task<HttpResponseMessage> UpdateKeyAsync(string serviceAccountId = default(string), string keyId = default(string), KeyUpdatePayload keyUpdatePayload = default(KeyUpdatePayload), string accessToken = default(string), bool throwOnError = true);
}

/// <summary>
/// Represents a collection of functions to interact with the API endpoints
/// </summary>
public partial class KeyManagementApi : IKeyManagementApi
{
   private ILogger _logger;

   /// <summary>
   /// Initializes a new instance of the <see cref="KeyManagementApi"/> class
   /// using SDKManager object
   /// </summary>
   /// <param name="sdkManager">
   /// An instance of SDKManager
   /// </param>
   public KeyManagementApi(SDKManager.SDKManager sdkManager)
   {
      Service = sdkManager.ApsClient.Service;
      _logger = sdkManager.Logger;
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
            dictionary.Add(name, string.Join(" ", (List<string>)value));
         }
         else
         {
            List<string> concatenatedList = [];
            foreach (var x in (IList)value)
            {
               var type = x.GetType();
               var memberInfos = type.GetMember(x.ToString());
               var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
               var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
               concatenatedList.Add(((EnumMemberAttribute)valueAttributes[0]).Value);
            }
            dictionary.Add(name, string.Join(" ", concatenatedList));
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
   /// Creates a service account key.
   /// A service account key is a public-private key pair, generated using RSA with a key length of 2048 bits by the Identity Authorization Service(AuthZ).
   /// The private key is returned once during its creation.AuthZ only stores the public key.
   /// A service account can have up to 3 keys at any given time.
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
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="KeyCreated"/>&gt;&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ApiResponse<KeyCreated>> CreateKeyAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      _logger.LogInformation($"Entered into {nameof(CreateKeyAsync)}");

      using var request = new HttpRequestMessage();

      var queryParam = new Dictionary<string, object>();
      request.RequestUri =
          Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}/keys",
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
         return new ApiResponse<KeyCreated>(response, default(KeyCreated));
      }
      _logger.LogInformation($"Exited from {nameof(CreateKeyAsync)} with response statusCode: {response.StatusCode}");
      return new ApiResponse<KeyCreated>(response, await LocalMarshalling.DeserializeAsync<KeyCreated>(response.Content));
   }

   /// <summary>
   /// Deletes an existing key.
   /// </summary>
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
   /// <exception cref="HttpRequestException">
   /// Thrown when fails to make API call.
   /// </exception>
   /// <returns>
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="HttpResponseMessage"/>&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKeyAsync(string serviceAccountId = default(string), string keyId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      _logger.LogInformation($"Entered into {nameof(DeleteKeyAsync)}");

      using var request = new HttpRequestMessage();

      var queryParam = new Dictionary<string, object>();
      request.RequestUri =
          Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}/keys/{keyId}",
              routeParameters: new Dictionary<string, object>
              {
                  { "serviceAccountId", serviceAccountId},
                  { "keyId", keyId },
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
      _logger.LogInformation($"Exited from {nameof(DeleteKeyAsync)} with response statusCode: {response.StatusCode}");
      return response;
   }

   /// <summary>
   /// Lists all keys associated with the service account.
   /// This operation will only return key metadata, not the private or public key.
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
   /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="KeysResponse"/>&gt;&gt;
   /// </returns>
   public async System.Threading.Tasks.Task<ApiResponse<KeysResponse>> GetKeysAsync(string serviceAccountId = default(string), string accessToken = default(string), bool throwOnError = true)
   {
      _logger.LogInformation($"Entered into {nameof(GetKeysAsync)}");

      using var request = new HttpRequestMessage();

      var queryParam = new Dictionary<string, object>();
      request.RequestUri =
          Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}/keys",
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
         return new ApiResponse<KeysResponse>(response, default(KeysResponse));
      }
      _logger.LogInformation($"Exited from {nameof(GetKeysAsync)} with response statusCode: {response.StatusCode}");
      return new ApiResponse<KeysResponse>(response, await LocalMarshalling.DeserializeAsync<KeysResponse>(response.Content));
   }

   /// <summary>
   /// Deletes an existing key.
   /// </summary>
   /// <param name="serviceAccountId">
   /// The Autodesk ID of the service account.
   /// </param>
   /// <param name="keyId">
   /// The ID of the private key.
   /// </param>
   /// <param name="keyUpdatePayload">
   /// Describes the updates to the key associated with the service account.
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
   public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKeyAsync(string serviceAccountId = default(string), string keyId = default(string), KeyUpdatePayload keyUpdatePayload = default(KeyUpdatePayload), string accessToken = default(string), bool throwOnError = true)
   {
      _logger.LogInformation($"Entered into {nameof(UpdateKeyAsync)}");

      using var request = new HttpRequestMessage();

      var queryParam = new Dictionary<string, object>();
      request.RequestUri =
          Marshalling.BuildRequestUri("/authentication/v2/service-accounts/{serviceAccountId}/keys/{keyId}",
              routeParameters: new Dictionary<string, object>
              {
                  { "serviceAccountId", serviceAccountId},
                  { "keyId", keyId },
              },
              queryParameters: queryParam
          );

      request.Headers.TryAddWithoutValidation("Accept", "application/json");
      request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

      if (!string.IsNullOrEmpty(accessToken))
      {
         request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
      }

      request.Content = Marshalling.Serialize(keyUpdatePayload);

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
      _logger.LogInformation($"Exited from {nameof(UpdateKeyAsync)} with response statusCode: {response.StatusCode}");
      return response;
   }
}
