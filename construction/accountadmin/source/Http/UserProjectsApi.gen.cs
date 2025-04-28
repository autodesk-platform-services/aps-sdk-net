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
    /// Represents a collection of functions to interact with the API endpoints.
    /// </summary>
    public interface IUserProjectsApi
    {
        /// <summary>
        /// Get projects of user in account.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the projects in the specified account.
        /// </remarks>
        /// <exception cref="HttpRequestException">
        /// Thrown when fails to make API call.
        /// </exception>
        /// <param name="accountId">
        /// The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
        /// </param>
        /// <param name="acceptLanguage">
        /// This header is not currently supported in the Account Admin API. (optional)
        /// </param>
        /// <param name="region">
        /// The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
        /// </param>
        /// <param name="userId">
        /// Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
        /// </param>
        /// <param name="filterId">
        /// A list of the ACC IDs of users to retrieve. (optional)
        /// </param>
        /// <param name="fields">
        /// A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
        /// </param>
        /// <param name="filterClassification">
        /// A list of the classifications of projects to include in the response. Possible values: production, template, component, sample. (optional)
        /// </param>
        /// <param name="filterName">
        /// A project name or name pattern to filter projects by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
        /// </param>
        /// <param name="filterPlatform">
        /// Filter resource by platform. Possible values: acc and bim360. (optional)
        /// </param>
        /// <param name="filterStatus">
        /// A list of the statuses of projects to include in the response. Possible values:  active, pending, archived, suspended. (optional)
        /// </param>
        /// <param name="filterType">
        /// A list of project types to filter projects by. To exclude a project type from the response, prefix it with - (a hyphen); for example, -Bridge excludes bridge projects. (optional)
        /// </param>
        /// <param name="filterJobNumber">
        /// The user-defined identifier for a project to be returned. This ID was defined when the project was created. This filter accepts a partial match based on the value of filterTextMatch that you provide. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        /// A range of dates during which the desired projects were updated. The range must be specified with dates in ISO 8601 format with time required. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAccessLevels">
        ///A list of user access levels that the returned users must have. (optional)
        /// </param>
        /// <param name="filterTextMatch">
        /// When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
        /// </param>
        /// <param name="sort">
        /// A list of fields to sort the returned projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
        /// </param>
        /// <param name="limit">
        ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
        /// </param>
        /// <param name="offset">
        /// The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
        /// </param>
        /// <returns>
        /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="UserProjects"/>&gt;&gt;
        /// </returns>        
        System.Threading.Tasks.Task<ApiResponse<UserProjects>> GetUserProjectsAsync (string accountId, string acceptLanguage = default, Region? region = null, string userId = default, List<string> filterId = default, List<Fields> fields = default, List<Classification> filterClassification = default, string filterName = default, List<Platform> filterPlatform = default, List<Status> filterStatus = default, List<string> filterType = default, string filterJobNumber = default, string filterUpdatedAt = default, List<AccessLevels> filterAccessLevels = default, FilterTextMatch? filterTextMatch = null, List<SortBy> sort = default, int? limit = default, int? offset = default, string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints.
    /// </summary>
    public partial class UserProjectsApi : IUserProjectsApi
	 {
        private ILogger logger;

        /// <summary>
        /// Gets or sets the ApsConfiguration object.
        /// </summary>
        /// <value>
        /// An instance of the ForgeService.
        /// </value>
        public ForgeService Service {get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjectsApi"/> class using SDKManager object.
        /// </summary>
        /// <param name="sdkManager">
        /// An instance of SDKManager.
        /// </param>
        /// <returns></returns>
        public UserProjectsApi(SDKManager.SDKManager sdkManager)
        {
            logger = sdkManager.Logger;
            Service = sdkManager.ApsClient.Service;
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
                    value = string.Join(",",(List<string>)value);
                    dictionary.Add(name, value);
                }
                else 
                {
                    List<string>newlist = [];
                    foreach ( var x in (IList)value)
                    {
                        var type = x.GetType();
                        var memberInfos = type.GetMember(x.ToString());
                        var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                        var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                        newlist.Add(((EnumMemberAttribute)valueAttributes[0]).Value);                            
                    }
                    string joinedString = string.Join(",", newlist);
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
        /// Get projects of user in account.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of the projects in the specified account.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="accountId">
        /// The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
        /// </param>
        /// <param name="acceptLanguage">
        /// This header is not currently supported in the Account Admin API. (optional)
        /// </param>
        /// <param name="region">
        /// The region where the bucket resides. Acceptable values: US, EMEA, AUS. (optional)
        /// </param>
        /// <param name="userId">
        /// Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
        /// </param>
        /// <param name="filterId">
        /// A list of the ACC IDs of users to retrieve. (optional)
        /// </param>
        /// <param name="fields">
        /// A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
        /// </param>
        /// <param name="filterClassification">
        /// A list of the classifications of projects to include in the response. Possible values: production, template, component, sample. (optional)
        /// </param>
        /// <param name="filterName">
        /// A project name or name pattern to filter projects by. Can be a partial match based on the value of filterTextMatch that you provide; for example: filter[name]=ABCco filterTextMatch=startsWith.  Max length: 255 (optional)
        /// </param>
        /// <param name="filterPlatform">
        /// Filter resource by platform. Possible values: acc and bim360. (optional)
        /// </param>
        /// <param name="filterStatus">
        /// A list of the statuses of projects to include in the response. Possible values:  active pending archived suspended (optional)
        /// </param>
        /// <param name="filterType">
        /// A list of project types to filter projects by. To exclude a project type from the response, prefix it with - (a hyphen); for example, -Bridge excludes bridge projects. (optional)
        /// </param>
        /// <param name="filterJobNumber">
        /// The user-defined identifier for a project to be returned. This ID was defined when the project was created. This filter accepts a partial match based on the value of filterTextMatch that you provide. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        /// A range of dates during which the desired projects were updated. The range must be specified with dates in ISO 8601 format with time required. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAccessLevels">
        ///A list of user access levels that the returned users must have. (optional)
        /// </param>
        /// <param name="filterTextMatch">
        /// When filtering on a text-based field, this value indicates how to do the matching. Default value: contains. Possible values: contains, startsWith, endsWith and equals. (optional)
        /// </param>
        /// <param name="sort">
        /// A list of fields to sort the returned projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. (optional)
        /// </param>
        /// <param name="limit">
        ///The maximum number of records to return in a single request. Possible range: 1-200. Default value: 20. (optional)
        /// </param>
        /// <param name="offset">
        /// The record number that the returned page should start with. When the total number of records exceeds the value of limit, increase the offset value in subsequent requests to continue getting the remaining results. (optional)
        /// </param>
        /// <returns>
        /// <see cref="System.Threading.Tasks.Task"/>&lt;<see cref="ApiResponse"/>&lt;<see cref="UserProjects"/>&gt;&gt;
        /// </returns>    
        public async System.Threading.Tasks.Task<ApiResponse<UserProjects>> GetUserProjectsAsync(
				string accountId, string acceptLanguage = default, Region? region = null, string userId = default, List<string> filterId = default, List<Fields> fields = default, List<Classification> filterClassification = default, string filterName = default, List<Platform> filterPlatform = default, List<Status> filterStatus = default, List<string> filterType = default, string filterJobNumber = default, string filterUpdatedAt = default, List<AccessLevels> filterAccessLevels = default, FilterTextMatch? filterTextMatch = null, List<SortBy> sort = default, int? limit = default, int? offset = default, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation($"Entered into {nameof(GetUserProjectsAsync)}");
			   using HttpRequestMessage request = new();
			   Dictionary<string, object> queryParam = [];
			   SetQueryParameter("filter[id]", filterId, queryParam);
			   SetQueryParameter("fields", fields, queryParam);
			   SetQueryParameter("filter[classification]", filterClassification, queryParam);
			   SetQueryParameter("filter[name]", filterName, queryParam);
			   SetQueryParameter("filter[platform]", filterPlatform, queryParam);
			   SetQueryParameter("filter[status]", filterStatus, queryParam);
			   SetQueryParameter("filter[type]", filterType, queryParam);
			   SetQueryParameter("filter[jobNumber]", filterJobNumber, queryParam);
			   SetQueryParameter("filter[updatedAt]", filterUpdatedAt, queryParam);
			   SetQueryParameter("filter[accessLevels]", filterAccessLevels, queryParam);
			   SetQueryParameter("filterTextMatch", filterTextMatch, queryParam);
			   SetQueryParameter("sort", sort, queryParam);
			   SetQueryParameter("limit", limit, queryParam);
			   SetQueryParameter("offset", offset, queryParam);
			   request.RequestUri =
				    Marshalling.BuildRequestUri("/construction/admin/v1/accounts/{accountId}/users/{userId}/projects",
					     routeParameters: new Dictionary<string, object> {
						      { "accountId", accountId},
								{ "userId", userId},
					     },
					     queryParameters: queryParam
				    );

			   request.Headers.TryAddWithoutValidation("Accept", "application/json");
			   request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ACCOUNT.ADMIN/C#/1.0.0");
			   if (!string.IsNullOrEmpty(accessToken))
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
			   var response = await Service.Client.SendAsync(request);

			   if (throwOnError)
			   {
				    try
				    {
					     await response.EnsureSuccessStatusCodeAsync();
				    }
				    catch (HttpRequestException ex)
				    {
					     throw new ConstructionAccountAdminApiException(ex.Message, response, ex);
				    }
			   }
			   else if (!response.IsSuccessStatusCode)
			   {
				    logger.LogError($"Response unsuccess with status code: {response.StatusCode}");
				    return new ApiResponse<UserProjects>(response, default);
			   }
			   logger.LogInformation($"Exited from {nameof(GetUserProjectsAsync)} with response statusCode: {response.StatusCode}");
			   return new ApiResponse<UserProjects>(response, await LocalMarshalling.DeserializeAsync<UserProjects>(response.Content));
		  }
    }
}
