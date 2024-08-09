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
using System.Collections;
using System.IO;

namespace Autodesk.Construction.AccountAdmin.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsApi
    {
        /// <summary>
        /// Create new Project
        /// </summary>
        /// <remarks>
        ///Creates a new project in the specified account. You can create the project directly, or clone the project from a project template.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Project&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Project>> CreateProjectAsync (string accountId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), ProjectPayload projectPayload= default(ProjectPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create or update a project’s image
        /// </summary>
        /// <remarks>
        ///Create or update a project’s image.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The account ID of the project. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="accountId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the BIM 360 API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="body">
         ///The file to be uploaded as HTTP multipart (chunk) data. Supported MIME types are image/png, image/jpeg, image/jpg, image/bmp, and image/gif.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectPatchResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectPatchResponse>> CreateProjectImageAsync (string projectId, string accountId, System.IO.Stream body, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get a project by ID
        /// </summary>
        /// <remarks>
        ///Retrieves a project specified by project ID.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Project&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Project>> GetProjectAsync (string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Fields> fields= default(List<Fields>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Project in account
        /// </summary>
        /// <remarks>
        ///Retrieves a list of the projects in the specified account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
         /// <param name="filterClassification">
         ///A list of the classifications of projects to include in the response. Possible values: production, template, component, sample. (optional)
         /// </param>
         /// <param name="filterPlatform">
         ///Filter resource by platform. Possible values: acc and bim360. (optional)
         /// </param>
         /// <param name="filterProducts">
         ///A comma-separated list of the products that the returned projects must use. Only projects that use one or more of the listed products are returned. (optional)
         /// </param>
         /// <param name="filterName">
         ///A project name or name pattern to filter projects by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterType">
         ///A list of project types to filter projects by. To exclude a project type from the response, prefix it with - (a hyphen); for example, -Bridge excludes bridge projects. (optional)
         /// </param>
         /// <param name="filterStatus">
         ///A list of the statuses of projects to include in the response. Possible values:  active pending archived suspended (optional)
         /// </param>
         /// <param name="filterBusinessUnitId">
         ///The ID of the business unit that returned projects must be associated with. (optional)
         /// </param>
         /// <param name="filterJobNumber">
         ///The user-defined identifier for a project to be returned. This ID was defined when the project was created. This filter accepts a partial match based on the value of filterTextMatch that you provide. (optional)
         /// </param>
         /// <param name="filterUpdatedAt">
         ///A range of dates during which the desired projects were updated. The range must be specified with dates in ISO 8601 format with time required. Separate multiple values with commas. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Projects&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Projects>> GetProjectsAsync (string accountId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Fields> fields= default(List<Fields>), List<Classification> filterClassification= default(List<Classification>), List<Platform> filterPlatform= default(List<Platform>), List<Products> filterProducts= default(List<Products>), string filterName= default(string), List<string> filterType= default(List<string>), List<Status> filterStatus= default(List<Status>), string filterBusinessUnitId= default(string), string filterJobNumber= default(string), string filterUpdatedAt= default(string), FilterTextMatch? filterTextMatch= null, List<SortBy> sort= default(List<SortBy>), int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProjectsApi : IProjectsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ProjectsApi(SDKManager.SDKManager sdkManager)
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
            else if (value is IList)
            {
                if (value is List<string>)
                {
                    value = String.Join(",",(List<string>)value);
                     dictionary.Add(name, value);
                }
                else 
                {
                    List<string>newlist = new List<string>();
                    foreach ( var x in (IList)value)
                    {
                            var type = x.GetType();
                            var memberInfos = type.GetMember(x.ToString());
                            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                            newlist.Add(((EnumMemberAttribute)valueAttributes[0]).Value);                            
                    }
                    string joinedString = String.Join(",", newlist);
                    dictionary.Add(name, joinedString);
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
        /// Create new Project
        /// </summary>
        /// <remarks>
        ///Creates a new project in the specified account. You can create the project directly, or clone the project from a project template.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Project&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Project>> CreateProjectAsync (string accountId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),ProjectPayload projectPayload= default(ProjectPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateProjectAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/accounts/{accountId}/projects",
                        routeParameters: new Dictionary<string, object> {
                            { "accountId", accountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(projectPayload); // http body (model) parameter


                SetHeader("Accept-Language", acceptLanguage, request);
                SetHeader("Region", region, request);
                SetHeader("User-Id", userId, request);

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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Project>(response, default(Project));
                }
                logger.LogInformation($"Exited from CreateProjectAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Project>(response, await LocalMarshalling.DeserializeAsync<Project>(response.Content));

            } // using
        }
        /// <summary>
        /// Create or update a project’s image
        /// </summary>
        /// <remarks>
        ///Create or update a project’s image.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The account ID of the project. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="accountId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the BIM 360 API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="body">
         ///The file to be uploaded as HTTP multipart (chunk) data. Supported MIME types are image/png, image/jpeg, image/jpg, image/bmp, and image/gif.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectPatchResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectPatchResponse>> CreateProjectImageAsync (string projectId,string accountId,System.IO.Stream body,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateProjectImageAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/projects/{project_id}/image",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ProjectPatchResponse>(response, default(ProjectPatchResponse));
                }
                logger.LogInformation($"Exited from CreateProjectImageAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectPatchResponse>(response, await LocalMarshalling.DeserializeAsync<ProjectPatchResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// Get a project by ID
        /// </summary>
        /// <remarks>
        ///Retrieves a project specified by project ID.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Project&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Project>> GetProjectAsync (string projectId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),List<Fields> fields= default(List<Fields>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("fields", fields, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Accept-Language", acceptLanguage, request);
                SetHeader("Region", region, request);
                SetHeader("User-Id", userId, request);

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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Project>(response, default(Project));
                }
                logger.LogInformation($"Exited from GetProjectAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Project>(response, await LocalMarshalling.DeserializeAsync<Project>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Project in account
        /// </summary>
        /// <remarks>
        ///Retrieves a list of the projects in the specified account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
         /// <param name="filterClassification">
         ///A list of the classifications of projects to include in the response. Possible values: production, template, component, sample. (optional)
         /// </param>
         /// <param name="filterPlatform">
         ///Filter resource by platform. Possible values: acc and bim360. (optional)
         /// </param>
         /// <param name="filterProducts">
         ///A comma-separated list of the products that the returned projects must use. Only projects that use one or more of the listed products are returned. (optional)
         /// </param>
         /// <param name="filterName">
         ///A project name or name pattern to filter projects by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterType">
         ///A list of project types to filter projects by. To exclude a project type from the response, prefix it with - (a hyphen); for example, -Bridge excludes bridge projects. (optional)
         /// </param>
         /// <param name="filterStatus">
         ///A list of the statuses of projects to include in the response. Possible values:  active pending archived suspended (optional)
         /// </param>
         /// <param name="filterBusinessUnitId">
         ///The ID of the business unit that returned projects must be associated with. (optional)
         /// </param>
         /// <param name="filterJobNumber">
         ///The user-defined identifier for a project to be returned. This ID was defined when the project was created. This filter accepts a partial match based on the value of filterTextMatch that you provide. (optional)
         /// </param>
         /// <param name="filterUpdatedAt">
         ///A range of dates during which the desired projects were updated. The range must be specified with dates in ISO 8601 format with time required. Separate multiple values with commas. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Projects&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Projects>> GetProjectsAsync (string accountId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),List<Fields> fields= default(List<Fields>),List<Classification> filterClassification= default(List<Classification>),List<Platform> filterPlatform= default(List<Platform>),List<Products> filterProducts= default(List<Products>),string filterName= default(string),List<string> filterType= default(List<string>),List<Status> filterStatus= default(List<Status>),string filterBusinessUnitId= default(string),string filterJobNumber= default(string),string filterUpdatedAt= default(string),FilterTextMatch? filterTextMatch= null,List<SortBy> sort= default(List<SortBy>),int? limit= default(int?),int? offset= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("fields", fields, queryParam);
                SetQueryParameter("filter[classification]", filterClassification, queryParam);
                SetQueryParameter("filter[platform]", filterPlatform, queryParam);
                SetQueryParameter("filter[products]", filterProducts, queryParam);
                SetQueryParameter("filter[name]", filterName, queryParam);
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[status]", filterStatus, queryParam);
                SetQueryParameter("filter[businessUnitId]", filterBusinessUnitId, queryParam);
                SetQueryParameter("filter[jobNumber]", filterJobNumber, queryParam);
                SetQueryParameter("filter[updatedAt]", filterUpdatedAt, queryParam);
                SetQueryParameter("filterTextMatch", filterTextMatch, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/accounts/{accountId}/projects",
                        routeParameters: new Dictionary<string, object> {
                            { "accountId", accountId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("Accept-Language", acceptLanguage, request);
                SetHeader("Region", region, request);
                SetHeader("User-Id", userId, request);

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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Projects>(response, default(Projects));
                }
                logger.LogInformation($"Exited from GetProjectsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Projects>(response, await LocalMarshalling.DeserializeAsync<Projects>(response.Content));

            } // using
        }
    }
}
