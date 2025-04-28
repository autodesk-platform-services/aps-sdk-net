/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Issues
 *
 * An issue is an item that is created in ACC for tracking, managing and communicating tasks, problems and other points of concern through to resolution. You can manage different types of issues, such as design, safety, and commissioning. We currently support issues that are associated with a project.
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
using Autodesk.Construction.Issues.Model;
using Autodesk.Construction.Issues.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;
using System.Collections;

namespace Autodesk.Construction.Issues.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIssuesApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///Adds an issue to a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="issuePayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Issue>> CreateIssueAsync(string projectId, Region? xAdsRegion = null, IssuePayload issuePayload = default(IssuePayload), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves detailed information about a single issue. For general information about all the issues in a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Issue>> GetIssueDetailsAsync(string projectId, string issueId, Region? xAdsRegion = null, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves information about all the issues in a project, including details about their associated comments and attachments.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="filterId">
        ///Filter issues by the unique issue ID. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterIssueTypeId">
        ///Filter issues by the unique identifier of the category of the issue. Note that the API name for category is type. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterIssueSubtypeId">
        ///Filter issues by the unique identifier of the type of the issue. Note that the API name for type is subtype. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterStatus">
        ///Filter issues by their status. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterLinkedDocumentUrn">
        ///Retrieves pushpin issues associated with the specified files. We support all file types that are compatible with the Files tool. You need to specify the URL-encoded file item IDs. (optional)
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="filterDueDate">
        ///Filter issues by due date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterStartDate">
        ///Filter issues by start date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterDeleted">
        ///Filter deleted issues. For example, filter[deleted]=true. If set to true it only returns deleted issues. If set to false it only returns undeleted issues. Note that we do not currently support returning both deleted and undeleted issues. Default value: false. (optional)
        /// </param>
        /// <param name="filterCreatedAt">
        ///Filter issues created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas (optional)
        /// </param>
        /// <param name="filterCreatedBy">
        ///Filter issues by the unique identifier of the user who created the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        ///Filter issues updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)
        /// </param>
        /// <param name="filterUpdatedBy">
        ///Filter issues by the unique identifier of the user who updated the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAssignedTo">
        ///Filter issues by the unique Autodesk ID of the User/Company/Role identifier of the current assignee of this issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterRootCauseId">
        ///Filter issues by the unique identifier of the type of root cause for the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterLocationId">
        ///Retrieves issues associated with the specified location but not the location’s sublocations. To also retrieve issues that relate to the locations’s sublocations use the sublocationId filter. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterSubLocationId">
        ///Retrieves issues associated with the specified unique LBS (Location Breakdown Structure) identifier, as well as issues associated with the sub locations of the LBS identifier. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterClosedBy">
        ///Filter issues by the unique identifier of the user who closed the issue. Separate multiple values with commas. For Example: A3RGM375QTZ7. (optional)
        /// </param>
        /// <param name="filterClosedAt">
        ///Filter issues closed at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterSearch">
        ///Filter issues using ‘search’ criteria. this will filter both title and issues display ID. For example, use filter[search]=300 (optional)
        /// </param>
        /// <param name="filterDisplayId">
        ///Filter issues by the chronological user-friendly identifier. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAssignedToType">
        ///Filter issues by the type of the current assignee of this issue. Separate multiple values with commas. Possible values: Possible values: user, company, role, null. For Example: user. (optional)
        /// </param>
        /// <param name="filterCustomAttributes">
        ///Filter issues by the custom attributes. Each custom attribute filter should be defined by it’s uuid. For example: filter[customAttributes][f227d940-ae9b-4722-9297-389f4411f010]=1,2,3. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterValid">
        ///Only return valid issues (=no empty type/subtype). Default value: undefined (meaning will return both valid & invalid issues). (optional)
        /// </param>
        /// <param name="limit">
        ///Return specified number of issues. Acceptable values are 1-100. Default value: 100. (optional)
        /// </param>
        /// <param name="offset">
        ///Return issues starting from the specified offset number. Default value: 0. (optional)
        /// </param>
        /// <param name="sortBy">
        ///Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)
        /// </param>
        /// <param name="fields">
        ///Return only specific fields in issue object. Separate multiple values with commas. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;IssuesPage&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<IssuesPage>> GetIssuesAsync(string projectId, List<string> filterId = default(List<string>), List<string> filterIssueTypeId = default(List<string>), List<string> filterIssueSubtypeId = default(List<string>), string filterStatus = default(string), List<string> filterLinkedDocumentUrn = default(List<string>), Region? xAdsRegion = null, string filterDueDate = default(string), string filterStartDate = default(string),bool? filterDeleted = default(bool?), string filterCreatedAt = default(string), List<string> filterCreatedBy = default(List<string>), string filterUpdatedAt = default(string), List<string> filterUpdatedBy = default(List<string>), List<string> filterAssignedTo = default(List<string>), List<string> filterRootCauseId = default(List<string>), List<string> filterLocationId = default(List<string>), List<string> filterSubLocationId = default(List<string>), List<string> filterClosedBy = default(List<string>), string filterClosedAt = default(string), string filterSearch = default(string), int? filterDisplayId = default(int?), string filterAssignedToType = default(string), List<string> filterCustomAttributes = default(List<string>), bool? filterValid = default(bool?), int? limit = default(int?), int? offset = default(int?), List<SortBy> sortBy = default(List<SortBy>), List<Fields> fields = default(List<Fields>), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///Updates an issue.
        ///
        ///To verify whether a user can update issues for a specific project, call GET users/me.
        ///
        ///To verify which attributes the user can update, call GET issues/:id and check the permittedAttributes and permittedStatuses lists.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="issuePayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Issue>> PatchIssueDetailsAsync(string projectId, string issueId, Region? xAdsRegion = null, IssuePayload issuePayload = default(IssuePayload), string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IssuesApi : IIssuesApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssuesApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public IssuesApi(SDKManager.SDKManager sdkManager)
        {
            this.Service = sdkManager.ApsClient.Service;
            this.logger = sdkManager.Logger;
        }
        private void SetQueryParameter(string name, object value, Dictionary<string, object> dictionary)
        {
            if (value is Enum)
            {
                var type = value.GetType();
                var memberInfos = type.GetMember(value.ToString());
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if (valueAttributes.Length > 0)
                {
                    dictionary.Add(name, ((EnumMemberAttribute)valueAttributes[0]).Value);
                }
            }
            else if (value is int)
            {
                if ((int)value > 0)
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
                if (value != null)
                {
                    
                    dictionary.Add(name, value);
                }
            }
        }
        private void SetHeader(string baseName, object value, HttpRequestMessage req)
        {
            if (value is DateTime)
            {
                if ((DateTime)value != DateTime.MinValue)
                {
                    req.Headers.TryAddWithoutValidation(baseName, LocalMarshalling.ParameterToString(value)); // header parameter
                }
            }
            else
            {
                if (value != null)
                {
                    if (!string.Equals(baseName, "Content-Range"))
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
        public ForgeService Service { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///Adds an issue to a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="issuePayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Issue>> CreateIssueAsync(string projectId, Region? xAdsRegion = null, IssuePayload issuePayload = default(IssuePayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateIssueAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(issuePayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

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
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new ConstructionissuesApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Issue>(response, default(Issue));
                }
                logger.LogInformation($"Exited from CreateIssueAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Issue>(response, await LocalMarshalling.DeserializeAsync<Issue>(response.Content));

            } // using
        }
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves detailed information about a single issue. For general information about all the issues in a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Issue>> GetIssueDetailsAsync(string projectId, string issueId, Region? xAdsRegion = null, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetIssueDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues/{issueId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "issueId", issueId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new ConstructionissuesApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Issue>(response, default(Issue));
                }
                logger.LogInformation($"Exited from GetIssueDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Issue>(response, await LocalMarshalling.DeserializeAsync<Issue>(response.Content));

            } // using
        }
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves information about all the issues in a project, including details about their associated comments and attachments.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="filterId">
        ///Filter issues by the unique issue ID. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterIssueTypeId">
        ///Filter issues by the unique identifier of the category of the issue. Note that the API name for category is type. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterIssueSubtypeId">
        ///Filter issues by the unique identifier of the type of the issue. Note that the API name for type is subtype. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterStatus">
        ///Filter issues by their status. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterLinkedDocumentUrn">
        ///Retrieves pushpin issues associated with the specified files. We support all file types that are compatible with the Files tool. You need to specify the URL-encoded file item IDs. (optional)
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="filterDueDate">
        ///Filter issues by due date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterStartDate">
        ///Filter issues by start date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterCreatedAt">
        ///Filter issues created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas (optional)
        /// </param>
        /// <param name="filterCreatedBy">
        ///Filter issues by the unique identifier of the user who created the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        ///Filter issues updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)
        /// </param>
        /// <param name="filterUpdatedBy">
        ///Filter issues by the unique identifier of the user who updated the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAssignedTo">
        ///Filter issues by the unique Autodesk ID of the User/Company/Role identifier of the current assignee of this issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterRootCauseId">
        ///Filter issues by the unique identifier of the type of root cause for the issue. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterLocationId">
        ///Retrieves issues associated with the specified location but not the location’s sublocations. To also retrieve issues that relate to the locations’s sublocations use the sublocationId filter. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterSubLocationId">
        ///Retrieves issues associated with the specified unique LBS (Location Breakdown Structure) identifier, as well as issues associated with the sub locations of the LBS identifier. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterClosedBy">
        ///Filter issues by the unique identifier of the user who closed the issue. Separate multiple values with commas. For Example: A3RGM375QTZ7. (optional)
        /// </param>
        /// <param name="filterClosedAt">
        ///Filter issues closed at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterSearch">
        ///Filter issues using ‘search’ criteria. this will filter both title and issues display ID. For example, use filter[search]=300 (optional)
        /// </param>
        /// <param name="filterDisplayId">
        ///Filter issues by the chronological user-friendly identifier. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAssignedToType">
        ///Filter issues by the type of the current assignee of this issue. Separate multiple values with commas. Possible values: Possible values: user, company, role, null. For Example: user. (optional)
        /// </param>
        /// <param name="filterCustomAttributes">
        ///Filter issues by the custom attributes. Each custom attribute filter should be defined by it’s uuid. For example: filter[customAttributes][f227d940-ae9b-4722-9297-389f4411f010]=1,2,3. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterValid">
        ///Only return valid issues (=no empty type/subtype). Default value: undefined (meaning will return both valid & invalid issues). (optional)
        /// </param>
        /// <param name="limit">
        ///Return specified number of issues. Acceptable values are 1-100. Default value: 100. (optional)
        /// </param>
        /// <param name="offset">
        ///Return issues starting from the specified offset number. Default value: 0. (optional)
        /// </param>
        /// <param name="sortBy">
        ///Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)
        /// </param>
        /// <param name="fields">
        ///Return only specific fields in issue object. Separate multiple values with commas. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;IssuesPage&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<IssuesPage>> GetIssuesAsync(string projectId, List<string> filterId = default(List<string>), List<string> filterIssueTypeId = default(List<string>), List<string> filterIssueSubtypeId = default(List<string>), string filterStatus = default(string), List<string> filterLinkedDocumentUrn = default(List<string>), Region? xAdsRegion = null, string filterDueDate = default(string), string filterStartDate = default(string),bool? filterDeleted = default(bool?), string filterCreatedAt = default(string), List<string> filterCreatedBy = default(List<string>), string filterUpdatedAt = default(string), List<string> filterUpdatedBy = default(List<string>), List<string> filterAssignedTo = default(List<string>), List<string> filterRootCauseId = default(List<string>), List<string> filterLocationId = default(List<string>), List<string> filterSubLocationId = default(List<string>), List<string> filterClosedBy = default(List<string>), string filterClosedAt = default(string), string filterSearch = default(string), int? filterDisplayId = default(int?), string filterAssignedToType = default(string), List<string> filterCustomAttributes = default(List<string>), bool? filterValid = default(bool?), int? limit = default(int?), int? offset = default(int?), List<SortBy> sortBy = default(List<SortBy>), List<Fields> fields = default(List<Fields>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetIssuesAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[issueTypeId]", filterIssueTypeId, queryParam);
                SetQueryParameter("filter[issueSubtypeId]", filterIssueSubtypeId, queryParam);
                SetQueryParameter("filter[status]", filterStatus, queryParam);
                SetQueryParameter("filter[linkedDocumentUrn]", filterLinkedDocumentUrn, queryParam);
                SetQueryParameter("filter[dueDate]", filterDueDate, queryParam);
                SetQueryParameter("filter[startDate]", filterStartDate, queryParam);
                SetQueryParameter("filter[deleted]", filterDeleted, queryParam);
                SetQueryParameter("filter[createdAt]", filterCreatedAt, queryParam);
                SetQueryParameter("filter[createdBy]", filterCreatedBy, queryParam);
                SetQueryParameter("filter[updatedAt]", filterUpdatedAt, queryParam);
                SetQueryParameter("filter[updatedBy]", filterUpdatedBy, queryParam);
                SetQueryParameter("filter[assignedTo]", filterAssignedTo, queryParam);
                SetQueryParameter("filter[rootCauseId]", filterRootCauseId, queryParam);
                SetQueryParameter("filter[locationId]", filterLocationId, queryParam);
                SetQueryParameter("filter[subLocationId]", filterSubLocationId, queryParam);
                SetQueryParameter("filter[closedBy]", filterClosedBy, queryParam);
                SetQueryParameter("filter[closedAt]", filterClosedAt, queryParam);
                SetQueryParameter("filter[search]", filterSearch, queryParam);
                SetQueryParameter("filter[displayId]", filterDisplayId, queryParam);
                SetQueryParameter("filter[assignedToType]", filterAssignedToType, queryParam);
                SetQueryParameter("filter[customAttributes]", filterCustomAttributes, queryParam);
                SetQueryParameter("filter[valid]", filterValid, queryParam);
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sortBy", sortBy, queryParam);
                SetQueryParameter("fields", fields, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new ConstructionissuesApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<IssuesPage>(response, default(IssuesPage));
                }
                logger.LogInformation($"Exited from GetIssuesAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<IssuesPage>(response, await LocalMarshalling.DeserializeAsync<IssuesPage>(response.Content));

            } // using
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///Updates an issue.
        ///
        ///To verify whether a user can update issues for a specific project, call GET users/me.
        ///
        ///To verify which attributes the user can update, call GET issues/:id and check the permittedAttributes and permittedStatuses lists.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="issuePayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Issue&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Issue>> PatchIssueDetailsAsync(string projectId, string issueId, Region? xAdsRegion = null, IssuePayload issuePayload = default(IssuePayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchIssueDetailsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues/{issueId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "issueId", issueId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(issuePayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

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
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new ConstructionissuesApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Issue>(response, default(Issue));
                }
                logger.LogInformation($"Exited from PatchIssueDetailsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Issue>(response, await LocalMarshalling.DeserializeAsync<Issue>(response.Content));

            } // using
        }
    }
}
