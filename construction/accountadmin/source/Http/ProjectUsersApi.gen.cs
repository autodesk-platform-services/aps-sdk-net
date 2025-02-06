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
using System.Collections;

namespace Autodesk.Construction.AccountAdmin.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectUsersApi
    {
        /// <summary>
        /// Assigns a user to the specified project
        /// </summary>
        /// <remarks>
        ///Assigns a user to the specified project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUserPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUserResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectUserResponse>> AssignProjectUserAsync (string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), ProjectUserPayload projectUserPayload= default(ProjectUserPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get project user
        /// </summary>
        /// <remarks>
        ///Retrieves detailed information about the specified user in a project.
///
///There are two primary reasons to do this:
///
///To verify that a user assigned to the specified project has been activated as a member of the project.
///To check other information about the user, such as their project user ID, roles, and products.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUser&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectUser>> GetProjectUserAsync (string projectId, string userId, string acceptLanguage= default(string), Region? region= null, string userId2= default(string), List<UserFields> fields= default(List<UserFields>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get project users
        /// </summary>
        /// <remarks>
        ///Retrieves information about a filtered subset of users in the specified project.
///
///There are two primary reasons to do this:
///
///To verify that all users assigned to the project have been activated as members of the project.
///To check other information about users, such as their project user ID, roles, and products.
///Note that if you want to retrieve information about users associated with a particular Autodesk account, call the GET users endpoint.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="filterProducts">
         ///A comma-separated list of the products that the returned projects must use. Only projects that use one or more of the listed products are returned. (optional)
         /// </param>
         /// <param name="filterName">
         ///A user name or name pattern to filter users by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterEmail">
         ///A user email address or address pattern that the returned users must have. This can be a partial match based on the value of filterTextMatch that you provide. For example:  filter[email]=sample filterTextMatch=startsWith  Max length: 255 (optional)
         /// </param>
         /// <param name="filterStatus">
         ///A list of statuses that the returned project users must be in. The default values are active and pending. (optional)
         /// </param>
         /// <param name="filterAccessLevels">
         ///A list of user access levels that the returned users must have. (optional)
         /// </param>
         /// <param name="filterCompanyId">
         ///The ID of a company that the returned users must represent. (optional)
         /// </param>
         /// <param name="filterCompanyName">
         ///The name of a company that returned users must be associated with. Can be a partial match based on the value of filterTextMatch that you provide. For example: filter[companyName]=Sample filterTextMatch=startsWith  Max length: 255 (optional)
         /// </param>
         /// <param name="filterAutodeskId">
         ///A list of the Autodesk IDs of users to retrieve. (optional)
         /// </param>
         /// <param name="filterId">
         ///A list of the ACC IDs of users to retrieve. (optional)
         /// </param>
         /// <param name="filterRoleId">
         ///The ID of a user role that the returned users must have. To obtain a role ID for this filter, you can inspect the roleId field in previous responses to this endpoint or to the GET projects/:projectId/users/:userId endpoint.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterRoleIds">
         ///A list of the IDs of user roles that the returned users must have. To obtain a role ID for this filter, you can inspect the roleId field in previous responses to this endpoint or to the GET projects/:projectId/users/:userId endpoint. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned users by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
         /// </param>
         /// <param name="fields">
         ///A list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
         /// <param name="orFilters">
         ///A list of user fields to combine with the SQL OR operator for filtering the returned project users. The OR is automatically incorporated between the fields; any one of them can produce a valid match. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUsers&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectUsers>> GetProjectUsersAsync (string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Products> filterProducts= default(List<Products>), string filterName= default(string), string filterEmail= default(string), List<StatusFilter> filterStatus= default(List<StatusFilter>), List<AccessLevels> filterAccessLevels= default(List<AccessLevels>), string filterCompanyId= default(string), string filterCompanyName= default(string), List<string> filterAutodeskId= default(List<string>), List<string> filterId= default(List<string>), string filterRoleId= default(string), List<string> filterRoleIds= default(List<string>), List<UserSortBy> sort= default(List<UserSortBy>), List<UserFields> fields= default(List<UserFields>), List<OrFilters> orFilters= default(List<OrFilters>), FilterTextMatch? filterTextMatch= null, int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Assigns multiple users to a project
        /// </summary>
        /// <remarks>
        ///Assigns multiple users to a project at once. This endpoint can assign up to 200 users per request.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUsersImportPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUsersImportResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectUsersImportResponse>> ImportProjectUsersAsync (string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), ProjectUsersImportPayload projectUsersImportPayload= default(ProjectUsersImportPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Remove Project User
        /// </summary>
        /// <remarks>
        ///Removes the specified user from a project.
///
///Note that the Authorization header token can be obtained either via a three-legged OAuth flow, or via a two-legged Oauth flow with user impersonation, for which the User-Id header is also required.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> RemoveProjectUserAsync (string projectId, string userId, string acceptLanguage= default(string), Region? region= null, string userId2= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update user in project
        /// </summary>
        /// <remarks>
        ///Updates information about the specified user in a project.
///
///Note that the Authorization header token can be obtained either via a three-legged OAuth flow, or via a two-legged Oauth flow with user impersonation, for which the User-Id header is also required.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUsersUpdatePayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUserResponse&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProjectUserResponse>> UpdateProjectUserAsync (string projectId, string userId, string acceptLanguage= default(string), Region? region= null, string userId2= default(string), ProjectUsersUpdatePayload projectUsersUpdatePayload= default(ProjectUsersUpdatePayload),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProjectUsersApi : IProjectUsersApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUsersApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ProjectUsersApi(SDKManager.SDKManager sdkManager)
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
        /// Assigns a user to the specified project
        /// </summary>
        /// <remarks>
        ///Assigns a user to the specified project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUserPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUserResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectUserResponse>> AssignProjectUserAsync (string projectId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),ProjectUserPayload projectUserPayload= default(ProjectUserPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into AssignProjectUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}/users",
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

                request.Content = Marshalling.Serialize(projectUserPayload); // http body (model) parameter


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
                    return new ApiResponse<ProjectUserResponse>(response, default(ProjectUserResponse));
                }
                logger.LogInformation($"Exited from AssignProjectUserAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectUserResponse>(response, await LocalMarshalling.DeserializeAsync<ProjectUserResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// Get project user
        /// </summary>
        /// <remarks>
        ///Retrieves detailed information about the specified user in a project.
///
///There are two primary reasons to do this:
///
///To verify that a user assigned to the specified project has been activated as a member of the project.
///To check other information about the user, such as their project user ID, roles, and products.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUser&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectUser>> GetProjectUserAsync (string projectId,string userId,string acceptLanguage= default(string),Region? region= null,string userId2= default(string),List<UserFields> fields= default(List<UserFields>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("fields", fields, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}/users/{userId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "userId", userId},
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
                SetHeader("User-Id", userId2, request);

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
                    return new ApiResponse<ProjectUser>(response, default(ProjectUser));
                }
                logger.LogInformation($"Exited from GetProjectUserAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectUser>(response, await LocalMarshalling.DeserializeAsync<ProjectUser>(response.Content));

            } // using
        }
        /// <summary>
        /// Get project users
        /// </summary>
        /// <remarks>
        ///Retrieves information about a filtered subset of users in the specified project.
