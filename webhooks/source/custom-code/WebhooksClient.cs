using Autodesk.Webhooks.Http;
using Autodesk.Webhooks.Model;
using System.Net.Http;

namespace Autodesk.Webhooks
{
    public class WebhooksClient
    {
        public IHooksApi HooksApi { get; }
        public ITokensApi TokensApi { get; }


        public WebhooksClient(SDKManager.SDKManager sdkManager)
        {

            this.HooksApi = new HooksApi(sdkManager);
            this.TokensApi = new TokensApi(sdkManager);
        }

        #region  HooksApi
        /// <summary>
        /// Add new webhook to receive the notification on a specified event.
        /// </summary>
        /// <remarks>
        /// Add new webhook to receive the notification on a specified event.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="_event">string A system for example data for Data Management</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="hookPayload"> (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateSystemEventHookAsync(string accessToken, Systems system, Events _event, HookPayload hookPayload, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.CreateSystemEventHookAsync(system, _event, region, xAdsRegion, hookPayload, accessToken, throwOnError);
            return response;
        }


        /// <summary>
        /// Add new webhooks to receive the notification on all the events.
        /// </summary>
        /// <remarks>
        /// Add new webhooks to receive the notification on all the events.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="hookPayload"> (optional)</param>
        /// <returns>Task of HookCreationResult</returns>

