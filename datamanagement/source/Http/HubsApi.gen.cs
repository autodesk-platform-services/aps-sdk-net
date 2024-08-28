/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Data Management
 *
 * The Data Management API provides a unified and consistent way to access data across BIM 360 Team, Fusion Team (formerly known as A360 Team), BIM 360 Docs, A360 Personal, and the Object Storage Service.  With this API, you can accomplish a number of workflows, including accessing a Fusion model in Fusion Team and getting an ordered structure of items, IDs, and properties for generating a bill of materials in a 3rd-party process. Or, you might want to superimpose a Fusion model and a building model to use in the Viewer.
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
using Autodesk.DataManagement.Model;
using Autodesk.DataManagement.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.DataManagement.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHubsApi
    {
        /// <summary>
        /// Get a Hub
        /// </summary>
        /// <remarks>
        ///Returns the hub specified by the `hub_id` parameter.
///
///For BIM 360 Docs, a hub ID corresponds to a BIM 360 account ID. To convert a BIM 360 account ID to a hub ID, prefix the account ID with `b.`. For example, an account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="hubId">
         ///The unique identifier of a hub.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hub&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hub>> GetHubAsync (string hubId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List Hubs
        /// </summary>
        /// <remarks>
        ///Returns a collection of hubs that the user of your app can access.
///
///The returned hubs can be BIM 360 Team hubs, Fusion Team hubs (formerly known as A360 Team hubs), A360 Personal hubs, ACC Docs (Autodesk Docs) accounts, or BIM 360 Docs accounts. Only active hubs are returned.
///
///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
         /// <param name="filterId">
         ///Filter by the `id` of the `ref` target. (optional)
         /// </param>
         /// <param name="filterName">
         ///Filter by the `name` of the `ref` target. (optional)
         /// </param>
         /// <param name="filterExtensionType">
         ///Filter by the extension type.  (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hubs&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hubs>> GetHubsAsync (string xUserId= default(string), List<string> filterId= default(List<string>), string filterName= default(string), List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HubsApi : IHubsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HubsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public HubsApi(SDKManager.SDKManager sdkManager)
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
        /// Get a Hub
        /// </summary>
        /// <remarks>
        ///Returns the hub specified by the `hub_id` parameter.
///
///For BIM 360 Docs, a hub ID corresponds to a BIM 360 account ID. To convert a BIM 360 account ID to a hub ID, prefix the account ID with `b.`. For example, an account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="hubId">
         ///The unique identifier of a hub.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hub&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hub>> GetHubAsync (string hubId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHubAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs/{hub_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "hub_id", hubId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hub>(response, default(Hub));
                }
                logger.LogInformation($"Exited from GetHubAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hub>(response, await LocalMarshalling.DeserializeAsync<Hub>(response.Content));

            } // using
        }
        /// <summary>
        /// List Hubs
        /// </summary>
        /// <remarks>
        ///Returns a collection of hubs that the user of your app can access.
///
///The returned hubs can be BIM 360 Team hubs, Fusion Team hubs (formerly known as A360 Team hubs), A360 Personal hubs, ACC Docs (Autodesk Docs) accounts, or BIM 360 Docs accounts. Only active hubs are returned.
///
///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
         /// <param name="filterId">
         ///Filter by the `id` of the `ref` target. (optional)
         /// </param>
         /// <param name="filterName">
         ///Filter by the `name` of the `ref` target. (optional)
         /// </param>
         /// <param name="filterExtensionType">
         ///Filter by the extension type.  (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hubs&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hubs>> GetHubsAsync (string xUserId= default(string),List<string> filterId= default(List<string>),string filterName= default(string),List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHubsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter_name", filterName, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hubs>(response, default(Hubs));
                }
                logger.LogInformation($"Exited from GetHubsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hubs>(response, await LocalMarshalling.DeserializeAsync<Hubs>(response.Content));

            } // using
        }
    }
}
