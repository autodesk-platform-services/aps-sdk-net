/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined. You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project. Below is quick summary of this workflow: 1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
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
        /// Create a Webhook for an Event
        /// </summary>
        /// <remarks>
        ///Adds a new webhook to receive notifications of the occurrence of a specified event for the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync (string system, string _event, Region? region= null, XAdsRegion? xAdsRegion= null, HookPayload hookPayload= default(HookPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create Webhooks for All Events
        /// </summary>
        /// <remarks>
        ///Adds a new webhook to receive notifications of all events for the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hook&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hook>> CreateSystemHookAsync (string system, XAdsRegion? xAdsRegion= null, Region? region= null, HookPayload hookPayload= default(HookPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Delete a Webhook
        /// </summary>
        /// <remarks>
        ///Deletes the webhook specified by its ID.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync (string system, string _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List All Webhooks for an App
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks created by the calling application. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
///
///**Note:** This operation requires an access token through a Client Credentials flow (two-legged OAuth). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="sort">
         ///Specifies the sorting order of the list of webhooks by their `lastUpdatedDate` attribute. 
///
///- `asc` - Ascending order.
///- `desc` - (Default) Descending order.  (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetAppHooksAsync (XAdsRegion? xAdsRegion= null, string pageState= default(string), StatusFilter? status= null, Sort? sort= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Webhook Details
        /// </summary>
        /// <remarks>
        ///Retrieves the details of the webhook for the specified event within the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;HookDetails&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<HookDetails>> GetHookDetailsAsync (string system, string _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List All Webhooks
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks available to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetHooksAsync (string pageState= default(string), StatusFilter? status= null, Region? region= null, XAdsRegion? xAdsRegion= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List All Webhooks for an Event
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks for the specified event. The returned list contains a subset of webhooks accessible to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="scopeName">
         ///Filters retrieved webhooks by the scope name used to create hook. For example : `folder`.  If this parameter is not specified, the filter is not applied. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemEventHooksAsync (string system, string _event, XAdsRegion? xAdsRegion= null, Region? region= null, string scopeName= default(string), string pageState= default(string), StatusFilter? status= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List All Webhooks for a System
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks for the specified system. The returned list contains a subset of webhooks accessible to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemHooksAsync (string system, XAdsRegion? xAdsRegion= null, StatusFilter? status= null, string pageState= default(string), Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update a Webhook
        /// </summary>
        /// <remarks>
        ///Updates the webhook specified by the `hook_id` parameter. Currently the only attributes you can update are: 
///
///- filter
///- status
///- hook attribute
///- token
///- auto-reactivate hook flag
///- hook expiry
///- callbackWithEventPaylaod flag 
///
///See the request body documentation for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="modifyHookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync (string system, string _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null, ModifyHookPayload modifyHookPayload= default(ModifyHookPayload),  string accessToken = null, bool throwOnError = true);
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
        /// Create a Webhook for an Event
        /// </summary>
        /// <remarks>
        ///Adds a new webhook to receive notifications of the occurrence of a specified event for the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync (string system,string _event,Region? region= null,XAdsRegion? xAdsRegion= null,HookPayload hookPayload= default(HookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                            { "event", _event},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// Create Webhooks for All Events
        /// </summary>
        /// <remarks>
        ///Adds a new webhook to receive notifications of all events for the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="hookPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hook&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hook>> CreateSystemHookAsync (string system,XAdsRegion? xAdsRegion= null,Region? region= null,HookPayload hookPayload= default(HookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateSystemHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// Delete a Webhook
        /// </summary>
        /// <remarks>
        ///Deletes the webhook specified by its ID.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync (string system,string _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                            { "event", _event},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// List All Webhooks for an App
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks created by the calling application. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
///
///**Note:** This operation requires an access token through a Client Credentials flow (two-legged OAuth). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="sort">
         ///Specifies the sorting order of the list of webhooks by their `lastUpdatedDate` attribute. 
///
///- `asc` - Ascending order.
///- `desc` - (Default) Descending order.  (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetAppHooksAsync (XAdsRegion? xAdsRegion= null,string pageState= default(string),StatusFilter? status= null,Sort? sort= null,Region? region= null, string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// Get Webhook Details
        /// </summary>
        /// <remarks>
        ///Retrieves the details of the webhook for the specified event within the specified system.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;HookDetails&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<HookDetails>> GetHookDetailsAsync (string system,string _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHookDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                            { "event", _event},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// List All Webhooks
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks available to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetHooksAsync (string pageState= default(string),StatusFilter? status= null,Region? region= null,XAdsRegion? xAdsRegion= null, string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// List All Webhooks for an Event
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks for the specified event. The returned list contains a subset of webhooks accessible to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="scopeName">
         ///Filters retrieved webhooks by the scope name used to create hook. For example : `folder`.  If this parameter is not specified, the filter is not applied. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemEventHooksAsync (string system,string _event,XAdsRegion? xAdsRegion= null,Region? region= null,string scopeName= default(string),string pageState= default(string),StatusFilter? status= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetSystemEventHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                SetQueryParameter("scopeName", scopeName, queryParam);
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("status", status, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                            { "event", _event},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// List All Webhooks for a System
        /// </summary>
        /// <remarks>
        ///Retrieves a paginated list of webhooks for the specified system. The returned list contains a subset of webhooks accessible to the provided access token within the specified region. Each page includes up to 200 webhooks.
///
///If the `pageState` query string parameter is not provided, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="status">
         ///Filters retrieved webhooks by their current state. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive but was reactivated. No events have occurred since reactivation.
///
///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
         /// </param>
         /// <param name="pageState">
         ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Hooks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hooks>> GetSystemHooksAsync (string system,XAdsRegion? xAdsRegion= null,StatusFilter? status= null,string pageState= default(string),Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetSystemHooksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("status", status, queryParam);
                SetQueryParameter("pageState", pageState, queryParam);
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/hooks",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
        /// Update a Webhook
        /// </summary>
        /// <remarks>
        ///Updates the webhook specified by the `hook_id` parameter. Currently the only attributes you can update are: 
///
///- filter
///- status
///- hook attribute
///- token
///- auto-reactivate hook flag
///- hook expiry
///- callbackWithEventPaylaod flag 
///
///See the request body documentation for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="system">
         ///The ID of the system the webhook applies to. For example data for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of supported systems and their IDs.
         /// </param>
         /// <param name="_event">
         ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events.
         /// </param>
         /// <param name="hookId">
         ///The ID of the webhook to delete.
         /// </param>
         /// <param name="xAdsRegion">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `region` query string parameter to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="region">
         ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** 
///
///1. Beta features are subject to change. Please avoid using them in production environments.
///2. You can also use the `x-ads-region` header to specify the region. If you specify the `region` query string parameter as well as the `x-ads-region` header, the `x-ads-region` header takes precedence. (optional)
         /// </param>
         /// <param name="modifyHookPayload">
         /// (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync (string system,string _event,string hookId,XAdsRegion? xAdsRegion= null,Region? region= null,ModifyHookPayload modifyHookPayload= default(ModifyHookPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchSystemEventHookAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("region", region, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/webhooks/v1/systems/{system}/events/{event}/hooks/{hook_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "system", system},
                            { "event", _event},
                            { "hook_id", hookId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/WEBHOOKS/C#/2.0.0");
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
