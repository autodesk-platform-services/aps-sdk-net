using Autodesk.Construction.AccountAdmin.Model;
using Autodesk.Construction.AccountAdmin.Http;
using Autodesk.SDKManager;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace Autodesk.Construction.AccountAdmin
{
        public class AdminClient : BaseClient
        {
                public IProjectsApi ProjectsApi { get; }
                public IProjectUsersApi ProjectUsersApi { get; }
                public ICompaniesApi CompaniesApi { get; }
                public IAccountUsersApi AccountUsersApi { get; }
                public IBusinessUnitsApi BusinessUnitsApi { get; }
                public IUserProjectsApi UserProjectsApi { get; }

                public AdminClient( SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default): base(authenticationProvider)
                {
                        if(sdkManager == null){
                                sdkManager= SdkManagerBuilder.Create().Build();
                        }
                        this.ProjectsApi = new ProjectsApi(sdkManager);
                        this.ProjectUsersApi = new ProjectUsersApi(sdkManager);
                        this.CompaniesApi = new CompaniesApi(sdkManager);
                        this.AccountUsersApi = new AccountUsersApi(sdkManager);
                        this.BusinessUnitsApi = new BusinessUnitsApi(sdkManager);
                        this.UserProjectsApi = new UserProjectsApi(sdkManager);
                }
                
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="userId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="projectPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Project&gt;</returns>
                public async System.Threading.Tasks.Task<Project> CreateProjectAsync(string accountId, ProjectPayload projectPayload, string acceptLanguage= default(string), Region? region= null, string userId= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectsApi.CreateProjectAsync(accountId, acceptLanguage, region, userId, projectPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="userId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="fields">
                ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Project&gt;</returns>
                public async System.Threading.Tasks.Task<Project> GetProjectAsync(string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Fields> fields= default(List<Fields>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectsApi.GetProjectAsync(projectId, acceptLanguage, region, userId, fields, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProjectPatch&gt;></returns>
                public async System.Threading.Tasks.Task<ProjectPatch> CreateProjectImageAsync(string projectId, string accountId, System.IO.Stream body, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectsApi.CreateProjectImageAsync(projectId, accountId, body, region, accessToken, throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
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
                /// <returns>Task of ApiResponse&lt;ProjectsPage&gt;</returns>
        
                public async System.Threading.Tasks.Task<ProjectsPage> GetProjectsAsync(string accountId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Fields> fields= default(List<Fields>), List<Classification> filterClassification= default(List<Classification>), List<Platform> filterPlatform= default(List<Platform>), List<Products> filterProducts= default(List<Products>), string filterName= default(string), List<string> filterType= default(List<string>), List<Status> filterStatus= default(List<Status>), string filterBusinessUnitId= default(string), string filterJobNumber= default(string), string filterUpdatedAt= default(string), FilterTextMatch? filterTextMatch= null, List<SortBy> sort= default(List<SortBy>), int? limit= default(int?), int? offset= default(int?), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectsApi.GetProjectsAsync(accountId, acceptLanguage, region, userId, fields, filterClassification, filterPlatform, filterProducts, filterName, filterType, filterStatus, filterBusinessUnitId, filterJobNumber, filterUpdatedAt, filterTextMatch, sort, limit, offset, accessToken, throwOnError);
                        return response.Content;
                }

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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <param name="companyPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
                public async System.Threading.Tasks.Task<Company> CreateCompanyAsync(string accountId, CompanyPayload companyPayload, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.CreateCompanyAsync(accountId, region, companyPayload, accessToken, throwOnError );
                        return response.Content;
                }

                /// <summary>
                /// Get account companies
                /// </summary>
                /// <remarks>
                ///Returns a list of companies in an account.
                ///
                ///You can also use this endpoint to filter out the list of companies by setting the filter parameters.
                ///
                ///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="accountId">
                ///The ID of the ACC account that contains the project being created or the projects being retrieved. This corresponds to the hub ID in the Data Management API. To convert a hub ID into an account ID, remove the “b." prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
                /// </param>
                /// <param name="region">
                ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. For a complete list of supported regions, see the Regions page. (optional)
                /// </param>
                /// <param name="userId">
                ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId).  Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
                /// </param>
                /// <param name="filterName">
                ///Filter companies by name. Can be a partial match based on the value of filterTextMatch provided. Max length: 255 (optional)
                /// </param>
                /// <param name="filterTrade">
                ///Filter companies by trade. Can be a partial match based on the value of filterTextMatch provided. Max length: 255 (optional)
                /// </param>
                /// <param name="filterErpId">
                ///Filter companies by ERP Id. Can be a partial match based on the value of filterTextMatch provided. Max length: 255 (optional)
                /// </param>
                /// <param name="filterTaxId">
                ///Filter companies by tax Id. Can be a partial match based on the value of filterTextMatch provided. Max length: 255 (optional)
                /// </param>
                /// <param name="filterUpdatedAt">
                ///Filter companies by updated at date range. The range must be specified with dates in an ISO-8601 format with time required. The start and end dates of the range should be separated by .. One of the dates in the range may be omitted. For example, to get everything on or before June 1, 2019 the range would be ..2019-06-01T23:59:59.999Z. To get everything after June 1, 2019 the range would be 2019-06-01T00:00:00.000Z... Max length: 100 (optional)
                /// </param>
                /// <param name="orFilters">
                ///List of filtered fields to apply an “or” operator. Valid list of fields are erpId, name, taxId, trade, updatedAt. (optional)
                /// </param>
                /// <param name="filterTextMatch">
                ///Defines how text-based filters should match results. Possible values: contains (default) – Returns results where the text appears anywhere in the field. startsWith – Matches only if the field starts with the given value. endsWith – Matches only if the field ends with the given value. equals – Matches only if the field is an exact match. (optional)
                /// </param>
                /// <param name="sort">
                ///The list of fields to sort by. When multiple fields are listed the later property is used to sort the resources where the previous fields have the same value. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). If no direction is specified then asc is assumed. Valid fields for sorting are name, trade, erpId, taxId, status, createdAt, updatedAt, projectSize and userSize. Default sort is name. (optional)
                /// </param>
                /// <param name="fields">
                ///List of fields to return in the response. Defaults to all fields. Valid list of fields are accountId, name, trade, addresses, websiteUrl, description, erpId, taxId, imageUrl, status, createdAt, updatedAt, projectSize, userSize and originalName. (optional)
                /// </param>
                /// <param name="limit">
                ///The maximum number of records per request. Default: 20. Minimum: 1, Maximum: 200. If a value greater than 200 is provided, only 200 records are returned. (optional)
                /// </param>
                /// <param name="offset">
                ///The record number to start returning results from, used for pagination. For example, if limit=20 and offset=20, the request retrieves the second page of results. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;CompaniesPage&gt;</returns>
                public async System.Threading.Tasks.Task<CompaniesPage> GetCompaniesWithPaginationAsync(string accountId, Region? region= null, string userId= default(string), string filterName= default(string), string filterTrade= default(string), string filterErpId= default(string), string filterTaxId= default(string), string filterUpdatedAt= default(string), List<CompanyOrFilters> orFilters= default(List<CompanyOrFilters>), FilterTextMatch? filterTextMatch= null, List<FilterCompanySort> sort= default(List<FilterCompanySort>), List<FilterCompanyFields> fields= default(List<FilterCompanyFields>), int? limit= default(int?), int? offset= default(int?),  string accessToken = null, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.GetCompaniesWithPaginationAsync(accountId, region, userId, filterName, filterTrade, filterErpId, filterTaxId, filterUpdatedAt, orFilters, filterTextMatch, sort, fields, limit, offset, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
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
                public async System.Threading.Tasks.Task<List<Company>> GetCompaniesAsync(string accountId, Region? region= null, int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.GetCompaniesAsync(accountId, region, limit, offset, sort, field, accessToken,throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
                public async System.Threading.Tasks.Task<Company> GetCompanyAsync(string companyId, string accountId, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.GetCompanyAsync(companyId, accountId, region, accessToken, throwOnError);
                        return response.Content;
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
                /// <returns>Task of ApiResponse&lt;List&lt;ProjectCompanies&gt;&gt;</returns>
                public async System.Threading.Tasks.Task<List<ProjectCompanies>> GetProjectCompaniesAsync(string accountId, string projectId, Region? region= null, int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.GetProjectCompaniesAsync (accountId, projectId, region, limit, offset, sort, field, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <param name="companyPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;CompanyImport&gt;</returns>
                public async System.Threading.Tasks.Task<CompanyImport> ImportCompaniesAsync(string accountId, Region? region= null, List<CompanyPayload> companyPayload= default(List<CompanyPayload>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.ImportCompaniesAsync(accountId, region, companyPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <param name="companyPatchPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
                public async System.Threading.Tasks.Task<Company> PatchCompanyDetailsAsync(string companyId, string accountId, CompanyPatchPayload companyPatchPayload, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.PatchCompanyDetailsAsync(companyId, accountId, region, companyPatchPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;Company&gt;</returns>
                public async System.Threading.Tasks.Task<Company> PatchCompanyImageAsync(string companyId, string accountId, System.IO.Stream body, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.PatchCompanyImageAsync(companyId, accountId, body, region, accessToken, throwOnError);
                        return response.Content;
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
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
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
                public async System.Threading.Tasks.Task<List<Company>> SearchCompaniesAsync(string accountId, Region? region= null, string name= default(string), string trade= default(string), string _operator= default(string), bool? partial= default(bool?), int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.CompaniesApi.SearchCompaniesAsync(accountId,region, name, trade, _operator, partial, limit, offset, sort, field, accessToken, throwOnError);
                        return response.Content;
                }

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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="userId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="projectUserPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProjectUserDetails&gt;</returns>
                public async System.Threading.Tasks.Task<ProjectUserDetails> AssignProjectUserAsync(string projectId, ProjectUserPayload projectUserPayload, string acceptLanguage= default(string), Region? region= null, string userId= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.AssignProjectUserAsync(projectId, acceptLanguage, region, userId, projectUserPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="adminUserId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="fields">
                ///A comma-separated list of the project fields to include in the response. Default value: all fields. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProjectUser&gt;</returns>
                public async System.Threading.Tasks.Task<ProjectUser> GetProjectUserAsync(string projectId, string userId, string acceptLanguage= default(string), Region? region= null, string adminUserId= default(string), List<UserFields> fields= default(List<UserFields>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.GetProjectUserAsync(projectId, userId, acceptLanguage, region, adminUserId, fields, accessToken, throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
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
                /// <returns>Task of ApiResponse&lt;ProjectUsersPage&gt;</returns>
                public async System.Threading.Tasks.Task<ProjectUsersPage> GetProjectUsersAsync(string projectId, string acceptLanguage= default(string), Region? region= null, string userId= default(string), List<Products> filterProducts= default(List<Products>), string filterName= default(string), string filterEmail= default(string), List<StatusFilter> filterStatus= default(List<StatusFilter>), List<AccessLevels> filterAccessLevels= default(List<AccessLevels>), string filterCompanyId= default(string), string filterCompanyName= default(string), List<string> filterAutodeskId= default(List<string>), List<string> filterId= default(List<string>), string filterRoleId= default(string), List<string> filterRoleIds= default(List<string>), List<UserSortBy> sort= default(List<UserSortBy>), List<UserFields> fields= default(List<UserFields>), List<OrFilters> orFilters= default(List<OrFilters>), FilterTextMatch? filterTextMatch= null, int? limit= default(int?), int? offset= default(int?), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.GetProjectUsersAsync( projectId, acceptLanguage, region, userId,  filterProducts, filterName, filterEmail, filterStatus, filterAccessLevels, filterCompanyId, filterCompanyName, filterAutodeskId, filterId, filterRoleId, filterRoleIds, sort, fields, orFilters, filterTextMatch, limit, offset, accessToken,throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="userId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="projectUsersImportPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProjectUsersImport&gt;</returns>
                public async System.Threading.Tasks.Task<ProjectUsersImport> ImportProjectUsersAsync(string projectId, ProjectUsersImportPayload projectUsersImportPayload, string acceptLanguage= default(string), Region? region= null, string userId= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.ImportProjectUsersAsync(projectId, acceptLanguage, region, userId, projectUsersImportPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="adminUserId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>           
                /// <returns>Task of HttpResponseMessage</returns>
                public async System.Threading.Tasks.Task<HttpResponseMessage> RemoveProjectUserAsync(string projectId, string userId, string acceptLanguage= default(string), Region? region= null, string adminUserId= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.RemoveProjectUserAsync(projectId, userId, acceptLanguage, region, adminUserId, accessToken, throwOnError);
                        return response;
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
                ///The region where the bucket resides. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. (optional)
                /// </param>
                /// <param name="adminUserId">
                ///Note that this header is not relevant for Account Admin GET endpoints. The ID of a user on whose behalf your API request is acting. Required if you’re using a 2-legged authentication context, which must be 2-legged OAuth2 security with user impersonation.  Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request.  You can use either the user’s ACC ID (id), or their Autodesk ID (autodeskId). (optional)
                /// </param>
                /// <param name="projectUsersUpdatePayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProjectUserDetails&gt;</returns>
                public async System.Threading.Tasks.Task<ProjectUserDetails> UpdateProjectUserAsync(string projectId, string userId, ProjectUsersUpdatePayload projectUsersUpdatePayload, string acceptLanguage= default(string), Region? region= null, string adminUserId= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.ProjectUsersApi.UpdateProjectUserAsync(projectId, userId, acceptLanguage, region, adminUserId, projectUsersUpdatePayload, accessToken, throwOnError);
                        return response.Content;
                }

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
                public async System.Threading.Tasks.Task<User> CreateUserAsync(string accountId, UserPayload userPayload, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.CreateUserAsync(accountId, region, userPayload, accessToken, throwOnError);
                        return response.Content;
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
                /// <returns>Task of ApiResponse&lt;User&gt;</returns>                
                public async System.Threading.Tasks.Task<User> GetUserAsync(string accountId, string userId, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.GetUserAsync(accountId, userId, region, accessToken, throwOnError);
                        return response.Content;
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
                /// <returns>Task of ApiResponse&lt;List&lt;User&gt;&gt;</returns>
                public async System.Threading.Tasks.Task<List<User>> GetUsersAsync(string accountId, Region? region= null, int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.GetUsersAsync(accountId, region, limit, offset, sort, field, accessToken, throwOnError);
                        return response.Content;
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
                /// <returns>Task of ApiResponse&lt;UserImport&gt;</returns>
                public async System.Threading.Tasks.Task<UserImport> ImportUsersAsync(string accountId, Region? region= null, List<UserPayload> userPayload= default(List<UserPayload>), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.ImportUsersAsync(accountId, region, userPayload, accessToken, throwOnError);
                        return response.Content;
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
                /// <returns>Task of ApiResponse&lt;User&gt;</returns>
                public async System.Threading.Tasks.Task<User> PatchUserDetailsAsync(string accountId, string userId, UserPatchPayload userPatchPayload, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.PatchUserDetailsAsync(accountId, userId, region, userPatchPayload, accessToken, throwOnError);
                        return response.Content;
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
                ///Response array's size Default value: 10 Max limit: 100 (optional)
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
                
                public async System.Threading.Tasks.Task<List<User>> SearchUsersAsync(string accountId, Region? region= null, string name= default(string), string email= default(string), string companyName= default(string), string _operator= default(string), bool? partial= default(bool?), int? limit= default(int?), int? offset= default(int?), string sort= default(string), string field= default(string), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.SearchUsersAsync(accountId, region, name, email, companyName, _operator, partial, limit, offset, sort, field, accessToken, throwOnError);
                        return response.Content;
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
                ///The account ID of the user.
                /// </param>
                /// <param name="userId">
                ///The ID of the user.
                /// </param>
                /// <param name="region">
                ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
                /// </param>
                /// <param name="adminUserId">
                ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request. You can use either the user's ACC ID (id), or their Autodesk ID (autodeskId). Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
                /// </param>
                /// <param name="filterProjectId">
                ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
                /// </param>
                /// <param name="filterKey">
                ///Filters the list of products by product key — a machine-readable identifier for an ACC product (such as docs, build, or cost). You can specify one or more keys to return only those products the user is associated with. Example: filter[key]=docs,build Possible values: accountAdministration, autoSpecs, build, buildingConnected, capitalPlanning, cloudWorksharing, cost, designCollaboration, docs, financials, insight, modelCoordination, projectAdministration, takeoff, and workshopxr. (optional)
                /// </param>
                /// <param name="fields">
                ///List of fields to return in the response. Defaults to all fields. Possible values: projectIds, name and icon. (optional)
                /// </param>
                /// <param name="sort">
                ///The list of fields to sort by. Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc. Possible values: name. Default is the order in database. (optional)
                /// </param>
                /// <param name="limit">
                ///The maximum number of records to return in the response. Default: 20 Minimum: 1 Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
                /// </param>
                /// <param name="offset">
                ///The index of the first record to return. Used for pagination in combination with the limit parameter. Example: limit=20 and offset=40 returns records 41–60. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;ProductsPage&gt;</returns>
                public async System.Threading.Tasks.Task<ProductsPage> GetUserProductsAsync(string accountId, string userId, Region? region = null, string adminUserId = default(string), List<string> filterProjectId = default(List<string>), List<FilterProductKey> filterKey = default(List<FilterProductKey>), List<FilterProductField> fields = default(List<FilterProductField>), List<FilterProductSort> sort = default(List<FilterProductSort>), int? limit = default(int?), int? offset = default(int?), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.GetUserProductsAsync(accountId, userId, region, adminUserId, filterProjectId, filterKey, fields, sort, limit, offset, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// Get user roles
                /// </summary>
                /// <remarks>
                ///Returns the roles assigned to a specific user across the projects they belong to.
                ///
                ///Only users with account admin permissions can call this endpoint. To verify a user's permissions, call GET users.
                ///
                ///Note that this endpoint is compatible with both BIM 360 and Autodesk Construction Cloud (ACC) projects.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="accountId">
                ///The account ID of the user.
                /// </param>
                /// <param name="userId">
                ///The ID of the user.
                /// </param>
                /// <param name="region">
                ///Specifies the region where your request should be routed. If not set, the request is routed automatically, which may result in a slight increase in latency. Possible values: US, EMEA. For a complete list of supported regions, see the Regions page. (optional)
                /// </param>
                /// <param name="adminUserId">
                ///The ID of a user on whose behalf your request is acting. Your app has access to all users specified by the administrator in the SaaS integrations UI. Provide this header value to identify the user to be affected by the request. You can use either the user's ACC ID (id), or their Autodesk ID (autodeskId). Note that this header is required for Account Admin POST, PATCH, and DELETE endpoints if you want to use a 2-legged authentication context. This header is optional for Account Admin GET endpoints. (optional)
                /// </param>
                /// <param name="filterProjectId">
                ///A list of project IDs. Only results where the user is associated with one or more of the specified projects are returned. (optional)
                /// </param>
                /// <param name="filterStatus">
                ///Filters roles by their status. Accepts one or more of the following values: active – The role is currently in use. inactive – The role has been removed or is no longer in use. (optional)
                /// </param>
                /// <param name="filterName">
                ///Filters roles by name. By default, this performs a partial match (case-insensitive).  You can control how the match behaves by using the filterTextMatch parameter. For example, to match only names that start with (startsWith), end with (endsWith), or exactly equal (equals) the provided value. (optional)
                /// </param>
                /// <param name="filterTextMatch">
                ///Specifies how text-based filters should match values in supported fields. This parameter can be used in any endpoint that supports text-based filtering (e.g., filter[name], filter[jobNumber], filter[companyName], etc.). Possible values: contains (default) – Matches if the field contains the specified text anywhere startsWith – Matches if the field starts with the specified text endsWith – Matches if the field ends with the specified text equals – Matches only if the field exactly matches the specified text Matching is case-insensitive. Wildcards and regular expressions are not supported. (optional)
                /// </param>
                /// <param name="fields">
                ///Comma-separated list of response fields to include. Defaults to all fields if not specified. Use this parameter to reduce the response size by retrieving only the fields you need. Possible values: projectIds – Projects where the user holds this role name – Role name status – Role status (active or inactive) key – Internal key used to translate the role name createdAt – Timestamp when the role was created updatedAt – Timestamp when the role was last updated (optional)
                /// </param>
                /// <param name="sort">
                ///Sorts the results by one or more fields. Each field can be followed by a direction modifier: asc – Ascending order (default) desc – Descending order Possible values: name, createdAt, updatedAt. Default sort: name asc Example: sort=name,updatedAt desc (optional)
                /// </param>
                /// <param name="limit">
                ///The maximum number of records to return in the response. Default: 20 Minimum: 1 Maximum: 200 (If a larger value is provided, only 200 records are returned) (optional)
                /// </param>
                /// <param name="offset">
                ///The index of the first record to return. Used for pagination in combination with the limit parameter. Example: limit=20 and offset=40 returns records 41–60. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;RolesPage&gt;</returns>
                public async System.Threading.Tasks.Task<RolesPage> GetUserRolesAsync(string accountId, string userId, Region? region = null, string adminUserId = default(string), List<string> filterProjectId = default(List<string>), List<FilterRoleStatus> filterStatus = default(List<FilterRoleStatus>), string filterName = default(string), FilterTextMatch? filterTextMatch = null, List<FilterRoleField> fields = default(List<FilterRoleField>), List<FilterRoleSort> sort = default(List<FilterRoleSort>), int? limit = default(int?), int? offset = default(int?), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.AccountUsersApi.GetUserRolesAsync(accountId, userId, region, adminUserId, filterProjectId, filterStatus, filterName, filterTextMatch, fields, sort, limit, offset, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// Create Business Units
                /// </summary>
                /// <remarks>
                ///Query all the business units in a specific BIM 360 account.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="accountId">
                ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
                /// </param>
                /// <param name="region">
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <param name="businessUnitsPayload">
                /// (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;BusinessUnits&gt;</returns>                
                public async System.Threading.Tasks.Task<BusinessUnits> CreateBusinessUnitsAsync(string accountId, Region? region= null, BusinessUnitsPayload businessUnitsPayload= default(BusinessUnitsPayload), string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.BusinessUnitsApi.CreateBusinessUnitsAsync(accountId, region, businessUnitsPayload, accessToken, throwOnError);
                        return response.Content;
                }

                /// <summary>
                /// Get Business Units
                /// </summary>
                /// <remarks>
                ///Query all the business units in a specific BIM 360 account.
                /// </remarks>
                /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
                /// <param name="accountId">
                ///The account ID of the business unit. This corresponds to hub ID in the Data Management API. To convert a hub ID into an account ID you need to remove the “b.” prefix. For example, a hub ID of b.c8b0c73d-3ae9 translates to an account ID of c8b0c73d-3ae9.
                /// </param>
                /// <param name="region">
                ///The geographic area where the data is stored. Acceptable values: US, EMEA, AUS, CAN, DEU, IND, JPN, GBR. By default, it is set to US. (optional)
                /// </param>
                /// <returns>Task of ApiResponse&lt;BusinessUnits&gt;</returns>        
                public async System.Threading.Tasks.Task<BusinessUnits> GetBusinessUnitsAsync(string accountId, Region? region= null, string accessToken = default, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.BusinessUnitsApi.GetBusinessUnitsAsync(accountId, region, accessToken, throwOnError);
                        return response.Content;
                }
      
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
                /// <param name="adminUserId">
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
                public async System.Threading.Tasks.Task<UserProjectsPage> GetUserProjectsAsync(string accountId, string userId, Region? region= null, string adminUserId= default(string), List<string> filterId= default(List<string>), List<UserProjectFields> fields= default(List<UserProjectFields>), List<Classification> filterClassification= default(List<Classification>), string filterName= default(string), List<Platform> filterPlatform= default(List<Platform>), List<Status> filterStatus= default(List<Status>), List<string> filterType= default(List<string>), string filterJobNumber= default(string), string filterUpdatedAt= default(string), List<FilterUserProjectsAccessLevels> filterAccessLevels= default(List<FilterUserProjectsAccessLevels>), FilterTextMatch? filterTextMatch= null, List<UserProjectSortBy> sort= default(List<UserProjectSortBy>), int? limit= default(int?), int? offset= default(int?), string accessToken = null, bool throwOnError = true)
                {
                        if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
                        {
                                throw new Exception("Please provide a valid access token or an authentication provider");
                        }
                        else if (String.IsNullOrEmpty(accessToken))
                        {
                                accessToken = await this.AuthenticationProvider.GetAccessToken();
                        }
                        var response = await this.UserProjectsApi.GetUserProjectsAsync(accountId, userId, region, adminUserId , filterId, fields, filterClassification, filterName, filterPlatform, filterStatus, filterType, filterJobNumber, filterUpdatedAt, filterAccessLevels, filterTextMatch, sort, limit, offset, accessToken, throwOnError);
                        return response.Content;
                }
        }
}