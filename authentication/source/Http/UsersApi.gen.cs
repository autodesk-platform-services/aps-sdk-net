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
    public interface IUsersApi
    {
        /// <summary>
        /// GET User Info
        /// </summary>
        /// <remarks>
        /// Retrieves basic information for the given authenticated user. Only supports 3-legged access tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">YOUR_3_LEGGED_ACCESS_TOKEN (optional)</param>
        /// <returns>Task of ApiResponse<UserInfo></returns>
        
        System.Threading.Tasks.Task<ApiResponse<UserInfo>> GetUserinfoAsync (string authorization, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UsersApi : IUsersApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public UsersApi(SDKManager.SDKManager sdkManager)
        {
            this.Service = sdkManager.ApsClient.Service;
            this.logger = sdkManager.Logger;
        }
        private void SetQueryParameter(string name, object value, Dictionary<string, object> dictionary)
        {
            if(value is Enum)
            {
                var type = value.GetType();
                var memberInfos = type.GetMember(value.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if(valueAttributes.Length > 0)
                {
                    dictionary.Add(name, ((EnumMemberAttribute)valueAttributes[0]).Value);
                }
            }
            else if(value is int)
            {
                if((int)value > 0)
                {
                    dictionary.Add(name, value);
                }
            }
            else
            {
                if(value != null)
                {
                    dictionary.Add(name, value);
                }
            }
        }
        private void SetHeader(string baseName, object value, HttpRequestMessage req)
        {
                if(value is DateTime)
                {
                    if((DateTime)value != DateTime.MinValue)
                    {
                        req.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                    }
                }
                else
                {
                    if (value != null)
                    {
                        if(!string.Equals(baseName, "Content-Range"))
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
        public ForgeService Service {get; set;}

        /// <summary>
        /// GET User Info
        /// </summary>
        /// <remarks>
        /// Retrieves basic information for the given authenticated user. Only supports 3-legged access tokens.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="authorization">YOUR_3_LEGGED_ACCESS_TOKEN (optional)</param>
        /// <returns>Task of ApiResponse<UserInfo></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<UserInfo>> GetUserinfoAsync (string authorization, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUserinfoAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                // *** ss added manually
                request.RequestUri = new Uri("https://api.userprofile.autodesk.com/userinfo");
                    // Marshalling.BuildRequestUri("/userinfo",
                    //     routeParameters: new Dictionary<string, object> {
                    //     },
                    //     queryParameters: queryParam
                    // );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/AUTHENTICATION/C#/1.0.0-beta1");
                if(!string.IsNullOrEmpty(authorization))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {authorization}");
                }



               // SetHeader("Authorization", authorization, request);

                // *** ss code end***

                // tell the underlying pipeline what scope we'd like to use

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new AuthenticationApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<UserInfo>(response, default(UserInfo));
                }
                logger.LogInformation($"Exited from GetUserinfoAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<UserInfo>(response, await LocalMarshalling.DeserializeAsync<UserInfo>(response.Content));

            } // using
        }
    }
}
