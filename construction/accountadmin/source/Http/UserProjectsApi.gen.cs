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
    public interface IUserProjectsApi
    {
        /// <summary>
        /// Get user projects
        /// </summary>
        /// <remarks>
        ///Returns a list of projects for a specified user within an Autodesk Construction Cloud (ACC) or BIM 360 account. Only projects the user participates in will be returned. The calling user must be an account administrator.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterId">
         ///A list of project IDs to filter by. (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of user project fields to include in the response. If not specified, all available fields are included by default. Possible values: accessLevels, accountId, addressLine1, addressLine2, city, constructionType, country, createdAt, classification, deliveryMethod, endDate, imageUrl, jobNumber, latitude, longitude, name, platform, postalCode, projectValue, sheetCount, startDate, stateOrProvince, status, thumbnailImageUrl, timezone, type, updatedAt, contractType and currentPhase. (optional)
         /// </param>
         /// <param name="filterClassification">
         ///Filters projects by classification. Possible values: production – Standard production projects. template – Project templates that can be cloned to create production projects. component – Placeholder projects that contain standardized components (e.g., forms) for use across projects. Only one component project is permitted per account. Known as a library in the ACC unified products UI. sample – The single sample project automatically created upon ACC trial setup. Only one sample project is permitted per account.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterName">
         ///Filters projects by name. Supports partial matches when used with filterTextMatch. For example filter[name]=ABCco&filterTextMatch=startsWith returns projects whose names start with “ABCco”. Max length: 255 (optional)
         /// </param>
         /// <param name="filterPlatform">
         ///Filters by platform. Possible values: acc (Autodesk Construction Cloud) and bim360 (BIM 360). Max length: 255 (optional)
         /// </param>
         /// <param name="filterStatus">
         ///Filters projects by status. Possible values: active, pending, archived, suspended. (optional)
         /// </param>
         /// <param name="filterType">
         ///Filters by project type. To exclude a type, prefix it with - (e.g., -Bridge excludes bridge projects). Possible values: Airport, Assisted Living / Nursing Home, Bridge, Canal / Waterway, Convention Center, Court House, Data Center, Dams / Flood Control / Reservoirs, Demonstration Project, Dormitory, Education Facility, Government Building, Harbor / River Development, Hospital, Hotel / Motel, Library, Manufacturing / Factory, Medical Laboratory, Medical Office, Military Facility, Mining Facility, Multi-Family Housing, Museum, Oil & Gas,`Plant`, Office, OutPatient Surgery Center, Parking Structure / Garage, Performing Arts, Power Plant, Prison / Correctional Facility, Rail, Recreation Building, Religious Building, Research Facility / Laboratory, Restaurant, Retail, Seaport, Single-Family Housing, Solar Farm, Stadium/Arena, Streets / Roads / Highways, Template Project, Theme Park, Training Project, Transportation Building, Tunnel, Utilities, Warehouse (non-manufacturing), Waste Water / Sewers, Water Supply, Wind Farm. (optional)
         /// </param>
         /// <param name="filterJobNumber">
         ///Filters by a user-defined project identifier. Supports partial matches when used with filterTextMatch. For example, filter[jobNumber]=HP-0002&filterTextMatch=equals returns projects where the job number is exactly “HP-0002”. Max length: 255 (optional)
         /// </param>
         /// <param name="filterUpdatedAt">
         ///Filters projects updated within a specific date range in ISO 8601 format. For example: Date range: 2023-03-02T00:00:00.000Z..2023-03-03T23:59:59 .999Z Specific start date: 2023-03-02T00:00:00.000Z.. Specific end date: ..2023-03-02T23:59:59.999Z  For more details, see JSON API Filtering.  Max length: 100 (optional)
         /// </param>
         /// <param name="filterAccessLevels">
         ///Filters projects by user access level. Possible values: projectAdmin, projectMember. Max length: 255 (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///Defines how text-based filters should match results. Possible values: contains (default) – Returns results where the text appears anywhere in the field. startsWith – Matches only if the field starts with the given value. endsWith – Matches only if the field ends with the given value. equals – Matches only if the field is an exact match. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned user projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.  Possible values: name (the default), startDate, endDate, type, status, jobNumber, constructionType, deliveryMethod, contractType, currentPhase, createdAt, updatedAt and platform. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records per request. Default: 20. Minimum: 1, Maximum: 200. If a value greater than 200 is provided, only 200 records are returned. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number to start returning results from, used for pagination. For example, if limit=20 and offset=20, the request retrieves the second page of results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;UserProjectsPage&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<UserProjectsPage>> GetUserProjectsAsync (string accountId, string userId, Region? region= null, string userId2= default(string), List<string> filterId= default(List<string>), List<UserProjectFields> fields= default(List<UserProjectFields>), List<Classification> filterClassification= default(List<Classification>), string filterName= default(string), List<Platform> filterPlatform= default(List<Platform>), List<Status> filterStatus= default(List<Status>), List<string> filterType= default(List<string>), string filterJobNumber= default(string), string filterUpdatedAt= default(string), List<FilterUserProjectsAccessLevels> filterAccessLevels= default(List<FilterUserProjectsAccessLevels>), FilterTextMatch? filterTextMatch= null, List<UserProjectSortBy> sort= default(List<UserProjectSortBy>), int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class UserProjectsApi : IUserProjectsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjectsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public UserProjectsApi(SDKManager.SDKManager sdkManager)
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
        /// Get user projects
        /// </summary>
        /// <remarks>
        ///Returns a list of projects for a specified user within an Autodesk Construction Cloud (ACC) or BIM 360 account. Only projects the user participates in will be returned. The calling user must be an account administrator.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
         /// <param name="accountId">
         ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
         /// </param>
         /// <param name="userId">
         ///The ID of the user. You can use either the ACC ID (id) or the Autodesk ID (autodeskId).
         /// </param>
         /// <param name="region">
         ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. For a complete list of supported regions, see the Regions page. (optional)
         /// </param>
         /// <param name="userId2">
         ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
         /// </param>
         /// <param name="filterId">
         ///A list of project IDs to filter by. (optional)
         /// </param>
         /// <param name="fields">
         ///A comma-separated list of user project fields to include in the response. If not specified, all available fields are included by default. Possible values: accessLevels, accountId, addressLine1, addressLine2, city, constructionType, country, createdAt, classification, deliveryMethod, endDate, imageUrl, jobNumber, latitude, longitude, name, platform, postalCode, projectValue, sheetCount, startDate, stateOrProvince, status, thumbnailImageUrl, timezone, type, updatedAt, contractType and currentPhase. (optional)
         /// </param>
         /// <param name="filterClassification">
         ///Filters projects by classification. Possible values: production – Standard production projects. template – Project templates that can be cloned to create production projects. component – Placeholder projects that contain standardized components (e.g., forms) for use across projects. Only one component project is permitted per account. Known as a library in the ACC unified products UI. sample – The single sample project automatically created upon ACC trial setup. Only one sample project is permitted per account.  Max length: 255 (optional)
         /// </param>
         /// <param name="filterName">
         ///Filters projects by name. Supports partial matches when used with filterTextMatch. For example filter[name]=ABCco&filterTextMatch=startsWith returns projects whose names start with “ABCco”. Max length: 255 (optional)
         /// </param>
         /// <param name="filterPlatform">
         ///Filters by platform. Possible values: acc (Autodesk Construction Cloud) and bim360 (BIM 360). Max length: 255 (optional)
         /// </param>
         /// <param name="filterStatus">
         ///Filters projects by status. Possible values: active, pending, archived, suspended. (optional)
         /// </param>
         /// <param name="filterType">
         ///Filters by project type. To exclude a type, prefix it with - (e.g., -Bridge excludes bridge projects). Possible values: Airport, Assisted Living / Nursing Home, Bridge, Canal / Waterway, Convention Center, Court House, Data Center, Dams / Flood Control / Reservoirs, Demonstration Project, Dormitory, Education Facility, Government Building, Harbor / River Development, Hospital, Hotel / Motel, Library, Manufacturing / Factory, Medical Laboratory, Medical Office, Military Facility, Mining Facility, Multi-Family Housing, Museum, Oil & Gas,`Plant`, Office, OutPatient Surgery Center, Parking Structure / Garage, Performing Arts, Power Plant, Prison / Correctional Facility, Rail, Recreation Building, Religious Building, Research Facility / Laboratory, Restaurant, Retail, Seaport, Single-Family Housing, Solar Farm, Stadium/Arena, Streets / Roads / Highways, Template Project, Theme Park, Training Project, Transportation Building, Tunnel, Utilities, Warehouse (non-manufacturing), Waste Water / Sewers, Water Supply, Wind Farm. (optional)
         /// </param>
         /// <param name="filterJobNumber">
         ///Filters by a user-defined project identifier. Supports partial matches when used with filterTextMatch. For example, filter[jobNumber]=HP-0002&filterTextMatch=equals returns projects where the job number is exactly “HP-0002”. Max length: 255 (optional)
         /// </param>
         /// <param name="filterUpdatedAt">
         ///Filters projects updated within a specific date range in ISO 8601 format. For example: Date range: 2023-03-02T00:00:00.000Z..2023-03-03T23:59:59 .999Z Specific start date: 2023-03-02T00:00:00.000Z.. Specific end date: ..2023-03-02T23:59:59.999Z  For more details, see JSON API Filtering.  Max length: 100 (optional)
         /// </param>
         /// <param name="filterAccessLevels">
         ///Filters projects by user access level. Possible values: projectAdmin, projectMember. Max length: 255 (optional)
         /// </param>
         /// <param name="filterTextMatch">
         ///Defines how text-based filters should match results. Possible values: contains (default) – Returns results where the text appears anywhere in the field. startsWith – Matches only if the field starts with the given value. endsWith – Matches only if the field ends with the given value. equals – Matches only if the field is an exact match. (optional)
         /// </param>
         /// <param name="sort">
         ///A list of fields to sort the returned user projects by. Multiple sort fields are applied in sequence order — each sort field produces groupings of projects with the same values of that field; the next sort field applies within the groupings produced by the previous sort field. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.  Possible values: name (the default), startDate, endDate, type, status, jobNumber, constructionType, deliveryMethod, contractType, currentPhase, createdAt, updatedAt and platform. (optional)
         /// </param>
         /// <param name="limit">
         ///The maximum number of records per request. Default: 20. Minimum: 1, Maximum: 200. If a value greater than 200 is provided, only 200 records are returned. (optional)
         /// </param>
         /// <param name="offset">
         ///The record number to start returning results from, used for pagination. For example, if limit=20 and offset=20, the request retrieves the second page of results. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;UserProjectsPage&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<UserProjectsPage>> GetUserProjectsAsync (string accountId,string userId,Region? region= null,string userId2= default(string),List<string> filterId= default(List<string>),List<UserProjectFields> fields= default(List<UserProjectFields>),List<Classification> filterClassification= default(List<Classification>),string filterName= default(string),List<Platform> filterPlatform= default(List<Platform>),List<Status> filterStatus= default(List<Status>),List<string> filterType= default(List<string>),string filterJobNumber= default(string),string filterUpdatedAt= default(string),List<FilterUserProjectsAccessLevels> filterAccessLevels= default(List<FilterUserProjectsAccessLevels>),FilterTextMatch? filterTextMatch= null,List<UserProjectSortBy> sort= default(List<UserProjectSortBy>),int? limit= default(int?),int? offset= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetUserProjectsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
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
                    return new ApiResponse<UserProjectsPage>(response, default(UserProjectsPage));
                }
                logger.LogInformation($"Exited from GetUserProjectsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<UserProjectsPage>(response, await LocalMarshalling.DeserializeAsync<UserProjectsPage>(response.Content));

            } // using
        }
    }
}