///
///There are two primary reasons to do this:
///
///To verify that all users assigned to the project have been activated as members of the project.
///To check other information about users, such as their project user ID, roles, and products.
///Note that if you want to retrieve information about users associated with a particular Autodesk account, call the GET users endpoint.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="filterProducts">
         ///A comma-separated list of the products that the returned projects must use. Only projects that use one or more of the listed products are returned. (optional)
         /// </param>
         /// <param name="filterName">
         ///A user name or name pattern to filter users by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterEmail">
         ///A user email address or address pattern that the returned users must have. This can be a partial match based on the value of filterTextMatch that you provide. For example:  filter[email]=sample filterTextMatch=startsWith  Max length: 255 (optional)
         /// </param>
         /// <param name="filterStatus">
         ///A list of statuses that the returned project users must be in. The default values are active and pending. (optional)
         /// </param>
         /// <param name="filterAccessLevels">
         ///A list of user access levels that the returned users must have. (optional)
         /// </param>
         /// <param name="filterCompanyId">
         ///The ID of a company that the returned users must represent. (optional)
         /// </param>
         /// <param name="filterCompanyName">
         ///The name of a company that returned users must be associated with. Can be a partial match based on the value of filterTextMatch that you provide. For example: filter[companyName]=Sample filterTextMatch=startsWith  Max length: 255 (optional)
         /// </param>
         /// <param name="filterAutodeskId">
         ///A list of the Autodesk IDs of users to retrieve. (optional)
         /// </param>
         /// <param name="filterId">
         ///A list of the ACC IDs of users to retrieve. (optional)
         /// </param>
         /// <param name="filterRoleId">
         ///The ID of a user role that the returned users must have. To obtain a role ID for this filter, you can inspect the roleId field in previous responses to this endpoint or to the GET projects/:projectId/users/:userId endpoint.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterRoleIds">
         ///A list of the IDs of user roles that the returned users must have. To obtain a role ID for this filter, you can inspect the roleId field in previous responses to this endpoint or to the GET projects/:projectId/users/:userId endpoint. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned users by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
         /// </param>
         /// <param name="fields">
         ///A list of the project fields to include in the response. Default value: all fields. (optional)
         /// </param>
         /// <param name="orFilters">
         ///A list of user fields to combine with the SQL OR operator for filtering the returned project users. The OR is automatically incorporated between the fields; any one of them can produce a valid match. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUsers&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectUsers>> GetProjectUsersAsync (string projectId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),List<Products> filterProducts= default(List<Products>),string filterName= default(string),string filterEmail= default(string),List<StatusFilter> filterStatus= default(List<StatusFilter>),List<AccessLevels> filterAccessLevels= default(List<AccessLevels>),string filterCompanyId= default(string),string filterCompanyName= default(string),List<string> filterAutodeskId= default(List<string>),List<string> filterId= default(List<string>),string filterRoleId= default(string),List<string> filterRoleIds= default(List<string>),List<UserSortBy> sort= default(List<UserSortBy>),List<UserFields> fields= default(List<UserFields>),List<OrFilters> orFilters= default(List<OrFilters>),FilterTextMatch? filterTextMatch= null,int? limit= default(int?),int? offset= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectUsersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[products]", filterProducts, queryParam);
                SetQueryParameter("filter[name]", filterName, queryParam);
                SetQueryParameter("filter[email]", filterEmail, queryParam);
                SetQueryParameter("filter[status]", filterStatus, queryParam);
                SetQueryParameter("filter[accessLevels]", filterAccessLevels, queryParam);
                SetQueryParameter("filter[companyId]", filterCompanyId, queryParam);
                SetQueryParameter("filter[companyName]", filterCompanyName, queryParam);
                SetQueryParameter("filter[autodeskId]", filterAutodeskId, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[roleId]", filterRoleId, queryParam);
                SetQueryParameter("filter[roleIds]", filterRoleIds, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("fields", fields, queryParam);
                SetQueryParameter("orFilters", orFilters, queryParam);
                SetQueryParameter("filterTextMatch", filterTextMatch, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}/users",
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
                    return new ApiResponse<ProjectUsers>(response, default(ProjectUsers));
                }
                logger.LogInformation($"Exited from GetProjectUsersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectUsers>(response, await LocalMarshalling.DeserializeAsync<ProjectUsers>(response.Content));

            } // using
        }
        /// <summary>
        /// Assigns multiple users to a project
        /// </summary>
        /// <remarks>
        ///Assigns multiple users to a project at once. This endpoint can assign up to 200 users per request.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUsersImportPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUsersImportResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectUsersImportResponse>> ImportProjectUsersAsync (string projectId,string acceptLanguage= default(string),Region? region= null,string userId= default(string),ProjectUsersImportPayload projectUsersImportPayload= default(ProjectUsersImportPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into ImportProjectUsersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v2/projects/{projectId}/users:import",
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

                request.Content = Marshalling.Serialize(projectUsersImportPayload); // http body (model) parameter


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
                    return new ApiResponse<ProjectUsersImportResponse>(response, default(ProjectUsersImportResponse));
                }
                logger.LogInformation($"Exited from ImportProjectUsersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectUsersImportResponse>(response, await LocalMarshalling.DeserializeAsync<ProjectUsersImportResponse>(response.Content));

            } // using
        }
        /// <summary>
        /// Remove Project User
        /// </summary>
        /// <remarks>
        ///Removes the specified user from a project.