        public async System.Threading.Tasks.Task<Hook> CreateSystemHookAsync(string accessToken, Systems system, HookPayload hookPayload, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.CreateSystemHookAsync(system, xAdsRegion, region, hookPayload, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Deletes a webhook based on webhook ID
        /// </summary>
        /// <remarks>
        /// Deletes a webhook based on webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="_event">string A system for example data for Data Management</param>/// <param name="hookId">Id of the webhook to retrieve</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSystemEventHookAsync(string accessToken, Systems system, Events _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.DeleteSystemEventHookAsync(system, _event, hookId, xAdsRegion, region, accessToken, throwOnError);
            return response;
        }

        /// <summary>
        /// Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        /// Retrieves a paginated list of webhooks created in the context of a Client or Application. This API accepts 2-legged token of the application only. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="pageState">Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the &#x60;&#x60;next&#x60;&#x60; field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)</param>/// <param name="status">Status of the hooks. Options: &#x60;&#x60;active&#x60;&#x60;, &#x60;&#x60;inactive&#x60;&#x60; (optional)</param>/// <param name="sort">Sort order of the hooks based on last updated time. Options: ‘asc’, ‘desc’. Default is ‘desc’. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>
        /// <returns>Task of HooksResult</returns>

        public async System.Threading.Tasks.Task<Hooks> GetAppHooksAsync(string accessToken, XAdsRegion? xAdsRegion= null, Region? region= null, string pageState = default(string), string status = default(string), string sort = default(string), bool throwOnError = true)
        {
            var response = await this.HooksApi.GetAppHooksAsync(xAdsRegion, pageState, status, sort, region, accessToken, throwOnError);
            return response.Content;
        }


        /// <summary>
        /// Get details of a webhook based on its webhook ID
        /// </summary>
        /// <remarks>
        /// Get details of a webhook based on its webhook ID
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="_event">string A system for example data for Data Management</param>/// <param name="hookId">Id of the webhook to retrieve</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>
        /// <returns>Task of HookDetailsResult</returns>

        public async System.Threading.Tasks.Task<HookDetails> GetHookDetailsAsync(string accessToken, Systems system, Events _event, string hookId, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.GetHookDetailsAsync(system, _event, hookId, xAdsRegion, region, accessToken, throwOnError);
            return response.Content;

        }

        /// <summary>
        /// Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        /// Retrieves a paginated list of all the webhooks. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="pageState">Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the next field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)</param>/// <param name="status">Status of the hooks. Options: ‘active’, ‘inactive’ (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: EMEA, US. Default is US. (optional)</param>
        /// <returns>Task of HooksResult</returns>

        public async System.Threading.Tasks.Task<Hooks> GetHooksAsync(string accessToken, string pageState = default(string), string status = default(string), XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.GetHooksAsync(pageState, status, region, xAdsRegion, accessToken, throwOnError);
            return response.Content;

        }

        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        /// Retrieves a paginated list of all the webhooks for a specified event. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="_event">string A system for example data for Data Management</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="scopeName">Scope name used to create hook. For example : folder (optional)</param>/// <param name="pageState">Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the &#x60;&#x60;next&#x60;&#x60; field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)</param>/// <param name="status">Status of the hooks. Options: &#x60;&#x60;active&#x60;&#x60;, &#x60;&#x60;inactive&#x60;&#x60; (optional)</param>
        /// <returns>Task of HooksResult</returns>

        public async System.Threading.Tasks.Task<Hooks> GetSystemEventHooksAsync(string accessToken, Systems system, Events _event, XAdsRegion? xAdsRegion= null, Region? region= null, string scopeName = default(string), string pageState = default(string), string status = default(string), bool throwOnError = true)
        {
            var response = await this.HooksApi.GetSystemEventHooksAsync(system, _event, xAdsRegion, region, scopeName, pageState, status, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </summary>
        /// <remarks>
        /// Retrieves a paginated list of all the webhooks for a specified system. If the pageState query string is not specified, the first page is returned.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="status">Status of the hooks. Options: &#x60;&#x60;active&#x60;&#x60;, &#x60;&#x60;inactive&#x60;&#x60; (optional)</param>/// <param name="pageState">Base64 encoded string used to return the next page of the list of webhooks. This can be obtained from the &#x60;&#x60;next&#x60;&#x60; field of the previous page. PagingState instances are not portable and implementation is subject to change across versions. Default page size is 200. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>
        /// <returns>Task of HooksResult</returns>

        public async System.Threading.Tasks.Task<Hooks> GetSystemHooksAsync(string accessToken, Systems system, XAdsRegion? xAdsRegion= null, Region? region= null, string status = default(string), string pageState = default(string), bool throwOnError = true)
        {
            var response = await this.HooksApi.GetSystemHooksAsync(system, xAdsRegion, status, pageState, region, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </summary>
        /// <remarks>
        /// Partially update a webhook based on its webhook ID. The only fields that may be updated are: status, filter, hookAttribute, and hookExpiry.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="system">string A system for example data for Data Management</param>/// <param name="_event">string A system for example data for Data Management</param>/// <param name="hookId">Id of the webhook to retrieve</param>/// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="modifyHookPayload"> (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PatchSystemEventHookAsync(string accessToken, Systems system, Events _event, string hookId, ModifyHookPayload modifyHookPayload, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.HooksApi.PatchSystemEventHookAsync(system, _event, hookId, xAdsRegion, region, modifyHookPayload, accessToken, throwOnError);
            return response;
        }
        #endregion HooksApi

        #region  TokensApi

        /// <summary>
        /// Add a new Webhook secret token
        /// </summary>
        /// <remarks>
        /// Add a new Webhook secret token
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="tokenPayload">A secret token that is used to generate a hash signature, which is passed along with notification requests to the callback URL (optional)</param>
        /// <returns>Task of TokenCreationResult</returns>

        public async System.Threading.Tasks.Task<Token> CreateTokenAsync(string accessToken, TokenPayload tokenPayload, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.TokensApi.CreateTokenAsync(xAdsRegion, region, tokenPayload, accessToken, throwOnError);
            return response.Content;

        }
        /// <summary>
        /// Delete a Webhook secret token
        /// </summary>
        /// <remarks>
        /// Delete a Webhook secret token
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTokenAsync(string accessToken, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.TokensApi.DeleteTokenAsync(xAdsRegion, region, accessToken, throwOnError);
            return response;
        }

        /// <summary>
        /// Update an existing Webhook secret token
        /// </summary>
        /// <remarks>
        /// Update an existing Webhook secret token
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xAdsRegion">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;. (optional)</param>/// <param name="region">Specifies the geographical location (region) of the server that the request is executed on. Supported values are: &#x60;&#x60;EMEA&#x60;&#x60;, &#x60;&#x60;US&#x60;&#x60;. Default is &#x60;&#x60;US&#x60;&#x60;.  The &#x60;&#x60;x-ads-region&#x60;&#x60; header also specifies the region. If you specify both, &#x60;&#x60;x-ads-region&#x60;&#x60; has precedence.  (optional)</param>/// <param name="tokenPayload"> (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> PutTokenAsync(string accessToken, TokenPayload tokenPayload, XAdsRegion? xAdsRegion= null, Region? region= null, bool throwOnError = true)
        {
            var response = await this.TokensApi.PutTokenAsync(xAdsRegion, region, tokenPayload, accessToken, throwOnError);
            return response;
        }
        #endregion TokensApi



    }
}