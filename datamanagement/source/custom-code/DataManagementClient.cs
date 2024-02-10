using Autodesk.DataManagement.Http;
using Autodesk.DataManagement.Model;
using System.Net.Http;
using System.Collections.Generic;

namespace Autodesk.DataManagement
{
    public class DataManagementClient
    {
        public ICommandsApi CommandsApi { get; }
        public IFoldersApi FoldersApi { get; }
        public IHubsApi HubsApi { get; }
        public IItemsApi ItemsApi { get; }
        public IProjectsApi ProjectsApi { get; }
        public IVersionsApi VersionsApi { get; }

        public DataManagementClient(SDKManager.SDKManager sdkManager)
        {

            this.CommandsApi = new CommandsApi(sdkManager);
            this.FoldersApi = new FoldersApi(sdkManager);
            this.HubsApi = new HubsApi(sdkManager);
            this.ItemsApi = new ItemsApi(sdkManager);
            this.ProjectsApi = new ProjectsApi(sdkManager);
            this.VersionsApi = new VersionsApi(sdkManager);
        }

        #region CommandsApi
        /// <summary>
        /// Create commands
        /// </summary>
        /// <remarks>
        /// Commands enable you to perform general operations on multiple resources. For example, you can check whether a user has permission to delete specific versions, items, and folders. Commands are executed by sending requests in the body payload. See the [Commands](/en/docs/data/v2/overview/commands/) section for more information. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="createCommand">The POST body is a JSON object with the following attributes. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Command&#62;</returns>

