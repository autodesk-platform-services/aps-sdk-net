using Autodesk.Construction.Issues.Model;
using Autodesk.Construction.Issues.Http;
using Autodesk.SDKManager;
using System.Collections.Generic;
using System;
using Autodesk.Forge.Core;

namespace Autodesk.Construction.Issues
{
        public class IssuesClient : BaseClient
        {


                public IIssueAttributeDefinitionsApi IssueAttributeDefinitionsApi { get; }
                public IIssueAttributeMappingsApi IssueAttributeMappingsApi { get; }
                public IIssueCommentsApi IssueCommentsApi { get; }
                public IIssueRootCauseCategoriesApi IssueRootCauseCategoriesApi { get; }
                public IIssuesApi IssuesApi { get; }
                public IIssuesProfileApi IssuesProfileApi { get; }
                public IIssueTypesApi IssueTypesApi { get; }

                public IssuesClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default) : base(authenticationProvider)
                {
                        if (sdkManager == null)
                        {
                                sdkManager = SdkManagerBuilder.Create().Build();
                        }
                        this.IssueAttributeDefinitionsApi = new IssueAttributeDefinitionsApi(sdkManager);
                        this.IssueAttributeMappingsApi = new IssueAttributeMappingsApi(sdkManager);
                        this.IssueCommentsApi = new IssueCommentsApi(sdkManager);
                        this.IssueRootCauseCategoriesApi = new IssueRootCauseCategoriesApi(sdkManager);
                        this.IssuesApi = new IssuesApi(sdkManager);
                        this.IssuesProfileApi = new IssuesProfileApi(sdkManager);
                        this.IssueTypesApi = new IssueTypesApi(sdkManager);
                }


                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves information about issue custom attributes (custom fields) for a project, including the custom attribute title, description and type.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId"></param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="limit">The number of custom attribute definitions to return in the response payload. For example, limit&#x3D;2. Acceptable values: 1-200. Default value: 200. (optional)</param>/// <param name="offset">The number of custom attribute definitions you want to begin retrieving results from. (optional)</param>/// <param name="filterCreatedAt">Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterUpdatedAt">Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterDeletedAt">Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)</param>/// <param name="filterDataType">Retrieves issue custom attribute definitions with the specified data type. Possible values: list (this corresponds to dropdown in the UI), text, paragraph, numeric. For example, filter[dataType]&#x3D;text,numeric. (optional)</param>
                /// <returns>Task of ApiResponse<AttrDefinition></returns>

