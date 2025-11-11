using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using Autodesk.DataManagement.Client;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using Autodesk.SDKManager;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;



namespace Autodesk.DataManagement
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DataManagementClient : BaseClient
    {
        /// <summary>
        /// Gets the instance of the ICommandsApi interface.
        /// </summary>
        public ICommandsApi CommandsApi { get; }
        /// <summary>
        /// Gets the instance of the IFoldersApi interface.
        /// </summary>
        public IFoldersApi FoldersApi { get; }
        /// <summary>
        /// Gets the instance of the IHubsApi interface.
        /// </summary>
        public IHubsApi HubsApi { get; }
        /// <summary>
        /// Gets the instance of the IItemsApi interface.
        /// </summary>
        public IItemsApi ItemsApi { get; }
        /// <summary>
        /// Gets the instance of the IProjectsApi interface.
        /// </summary>
        public IProjectsApi ProjectsApi { get; }
        /// <summary>
        /// Gets the instance of the IVersionsApi interface.
        /// </summary>
        public IVersionsApi VersionsApi { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataManagementClient"/> class.
        /// </summary>
        /// <param name="sdkManager">The SDK manager.</param>
        /// <param name="authenticationProvider">The authentication provider.</param>
        public DataManagementClient(SDKManager.SDKManager sdkManager = default, IAuthenticationProvider authenticationProvider = default) : base(authenticationProvider)
        {
            if (sdkManager == null)
            {
                sdkManager = SdkManagerBuilder.Create().Build();
            }

            this.CommandsApi = new CommandsApi(sdkManager);
            this.FoldersApi = new FoldersApi(sdkManager);
            this.HubsApi = new HubsApi(sdkManager);
            this.ItemsApi = new ItemsApi(sdkManager);
            this.ProjectsApi = new ProjectsApi(sdkManager);
            this.VersionsApi = new VersionsApi(sdkManager);
        }

        #region HubsApi
        /// <summary>
        /// List Hubs
        /// </summary>
        /// <remarks>
        ///Returns a collection of hubs that the user of your app can access.
        ///
        ///The returned hubs can be BIM 360 Team hubs, Fusion Team hubs (formerly known as A360 Team hubs), A360 Personal hubs, ACC Docs (Autodesk Docs) accounts, or BIM 360 Docs accounts. Only active hubs are returned.
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterName">
        ///Filter by the `name` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Hubs</returns>

        public async System.Threading.Tasks.Task<Hubs> GetHubsAsync(string xUserId = default(string), List<string> filterId = default(List<string>), List<string> filterName = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HubsApi.GetHubsAsync(xUserId, filterId, filterName, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Get a Hub
        /// </summary>
        /// <remarks>
        ///Returns the hub specified by the `hub_id` parameter.
        ///
        ///For BIM 360 Docs, a hub ID corresponds to a BIM 360 account ID. To convert a BIM 360 account ID to a hub ID, prefix the account ID with `b.`. For example, an account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="hubId">
        ///The unique identifier of a hub.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Hub</returns>

        public async System.Threading.Tasks.Task<Hub> GetHubAsync(string hubId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.HubsApi.GetHubAsync(hubId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        #endregion HubsApi

        #region ProjectsApi
        /// <summary>
        /// Get Projects
        /// </summary>
        /// <remarks>
        ///Returns a collection of active projects within the specified hub. The returned projects can be Autodesk Construction Cloud (ACC), BIM 360, BIM 360 Team, Fusion Team, and A360 Personal projects. 
        ///
        ///For BIM 360 and ACC projects a hub ID corresponds to an Account ID. To convert an Account ID to a hub ID, prefix the account ID with `b.`. For example, a BIM 360 account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert a BIM 360 and ACC project IDs to  Data Management project IDs prefix the BIM 360 or ACC Project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="hubId">
        ///The unique identifier of a hub.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <param name="pageLimit">
        ///Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Projects</returns>

        public async System.Threading.Tasks.Task<Projects> GetHubProjectsAsync(string hubId, string xUserId = default(string), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), int pageNumber = 0, int pageLimit = 200, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetHubProjectsAsync(hubId, xUserId, filterId, filterExtensionType, pageNumber, pageLimit, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Get a Project
        /// </summary>
        /// <remarks>
        ///Returns the specified project from within the specified hub.
        ///
        ///For BIM 360 Docs, a hub ID corresponds to a BIM 360 account ID. To convert a BIM 360 account ID to a hub ID, prefix the account ID with `b.`. For example, an account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert a BIM 360 project ID to a Data Management project ID prefix the BIM 360 Project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="hubId">
        ///The unique identifier of a hub.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Project</returns>

        public async System.Threading.Tasks.Task<Project> GetProjectAsync(string hubId, string projectId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetProjectAsync(hubId, projectId, xUserId, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Get Hub for Project
        /// </summary>
        /// <remarks>
        ///Returns the hub that contains the project specified by the  `project_id` parameter.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="hubId">
        ///The unique identifier of a hub.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Hub</returns>

        public async System.Threading.Tasks.Task<Hub> GetProjectHubAsync(string hubId, string projectId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetProjectHubAsync(hubId, projectId, xUserId, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// List Top-level Project Folders
        /// </summary>
        /// <remarks>
        ///Returns the details of the highest level folders within a project that the user calling this operation has access to. The user must have at least read access to the folders.
        ///
        ///If the user is a Project Admin, it returns all top-level folders in the project. Otherwise, it returns all the highest level folders in the folder hierarchy the user has access to.
        ///
        ///Users with access permission to a folder has access permission to all its subfolders.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="hubId">
        ///The unique identifier of a hub.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="excludeDeleted">
        ///Specifies whether deleted folders are excluded from the response for BIM 360 Docs projects, when user context is provided. 
        ///
        ///- `true`: Response excludes deleted folders for BIM 360 Docs projects.  
        ///- `false`: (Default) Response will not exclude deleted folders for BIM 360 Docs projects. (optional)
        /// </param>
        /// <param name="projectFilesOnly">
        ///Specifies what folders and subfolders to return for BIM 360 Docs projects, when user context is provided. 
        ///
        ///- `true`: Response will be restricted to folder and subfolders containing project files for BIM 360 Docs projects.  
        ///- `false`: (Default) Response will include all available folders. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of TopFolders</returns>

        public async System.Threading.Tasks.Task<TopFolders> GetProjectTopFoldersAsync(string hubId, string projectId, string xUserId = default(string), bool excludeDeleted = false, bool projectFilesOnly = false, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetProjectTopFoldersAsync(hubId, projectId, xUserId, excludeDeleted, projectFilesOnly, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Get Download Details
        /// </summary>
        /// <remarks>
        ///Returns the details of a downloadable format of a version of an item.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="downloadId">
        ///The Job ID of the job used to generate the download.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Download</returns>

        public async System.Threading.Tasks.Task<Download> GetDownloadAsync(string projectId, string downloadId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetDownloadAsync(projectId, downloadId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Check Download Creation Progress
        /// </summary>
        /// <remarks>
        ///Checks the status of a job that generates a downloadable format of a version of an item. 
        ///
        ///**Note**: If the job has finished, this operation returns a HTTP status 303, with the `location` return header set to the URI that returns the details of the download.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="jobId">
        ///The unique identifier of a job.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Job</returns>

        public async System.Threading.Tasks.Task<Job> GetDownloadJobAsync(string projectId, string jobId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.GetDownloadJobAsync(projectId, jobId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create Download
        /// </summary>
        /// <remarks>
        ///Kicks off a job to generate the specified download format of the version. Once the job completes, the specified format becomes available for download. 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="downloadPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of CreatedDownload</returns>

        public async System.Threading.Tasks.Task<CreatedDownload> CreateDownloadAsync(string projectId, DownloadPayload downloadPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.CreateDownloadAsync(projectId, xUserId, downloadPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create a Storage Location in OSS
        /// </summary>
        /// <remarks>
        ///Creates a placeholder for an item or a version of an item in the OSS. Later, you can upload the binary content for the item or version to this storage location.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="storagePayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Storage</returns>

        public async System.Threading.Tasks.Task<Storage> CreateStorageAsync(string projectId, StoragePayload storagePayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ProjectsApi.CreateStorageAsync(projectId, xUserId, storagePayload, accessToken, throwOnError);
            return response.Content;
        }
        #endregion ProjectsApi

        #region FoldersApi

        /// <summary>
        /// Get a Folder
        /// </summary>
        /// <remarks>
        ///Returns the folder specified by the `folder_id` parameter from within the project identified by the `project_id` parameter. All folders and subfolders within a project (including the root folder) have a unique ID.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="ifModifiedSince">
        ///Specify a date in the `YYYY-MM-DDThh:mm:ss.sz` format. If the resource has not been modified since the specified date/time, the response will return a HTTP status of 304 without any response body; the `Last-Modified` response header will contain the date of last modification. (optional)
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Folder</returns>

        public async System.Threading.Tasks.Task<Folder> GetFolderAsync(string projectId, string folderId, DateTime ifModifiedSince = default(DateTime), string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderAsync(projectId, folderId, ifModifiedSince, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Folder Contents
        /// </summary>
        /// <remarks>
        ///Returns a list of items and folders within the specified folder. Items represent word documents, fusion design files, drawings, spreadsheets, etc.
        ///
        ///The resources contained in the `included` array of the response are their tip versions.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the type of the objects in the folder. Supported values are `folders` and `items`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="filterLastModifiedTimeRollup">
        ///Filter by the `lastModifiedTimeRollup` attribute. Supported values are date-time string in the form `YYYY-MM-DDTHH:MM:SS.000000Z` or `YYYY-MM-DDTHH:MM:SS` based on RFC3339. (optional)
        /// </param>
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <param name="pageLimit">
        ///Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)
        /// </param>
        /// <param name="includeHidden">
        ///`true`: Response will contain items and folders that were deleted from BIM 360 Docs projects. 
        ///
        ///`false`: (Default): Response will not contain items and folders that were deleted from BIM 360 Docs projects.  
        ///
        ///To return only items and folders that were deleted from BIM 360 Docs projects, see the documentation on [Filtering](/en/docs/data/v2/overview/filtering/). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of FolderContents</returns>

        public async System.Threading.Tasks.Task<FolderContents> GetFolderContentsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterType> filterType = default(List<FilterType>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<string> filterLastModifiedTimeRollup = default(List<string>), int pageNumber = 0, int pageLimit = 200, bool includeHidden = false, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderContentsAsync(projectId, folderId, xUserId, filterType, filterId, filterExtensionType, filterLastModifiedTimeRollup, pageNumber, pageLimit, includeHidden, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Get Parent of a Folder
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified folder. In a project, folders are organized in a hierarchy. Each folder except for the root folder has a parent folder.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Folder</returns>

        public async System.Threading.Tasks.Task<Folder> GetFolderParentAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderParentAsync(projectId, folderId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Related Resources for a Folder
        /// </summary>
        /// <remarks>
        ///Returns the resources (items, folders, and versions) that have a custom relationship with the specified folder. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).
        ///
        ///Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links.
        ///Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of FolderRefs</returns>

        public async System.Threading.Tasks.Task<FolderRefs> GetFolderRefsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderRefsAsync(projectId, folderId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Relationship Links for a Folder
        /// </summary>
        /// <remarks>
        ///Returns a list of links for the specified folder. 
        ///
        ///Custom relationships can be established between a folder and other external resources residing outside the data domain service. A link’s `href` attribute defines the target URI to access a resource.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipLinks</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetFolderRelationshipsLinksAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderRelationshipsLinksAsync(projectId, folderId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Custom Relationships for a Folder
        /// </summary>
        /// <remarks>
        ///Returns the custom relationships associated with the specified folder. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).
        ///
        ///Each relationship is defined by the ID of the object at the other end of the relationship, together with type, specific reference meta including extension data.
        ///Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///The response body will have an included array that contains the resources in the relationship, which is essentially what is returned by the [List Related Resources for a Folder](/en/docs/data/v2/reference/http/projects-project_id-folders-folder_id-refs-GET/) operation.  
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterRefType">
        ///Filter by `refType`. Possible values: `derived`, `dependencies`, `auxiliary`, `xrefs`, and `includes`. (optional)
        /// </param>
        /// <param name="filterDirection">
        ///Filter by the direction of the reference. Possible values: `from` and `to`. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipRefs</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetFolderRelationshipsRefsAsync(string folderId, string projectId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), FilterRefType filterRefType = default, FilterDirection filterDirection = default, List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.GetFolderRelationshipsRefsAsync(folderId, projectId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Folder and Subfolder Contents
        /// </summary>
        /// <remarks>
        ///Searches the specified folder and its subfolders and returns a list of the latest versions of the items you can access.
        ///
        ///
        ///Use the `filter` query string parameter to narrow down the list as appropriate. You can filter by the following properties of the version payload: 
        ///
        ///- `type` property, 
        ///- `id` property, 
        ///- any of the attributes object properties. 
        ///
        ///For example, you can filter by `createTime` and `mimeType`. It returns tip versions (latest versions) of properties where the filter conditions are satisfied. To verify the properties of the attributes object for a specific version, use the [Get a Version](/en/docs/data/v2/reference/http/projects-project_id-versions-version_id-GET/) operation.
        ///
        ///To list the immediate contents of the folder without parsing subfolders, use the [List Folder Contents](/en/docs/data/v2/reference/http/projects-project_id-folders-folder_id-contents-GET/) operation.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="filterFieldName"></param>
                /// Field name for filtering the data. See the [Filtering](/en/docs/data/v2/overview/filtering/) section for details. (optional)
                /// <param name="filterValue"></param>
                /// Value to match the filter with. See the [Filtering](/en/docs/data/v2/overview/filtering/) section for details. (optional)
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Search</returns>

        public async System.Threading.Tasks.Task<Search> GetFolderSearchAsync(
            string projectId,
            string folderId,
            List<(string fieldName, ComparisonTypes? operatorType, List<string> values)> filters = null,
            int pageNumber = 0,
            string accessToken = default,
            bool throwOnError = true)
        {
            // Ensure access token is available
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }

            // Call the API with the complex filters
            var response = await this.FoldersApi.GetFolderSearchAsync(
                projectId,
                folderId,
                filters,   // Pass the complex filters list
                pageNumber,
                accessToken,
                throwOnError
            );

            // Return the content of the response (Search object)
            return response.Content;
        }

        /// <summary>
        /// Modify a Folder
        /// </summary>
        /// <remarks>
        ///Renames, moves, hides, or unhides a folder. Marking a BIM 360 Docs folder as hidden effectively deletes it. You can restore it by changing its `hidden` attribute. You can also move BIM 360 Docs folders by changing their parent folder.
        ///
        ///You cannot permanently delete BIM 360 Docs folders. They are tagged as hidden folders and are removed from the BIM 360 Docs UI and from regular Data Management API responses. You can use the hidden filter (`filter[hidden]=true`) to get a list of deleted folders with the [List Folder Contents](/en/docs/data/v2/reference/http/projects-project_id-folders-folder_id-contents-GET/) operation.
        ///
        ///Before you use the Data Management API to access BIM 360 Docs folders, provision your app through the BIM 360 Account Administrator portal. For details, see the [Manage Access to Docs tutorial](/en/docs/bim360/v1/tutorials/getting-started/manage-access-to-docs/).
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](/en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="modifyFolderPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Folder</returns>

        public async System.Threading.Tasks.Task<Folder> PatchFolderAsync(string projectId, string folderId, ModifyFolderPayload modifyFolderPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.PatchFolderAsync(projectId, folderId, xUserId, modifyFolderPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create a Folder
        /// </summary>
        /// <remarks>
        ///Creates a new folder in the specified project. Use the `parent` attribute in the request body to specify where in the hierarchy the new folder should be located. Folders can be nested up to 25 levels deep.
        ///
        ///Use the [Modify a Folder](/en/docs/data/v2/reference/http/projects-project_id-folders-folder_id-PATCH/) operation to delete and restore folders.
        ///
        ///Before you use the Data Management API to access BIM 360 Docs folders, provision your app through the BIM 360 Account Administrator portal. For details, see the [Manage Access to Docs tutorial](/en/docs/bim360/v1/tutorials/getting-started/manage-access-to-docs/).
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="folderPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Folder</returns>

        public async System.Threading.Tasks.Task<Folder> CreateFolderAsync(string projectId, FolderPayload folderPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.CreateFolderAsync(projectId, xUserId, folderPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create a Custom Relationship for a Folder
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="folderId">
        ///The unique identifier of a folder.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="relationshipRefsPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync(string folderId, string projectId, RelationshipRefsPayload relationshipRefsPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.FoldersApi.CreateFolderRelationshipsRefAsync(folderId, projectId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }

        #endregion FoldersApi

        #region ItemsApi
        /// <summary>
        /// Get an Item
        /// </summary>
        /// <remarks>
        ///Retrieves an item. Items represent Word documents, Fusion 360 design files, drawings, spreadsheets, etc.
        ///
        ///The tip version for the item is included in the included array of the payload.
        ///To retrieve multiple items, see the ListItems command.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="includePathInProject">
        ///Specify whether to return `pathInProject` attribute in response for BIM 360 Docs projects. `pathInProject` is the relative path of the item starting from project’s root folder. 
        ///
        ///- `true`: Response will include the `pathInProject` attribute for BIM 360 Docs projects.  
        ///- `false`: (Default) Response will not include `pathInProject` attribute for BIM 360 Docs projects. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Item</returns>

        public async System.Threading.Tasks.Task<Item> GetItemAsync(string projectId, string itemId, string xUserId = default(string), bool includePathInProject = false, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemAsync(projectId, itemId, xUserId, includePathInProject, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Get Parent of an Item
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified item.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Folder</returns>

        public async System.Threading.Tasks.Task<Folder> GetItemParentFolderAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemParentFolderAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Related Resources for an Item
        /// </summary>
        /// <remarks>
        ///Returns the resources (items, folders, and versions) that have a custom relationship with the specified item. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).
        ///
        ///
        ///Each relationship is defined by the ID of the object at the other end of the relationship, together with type, attributes, and relationships links.
        ///Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Refs</returns>

        public async System.Threading.Tasks.Task<Refs> GetItemRefsAsync(string projectId, string itemId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemRefsAsync(projectId, itemId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Relationship Links for an Item
        /// </summary>
        /// <remarks>
        ///Returns a list of links for the specified item. 
        ///
        ///Custom relationships can be established between an item and other external resources residing outside the data domain service. A link’s `href` attribute defines the target URI to access a resource.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipLinks</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetItemRelationshipsLinksAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemRelationshipsLinksAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Custom Relationships for an Item
        /// </summary>
        /// <remarks>
        ///Returns the custom relationships that are associated with the specified item. Custom relationships can be established between an item and other resources within the `data` domain service (folders, items, and versions).
        ///
        ///Each relationship is defined by the ID of the object at the other end of the relationship, together with type, specific reference meta including extension data.
        ///Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///The response body will have an included array that contains the resources in the relationship, which is essentially what is returned by the [List Related Resources for an Item](/en/docs/data/v2/reference/http/projects-project_id-items-item_id-refs-GET/) operation.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterRefType">
        ///Filter by `refType`. Possible values: `derived`, `dependencies`, `auxiliary`, `xrefs`, and `includes`. (optional)
        /// </param>
        /// <param name="filterDirection">
        ///Filter by the direction of the reference. Possible values: `from` and `to`. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipRefs</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetItemRelationshipsRefsAsync(string projectId, string itemId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), FilterRefType filterRefType = default, FilterDirection filterDirection = default, List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemRelationshipsRefsAsync(projectId, itemId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Get Tip Version of an Item
        /// </summary>
        /// <remarks>
        ///Returns the latest version of the specified item. A project can contain multiple versions of a resource item. The latest version is referred to as the tip version, which is returned by this operation.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of ItemTip</returns>

        public async System.Threading.Tasks.Task<ItemTip> GetItemTipAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.GetItemTipAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List all Versions of an Item
        /// </summary>
        /// <remarks>
        ///Lists all versions of the specified item. A project can contain multiple versions of a resource item.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="filterVersionNumber">
        ///Filter by versionNumber. (optional)
        /// </param>
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <param name="pageLimit">
        ///Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Versions</returns>

        public async System.Threading.Tasks.Task<Versions> GetItemVersionsAsync(string projectId, string itemId, string xUserId = default(string), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<int> filterVersionNumber = default(List<int>), int pageNumber = 0, int pageLimit = 200, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            // var nonNullableFilterVersionNumber = filterVersionNumber?.Where(v => v.HasValue).Select(v => v.Value).ToList() ?? new List<int>();
            var response = await this.ItemsApi.GetItemVersionsAsync(projectId, itemId, xUserId, filterId, filterExtensionType, filterVersionNumber, pageNumber, pageLimit, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Update an Item
        /// </summary>
        /// <remarks>
        ///Updates the `displayName` of the specified item. Note that updating the `displayName` of an item is not supported for BIM 360 Docs or ACC items.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="modifyItemPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Item</returns>

        public async System.Threading.Tasks.Task<Item> PatchItemAsync(string projectId, string itemId, ModifyItemPayload modifyItemPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.PatchItemAsync(projectId, itemId, xUserId, modifyItemPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create an Item
        /// </summary>
        /// <remarks>
        ///Creates the first version of a file (item). To create additional versions of an item, use POST versions.
        ///
        ///Before you create the first version of an item, you must create a placeholder for the file, and upload the file to the placeholder. For more details about the workflow, see the tutorial on uploading a file.
        ///
        ///This operation also allows you to create a new item by copying a specific version of an existing item to another folder. The copied version becomes the first version of the new item in the target folder.
        ///
        ///**Note:** You cannot copy versions of items across different projects and accounts.
        ///
        ///Use the [Create Version](/en/docs/data/v2/reference/http/projects-project_id-versions-POST/) operation with the `copyFrom` parameter if you want to create a new version of an item by copying a specific version of another item. 
        ///
        ///Before you use the Data Management API to access BIM 360 Docs files, you must provision your app through the BIM 360 Account Administrator portal. For details, see the [Manage Access to Docs tutorial](/en/docs/bim360/v1/tutorials/getting-started/manage-access-to-docs/).
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="copyFrom">
        ///The Version ID (URN) of the version to copy from. 
        ///
        ///**Note**: This parameter is relevant only for copying files to BIM 360 Docs.
        ///
        ///For information on how to find the URN, see the initial steps of the [Download a File](/en/docs/data/v2/tutorials/download-file/) tutorial.
        ///
        ///You can only copy files to the Plans folder or to subfolders of the Plans folder with an `item:autodesk.bim360:Document` item extension type. You can only copy files to the Project Files folder or to subfolders of the Project Files folder with an `item:autodesk.bim360:File` item extension type.  
        ///
        ///To verify an item’s extension type, use the [Get an Item](/en/docs/data/v2/reference/http/projects-project_id-items-item_id-GET/) operation, and check the `attributes.extension.type` attribute.  
        ///
        ///Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if users of your app did not have permission to download files in the source folder, but does have permission to download files in the target folder, they will not be able to download the copied file.  
        ///
        ///Note that you cannot copy a file while it is being uploaded, updated, or copied. To verify the current process state of a file, call the [Get an Item](en/docs/data/v2/reference/http/projects-project_id-items-item_id-GET/) operation , and check the `attributes.extension.data.processState` attribute. (optional)
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified.        
        ///
        ///Note that for a three-legged OAuth flow or for a two-legged OAuth flow with user impersonation (`x-user-id`), the users of your app must have permission to upload files to the specified parent folder (`data.attributes.relationships.parent.data.id`).
        ///
        ///For copying files, users of your app must have permission to view the source folder. 
        ///
        ///For information about managing and verifying folder permissions for BIM 360 Docs, see the section on [Managing Folder Permissions](http://help.autodesk.com/view/BIM360D/ENU/?guid=GUID-2643FEEF-B48A-45A1-B354-797DAD628C37).' (optional)
        /// </param>
        /// <param name="itemPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of CreatedItem</returns>

        public async System.Threading.Tasks.Task<CreatedItem> CreateItemAsync(string projectId, ItemPayload itemPayload, string copyFrom = default(string), string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.CreateItemAsync(projectId, copyFrom, xUserId, itemPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create a Custom Relationship for an Item
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="itemId">
        ///The unique identifier of an item.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="relationshipRefsPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateItemRelationshipsRefAsync(string projectId, string itemId, RelationshipRefsPayload relationshipRefsPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.ItemsApi.CreateItemRelationshipsRefAsync(projectId, itemId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }
        #endregion ItemsApi

        #region VersionsApi
        /// <summary>
        /// Get a Version
        /// </summary>
        /// <remarks>
        ///Returns the specified version of an item.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of ModelVersion</returns>

        public async System.Threading.Tasks.Task<ModelVersion> GetVersionAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Supported Download Formats
        /// </summary>
        /// <remarks>
        ///Returns a list of file formats the specified version of an item can be downloaded as.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of DownloadFormats</returns>

        public async System.Threading.Tasks.Task<DownloadFormats> GetVersionDownloadFormatsAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionDownloadFormatsAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Available Download Formats
        /// </summary>
        /// <remarks>
        ///Returns the list of file formats of the specified version of an item currently available for download.
        ///
        ///**Note:** This operation is not fully implemented as yet. It currently returns an empty data object.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterFormatFileType">
        ///Filter by the file type of the download object. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Downloads</returns>

        public async System.Threading.Tasks.Task<Downloads> GetVersionDownloadsAsync(string projectId, string versionId, string xUserId = default(string), List<string> filterFormatFileType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionDownloadsAsync(projectId, versionId, xUserId, filterFormatFileType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Get Item by Version
        /// </summary>
        /// <remarks>
        ///Returns the item corresponding to the specified version.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Item</returns>

        public async System.Threading.Tasks.Task<Item> GetVersionItemAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionItemAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Related Resources for a Version
        /// </summary>
        /// <remarks>
        ///Returns the resources (items, folders, and versions) that have a custom relationship with the specified version.
        ///
        ///Custom relationships can be established between a version of an item and other resources within the data domain service (folders, items, and versions).
        ///
        ///- Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links.
        ///- Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///- The response body will have an included array that contains the ref resources that are involved in the relationship, which is essentially the response to the [List Custom Relationships for a Version](/en/docs/data/v2/reference/http/projects-project_id-versions-version_id-relationships-refs-GET/) operation. 
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of Refs</returns>

        public async System.Threading.Tasks.Task<Refs> GetVersionRefsAsync(string projectId, string versionId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionRefsAsync(projectId, versionId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Links for a Version
        /// </summary>
        /// <remarks>
        ///Returns a collection of links for the specified version of an item. Custom relationships can be established between a version of an item and other external resources residing outside the data domain service. A link’s href defines the target URI to access the resource.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipLinks</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetVersionRelationshipsLinksAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionRelationshipsLinksAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// List Custom Relationships for a Version
        /// </summary>
        /// <remarks>
        ///Returns the custom relationships for the specified version. 
        ///
        ///Custom relationships can be established between a version of an item and other resources within the data domain service (folders, items, and versions).
        ///
        ///- Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data.
        ///- Callers will typically use a filter parameter to restrict the response to the custom relationship types (`filter[meta.refType]`) they are interested in.
        ///- The response body will have an included array that contains the resources in the relationship, which is essentially the response to the [List Related Resources operation](/en/docs/data/v2/reference/http/projects-project_id-versions-version_id-relationships-refs-POST/).
        ///- To get custom relationships for multiple versions, see the ListRefs command.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="filterType">
        ///Filter by the `type` of the `ref` target. Supported values include `folders`, `items`, and `versions`. (optional)
        /// </param>
        /// <param name="filterId">
        ///Filter by the `id` of the `ref` target. (optional)
        /// </param>
        /// <param name="filterRefType">
        ///Filter by `refType`. Possible values: `derived`, `dependencies`, `auxiliary`, `xrefs`, and `includes`. (optional)
        /// </param>
        /// <param name="filterDirection">
        ///Filter by the direction of the reference. Possible values: `from` and `to`. (optional)
        /// </param>
        /// <param name="filterExtensionType">
        ///Filter by the extension type.  (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of RelationshipRefs</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetVersionRelationshipsRefsAsync(string projectId, string versionId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), FilterRefType filterRefType = default, FilterDirection filterDirection = default, List<string> filterExtensionType = default(List<string>), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.GetVersionRelationshipsRefsAsync(projectId, versionId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Update a Version
        /// </summary>
        /// <remarks>
        ///Updates the properties of the specified version of an  item. Currently, you can only change the name of the version.
        ///
        ///**Note:** This operation is not supported for BIM 360 and ACC. If you want to rename a version, create a new version with a new name.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="modifyVersionPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of ModelVersion</returns>

        public async System.Threading.Tasks.Task<ModelVersion> PatchVersionAsync(string projectId, string versionId, ModifyVersionPayload modifyVersionPayload, string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.PatchVersionAsync(projectId, versionId, modifyVersionPayload, accessToken, throwOnError);
            return response.Content;
        }

        /// <summary>
        /// Create a Version
        /// </summary>
        /// <remarks>
        ///Creates a new versions of an existing item.
        ///
        ///Before creating a new version you must create a storage location for the version in OSS, and upload the file to that location. For more details about the workflow, see the tutorial on uploading a file.
        ///
        ///This operation also allows you to create a new version of an item by copying a specific version of an existing item from another folder within the project. The new version becomes the tip version of the item.
        ///
        ///Use the [Create an Item](/en/docs/data/v2/reference/http/projects-project_id-items-POST/) operation to copy a specific version of an existing item as a new item in another folder.
        ///
        ///This operation can also be used to delete files on BIM360 Document Management. For more information, please refer to the delete and restore a file tutorial.
        ///
        ///Before you use the Data Management API to access BIM 360 Docs files, you must provision your app through the BIM 360 Account Administrator portal. For details, see the [Manage Access to Docs tutorial](/en/docs/bim360/v1/tutorials/getting-started/manage-access-to-docs/).
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="copyFrom">
        ///The Version ID (URN) of the version to copy from. 
        ///
        ///**Note**: This parameter is relevant only for copying files to BIM 360 Docs.
        ///
        ///For information on how to find the URN, see the initial steps of the [Download a File](/en/docs/data/v2/tutorials/download-file/) tutorial.
        ///
        ///You can only copy files to the Plans folder or to subfolders of the Plans folder with an `item:autodesk.bim360:Document` item extension type. You can only copy files to the Project Files folder or to subfolders of the Project Files folder with an `item:autodesk.bim360:File` item extension type.  
        ///
        ///To verify an item’s extension type, use the [Get an Item](/en/docs/data/v2/reference/http/projects-project_id-items-item_id-GET/) operation, and check the `attributes.extension.type` attribute.  
        ///
        ///Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if users of your app did not have permission to download files in the source folder, but does have permission to download files in the target folder, they will not be able to download the copied file.  
        ///
        ///Note that you cannot copy a file while it is being uploaded, updated, or copied. To verify the current process state of a file, call the [Get an Item](en/docs/data/v2/reference/http/projects-project_id-items-item_id-GET/) operation , and check the `attributes.extension.data.processState` attribute. (optional)
        /// </param>
        /// <param name="versionPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of CreatedVersion</returns>

        public async System.Threading.Tasks.Task<CreatedVersion> CreateVersionAsync(string projectId, VersionPayload versionPayload, string xUserId = default(string), string copyFrom = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.CreateVersionAsync(projectId, xUserId, copyFrom, versionPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Create a Custom Relationship for a Version
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between a version of an item and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="versionId">
        ///The URL encoded unique identifier of a version.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="relationshipRefsPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateVersionRelationshipsRefAsync(string projectId, string versionId, RelationshipRefsPayload relationshipRefsPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)

        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var response = await this.VersionsApi.CreateVersionRelationshipsRefAsync(projectId, versionId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }
        #endregion VersionsApi

        #region CommandsApi
        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="checkPermissionPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of CheckPermission</returns>

        public async System.Threading.Tasks.Task<CheckPermission> ExecuteCheckPermissionAsync(string projectId, CheckPermissionPayload checkPermissionPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            CommandPayload commandPayload = new CommandPayload()
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = checkPermissionPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<CheckPermission>(response.Content.Data.ToString());
        }

        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="listItemsPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of ListItems</returns>
        public async System.Threading.Tasks.Task<ListItems> ExecuteListItemsAsync(string projectId, ListItemsPayload listItemsPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var commandPayload = new CommandPayload
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = listItemsPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<ListItems>(response.Content.Data.ToString()); ;
        }

        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="listRefsPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of ListRefs</returns>
        public async System.Threading.Tasks.Task<ListRefs> ExecuteListRefsAsync(string projectId, ListRefsPayload listRefsPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var commandPayload = new CommandPayload
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = listRefsPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<ListRefs>(response.Content.Data.ToString());
        }

        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="publishModelJobPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of PublishModelJob</returns>
        public async System.Threading.Tasks.Task<PublishModelJob> ExecuteGetPublishModelJobAsync(string projectId, PublishModelJobPayload publishModelJobPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var commandPayload = new CommandPayload
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = publishModelJobPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<PublishModelJob>(response.Content.Data.ToString());
        }

        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="publishModelPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of PublishModel</returns>
        public async System.Threading.Tasks.Task<PublishModel> ExecutePublishModelAsync(string projectId, PublishModelPayload publishModelPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var commandPayload = new CommandPayload
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = publishModelPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<PublishModel>(response.Content.Data.ToString());
        }

        /// <summary>
        /// Execute a Command
        /// </summary>
        /// <remarks>
        ///Executes the command that you specify in the request body. Commands enable you to perform general operations on multiple resources.
        ///
        ///For example, you can check whether a user has permission to delete a collection of versions, items, and folders.
        ///
        ///The command as well as the input data for the command are specified using the `data` object of the request body. 
        ///
        ///For more information about commands see the [Commands](/en/docs/data/v2/overview/commands/) section in the Developer's Guide.
        /// </remarks>
        /// <exception cref="DataManagementApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The unique identifier of a project. 
        ///
        ///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        ///
        ///Similarly, to convert an ACC or BIM 360 project ID to a Data Management project ID prefix the ACC or BIM 360 project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </param>
        /// <param name="xUserId">
        ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
        /// </param>
        /// <param name="publishWithoutLinksPayload">
        /// (optional)
        /// </param>
        /// <param name="throwOnError">
        /// Indicates whether to throw an exception on error.(optional)
        /// </param>
        /// <param name="accessToken">
        /// An access token obtained by a call to GetThreeLeggedTokenAsync() or GetTwoLeggedTokenAsync(). (optional)
        /// </param>
        /// <returns>Task of PublishWithoutLinks</returns>
        public async System.Threading.Tasks.Task<PublishWithoutLinks> ExecutePublishWithoutLinksAsync(string projectId, PublishWithoutLinksPayload publishWithoutLinksPayload, string xUserId = default(string), string accessToken = default, bool throwOnError = true)
        {
            if (String.IsNullOrEmpty(accessToken) && this.AuthenticationProvider == null)
            {
                throw new Exception("Please provide a valid access token or an authentication provider.");
            }
            else if (String.IsNullOrEmpty(accessToken))
            {
                accessToken = await this.AuthenticationProvider.GetAccessToken();
            }
            var commandPayload = new CommandPayload
            {
                Jsonapi = new JsonApiVersion()
                {
                    VarVersion = JsonApiVersionValue._10
                },
                Data = publishWithoutLinksPayload
            };
            var response = await this.CommandsApi.ExecuteCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return JsonConvert.DeserializeObject<PublishWithoutLinks>(response.Content.Data.ToString());
        }

        #endregion CommandsApi
    }

}