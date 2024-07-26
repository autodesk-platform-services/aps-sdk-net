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
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Autodesk.Construction.AccountAdmin.Model;
using Autodesk.Construction.AccountAdmin.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;
using System.IO;

namespace Autodesk.Construction.AccountAdmin.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICompaniesApi
    {
        /// <summary>
        /// Create a new partner company
        /// </summary>
        /// <remarks>
        ///Create a new partner company.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Company>> CreateCompanyAsync (string accountId, Region? region= null, CompanyPayload companyPayload= default(CompanyPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get all companies in an account
        /// </summary>
        /// <remarks>
        ///Query all the partner companies in a specific BIM 360 account.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order  Prepending a field with - sorts in descending order Invalid fields and whitespaces will be ignored (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response  id will always be returned Invalid fields will be ignored (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;Company&gt;&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<List<Company>>> GetCompaniesAsync (string accountId, Region? region= null, decimal? limit= default(decimal?), decimal? offset= default(decimal?), string sort= default(string), string field= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get details of a company
        /// </summary>
        /// <remarks>
        ///Query the details of a specific partner company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Company>> GetCompanyAsync (string companyId, string accountId, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get all companies in a project
        /// </summary>
        /// <remarks>
        ///Query all the partner companies in a specific BIM 360 project.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="projectId">
         ///The ID of the project. 
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;CompanyResponse&gt;&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<List<CompanyResponse>>> GetProjectCompaniesAsync (string accountId, string projectId, Region? region= null, int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Bulk import partner companies
        /// </summary>
        /// <remarks>
        ///Bulk import partner companies to the company directory in a specific BIM 360 account. (50 companies maximum can be included in each call.)
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;CompanyImportResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<CompanyImportResponse>> ImportCompaniesAsync (string accountId, Region? region= null, List<CompanyPayload> companyPayload= default(List<CompanyPayload>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update the properties of company
        /// </summary>
        /// <remarks>
        ///Update the properties of only the specified attributes of a specific partner company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPatchPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Company>> PatchCompanyDetailsAsync (string companyId, string accountId, Region? region= null, CompanyPatchPayload companyPatchPayload= default(CompanyPatchPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create or update a company’s image
        /// </summary>
        /// <remarks>
        ///Create or update a specific partner company’s image.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="body">
         ///The file to be uploaded as HTTP multipart (chunk) data. Supported MIME types are image/png, image/jpeg, image/jpg, image/bmp, and image/gif.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Company>> PatchCompanyImageAsync (string companyId, string accountId, System.IO.Stream body, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Search companies in account by name
        /// </summary>
        /// <remarks>
        ///Search partner companies in a specific BIM 360 account by name.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="name">
         ///Company name to match Max length: 255 (optional)
         /// </param>
         /// <param name="trade">
         ///Company trade to match Max length: 255 (optional)
         /// </param>
         /// <param name="_operator">
         ///Boolean operator to use: OR (default) or AND (optional)
         /// </param>
         /// <param name="partial">
         ///If true (default), perform a fuzzy match (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;Company&gt;&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<List<Company>>> SearchCompaniesAsync (string accountId, Region? region= null, string name= default(string), string trade= default(string), string _operator= default(string), bool? partial= default(bool?), int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CompaniesApi : ICompaniesApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompaniesApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public CompaniesApi(SDKManager.SDKManager sdkManager)
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
        /// Create a new partner company
        /// </summary>
        /// <remarks>
        ///Create a new partner company.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Company>> CreateCompanyAsync (string accountId,Region? region= null,CompanyPayload companyPayload= default(CompanyPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateCompanyAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies",
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

                request.Content = Marshalling.Serialize(companyPayload); // http body (model) parameter


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

                request.Method = new HttpMethod("POST");

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
                    return new ApiResponse<Company>(response, default(Company));
                }
                logger.LogInformation($"Exited from CreateCompanyAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Company>(response, await LocalMarshalling.DeserializeAsync<Company>(response.Content));

            } // using
        }
        /// <summary>
        /// Get all companies in an account
        /// </summary>
        /// <remarks>
        ///Query all the partner companies in a specific BIM 360 account.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order  Prepending a field with - sorts in descending order Invalid fields and whitespaces will be ignored (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response  id will always be returned Invalid fields will be ignored (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;Company&gt;&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<List<Company>>> GetCompaniesAsync (string accountId,Region? region= null,decimal? limit= default(decimal?),decimal? offset= default(decimal?),string sort= default(string),string field= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetCompaniesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("field", field, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies",
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
                    return new ApiResponse<List<Company>>(response, default(List<Company>));
                }
                logger.LogInformation($"Exited from GetCompaniesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<List<Company>>(response, await LocalMarshalling.DeserializeAsync<List<Company>>(response.Content));

            } // using
        }
        /// <summary>
        /// Get details of a company
        /// </summary>
        /// <remarks>
        ///Query the details of a specific partner company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Company>> GetCompanyAsync (string companyId,string accountId,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetCompanyAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies/{company_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "company_id", companyId},
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
                    return new ApiResponse<Company>(response, default(Company));
                }
                logger.LogInformation($"Exited from GetCompanyAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Company>(response, await LocalMarshalling.DeserializeAsync<Company>(response.Content));

            } // using
        }
        /// <summary>
        /// Get all companies in a project
        /// </summary>
        /// <remarks>
        ///Query all the partner companies in a specific BIM 360 project.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="projectId">
         ///The ID of the project. 
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;CompanyResponse&gt;&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<List<CompanyResponse>>> GetProjectCompaniesAsync (string accountId,string projectId,Region? region= null,int? limit= default(int?),int? offset= default(int?),string sort= default(string),string field= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectCompaniesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("field", field, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/projects/{project_id}/companies",
                        routeParameters: new Dictionary<string, object> {
                            { "account_id", accountId},
                            { "project_id", projectId},
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
                    return new ApiResponse<List<CompanyResponse>>(response, default(List<CompanyResponse>));
                }
                logger.LogInformation($"Exited from GetProjectCompaniesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<List<CompanyResponse>>(response, await LocalMarshalling.DeserializeAsync<List<CompanyResponse>>(response.Content));

            } // using
        }
        /// <summary>
        /// Bulk import partner companies
        /// </summary>
        /// <remarks>
        ///Bulk import partner companies to the company directory in a specific BIM 360 account. (50 companies maximum can be included in each call.)
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;CompanyImportResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<CompanyImportResponse>> ImportCompaniesAsync (string accountId,Region? region= null,List<CompanyPayload> companyPayload= default(List<CompanyPayload>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into ImportCompaniesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies/import",
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

                request.Content = Marshalling.Serialize(companyPayload); // http body (model) parameter


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

                request.Method = new HttpMethod("POST");

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
                    return new ApiResponse<CompanyImportResponse>(response, default(CompanyImportResponse));
                }
                logger.LogInformation($"Exited from ImportCompaniesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<CompanyImportResponse>(response, await LocalMarshalling.DeserializeAsync<CompanyImportResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// Update the properties of company
        /// </summary>
        /// <remarks>
        ///Update the properties of only the specified attributes of a specific partner company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="companyPatchPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Company>> PatchCompanyDetailsAsync (string companyId,string accountId,Region? region= null,CompanyPatchPayload companyPatchPayload= default(CompanyPatchPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchCompanyDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies/{company_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "company_id", companyId},
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

                request.Content = Marshalling.Serialize(companyPatchPayload); // http body (model) parameter


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

                request.Method = new HttpMethod("PATCH");

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
                    return new ApiResponse<Company>(response, default(Company));
                }
                logger.LogInformation($"Exited from PatchCompanyDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Company>(response, await LocalMarshalling.DeserializeAsync<Company>(response.Content));

            } // using
        }
        /// <summary>
        /// Create or update a company’s image
        /// </summary>
        /// <remarks>
        ///Create or update a specific partner company’s image.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="companyId">
         ///Company ID
         /// </param>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="body">
         ///The file to be uploaded as HTTP multipart (chunk) data. Supported MIME types are image/png, image/jpeg, image/jpg, image/bmp, and image/gif.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Company&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Company>> PatchCompanyImageAsync (string companyId,string accountId,System.IO.Stream body,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchCompanyImageAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies/{company_id}/image",
                        routeParameters: new Dictionary<string, object> {
                            { "company_id", companyId},
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


                var formdata = new MultipartFormDataContent();

                var fileStreamContent = new StreamContent(body);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                formdata.Add(fileStreamContent, "chunk", Path.GetFileName((body as FileStream).Name));

                request.Content = formdata;

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

                request.Method = new HttpMethod("PATCH");

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
                    return new ApiResponse<Company>(response, default(Company));
                }
                logger.LogInformation($"Exited from PatchCompanyImageAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Company>(response, await LocalMarshalling.DeserializeAsync<Company>(response.Content));

            } // using
        }
        /// <summary>
        /// Search companies in account by name
        /// </summary>
        /// <remarks>
        ///Search partner companies in a specific BIM 360 account by name.
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the company.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
         /// <param name="name">
         ///Company name to match Max length: 255 (optional)
         /// </param>
         /// <param name="trade">
         ///Company trade to match Max length: 255 (optional)
         /// </param>
         /// <param name="_operator">
         ///Boolean operator to use: OR (default) or AND (optional)
         /// </param>
         /// <param name="partial">
         ///If true (default), perform a fuzzy match (optional)
         /// </param>
         /// <param name="limit">
         ///Response array’s size Default value: 10 Max limit: 100 (optional)
         /// </param>
         /// <param name="offset">
         ///Offset of response array Default value: 0 (optional)
         /// </param>
         /// <param name="sort">
         ///Comma-separated fields to sort by in ascending order (optional)
         /// </param>
         /// <param name="field">
         ///Comma-separated fields to include in response (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;List&lt;Company&gt;&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<List<Company>>> SearchCompaniesAsync (string accountId,Region? region= null,string name= default(string),string trade= default(string),string _operator= default(string),bool? partial= default(bool?),int? limit= default(int?),int? offset= default(int?),string sort= default(string),string field= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into SearchCompaniesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("name", name, queryParam);
                SetQueryParameter("trade", trade, queryParam);
                SetQueryParameter("operator", _operator, queryParam);
                SetQueryParameter("partial", partial, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("field", field, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/companies/search",
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
                    return new ApiResponse<List<Company>>(response, default(List<Company>));
                }
                logger.LogInformation($"Exited from SearchCompaniesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<List<Company>>(response, await LocalMarshalling.DeserializeAsync<List<Company>>(response.Content));

            } // using
        }
    }
}