                public async System.Threading.Tasks.Task<AttrDefinition> GetAttributeDefinitionsAsync(string projectId, Region xAdsRegion = default, int? limit = default(int?), int? offset = default(int?), string filterCreatedAt = default(string), string filterUpdatedAt = default(string), string filterDeletedAt = default(string), List<DataType> filterDataType = default(List<DataType>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueAttributeDefinitionsApi.GetAttributeDefinitionsAsync(projectId, xAdsRegion, limit, offset, filterCreatedAt, filterUpdatedAt, filterDeletedAt, filterDataType, accessToken, throwOnError);
                        return response.Content;

                }

                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves information about the issue custom attributes (custom fields) that are assigned to issue categories and issue types.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="limit">The number of custom attribute mappings to return in the response payload. For example, limit&#x3D;2. Acceptable values: 1-200. Default value: 200. (optional)</param>/// <param name="offset">The number of custom attribute mappings you want to begin retrieving results from. (optional)</param>/// <param name="filterCreatedAt">Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterUpdatedAt">Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterDeletedAt">Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterAttributeDefinitionId">Retrieves issue custom attribute mappings associated with the specified issue custom attribute definitions. Separate multiple values with commas. For example: filter[attributeDefinitionId]&#x3D;18ee5858-cbf1-451a-a525-7c6ff8156775. (optional)</param>/// <param name="filterMappedItemId">Retrieves issue custom attribute mappings associated with the specified items (project, type, or subtype). Separate multiple values with commas. For example: filter[mappedItemId]&#x3D;18ee5858-cbf1-451a-a525-7c6ff8156775. Note that this does not retrieve inherited custom attribute mappings or custom attribute mappings of descendants. (optional)</param>
                /// <returns>Task of ApiResponse<AttrMapping></returns>

                public async System.Threading.Tasks.Task<AttrMapping> GetAttributeMappingsAsync(string projectId, Region xAdsRegion = default, int? limit = default(int?), int? offset = default(int?), string filterCreatedAt = default(string), string filterUpdatedAt = default(string), string filterDeletedAt = default(string), string filterAttributeDefinitionId = default(string), string filterMappedItemId = default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueAttributeMappingsApi.GetAttributeMappingsAsync(projectId, xAdsRegion, limit, offset, filterCreatedAt, filterUpdatedAt, filterDeletedAt, filterAttributeDefinitionId, filterMappedItemId, accessToken, throwOnError);
                        return response.Content;
                }
                /// <summary>
                /// 
                /// </summary>
                /// <remarks>
                /// Creates a new comment under a specific issue.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="issueId">The unique identifier of the issue.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="contentType">Must be application/json</param>/// <param name="body"> (optional)</param>
                /// <returns>Task of ApiResponse<CreatedComment></returns>

                public async System.Threading.Tasks.Task<CreatedComment> CreateCommentsAsync(string projectId, string issueId, CommentsPayload commentsPayload, Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueCommentsApi.CreateCommentsAsync(projectId, issueId, xAdsRegion, commentsPayload, accessToken, throwOnError);
                        return response.Content;
                }
                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Get all the comments for a specific issue.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="issueId">The unique identifier of the issue.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="limit">Add limit&#x3D;20 to limit the results count (together with the offset to support pagination). (optional)</param>/// <param name="offset">Add offset&#x3D;20 to get partial results (together with the limit to support pagination). (optional)</param>/// <param name="sortBy">Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)</param>
                /// <returns>Task of ApiResponse<Comments></returns>

                public async System.Threading.Tasks.Task<Comments> GetCommentsAsync(string projectId, string issueId, Region xAdsRegion = default, string limit = default(string), string offset = default(string), List<SortBy> sortBy = default(List<SortBy>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueCommentsApi.GetCommentsAsync(projectId, issueId, xAdsRegion, limit, offset, sortBy, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves a list of supported root cause categories and root causes that you can allocate to an issue. For example, communication and coordination.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="include">Add ‘include&#x3D;rootcauses’ to add the root causes for each category. (optional)</param>/// <param name="limit">Add limit&#x3D;20 to limit the results count (together with the offset to support pagination). (optional)</param>/// <param name="offset">Add offset&#x3D;20 to get partial results (together with the limit to support pagination) (optional)</param>/// <param name="filterUpdatedAt">Retrieves root cause categories updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>
                /// <returns>Task of ApiResponse<IssueRootCause></returns>

                public async System.Threading.Tasks.Task<IssueRootCause> GetRootCauseCategoriesAsync(string projectId, Region xAdsRegion = default, string include = default(string), int? limit = default(int?), int? offset = default(int?), string filterUpdatedAt = default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueRootCauseCategoriesApi.GetRootCauseCategoriesAsync(projectId, xAdsRegion, include, limit, offset, filterUpdatedAt, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <remarks>
                /// Adds an issue to a project.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="contentType">Must be application/json</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="issueUpdateRequest"> (optional)</param>
                /// <returns>Task of ApiResponse<IssueUpdateResponse></returns>

                public async System.Threading.Tasks.Task<Issue> CreateIssueAsync(string projectId, IssuePayload issuePayload, Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssuesApi.CreateIssueAsync(projectId, xAdsRegion, issuePayload, accessToken, throwOnError);
                        return response.Content;
                }
                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves detailed information about a single issue. For general information about all the issues in a project.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="issueId">The unique identifier of the issue.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>
                /// <returns>Task of ApiResponse<Issue></returns>

                public async System.Threading.Tasks.Task<Issue> GetIssueDetailsAsync(string projectId, string issueId, Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssuesApi.GetIssueDetailsAsync(projectId, issueId, xAdsRegion, accessToken, throwOnError);
                        return response.Content;
                }
                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves information about all the issues in a project, including details about their associated comments and attachments.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="filterId">Filter issues by the unique issue ID. Separate multiple values with commas. (optional)</param>/// <param name="filterIssueTypeId">Filter issues by the unique identifier of the category of the issue. Note that the API name for category is type. Separate multiple values with commas. (optional)</param>/// <param name="filterIssueSubtypeId">Filter issues by the unique identifier of the type of the issue. Note that the API name for type is subtype. Separate multiple values with commas. (optional)</param>/// <param name="filterStatus">Filter issues by their status. Separate multiple values with commas. (optional)</param>/// <param name="filterLinkedDocumentUrn">Retrieves pushpin issues associated with the specified files. We support all file types that are compatible with the Files tool. You need to specify the URL-encoded file item IDs. (optional)</param>/// <param name="filterDueDate">Filter issues by due date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterStartDate">Filter issues by start date, in one of the following URL-encoded format: YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterCreatedAt">Filter issues created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas (optional)</param>/// <param name="filterCreatedBy">Filter issues by the unique identifier of the user who created the issue. Separate multiple values with commas. (optional)</param>/// <param name="filterUpdatedAt">Filter issues updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)</param>/// <param name="filterUpdatedBy">Filter issues by the unique identifier of the user who updated the issue. Separate multiple values with commas. (optional)</param>/// <param name="filterAssignedTo">Filter issues by the unique Autodesk ID of the User/Company/Role identifier of the current assignee of this issue. Separate multiple values with commas. (optional)</param>/// <param name="filterRootCauseId">Filter issues by the unique identifier of the type of root cause for the issue. Separate multiple values with commas. (optional)</param>/// <param name="filterLocationId">Retrieves issues associated with the specified location but not the location’s sublocations. To also retrieve issues that relate to the locations’s sublocations use the sublocationId filter. Separate multiple values with commas. (optional)</param>/// <param name="filterSubLocationId">Retrieves issues associated with the specified unique LBS (Location Breakdown Structure) identifier, as well as issues associated with the sub locations of the LBS identifier. Separate multiple values with commas. (optional)</param>/// <param name="filterClosedBy">Filter issues by the unique identifier of the user who closed the issue. Separate multiple values with commas. For Example: A3RGM375QTZ7. (optional)</param>/// <param name="filterClosedAt">Filter issues closed at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterSearch">Filter issues using ‘search’ criteria. this will filter both title and issues display ID. For example, use filter[search]&#x3D;300 (optional)</param>/// <param name="filterDisplayId">Filter issues by the chronological user-friendly identifier. Separate multiple values with commas. (optional)</param>/// <param name="filterAssignedToType">Filter issues by the type of the current assignee of this issue. Separate multiple values with commas. Possible values: Possible values: user, company, role, null. For Example: user. (optional)</param>/// <param name="filterCustomAttributes">Filter issues by the custom attributes. Each custom attribute filter should be defined by it’s uuid. For example: filter[customAttributes][f227d940-ae9b-4722-9297-389f4411f010]&#x3D;1,2,3. Separate multiple values with commas. (optional)</param>/// <param name="filterValid">Only return valid issues (&#x3D;no empty type/subtype). Default value: undefined (meaning will return both valid &amp; invalid issues). (optional)</param>/// <param name="limit">Return specified number of issues. Acceptable values are 1-100. Default value: 100. (optional)</param>/// <param name="offset">Return issues starting from the specified offset number. Default value: 0. (optional)</param>/// <param name="sortBy">Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)</param>/// <param name="fields">Return only specific fields in issue object. Separate multiple values with commas. (optional)</param>
                /// <returns>Task of ApiResponse<Issues></returns>

                public async System.Threading.Tasks.Task<IssuesPage> GetIssuesAsync(string projectId, Region xAdsRegion = default, List<string> filterId = default(List<string>), List<string> filterIssueTypeId = default(List<string>), List<string> filterIssueSubtypeId = default(List<string>), string filterStatus = default(string), List<string> filterLinkedDocumentUrn = default(List<string>), string filterDueDate = default(string), string filterStartDate = default(string), string filterCreatedAt = default(string), FiltercreatedBy filterCreatedBy = default(FiltercreatedBy), string filterUpdatedAt = default(string), List<string> filterUpdatedBy = default(List<string>), List<string> filterAssignedTo = default(List<string>), List<string> filterRootCauseId = default(List<string>), List<string> filterLocationId = default(List<string>), List<string> filterSubLocationId = default(List<string>), List<string> filterClosedBy = default(List<string>), string filterClosedAt = default(string), string filterSearch = default(string), int? filterDisplayId = default(int?), string filterAssignedToType = default(string), List<string> filterCustomAttributes = default(List<string>), bool? filterValid = default(bool?), int? limit = default(int?), int? offset = default(int?), List<SortBy> sortBy = default(List<SortBy>), List<Fields> fields = default(List<Fields>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssuesApi.GetIssuesAsync(projectId, filterId, filterIssueTypeId, filterIssueSubtypeId, filterStatus, filterLinkedDocumentUrn, xAdsRegion, filterDueDate, filterStartDate, filterCreatedAt, filterCreatedBy, filterUpdatedAt, filterUpdatedBy, filterAssignedTo, filterRootCauseId, filterLocationId, filterSubLocationId, filterClosedBy, filterClosedAt, filterSearch, filterDisplayId, filterAssignedToType, filterCustomAttributes, filterValid, limit, offset, sortBy, fields, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <remarks>
                /// Updates an issue.  To verify whether a user can update issues for a specific project, call GET users/me.  To verify which attributes the user can update, call GET issues/:id and check the permittedAttributes and permittedStatuses lists.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId">The ID of the project.</param>/// <param name="issueId">The unique identifier of the issue.</param>/// <param name="contentType">Must be application/json</param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="issuePayload"> (optional)</param>
                /// <returns>Task of ApiResponse<Issue></returns>

                public async System.Threading.Tasks.Task<Issue> PatchIssueDetailsAsync(string projectId, string issueId, IssuePayload issuePayload, Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssuesApi.PatchIssueDetailsAsync(projectId, issueId, xAdsRegion, issuePayload, accessToken, throwOnError);
                        return response.Content;

                }
                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Returns the current user permissions.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId"></param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>
                /// <returns>Task of ApiResponse<User></returns>

                public async System.Threading.Tasks.Task<User> GetUserProfileAsync(string projectId, Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssuesProfileApi.GetUserProfileAsync(projectId, xAdsRegion, accessToken, throwOnError);
                        return response.Content;

                }
                /// <summary>
                /// Your GET endpoint
                /// </summary>
                /// <remarks>
                /// Retrieves a project’s categories and types.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="projectId"></param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="include">Use include&#x3D;subtypes to include the types (subtypes) for each category (type). (optional)</param>/// <param name="limit">Add limit&#x3D;20 to limit the results count (together with the offset to support pagination). (optional)</param>/// <param name="offset">Add offset&#x3D;20 to get partial results (together with the limit to support pagination). (optional)</param>/// <param name="filterUpdatedAt">Retrieves types that were last updated at the specified date and time, in in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterIsActive">Filter types by status e.g. filter[isActive]&#x3D;true will only return active types. Default value: undefined (meaning both active &amp; inactive issue type categories will return). (optional)</param>
                /// <returns>Task of ApiResponse<IssueType></returns>

                public async System.Threading.Tasks.Task<IssueType> GetIssuesTypesAsync(string projectId, string include = default(string), int? limit = default(int?), int? offset = default(int?), string filterUpdatedAt = default(string), bool? filterIsActive = default(bool?), Region xAdsRegion = default, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.IssueTypesApi.GetIssuesTypesAsync(projectId, include, limit, offset, filterUpdatedAt, filterIsActive, xAdsRegion, accessToken, throwOnError);
                        return response.Content;
                }
        }

}