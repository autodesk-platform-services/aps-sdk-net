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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;User&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<User>> GetUserAsync (string accountId, string userId, Region? region= null,  string accessToken = null, bool throwOnError = true);
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
         ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS. By default, it is set to US. (optional)
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