///
///Note that the Authorization header token can be obtained either via a three-legged OAuth flow, or via a two-legged Oauth flow with user impersonation, for which the User-Id header is also required.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> RemoveProjectUserAsync (string projectId,string userId,string acceptLanguage= default(string),Region? region= null,string userId2= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into RemoveProjectUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}/users/{userId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "userId", userId},
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
                SetHeader("User-Id", userId2, request);

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

                request.Method = new HttpMethod("DELETE");

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
                    return response;
                }
                logger.LogInformation($"Exited from RemoveProjectUserAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Update user in project
        /// </summary>
        /// <remarks>
        ///Updates information about the specified user in a project.
///
///Note that the Authorization header token can be obtained either via a three-legged OAuth flow, or via a two-legged Oauth flow with user impersonation, for which the User-Id header is also required.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="projectId">
         ///The ID of the project. This corresponds to project ID in the Data Management API. To convert a project ID in the Data Management API into a project ID in the ACC API you need to remove the “b.” prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="acceptLanguage">
         ///This header is not currently supported in the Account Admin API. (optional)
         /// </param>
         /// <param name="region">
         ///The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
         /// </param>
         /// <param name="userId2">
         ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
         /// </param>
         /// <param name="projectUsersUpdatePayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProjectUserResponse&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProjectUserResponse>> UpdateProjectUserAsync (string projectId,string userId,string acceptLanguage= default(string),Region? region= null,string userId2= default(string),ProjectUsersUpdatePayload projectUsersUpdatePayload= default(ProjectUsersUpdatePayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into UpdateProjectUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/projects/{projectId}/users/{userId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "userId", userId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(projectUsersUpdatePayload); // http body (model) parameter


                SetHeader("Accept-Language", acceptLanguage, request);
                SetHeader("Region", region, request);
                SetHeader("User-Id", userId2, request);

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
                    return new ApiResponse<ProjectUserResponse>(response, default(ProjectUserResponse));
                }
                logger.LogInformation($"Exited from UpdateProjectUserAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProjectUserResponse>(response, await LocalMarshalling.DeserializeAsync<ProjectUserResponse>(response.Content));

            } // using
        }
    }
}
