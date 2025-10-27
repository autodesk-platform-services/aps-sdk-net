/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    public interface IAccountUsersApi
    {
        /// <summary>
        /// Create User
        /// </summary>
        /// <remarks>
        ///Create a new user in the BIM 360 member directory.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<User>> CreateUserAsync (string accountId, Region? region= null, UserPayload userPayload= default(UserPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get the details of a user
        /// </summary>
        /// <remarks>
        ///Query the details of a specific user.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the user.
         /// </param>
         /// <param name="userId">
         ///User ID
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<User>> GetUserAsync (string accountId, string userId, Region? region= null,  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get user products
        /// </summary>
        /// <remarks>
        ///Returns a list of ACC products the user is associated with in their assigned projects.
///
///Only account administrators can call this endpoint.
///
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. To find the ID call GET users. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterProjectId">
         ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
         /// </param>
         /// <param name="filterKey">
         ///Filters the list of products by product key — a machine-readable identifier for an ACC product (such as docs, build, or cost). You can specify one or more keys to return only those products the user is associated with.  Example: filter[key]=docs,build  Possible values: accountAdministration, autoSpecs, build, buildingConnected, capitalPlanning, cloudWorksharing, cost, designCollaboration, docs, financials, insight, modelCoordination, projectAdministration, takeoff, and workshopxr. (optional)
         /// </param>
         /// <param name="fields">
         ///List of fields to return in the response. Defaults to all fields. Possible values: projectIds, name and icon. (optional)
         /// </param>
         /// <param name="sort">
         ///The list of fields to sort by. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.  Possible values: name.  Default is the order in database. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in the response. Default: 20  Minimum: 1  Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
         /// </param>
         /// <param name="offset">
         ///The index of the first record to return. Used for pagination in combination with the limit parameter.  Example: limit=20 and offset=40 returns records 41–60. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProductsPage&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ProductsPage>> GetUserProductsAsync (string accountId, string userId, Region? region= null, string userId2= default(string), List<string> filterProjectId= default(List<string>), List<FilterProductKey> filterKey= default(List<FilterProductKey>), List<FilterProductField> fields= default(List<FilterProductField>), List<FilterProductSort> sort= default(List<FilterProductSort>), int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get user roles
        /// </summary>
        /// <remarks>
        ///Returns the roles assigned to a specific user across the projects they belong to.
///
///Only users with account admin permissions can call this endpoint. To verify a user’s permissions, call GET users.
///
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. To find the ID call GET users. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterProjectId">
         ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
         /// </param>
         /// <param name="filterStatus">
         ///Filters roles by their status. Accepts one or more of the following values: active – The role is currently in use.  inactive – The role has been removed or is no longer in use. (optional)
         /// </param>
         /// <param name="filterName">
         ///Filters roles by name. By default, this performs a partial match (case-insensitive).  You can control how the match behaves by using the filterTextMatch parameter. For example, to match only names that start with (startsWith), end with (endsWith), or exactly equal (equals) the provided value. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///Specifies how text-based filters should match values in supported fields. This parameter can be used in any endpoint that supports text-based filtering (e.g., filter[name], filter[jobNumber], filter[companyName], etc.).  Possible values:  contains (default) – Matches if the field contains the specified text anywhere  startsWith – Matches if the field starts with the specified text  endsWith – Matches if the field ends with the specified text  equals – Matches only if the field exactly matches the specified text  Matching is case-insensitive.  Wildcards and regular expressions are not supported. (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of response fields to include. Defaults to all fields if not specified. Use this parameter to reduce the response size by retrieving only the fields you need.  Possible values:  projectIds – Projects where the user holds this role  name – Role name  status – Role status (active or inactive)  key – Internal key used to translate the role name  createdAt – Timestamp when the role was created  updatedAt – Timestamp when the role was last updated (optional)
         /// </param>
         /// <param name="sort">
         ///Sorts the results by one or more fields. Each field can be followed by a direction modifier:  asc – Ascending order (default)  desc – Descending order  Possible values: name, createdAt, updatedAt.  Default sort: name asc  Example: sort=name,updatedAt desc (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in the response. Default: 20  Minimum: 1  Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
         /// </param>
         /// <param name="offset">
         ///The index of the first record to return. Used for pagination in combination with the limit parameter.  Example: limit=20 and offset=40 returns records 41–60. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;RolesPage&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<RolesPage>> GetUserRolesAsync (string accountId, string userId, Region? region= null, string userId2= default(string), List<string> filterProjectId= default(List<string>), List<FilterRoleStatus> filterStatus= default(List<FilterRoleStatus>), string filterName= default(string), FilterTextMatch? filterTextMatch= null, List<FilterRoleField> fields= default(List<FilterRoleField>), List<FilterRoleSort> sort= default(List<FilterRoleSort>), int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get account users
        /// </summary>
        /// <remarks>
        ///Query all the users in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
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
        /// <returns>Task of ApiResponse&lt;List&lt;User&gt;&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<List<User>>> GetUsersAsync (string accountId, Region? region= null, int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Bulk import users
        /// </summary>
        /// <remarks>
        ///Bulk import users to the master member directory in a BIM 360 account. (50 users maximum can be included in each call.)
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;UserImport&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<UserImport>> ImportUsersAsync (string accountId, Region? region= null, List<UserPayload> userPayload= default(List<UserPayload>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update User
        /// </summary>
        /// <remarks>
        ///Update a specific user’s status or default company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the user.
         /// </param>
         /// <param name="userId">
         ///User ID
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPatchPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<User>> PatchUserDetailsAsync (string accountId, string userId, Region? region= null, UserPatchPayload userPatchPayload= default(UserPatchPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Search Users
        /// </summary>
        /// <remarks>
        ///Search users in the master member directory of a specific BIM 360 account by specified fields.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="name">
         ///User name to match Max length: 255 (optional)
         /// </param>
         /// <param name="email">
         ///User email to match Max length: 255 (optional)
         /// </param>
         /// <param name="companyName">
         ///User company to match Max length: 255 (optional)
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
        /// <returns>Task of ApiResponse&lt;List&lt;User&gt;&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<List<User>>> SearchUsersAsync (string accountId, Region? region= null, string name= default(string), string email= default(string), string companyName= default(string), string _operator= default(string), bool? partial= default(bool?), int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AccountUsersApi : IAccountUsersApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountUsersApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public AccountUsersApi(SDKManager.SDKManager sdkManager)
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
        /// Create User
        /// </summary>
        /// <remarks>
        ///Create a new user in the BIM 360 member directory.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<User>> CreateUserAsync (string accountId,Region? region= null,UserPayload userPayload= default(UserPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users",
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

                request.Content = Marshalling.Serialize(userPayload); // http body (model) parameter


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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<User>(response, default(User));
                }
                logger.LogInformation($"Exited from CreateUserAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<User>(response, await LocalMarshalling.DeserializeAsync<User>(response.Content));

            } // using
        }
        /// <summary>
        /// Get the details of a user
        /// </summary>
        /// <remarks>
        ///Query the details of a specific user.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the user.
         /// </param>
         /// <param name="userId">
         ///User ID
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<User>> GetUserAsync (string accountId,string userId,Region? region= null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUserAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users/{user_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "account_id", accountId},
                            { "user_id", userId},
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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<User>(response, default(User));
                }
                logger.LogInformation($"Exited from GetUserAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<User>(response, await LocalMarshalling.DeserializeAsync<User>(response.Content));

            } // using
        }
        /// <summary>
        /// Get user products
        /// </summary>
        /// <remarks>
        ///Returns a list of ACC products the user is associated with in their assigned projects.
///
///Only account administrators can call this endpoint.
///
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. To find the ID call GET users. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterProjectId">
         ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
         /// </param>
         /// <param name="filterKey">
         ///Filters the list of products by product key — a machine-readable identifier for an ACC product (such as docs, build, or cost). You can specify one or more keys to return only those products the user is associated with.  Example: filter[key]=docs,build  Possible values: accountAdministration, autoSpecs, build, buildingConnected, capitalPlanning, cloudWorksharing, cost, designCollaboration, docs, financials, insight, modelCoordination, projectAdministration, takeoff, and workshopxr. (optional)
         /// </param>
         /// <param name="fields">
         ///List of fields to return in the response. Defaults to all fields. Possible values: projectIds, name and icon. (optional)
         /// </param>
         /// <param name="sort">
         ///The list of fields to sort by. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.  Possible values: name.  Default is the order in database. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in the response. Default: 20  Minimum: 1  Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
         /// </param>
         /// <param name="offset">
         ///The index of the first record to return. Used for pagination in combination with the limit parameter.  Example: limit=20 and offset=40 returns records 41–60. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ProductsPage&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ProductsPage>> GetUserProductsAsync (string accountId,string userId,Region? region= null,string userId2= default(string),List<string> filterProjectId= default(List<string>),List<FilterProductKey> filterKey= default(List<FilterProductKey>),List<FilterProductField> fields= default(List<FilterProductField>),List<FilterProductSort> sort= default(List<FilterProductSort>),int? limit= default(int?),int? offset= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUserProductsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[projectId]", filterProjectId, queryParam);
                SetQueryParameter("filter[key]", filterKey, queryParam);
                SetQueryParameter("fields", fields, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/accounts/{accountId}/users/{userId}/products",
                        routeParameters: new Dictionary<string, object> {
                            { "accountId", accountId},
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
                    return new ApiResponse<ProductsPage>(response, default(ProductsPage));
                }
                logger.LogInformation($"Exited from GetUserProductsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ProductsPage>(response, await LocalMarshalling.DeserializeAsync<ProductsPage>(response.Content));

            } // using
        }
        /// <summary>
        /// Get user roles
        /// </summary>
        /// <remarks>
        ///Returns the roles assigned to a specific user across the projects they belong to.
///
///Only users with account admin permissions can call this endpoint. To verify a user’s permissions, call GET users.
///
///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. To find the ID call GET users. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterProjectId">
         ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
         /// </param>
         /// <param name="filterStatus">
         ///Filters roles by their status. Accepts one or more of the following values: active – The role is currently in use.  inactive – The role has been removed or is no longer in use. (optional)
         /// </param>
         /// <param name="filterName">
         ///Filters roles by name. By default, this performs a partial match (case-insensitive).  You can control how the match behaves by using the filterTextMatch parameter. For example, to match only names that start with (startsWith), end with (endsWith), or exactly equal (equals) the provided value. (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///Specifies how text-based filters should match values in supported fields. This parameter can be used in any endpoint that supports text-based filtering (e.g., filter[name], filter[jobNumber], filter[companyName], etc.).  Possible values:  contains (default) – Matches if the field contains the specified text anywhere  startsWith – Matches if the field starts with the specified text  endsWith – Matches if the field ends with the specified text  equals – Matches only if the field exactly matches the specified text  Matching is case-insensitive.  Wildcards and regular expressions are not supported. (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of response fields to include. Defaults to all fields if not specified. Use this parameter to reduce the response size by retrieving only the fields you need.  Possible values:  projectIds – Projects where the user holds this role  name – Role name  status – Role status (active or inactive)  key – Internal key used to translate the role name  createdAt – Timestamp when the role was created  updatedAt – Timestamp when the role was last updated (optional)
         /// </param>
         /// <param name="sort">
         ///Sorts the results by one or more fields. Each field can be followed by a direction modifier:  asc – Ascending order (default)  desc – Descending order  Possible values: name, createdAt, updatedAt.  Default sort: name asc  Example: sort=name,updatedAt desc (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records to return in the response. Default: 20  Minimum: 1  Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
         /// </param>
         /// <param name="offset">
         ///The index of the first record to return. Used for pagination in combination with the limit parameter.  Example: limit=20 and offset=40 returns records 41–60. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;RolesPage&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RolesPage>> GetUserRolesAsync (string accountId,string userId,Region? region= null,string userId2= default(string),List<string> filterProjectId= default(List<string>),List<FilterRoleStatus> filterStatus= default(List<FilterRoleStatus>),string filterName= default(string),FilterTextMatch? filterTextMatch= null,List<FilterRoleField> fields= default(List<FilterRoleField>),List<FilterRoleSort> sort= default(List<FilterRoleSort>),int? limit= default(int?),int? offset= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUserRolesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[projectId]", filterProjectId, queryParam);
                SetQueryParameter("filter[status]", filterStatus, queryParam);
                SetQueryParameter("filter[name]", filterName, queryParam);
                SetQueryParameter("filterTextMatch", filterTextMatch, queryParam);
                SetQueryParameter("fields", fields, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/admin/v1/accounts/{accountId}/users/{userId}/roles",
                        routeParameters: new Dictionary<string, object> {
                            { "accountId", accountId},
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
                    return new ApiResponse<RolesPage>(response, default(RolesPage));
                }
                logger.LogInformation($"Exited from GetUserRolesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RolesPage>(response, await LocalMarshalling.DeserializeAsync<RolesPage>(response.Content));

            } // using
        }
        /// <summary>
        /// Get account users
        /// </summary>
        /// <remarks>
        ///Query all the users in a specific BIM 360 account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
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
        /// <returns>Task of ApiResponse&lt;List&lt;User&gt;&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<List<User>>> GetUsersAsync (string accountId,Region? region= null,int? limit= default(int?),int? offset= default(int?),string sort= default(string),string field= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUsersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("field", field, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users",
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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<List<User>>(response, default(List<User>));
                }
                logger.LogInformation($"Exited from GetUsersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<List<User>>(response, await LocalMarshalling.DeserializeAsync<List<User>>(response.Content));

            } // using
        }
        /// <summary>
        /// Bulk import users
        /// </summary>
        /// <remarks>
        ///Bulk import users to the master member directory in a BIM 360 account. (50 users maximum can be included in each call.)
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;UserImport&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<UserImport>> ImportUsersAsync (string accountId,Region? region= null,List<UserPayload> userPayload= default(List<UserPayload>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into ImportUsersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users/import",
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

                request.Content = Marshalling.Serialize(userPayload); // http body (model) parameter


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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<UserImport>(response, default(UserImport));
                }
                logger.LogInformation($"Exited from ImportUsersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<UserImport>(response, await LocalMarshalling.DeserializeAsync<UserImport>(response.Content));

            } // using
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <remarks>
        ///Update a specific user’s status or default company.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the user.
         /// </param>
         /// <param name="userId">
         ///User ID
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="userPatchPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<User>> PatchUserDetailsAsync (string accountId,string userId,Region? region= null,UserPatchPayload userPatchPayload= default(UserPatchPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchUserDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users/{user_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "account_id", accountId},
                            { "user_id", userId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(userPatchPayload); // http body (model) parameter


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
                    return new ApiResponse<User>(response, default(User));
                }
                logger.LogInformation($"Exited from PatchUserDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<User>(response, await LocalMarshalling.DeserializeAsync<User>(response.Content));

            } // using
        }
        /// <summary>
        /// Search Users
        /// </summary>
        /// <remarks>
        ///Search users in the master member directory of a specific BIM 360 account by specified fields.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The account ID of the users.
         /// </param>
         /// <param name="region">
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
         /// </param>
         /// <param name="name">
         ///User name to match Max length: 255 (optional)
         /// </param>
         /// <param name="email">
         ///User email to match Max length: 255 (optional)
         /// </param>
         /// <param name="companyName">
         ///User company to match Max length: 255 (optional)
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
        /// <returns>Task of ApiResponse&lt;List&lt;User&gt;&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<List<User>>> SearchUsersAsync (string accountId,Region? region= null,string name= default(string),string email= default(string),string companyName= default(string),string _operator= default(string),bool? partial= default(bool?),int? limit= default(int?),int? offset= default(int?),string sort= default(string),string field= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into SearchUsersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("name", name, queryParam);
                SetQueryParameter("email", email, queryParam);
                SetQueryParameter("company_name", companyName, queryParam);
                SetQueryParameter("operator", _operator, queryParam);
                SetQueryParameter("partial", partial, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sort", sort, queryParam);
                SetQueryParameter("field", field, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/hq/v1/accounts/{account_id}/users/search",
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
                      throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<List<User>>(response, default(List<User>));
                }
                logger.LogInformation($"Exited from SearchUsersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<List<User>>(response, await LocalMarshalling.DeserializeAsync<List<User>>(response.Content));

            } // using
        }
    }
}