        public async System.Threading.Tasks.Task<Command> PostCommandAsync(string projectId, string xUserId = default(string), CommandPayload commandPayload = default(CommandPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.CommandsApi.PostCommandAsync(projectId, xUserId, commandPayload, accessToken, throwOnError);
            return response.Content;
        }

        #endregion CommandsApi

        #region FoldersApi

        /// <summary>
        /// Returns the folder by ID for any folder within a given project
        /// </summary>
        /// <remarks>
        /// Returns the folder by ID for any folder within a given project. All folders or sub-folders within a project are associated with their own unique ID, including the root folder.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="ifModifiedSince">If the resource has not been modified since, the response will be a 304 without any body; the Last-Modified response header will contain the date of last modification. (optional)</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Folder&#62;</returns>

        public async System.Threading.Tasks.Task<Folder> GetFolderAsync(string projectId, string folderId, string ifModifiedSince = default(string), string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderAsync(projectId, folderId, ifModifiedSince, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of items and folders within a folder
        /// </summary>
        /// <remarks>
        /// Returns a collection of items and folders within a folder. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for each item resource is included by default in the included array of the payload. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterLastModifiedTimeRollup">Filter by the lastModifiedTimeRollup in attributes Supported values are date-time string in the form YYYY-MM-DDTHH:MM:SS.000000Z or YYYY-MM-DDTHH:MM:SS based on RFC3339 (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>/// <param name="includeHidden">true: response will also include items and folders that were deleted from BIM 360 Docs projects. false (default): response will not include items and folders that were deleted from BIM 360 Docs projects.  To return only items and folders that were deleted from BIM 360 Docs projects, see the Filtering section. (optional)</param>
        /// <returns>Task of ApiResponse&#60;FolderContents&#62;</returns>

        public async System.Threading.Tasks.Task<FolderContents> GetFolderContentsAsync(string projectId, string folderId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<string> filterLastModifiedTimeRollup = default(List<string>), int? pageNumber = default(int?), int? pageLimit = default(int?), bool? includeHidden = default(bool?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderContentsAsync(projectId, folderId, xUserId, filterType, filterId, filterExtensionType, filterLastModifiedTimeRollup, pageNumber, pageLimit, includeHidden, accessToken, throwOnError);
            return response.Content;

        }
        /// <summary>
        /// nt folder (if it exists)
        /// </summary>
        /// <remarks>
        /// Returns the parent folder (if it exists). In a project, subfolders and resource items are stored under a folder except the root folder which does not have a parent of its own.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Folder&#62;</returns>

        public async System.Threading.Tasks.Task<Folder> GetFolderParentAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderParentAsync(projectId, folderId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the resources (items, folders, and versions)
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the ref target. Supported values include folders, items, and versions. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;FolderRefs&#62;</returns>

        public async System.Threading.Tasks.Task<FolderRefs> GetFolderRefsAsync(string projectId, string folderId, string xUserId = default(string), string filterType = default(string), string filterId = default(string), string filterExtensionType = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderRefsAsync(projectId, folderId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of links for the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given folder_id. Custom relationships can be established between a folder and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipLinks&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetFolderRelationshipsLinksAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderRelationshipsLinksAsync(projectId, folderId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the custom relationships that are associated with the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipRefs&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetFolderRelationshipsRefsAsync(string folderId, string projectId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), string filterRefType = null, string filterDirection = null, List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderRelationshipsRefsAsync(folderId, projectId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Filters the data of a folder and recursively in the subfolders
        /// </summary>
        /// <remarks>
        /// Filters the data of a folder and recursively in the subfolders of any project accessible to you, using the filter query string parameter. You can filter the following properties from the version payload: the type property, the id property, and any of the attributes object properties. For example, you can filter createTime, mimeType. It returns tip versions (latest versions) of properties where the filter conditions are satisfied. To verify the properties of the attributes object for a specific version, see the GET projects/:project_id/versions/:version_id.  To filter a folder&#39;s data without recursively filtering its subfolders, see the GET projects/:project_id/folders/:folder_id/contents endpoint.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="filter">Filter the data. See the Filtering section for details. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>
        /// <returns>Task of ApiResponse&#60;Search&#62;</returns>

        public async System.Threading.Tasks.Task<Search> GetFolderSearchAsync(string projectId, string folderId, string filter = default(string), int? pageNumber = default(int?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.GetFolderSearchAsync(projectId, folderId, filter, pageNumber, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Modifies folder names
        /// </summary>
        /// <remarks>
        /// Modifies folder names. You can also use this endpoint to delete and restore BIM 360 Docs folders by using the hidden attribute, or move BIM 360 Docs folders by using parent relationships.  Note that you cannot permanently delete BIM 360 Docs folders. They are tagged as hidden folders and are removed from the BIM 360 Docs UI and from regular Data Management API responses until you restore them. You can use the hidden filter (filter[hidden]&#x3D;true) to get a list of deleted folders with the GET projects/:project_id/folders/:folder_id/contents endpoint.  Note that to access BIM 360 Docs folders using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="modifyFolder">Describe the folder to be patched. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Folder&#62;</returns>

        public async System.Threading.Tasks.Task<Folder> PatchFolderAsync(string projectId, string folderId, string xUserId = default(string), ModifyFolderPayload modifyFolderPayload = default(ModifyFolderPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.PatchFolderAsync(projectId, folderId, xUserId, modifyFolderPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint
        /// </summary>
        /// <remarks>
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint.  BIM 360 and ACC  To access Docs folders using the Data Management API you need to provision your app in the Account Administrator portal. For more details, see the Manage Access to Docs tutorial. The number of subfolder levels is limited to 25. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="createFolder">Describe the folder to be created. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Folder&#62;</returns>

        public async System.Threading.Tasks.Task<Folder> CreateFolderAsync(string projectId, string xUserId = default(string), FolderPayload folderPayload = default(FolderPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.CreateFolderAsync(projectId, xUserId, folderPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates a custom relationship between a folder and another resource within the data
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsRequest">Describe the ref to be created. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync(string folderId, string projectId, string xUserId = default(string), RelationshipRefsPayload relationshipRefsPayload = default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.FoldersApi.CreateFolderRelationshipsRefAsync(folderId, projectId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }

        #endregion FoldersApi

        #region HubsApi
        /// <summary>
        /// Returns data on a specific hub_id
        /// </summary>
        /// <remarks>
        /// Returns data on a specific hub_id.  Note that for BIM 360 Docs, a hub ID corresponds to an account ID in the BIM 360 API. To convert an account ID into a hub ID you need to add a \&quot;b.\&quot; prefix. For example, an account ID of c8b0c73d-3ae9 translates to a hub ID of b.c8b0c73d-3ae9.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hubId">The unique identifier of a hub.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Hub&#62;</returns>

        public async System.Threading.Tasks.Task<Hub> GetHubAsync(string hubId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.HubsApi.GetHubAsync(hubId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of accessible hubs for this member
        /// </summary>
        /// <remarks>
        /// Returns a collection of accessible hubs for this member.  Hubs represent BIM 360 Team hubs, Fusion Team hubs (formerly known as A360 Team hubs), A360 Personal hubs, or BIM 360 Docs accounts. Team hubs include **BIM 360** Team hubs and Fusion Team hubs (formerly known as A360 Team hubs). Personal hubs include A360 Personal hubs. Only active hubs are listed.  Note that for BIM 360 Docs, a hub ID corresponds to an account ID in the BIM 360 API. To convert an account ID into a hub ID you need to add a \&quot;b.\&quot; prefix. For example, an account ID of c8b0c73d-3ae9 translates to a hub ID of b.c8b0c73d-3ae9.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterName">Filter by the name of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Hubs&#62;</returns>

        public async System.Threading.Tasks.Task<Hubs> GetHubsAsync(string xUserId = default(string), List<string> filterId = default(List<string>), string filterName = default(string), List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.HubsApi.GetHubsAsync(xUserId, filterId, filterName, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        #endregion HubsApi

        #region ItemsApi
        /// <summary>
        /// Retrieves metadata for a specified item
        /// </summary>
        /// <remarks>
        /// Retrieves metadata for a specified item. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for the item is included in the included array of the payload. To retrieve metadata for multiple items, see the ListItems command. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="includePathInProject">Specify whether to return pathInProject attribute in response for BIM 360 Docs projects. pathInProject is the relative path of the item starting from project’s root folder. true: response will include pathInProject attribute for BIM 360 Docs projects.  false (default): response will not include pathInProject attribute for BIM 360 Docs projects. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Item&#62;</returns>

        public async System.Threading.Tasks.Task<Item> GetItemAsync(string projectId, string itemId, string xUserId = default(string), bool? includePathInProject = default(bool?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemAsync(projectId, itemId, xUserId, includePathInProject, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the \&quot;parent\&quot; folder for the given item
        /// </summary>
        /// <remarks>
        /// Returns the \&quot;parent\&quot; folder for the given item.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Folder&#62;</returns>

        public async System.Threading.Tasks.Task<Folder> GetItemParentFolderAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemParentFolderAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Refs&#62;</returns>

        public async System.Threading.Tasks.Task<Refs> GetItemRefsAsync(string projectId, string itemId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemRefsAsync(projectId, itemId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of links for the given item_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given item_id. Custom relationships can be established between an item and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipLinks&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetItemRelationshipsLinksAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemRelationshipsLinksAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the custom relationships that are associated with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipRefs&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetItemRelationshipsRefsAsync(string projectId, string itemId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), string filterRefType = null, string filterDirection = null, List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemRelationshipsRefsAsync(projectId, itemId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the “tip” version for the given item
        /// </summary>
        /// <remarks>
        /// Returns the “tip” version for the given item. Multiple versions of a resource item can be uploaded in a project. The tip version is the most recent one.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;ItemTip&#62;</returns>

        public async System.Threading.Tasks.Task<ItemTip> GetItemTipAsync(string projectId, string itemId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemTipAsync(projectId, itemId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns versions for the given item
        /// </summary>
        /// <remarks>
        /// Returns versions for the given item. Multiple versions of a resource item can be uploaded in a project.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterVersionNumber">Filter by versionNumber. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Versions&#62;</returns>

        public async System.Threading.Tasks.Task<Versions> GetItemVersionsAsync(string projectId, string itemId, string xUserId = default(string), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<int?> filterVersionNumber = default(List<int?>), int? pageNumber = default(int?), int? pageLimit = default(int?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.GetItemVersionsAsync(projectId, itemId, xUserId, filterId, filterExtensionType, filterVersionNumber, pageNumber, pageLimit, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Updates the properties of the given item_id object
        /// </summary>
        /// <remarks>
        /// Updates the properties of the given item_id object.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="itemRequest">Describe the item to be patched. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Item&#62;</returns>

        public async System.Threading.Tasks.Task<Item> PatchItemAsync(string projectId, string itemId, string xUserId = default(string), ModifyItemPayload modifyItemPayload = default(ModifyItemPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.PatchItemAsync(projectId, itemId, xUserId, modifyItemPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates the first version of a file (item)
        /// </summary>
        /// <remarks>
        /// Creates the first version of a file (item). To create additional versions of an item, use POST versions.  Before you create the first version you need to create a storage location for the file, and upload the file to the storage object. For more details about the workflow, see the tutorial on uploading a file.  This endpoint also copies versions of items to other folders in the same project. The endpoint creates a new item and a first version of the item in the target folder. You cannot copy versions of items across different projects and accounts.  To copy versions of items to existng items in other folders, use POST versions. POST versions creates a new version of the existing item in the target folder.  Note that to access BIM 360 Docs files using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="copyFrom">Only relevant for copying files to BIM 360 Docs - the version ID (URN) of the file to copy. For details about finding the URN, follow the initial steps in the Download a File tutorial.  You can only copy files to the Plans folder or to subfolders of the Plans folder with an item:autodesk.bim360:Document item extension type, and you can only copy files to the Project Files folder or to subfolders of the Project Files folder with an item:autodesk.bim360:File item extension type.  To verify an item’s extension type, use GET item, and check the attributes.extension.type attribute.  Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if the end user did not have permission to download files in the source folder, but does have permission to download files in the target folder, he/she will not be able to download the copied file.  Note that you cannot copy a file if it is in the middle of being uploaded, updated, or copied. To verify the current process state of a file, call GET item, and check the attributes.extension.data.processState attribute. (optional)</param>/// <param name="createItem">Describe the item to be created. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Item&#62;</returns>

        public async System.Threading.Tasks.Task<Item> CreateItemAsync(string projectId, string xUserId = default(string), string copyFrom = default(string), ItemPayload itemPayload = default(ItemPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.CreateItemAsync(projectId, xUserId, copyFrom, itemPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsRequest">Describe the ref to be created. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateItemRelationshipsRefAsync(string projectId, string itemId, string xUserId = default(string), RelationshipRefsPayload relationshipRefsPayload = default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ItemsApi.CreateItemRelationshipsRefAsync(projectId, itemId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }
        #endregion ItemsApi

        #region ProjectsApi
        /// <summary>
        /// Returns the details for a specific download
        /// </summary>
        /// <remarks>
        /// Returns the details for a specific &#x60;&#x60;download&#x60;&#x60;. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="downloadId">The unique identifier of a download job.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Download&#62;</returns>

        public async System.Threading.Tasks.Task<DownloadDetails> GetDownloadAsync(string projectId, string downloadId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetDownloadAsync(projectId, downloadId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the job_id object
        /// </summary>
        /// <remarks>
        /// Returns the &#x60;&#x60;job_id&#x60;&#x60; object. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="jobId">The unique identifier of a job.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Job&#62;</returns>

        public async System.Threading.Tasks.Task<Job> GetDownloadJobAsync(string projectId, string jobId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetDownloadJobAsync(projectId, jobId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of projects for a given hub_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of projects for a given hub_id. A project represents a BIM 360 Team project, a Fusion Team project, a BIM 360 Docs project, or an A360 Personal project. Multiple projects can be created within a single hub. Only active projects are listed.  Note that for BIM 360 Docs, a hub ID corresponds to an account ID in the BIM 360 API. To convert an account ID into a hub ID you need to add a \&quot;b.\&quot; prefix. For example, an account ID of c8b0c73d-3ae9 translates to a hub ID of b.c8b0c73d-3ae9.  Similarly, for BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a \&quot;b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hubId">The unique identifier of a hub.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Projects&#62;</returns>

        public async System.Threading.Tasks.Task<Projects> GetHubProjectsAsync(string hubId, string xUserId = default(string), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), int? pageNumber = default(int?), int? pageLimit = default(int?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetHubProjectsAsync(hubId, xUserId, filterId, filterExtensionType, pageNumber, pageLimit, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a project for a given project_id
        /// </summary>
        /// <remarks>
        /// Returns a project for a given project_id.  Note that for BIM 360 Docs, a hub ID corresponds to an account ID in the BIM 360 API. To convert an account ID into a hub ID you need to add a \&quot;b.\&quot; prefix. For example, an account ID of c8b0c73d-3ae9 translates to a hub ID of b.c8b0c73d-3ae9.  Similarly, for BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a \&quot;b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hubId">The unique identifier of a hub.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Project&#62;</returns>

        public async System.Threading.Tasks.Task<Project> GetProjectAsync(string hubId, string projectId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetProjectAsync(hubId, projectId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the hub for a given project_id
        /// </summary>
        /// <remarks>
        /// Returns the hub for a given project_id.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hubId">The unique identifier of a hub.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Hub&#62;</returns>

        public async System.Threading.Tasks.Task<Hub> GetProjectHubAsync(string hubId, string projectId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetProjectHubAsync(hubId, projectId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the details of the highest level folders the user has access to for a given project
        /// </summary>
        /// <remarks>
        /// Returns the details of the highest level folders the user has access to for a given project. The user must have at least read access to the folders.  If the user is a Project Admin, it returns all top level folders in the project. Otherwise, it returns all the highest level folders in the folder hierarchy the user has access to.  Note that when users have access to a folder, access is automatically granted to its subfolders.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="hubId">The unique identifier of a hub.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="excludeDeleted">Specify whether to exclude deleted folders in response for BIM 360 Docs projects when user context is provided. true: response will exclude deleted folders for BIM 360 Docs projects.  false (default): response will not exclude deleted folders for BIM 360 Docs projects. (optional)</param>/// <param name="projectFilesOnly">Specify whether only Project Files folder or its subfolders will be returned for BIM 360 Docs projects when user context is provided. true: response will include only Project Files folder and its subfolders for BIM 360 Docs projects.  false (default): response will include all available folders. (optional)</param>
        /// <returns>Task of ApiResponse&#60;TopFolders&#62;</returns>

        public async System.Threading.Tasks.Task<TopFolders> GetProjectTopFoldersAsync(string hubId, string projectId, string xUserId = default(string), bool? excludeDeleted = default(bool?), bool? projectFilesOnly = default(bool?), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.GetProjectTopFoldersAsync(hubId, projectId, xUserId, excludeDeleted, projectFilesOnly, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Request the creation of a new download for a specific and supported file type
        /// </summary>
        /// <remarks>
        /// Request the creation of a new download for a specific and supported file type. The fileType specified in the POST body needs to be contained in the list of supported file types returned by the GET /data/v1/projects/:project_id/downloads endpoint for the specified version_id.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="createDownload">Describe the download to be created. (optional)</param>
        /// <returns>Task of ApiResponse&#60;CreatedDownload&#62;</returns>

        public async System.Threading.Tasks.Task<Download> CreateDownloadAsync(string projectId, string xUserId = default(string), DownloadPayload downloadPayload = default(DownloadPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.CreateDownloadAsync(projectId, xUserId, downloadPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates a storage location in the OSS where data can be uploaded to
        /// </summary>
        /// <remarks>
        /// Creates a storage location in the OSS where data can be uploaded to.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="storageRequest">Describe the file the storage is created for. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Storage&#62;</returns>

        public async System.Threading.Tasks.Task<Storage> CreateStorageAsync(string projectId, string xUserId = default(string), StoragePayload storagePayload = default(StoragePayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.ProjectsApi.CreateStorageAsync(projectId, xUserId, storagePayload, accessToken, throwOnError);
            return response.Content;
        }
        #endregion ProjectsApi

        #region VersionsApi
        /// <summary>
        /// Returns the version with the given version_id
        /// </summary>
        /// <remarks>
        /// Returns the version with the given version_id.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;ModelVersion&#62;</returns>

        public async System.Threading.Tasks.Task<VersionDetails> GetVersionAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of file formats this version could be converted to and downloaded as
        /// </summary>
        /// <remarks>
        /// Returns a collection of file formats this version could be converted to and downloaded as.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;DownloadFormats&#62;</returns>

        public async System.Threading.Tasks.Task<DownloadFormats> GetVersionDownloadFormatsAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionDownloadFormatsAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a set of already available downloads for this version
        /// </summary>
        /// <remarks>
        /// Returns a set of already available downloads for this version.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterFormatFileType">Filter by the file type of the download object. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Downloads&#62;</returns>

        public async System.Threading.Tasks.Task<Downloads> GetVersionDownloadsAsync(string projectId, string versionId, string xUserId = default(string), List<string> filterFormatFileType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionDownloadsAsync(projectId, versionId, xUserId, filterFormatFileType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the item the given version is associated with
        /// </summary>
        /// <remarks>
        /// Returns the item the given version is associated with.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Item&#62;</returns>

        public async System.Threading.Tasks.Task<Item> GetVersionItemAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionItemAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given version_id
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given version_id. Custom relationships can be established between a version of an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/versions/:version_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;Refs&#62;</returns>

        public async System.Threading.Tasks.Task<Refs> GetVersionRefsAsync(string projectId, string versionId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionRefsAsync(projectId, versionId, xUserId, filterType, filterId, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns a collection of links for the given item_id-version_id object
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given item_id-version_id object. Custom relationships can be established between a version of an item and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipLinks&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipLinks> GetVersionRelationshipsLinksAsync(string projectId, string versionId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionRelationshipsLinksAsync(projectId, versionId, xUserId, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Returns the custom relationships that are associated with the given version_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given version_id. Custom relationships can be established between a version of an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/versions/:version_id/refs endpoint. To get custom relationships for multiple versions, see the ListRefs command. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse&#60;RelationshipRefs&#62;</returns>

        public async System.Threading.Tasks.Task<RelationshipRefs> GetVersionRelationshipsRefsAsync(string projectId, string versionId, string xUserId = default(string), List<string> filterType = default(List<string>), List<string> filterId = default(List<string>), string filterRefType = null, string filterDirection = null, List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.GetVersionRelationshipsRefsAsync(projectId, versionId, xUserId, filterType, filterId, filterRefType, filterDirection, filterExtensionType, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Updates the properties of the given version_id object
        /// </summary>
        /// <remarks>
        /// Updates the properties of the given version_id object. 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="versionRequest">Describe the version to be patched. (optional)</param>
        /// <returns>Task of ApiResponse&#60;ModelVersion&#62;</returns>

        public async System.Threading.Tasks.Task<VersionDetails> PatchVersionAsync(string projectId, string versionId, ModifyVersionPayload modifyVersionPayload = default(ModifyVersionPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.PatchVersionAsync(projectId, versionId, modifyVersionPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates new versions of a file (item), except for the first version of the item
        /// </summary>
        /// <remarks>
        /// Creates new versions of a file (item), except for the first version of the item. To create the first version of the item, use POST items.  Before creating each version you need to create a new storage location for the version, and upload the file to the storage object. For more details about the workflow, see the tutorial on uploading a file.  This endpoint also copies versions of items to exisitng items in other folders. The endpoint creates a new version of the existing item in the target folder. You cannot copy versions of items across different projects and accounts.  To copy versions of items to other folders and create a new item and a first version of the item in the target folder, use POST versions.  This endpoint can also be used to delete files on BIM360 Document Management. For more information, please refer to the delete and restore a file turorial.  Note that to access BIM 360 Docs files using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="copyFrom">Only relevant for copying files to BIM 360 Docs - the version ID (URN) of the file to copy. For details about finding the URN, follow the initial steps in the Download a File tutorial.  You can only copy files to the Plans folder or to subfolders of the Plans folder with an item:autodesk.bim360:Document item extension type, and you can only copy files to the Project Files folder or to subfolders of the Project Files folder with an item:autodesk.bim360:File item extension type.  To verify an item’s extension type, use GET item, and check the attributes.extension.type attribute.  Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if the end user did not have permission to download files in the source folder, but does have permission to download files in the target folder, he/she will not be able to download the copied file.  Note that you cannot copy a file if it is in the middle of being uploaded, updated, or copied. To verify the current process state of a file, call GET item, and check the attributes.extension.data.processState attribute. (optional)</param>/// <param name="createVersion">Describe the version to be created. (optional)</param>
        /// <returns>Task of ApiResponse&#60;CreatedVersion&#62;</returns>

        public async System.Threading.Tasks.Task<ModelVersion> CreateVersionAsync(string projectId, string xUserId = default(string), string copyFrom = default(string), VersionPayload versionPayload = default(VersionPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.CreateVersionAsync(projectId, xUserId, copyFrom, versionPayload, accessToken, throwOnError);
            return response.Content;
        }
        /// <summary>
        /// Creates a custom relationship between a version and another resource within the data domain service (folder, item, or version)
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between a version and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="versionId">The unique identifier of a version.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsRequest">Describe the ref to be created. (optional)</param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateVersionRelationshipsRefAsync(string projectId, string versionId, string xUserId = default(string), RelationshipRefsPayload relationshipRefsPayload = default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
        {
            var response = await this.VersionsApi.CreateVersionRelationshipsRefAsync(projectId, versionId, xUserId, relationshipRefsPayload, accessToken, throwOnError);
            return response;
        }
        #endregion VersionsApi

    }

}