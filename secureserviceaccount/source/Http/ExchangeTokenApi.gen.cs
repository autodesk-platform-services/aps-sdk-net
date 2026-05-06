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
    public interface IExchangeTokenApi
    {
        /// <summary>
        /// Exchanging JWT assertion for token
        /// </summary>
        /// <remarks>
        ///Returns a three-legged access token for the JWT assertion you provide in the request body. See the Developer's Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
        ///
        ///This operation is only for confidential clients. It requires Basic Authorization (client_id, client_secret). Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="grantType">
        ///
        /// </param>
        /// <param name="assertion">
        ///The value of the JWT assertion.
        /// </param>
        /// <param name="authorization">
        ///Must be Basic &lt;credentials&gt;, where &lt;credentials&gt; is a base64 encoded string of client_id:client_secret. This parameter is required only if client_id and client_secret are not provided in the request body. (optional)
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
        /// Indicates whether to throw an exception on error.(optional)
        /// </param> 
        /// <returns>Task of ApiResponse&lt;ExchangeJwtToken&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<ExchangeJwtToken>> ExchangeJwtAssertionAsync(string assertion, GrantType grantType = default, string authorization = default(string), string clientId = default(string), string clientSecret = default(string), List<Scopes> scope = default(List<Scopes>), bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ExchangeTokenApi : IExchangeTokenApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeTokenApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ExchangeTokenApi(SDKManager.SDKManager sdkManager)
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
        /// Exchanging JWT assertion for token
        /// </summary>
        /// <remarks>
        ///Returns a three-legged access token for the JWT assertion you provide in the request body. See the Developer's Guide topic JWT Assertions for information on how to generate a JWT assertion for this operation.
        ///
        ///This operation is only for confidential clients. It requires Basic Authorization (client_id, client_secret). Authentication information (client_id, client_secret) can be included either in the header or the body, but not both simultaneously.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="grantType">
        ///
        /// </param>
        /// <param name="assertion">
        ///The value of the JWT assertion.
        /// </param>
        /// <param name="authorization">
        ///Must be Basic &lt;credentials&gt;, where &lt;credentials&gt; is a base64 encoded string of client_id:client_secret. This parameter is required only if client_id and client_secret are not provided in the request body. (optional)
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
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;ExchangeJwtToken&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<ExchangeJwtToken>> ExchangeJwtAssertionAsync(string assertion, GrantType grantType = default, string authorization = default(string), string clientId = default(string), string clientSecret = default(string), List<Scopes> scope = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into ExchangeJwtAssertionAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri($"/authentication/v2/token",
                        routeParameters: new Dictionary<string, object>
                        {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/SECURE SERVICE ACCOUNT/C#/1.0.0");

                SetHeader("Authorization", authorization, request);

                var formParams = new Dictionary<string, object>();
                SetQueryParameter("grant_type", grantType, formParams);
                if (!string.IsNullOrEmpty(clientId)) { formParams.Add("client_id", clientId); }
                if (!string.IsNullOrEmpty(clientSecret)) { formParams.Add("client_secret", clientSecret); }
                if (!string.IsNullOrEmpty(assertion)) { formParams.Add("assertion", assertion); }
                SetQueryParameter("scope", scope, formParams);
                request.Content = new FormUrlEncodedContent(formParams.ToDictionary(k => k.Key, v => v.Value.ToString()));


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
                    return new ApiResponse<ExchangeJwtToken>(response, default(ExchangeJwtToken));
                }
                logger.LogInformation($"Exited from ExchangeJwtAssertionAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ExchangeJwtToken>(response, await LocalMarshalling.DeserializeAsync<ExchangeJwtToken>(response.Content));

            }
        }
    }
}
