/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined.  You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project.  Below is quick summary of this workflow:  1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
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
using Autodesk.Webhooks.Model;
using Autodesk.Webhooks.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Webhooks.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHooksApi
    {
        /// <summary>
        /// Add new webhook to receive the notification on a specified event.
        /// </summary>
        /// <remarks>
        ///Add new webhook to receive the notification on a specified event.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync (Systems system, Events _event, Region? region= null, XAdsRegion? xAdsRegion= null, HookPayload hookPayload= default(HookPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Add new webhooks to receive the notification on all the events.
        /// </summary>
        /// <remarks>
        ///Add new webhooks to receive the notification on all the events.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hook&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hook>> CreateSystemHookAsync (Systems system, XAdsRegion? xAdsRegion= null, Region? region= null, HookPayload hookPayload= default(HookPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Deletes a webhook based on webhook ID
        /// </summary>
        /// <remarks>
        ///Deletes a webhook based on webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync (Systems system, Events _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
         /// <param name="sort">
         ///Sort order of the hooks based on last updated time. Options: ‘asc’, ‘desc’. Default is ‘desc’. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetAppHooksAsync (XAdsRegion? xAdsRegion= null, string pageState= default(string), string status= default(string), string sort= default(string), Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get details of a webhook based on its webhook ID
        /// </summary>
        /// <remarks>
        ///Get details of a webhook based on its webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;HookDetails&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<HookDetails>> GetHookDetailsAsync (Systems system, Events _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the next field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: ‘active’, ‘inactive’ (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: EMEA, US. Default is US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetHooksAsync (string pageState= default(string), string status= default(string), Region? region= null, XAdsRegion? xAdsRegion= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="scopeName">
         ///Scope name used to create hook. For example : folder (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemEventHooksAsync (Systems system, Events _event, XAdsRegion? xAdsRegion= null, Region? region= null, string scopeName= default(string), string pageState= default(string), string status= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemHooksAsync (Systems system, XAdsRegion? xAdsRegion= null, string status= default(string), string pageState= default(string), Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </summary>
        /// <remarks>
        ///Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="modifyHookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync (Systems system, Events _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null, ModifyHookPayload modifyHookPayload= default(ModifyHookPayload),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HooksApi : IHooksApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HooksApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public HooksApi(SDKManager.SDKManager sdkManager)
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
        /// Add new webhook to receive the notification on a specified event.
        /// </summary>
        /// <remarks>
        ///Add new webhook to receive the notification on a specified event.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync (Systems system,Events _event,Region? region= null,XAdsRegion? xAdsRegion= null,HookPayload hookPayload= default(HookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var eventEnumString = Utils.GetEnumString(_event);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                            { "event", eventEnumString},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(hookPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from CreateSystemEventHookAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Add new webhooks to receive the notification on all the events.
        /// </summary>
        /// <remarks>
        ///Add new webhooks to receive the notification on all the events.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hook&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hook>> CreateSystemHookAsync (Systems system,XAdsRegion? xAdsRegion= null,Region? region= null,HookPayload hookPayload= default(HookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateSystemHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(hookPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("POST");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hook>(response, default(Hook));
                }
                logger.LogInformation($"Exited from CreateSystemHookAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hook>(response, await LocalMarshalling.DeserializeAsync<Hook>(response.Content));

            } // using
        }
        /// <summary>
        /// Deletes a webhook based on webhook ID
        /// </summary>
        /// <remarks>
        ///Deletes a webhook based on webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync (Systems system,Events _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var eventEnumString = Utils.GetEnumString(_event);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                            { "event", eventEnumString},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("DELETE");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from DeleteSystemEventHookAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
         /// <param name="sort">
         ///Sort order of the hooks based on last updated time. Options: ‘asc’, ‘desc’. Default is ‘desc’. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetAppHooksAsync (XAdsRegion? xAdsRegion= null,string pageState= default(string),string status= default(string),string sort= default(string),Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetAppHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("status", status, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/app/hooks",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hooks>(response, default(Hooks));
                }
                logger.LogInformation($"Exited from GetAppHooksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hooks>(response, await LocalMarshalling.DeserializeAsync<Hooks>(response.Content));

            } // using
        }
        /// <summary>
        /// Get details of a webhook based on its webhook ID
        /// </summary>
        /// <remarks>
        ///Get details of a webhook based on its webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;HookDetails&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<HookDetails>> GetHookDetailsAsync (Systems system,Events _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHookDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var eventEnumString = Utils.GetEnumString(_event);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                            { "event", eventEnumString},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<HookDetails>(response, default(HookDetails));
                }
                logger.LogInformation($"Exited from GetHookDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<HookDetails>(response, await LocalMarshalling.DeserializeAsync<HookDetails>(response.Content));

            } // using
        }
        /// <summary>
        /// Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the next field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: ‘active’, ‘inactive’ (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: EMEA, US. Default is US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetHooksAsync (string pageState= default(string),string status= default(string),Region? region= null,XAdsRegion? xAdsRegion= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("status", status, queryParam);
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/hooks",
                        routeParameters: new Dictionary<string, object> {
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hooks>(response, default(Hooks));
                }
                logger.LogInformation($"Exited from GetHooksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hooks>(response, await LocalMarshalling.DeserializeAsync<Hooks>(response.Content));

            } // using
        }
        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="scopeName">
         ///Scope name used to create hook. For example : folder (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemEventHooksAsync (Systems system,Events _event,XAdsRegion? xAdsRegion= null,Region? region= null,string scopeName= default(string),string pageState= default(string),string status= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetSystemEventHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var eventEnumString = Utils.GetEnumString(_event);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                SetQueryParameter("scopeName", scopeName, queryParam);
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("status", status, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                            { "event", eventEnumString},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hooks>(response, default(Hooks));
                }
                logger.LogInformation($"Exited from GetSystemEventHooksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hooks>(response, await LocalMarshalling.DeserializeAsync<Hooks>(response.Content));

            } // using
        }
        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="status">
         ///Status of the hooks. Options: `active`, `inactive` (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the `next` field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemHooksAsync (Systems system,XAdsRegion? xAdsRegion= null,string status= default(string),string pageState= default(string),Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetSystemHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("status", status, queryParam);
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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

                request.Method = new HttpMethod("GET");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Hooks>(response, default(Hooks));
                }
                logger.LogInformation($"Exited from GetSystemHooksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hooks>(response, await LocalMarshalling.DeserializeAsync<Hooks>(response.Content));

            } // using
        }
        /// <summary>
        /// Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </summary>
        /// <remarks>
        ///Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="_event">
         ///string A system for example data for Data Management
         /// </param>
         /// <param name="hookId">
         ///Id of the webhook to retrieve
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server that the request is executed on. Supported values are: `EMEA`, `US`. Default is `US`.
///
///The `x-ads-region` header also specifies the region. If you specify both, `x-ads-region` has precedence. (optional)
         /// </param>
         /// <param name="modifyHookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync (Systems system,Events _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null,ModifyHookPayload modifyHookPayload= default(ModifyHookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var systemEnumString = Utils.GetEnumString(system);
                var eventEnumString = Utils.GetEnumString(_event);
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", systemEnumString},
                            { "event", eventEnumString},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(modifyHookPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:write ");
                // }
                // else
                // {
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }

                request.Method = new HttpMethod("PATCH");

                // make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                      await response.EnsureSuccessStatusCodeAsync();
                    } catch (HttpRequestException ex) {
                      throw new WebhooksApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from PatchSystemEventHookAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
    }
}
