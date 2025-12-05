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
using System.Collections;
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
public interface IExchangeTokenApi
{
    /// <summary>
    /// Returns a three-legged access token for the JWT assertion you provide in the request body.
    /// See the Developer’s Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
    /// This operation is only for confidential clients.
    /// It requires Basic Authorization (client_id, client_secret).
    /// Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
    /// </summary>
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
    /// A list of requested scopes.
    /// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
    /// The scope in the token endpoint request body should be a subset of or the same as the scope specified in the assertion.
    /// If the scope is not present, then the returned access token will have the same scope as the assertion.
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
    /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="ThreeLeggedToken"/>&gt;&gt;
    /// </returns>
    System.Threading.Tasks.Task<ApiResponse<ThreeLeggedToken>> ExchangeJwtAssertionAsync(string authorization = default(string), GrantType? grantType = null, string assertion = default(string), string clientId = default(string), string clientSecret = default(string), List<Scopes> scopes = null, bool throwOnError = true);
}

/// <summary>
/// Represents a collection of functions to interact with the API endpoints.
/// </summary>
public partial class ExchangeTokenApi : IExchangeTokenApi
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeTokenApi"/> class using <see cref="SDKManager.SDKManager"/>.
    /// </summary>
    /// <param name="sdkManager">
    /// An instance of <see cref="SDKManager.SDKManager"/>.
    /// </param>
    public ExchangeTokenApi(SDKManager.SDKManager sdkManager)
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
    /// Returns a three-legged access token for the JWT assertion you provide in the request body.
    /// See the Developer’s Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
    /// This operation is only for confidential clients.
    /// It requires Basic Authorization (client_id, client_secret).
    /// Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
    /// </summary>
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
    /// A list of requested scopes.
    /// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a list of valid values you can provide.
    /// The scope in the token endpoint request body should be a subset of or the same as the scope specified in the assertion.
    /// If the scope is not present, then the returned access token will have the same scope as the assertion.
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
    /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="ThreeLeggedToken"/>&gt;&gt;
    /// </returns>
    public async System.Threading.Tasks.Task<ApiResponse<ThreeLeggedToken>> ExchangeJwtAssertionAsync(string authorization = default(string), GrantType? grantType = null, string assertion = default(string), string clientId = default(string), string clientSecret = default(string), List<Scopes> scopes = null, bool throwOnError = true)
    {
        _logger.LogInformation($"Entered into {nameof(ExchangeJwtAssertionAsync)}");

        using var request = new HttpRequestMessage();

        var queryParam = new Dictionary<string, object>();
        request.RequestUri =
           Marshalling.BuildRequestUri("/authentication/v2/token",
              routeParameters: new Dictionary<string, object>
              {
              },
              queryParameters: queryParam
           );

        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/2.0.0");

        if (!string.IsNullOrEmpty(authorization))
        {
            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authorization}");
        }

        var formParams = new Dictionary<string, object>();
        // Convert grantType enum to string
        SetQueryParameter("grant_type", grantType, formParams);
        if (!string.IsNullOrEmpty(assertion)) { formParams.Add("assertion", assertion); }
        // Convert scopes enum to string
        SetQueryParameter("scope", scopes, formParams);
        if (!string.IsNullOrEmpty(clientId) && string.IsNullOrEmpty(authorization)) { formParams.Add("client_id", clientId); }
        if (!string.IsNullOrEmpty(clientSecret) && string.IsNullOrEmpty(authorization)) { formParams.Add("client_secret", clientSecret); }

        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>(formParams.ToDictionary(k => k.Key, k => k.Value.ToString())));

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
            return new ApiResponse<ThreeLeggedToken>(response, default(ThreeLeggedToken));
        }
        _logger.LogInformation($"Exited from {nameof(ExchangeJwtAssertionAsync)} with response statusCode: {response.StatusCode}");
        return new ApiResponse<ThreeLeggedToken>(response, await LocalMarshalling.DeserializeAsync<ThreeLeggedToken>(response.Content));
    }
}
