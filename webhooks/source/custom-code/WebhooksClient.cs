using Autodesk.Webhooks.Http;
using Autodesk.Webhooks.Model;
using System.Net.Http;
using Autodesk.SDKManager;
using System;

namespace Autodesk.Webhooks
{
    /// <summary>
    /// Client for managing webhooks.
    /// </summary>
    public class WebhooksClient : BaseClient
    {
        /// <summary>
        /// Gets the Hooks API instance.
        /// </summary>
        public IHooksApi HooksApi { get; }
        /// <summary>
        /// Gets the Tokens API instance.
        /// </summary>
        public ITokensApi TokensApi { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="WebhooksClient"/> class.
        /// </summary>
        /// <param name="sdkManager">The SDK manager instance.</param>
        /// <param name="authenticationProvider">The authentication provider instance.</param>
        public WebhooksClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default) : base(authenticationProvider)
        {
            if (sdkManager == null)
            {
                sdkManager = SdkManagerBuilder.Create().Build();
            }
            this.HooksApi = new HooksApi(sdkManager);
            this.TokensApi = new TokensApi(sdkManager);
        }

        #region  HooksApi
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="hookPayload">The payload for the webhook.</param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync(string system, string _event, HookPayload hookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.CreateSystemEventHookAsync(system, _event, region, null, hookPayload, accessToken, throwOnError);
            return response;
        }

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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="hookPayload">The payload for the webhook.</param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>

        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync(Systems system, Events _event, HookPayload hookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var eventString = Utils.GetEnumString(_event);
            var response = await this.HooksApi.CreateSystemEventHookAsync(systemString, eventString, region, null, hookPayload, accessToken, throwOnError);
            return response;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="hookPayload">The payload for the webhook.</param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hook</returns>

        public async System.Threading.Tasks.Task<Hook> CreateSystemHookAsync(string system, HookPayload hookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.CreateSystemHookAsync(system, null, region, hookPayload, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="hookPayload">The payload for the webhook.</param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hook</returns>

        public async System.Threading.Tasks.Task<Hook> CreateSystemHookAsync(Systems system, HookPayload hookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var response = await this.HooksApi.CreateSystemHookAsync(systemString, null, region, hookPayload, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync(string system, string _event, string hookId, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.DeleteSystemEventHookAsync(system, _event, hookId, null, region, accessToken, throwOnError);
            return response;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync(Systems system, Events _event, string hookId, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var eventString = Utils.GetEnumString(_event);
            var response = await this.HooksApi.DeleteSystemEventHookAsync(systemString, eventString, hookId, null, region, accessToken, throwOnError);
            return response;
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
        /// <param name="pageState">
        ///Base64 encoded string to fetch the next page of the list of webhooks. If you do not provide this parameter, the first page of results is returned. Use the `next` value from the previous response to fetch subsequent pages. (optional)
        /// </param>
        /// <param name="status">
        ///Filters retrieved webhooks by their current state. Possible values are 
        ///
        ///- `active` - Successfully delivered most recent event notifications. 
        ///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="sort">
        ///Specifies the sorting order of the list of webhooks by their `lastUpdatedDate` attribute. 
        ///
        ///- `asc` - Ascending order.
        ///- `desc` - (Default) Descending order.  (optional)
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hooks</returns>

        public async System.Threading.Tasks.Task<Hooks> GetAppHooksAsync(Region region = default, string pageState = default(string), StatusFilter? status = null, Sort? sort = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.GetAppHooksAsync(null, pageState, status, sort, region, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HookDetails</returns>

        public async System.Threading.Tasks.Task<HookDetails> GetHookDetailsAsync(string system, string _event, string hookId, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.GetHookDetailsAsync(system, _event, hookId, null, region, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HookDetails</returns>
        public async System.Threading.Tasks.Task<HookDetails> GetHookDetailsAsync(Systems system, Events _event, string hookId, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var eventString = Utils.GetEnumString(_event);
            var response = await this.HooksApi.GetHookDetailsAsync(systemString, eventString, hookId, null, region, accessToken, throwOnError);
            return response.Content;
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hooks</returns>

        public async System.Threading.Tasks.Task<Hooks> GetHooksAsync(string pageState = default(string), StatusFilter? status = null, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.GetHooksAsync(pageState, status, region, null, accessToken, throwOnError);
            return response.Content;

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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
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
        ///
        ///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>

        /// <returns>Task of Hooks</returns>

        public async System.Threading.Tasks.Task<Hooks> GetSystemEventHooksAsync(string system, string _event, Region region = default, string scopeName = default(string), string pageState = default(string), StatusFilter? status = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.GetSystemEventHooksAsync(system, _event, null, region, scopeName, pageState, status, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
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
        ///
        ///If this parameter is not specified, the filter is not applied. See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the state of a webhook changes. (optional)
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hooks</returns>
        public async System.Threading.Tasks.Task<Hooks> GetSystemEventHooksAsync(Systems system, Events _event, Region region = default, string scopeName = default(string), string pageState = default(string), StatusFilter? status = null, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var eventString = Utils.GetEnumString(_event);
            var response = await this.HooksApi.GetSystemEventHooksAsync(systemString, eventString, null, region, scopeName, pageState, status, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="status">
        ///Filters retrieved webhooks by their current state. Possible values are 
        ///
        ///- `active` - Successfully delivered most recent event notifications. 
        ///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hooks</returns>

        public async System.Threading.Tasks.Task<Hooks> GetSystemHooksAsync(string system, Region region = default, StatusFilter? status = null, string pageState = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.GetSystemHooksAsync(system, null, status, pageState, region, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="status">
        ///Filters retrieved webhooks by their current state. Possible values are 
        ///
        ///- `active` - Successfully delivered most recent event notifications. 
        ///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Hooks</returns>
        public async System.Threading.Tasks.Task<Hooks> GetSystemHooksAsync(Systems system, Region region = default, StatusFilter? status = null, string pageState = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var response = await this.HooksApi.GetSystemHooksAsync(systemString, null, status, pageState, region, accessToken, throwOnError);
            return response.Content;
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
        /// <param name="modifyHookPayload">
        ///The payload containing the modifications to be applied to the webhook.
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>   
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync(string system, string _event, string hookId, ModifyHookPayload modifyHookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HooksApi.PatchSystemEventHookAsync(system, _event, hookId, null, region, modifyHookPayload, accessToken, throwOnError);
            return response;
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
        /// <param name="modifyHookPayload">
        ///The payload containing the modifications to be applied to the webhook.
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
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>   
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync(Systems system, Events _event, string hookId, ModifyHookPayload modifyHookPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var systemString = Utils.GetEnumString(system);
            var eventString = Utils.GetEnumString(_event);
            var response = await this.HooksApi.PatchSystemEventHookAsync(systemString, eventString, hookId, null, region, modifyHookPayload, accessToken, throwOnError);
            return response;
        }
        #endregion HooksApi

        #region  TokensApi

        /// <summary>
        /// Create Secret Token
        /// </summary>
        /// <remarks>
        ///Sets a secret token to verify the authenticity of webhook payloads. 
        ///
        ///When a webhook event occurs, the service calculates a hash signature using the token and includes it in the event notification. The receiving application listening at the callback URL can verify the payload's integrity by comparing the calculated signature to the one received.
        ///
        ///The webhooks affected by this operation are determined by the type of access token you use.
        ///
        ///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
        ///- Three-legged Access Token: Sets the secret token for all webhooks owned by the calling user
        ///
        ///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
        ///
        ///
        ///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="tokenPayload">The payload containing the token information.</param>
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>
        /// <returns>Task of Token</returns>
        public async System.Threading.Tasks.Task<Token> CreateTokenAsync(TokenPayload tokenPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.TokensApi.CreateTokenAsync(null, region, tokenPayload, accessToken, throwOnError);
            return response.Content;

        }


        /// <summary>
        /// Delete Secret Token
        /// </summary>
        /// <remarks>
        ///Removes an existing secret token from the webhooks impacted by this operation. 
        ///
        ///The webhooks affected by this operation are determined by the type of access token you use.
        ///
        ///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
        ///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
        ///
        ///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
        ///
        ///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>       
        /// <returns>Task of HttpResponseMessage</returns>
        /// 
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTokenAsync(Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.TokensApi.DeleteTokenAsync(null, region, accessToken, throwOnError);
            return response;
        }

        /// <summary>
        /// Update Secret Token
        /// </summary>
        /// <remarks>
        ///Replaces an existing secret token with a new one. 
        ///
        ///Note that there can be a delay of up to 10 minutes while the change takes effect. We recommend that your callback accept both secret token values for a period of time to allow all requests to go through.
        ///
        ///The webhooks affected by this operation are determined by the type of access token you use.
        ///
        ///- Two-legged Access Token: Sets the secret token for all webhooks owned by calling the app.
        ///- Three-legged Access Token: Sets the secrety token for all webhooks owned by the calling user
        ///
        ///**Note:** Use the [Update Webhook operation](/en/docs/webhooks/v1/reference/http/webhooks/systems-system-events-event-hooks-hook_id-PATCH/) to set a token for a specific webhook.
        ///
        ///
        ///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="tokenPayload">The payload containing the token information.</param>
        /// <param name="region">
        ///Specifies the geographical location (region) of the server the request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make request to your callback URL. Possible values:
        ///
        ///- `US` - (Default) Data center dedicated to serve the United States region.
        ///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
        ///- `AUS` - (Beta) Data center dedicated to serve the Australia region.
        ///
        ///**Note:** 
        ///
        /// Beta features are subject to change. Please avoid using them in production environments.
        /// </param>
        /// <param name="accessToken">An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync().(optional)</param>
        /// <param name="throwOnError">Specifies whether to throw an exception on error. (optional)</param>       
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PutTokenAsync(TokenPayload tokenPayload, Region region = default, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.TokensApi.PutTokenAsync(null, region, tokenPayload, accessToken, throwOnError);
            return response;
        }
        #endregion TokensApi



    }
}