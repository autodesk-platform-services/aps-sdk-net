/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Account.Admin
 *
 * The Account Admin API automates creating and managing projects, assigning and managing project users, and managing member and partner company directories. You can also synchronize data with external systems. 
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
using Autodesk.Construction.AccountAdmin.Model;
using Autodesk.Construction.AccountAdmin.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Construction.AccountAdmin.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBusinessUnitsApi
    {
        /// <summary>
        /// Create Business Units
        /// </summary>
        /// <remarks>
        ///Query all the business units in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="businessUnitsRequestPyload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;BusinessUnitsResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<BusinessUnitsResponse>> CreateBusinessUnitsAsync (string accountId, Region? region= null, BusinessUnitsRequestPyload businessUnitsRequestPyload= default(BusinessUnitsRequestPyload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Business Units
        /// </summary>
        /// <remarks>
        ///Query all the business units in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;BusinessUnitsResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<BusinessUnitsResponse>> GetBusinessUnitsAsync (string accountId, Region? region= null,  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class BusinessUnitsApi : IBusinessUnitsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public BusinessUnitsApi(SDKManager.SDKManager sdkManager)
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
        /// Create Business Units
        /// </summary>
        /// <remarks>
        ///Query all the business units in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="businessUnitsRequestPyload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;BusinessUnitsResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<BusinessUnitsResponse>> CreateBusinessUnitsAsync (string accountId,Region? region= null,BusinessUnitsRequestPyload businessUnitsRequestPyload= default(BusinessUnitsRequestPyload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateBusinessUnitsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/business_units_structure",
                        routeParameters: new Dictionary<string, object> {
                            { "account_id", accountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(businessUnitsRequestPyload); // http body (model) parameter


                SetHeader("Region", region, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("PUT");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new ConstructionaccountadminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<BusinessUnitsResponse>(response, default(BusinessUnitsResponse));
                }
                logger.LogInformation($"Exited from CreateBusinessUnitsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<BusinessUnitsResponse>(response, await LocalMarshalling.DeserializeAsync<BusinessUnitsResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Business Units
        /// </summary>
        /// <remarks>
        ///Query all the business units in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;BusinessUnitsResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<BusinessUnitsResponse>> GetBusinessUnitsAsync (string accountId,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetBusinessUnitsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/business_units_structure",
                        routeParameters: new Dictionary<string, object> {
                            { "account_id", accountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Region", region, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new ConstructionaccountadminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<BusinessUnitsResponse>(response, default(BusinessUnitsResponse));
                }
                logger.LogInformation($"Exited from GetBusinessUnitsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<BusinessUnitsResponse>(response, await LocalMarshalling.DeserializeAsync<BusinessUnitsResponse>(response.Content));

            } // using
        }
    }
}
