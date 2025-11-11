/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Data Management
 *
 * The Data Management API provides a unified and consistent way to access data across BIM 360 Team, Fusion Team (formerly known as A360 Team), BIM 360 Docs, A360 Personal, and the Object Storage Service.  With this API, you can accomplish a number of workflows, including accessing a Fusion model in Fusion Team and getting an ordered structure of items, IDs, and properties for generating a bill of materials in a 3rd-party process. Or, you might want to superimpose a Fusion model and a building model to use in the Viewer.
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
using Autodesk.DataManagement.Model;
using Autodesk.DataManagement.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;
using System.Collections;

namespace Autodesk.DataManagement.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFoldersApi
    {
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Folder>> CreateFolderAsync(string projectId, string xUserId = default(string), FolderPayload folderPayload = default(FolderPayload), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create a Custom Relationship for a Folder
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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

        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync(string folderId, string projectId, string xUserId = default(string), RelationshipRefsPayload relationshipRefsPayload = default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get a Folder
        /// </summary>
        /// <remarks>
        ///Returns the folder specified by the `folder_id` parameter from within the project identified by the `project_id` parameter. All folders and subfolders within a project (including the root folder) have a unique ID.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderAsync(string projectId, string folderId, DateTime ifModifiedSince = default(DateTime), string xUserId = default(string), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;FolderContents&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<FolderContents>> GetFolderContentsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterType> filterType = default(List<FilterType>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<string> filterLastModifiedTimeRollup = default(List<string>), int pageNumber = default(int), int pageLimit = default(int), bool includeHidden = default(bool), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Parent of a Folder
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified folder. In a project, folders are organized in a hierarchy. Each folder except for the root folder has a parent folder.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderParentAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;FolderRefs&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<FolderRefs>> GetFolderRefsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipLinks&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetFolderRelationshipsLinksAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipRefs&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetFolderRelationshipsRefsAsync(string folderId, string projectId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), FilterRefType? filterRefType = null, FilterDirection? filterDirection = null, List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <param name="filter">
        ///Filter the data. See the [Filtering](/en/docs/data/v2/overview/filtering/) section for details. (optional)
        /// </param>
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Search&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Search>> GetFolderSearchAsync(string projectId, string folderId, List<(string fieldName, ComparisonTypes? operatorType, List<string> values)> filters = null, int pageNumber = default(int), string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Folder>> PatchFolderAsync(string projectId, string folderId, string xUserId = default(string), ModifyFolderPayload modifyFolderPayload = default(ModifyFolderPayload), string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FoldersApi : IFoldersApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public FoldersApi(SDKManager.SDKManager sdkManager)
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
                    // Get the value from EnumMember attribute (which will contain the operator, e.g., -eq, -lt)
                    var enumValue = ((EnumMemberAttribute)valueAttributes[0]).Value;
                    dictionary.Add(name, enumValue);
                }
            }
            else if (value is int intValue)
            {
                if (intValue > 0)
                {
                    dictionary.Add(name, intValue);
                }
            }
            else if (value is ValueTuple<string, ComparisonTypes?, List<string>> filterTuple)
            {
                var (fieldName, operatorType, values) = filterTuple;

                string operatorTypeValue = null;
                if (operatorType != null && operatorType.GetType().IsEnum)
                {
                    var type = operatorType.GetType();
                    var memberInfos = type.GetMember(operatorType.ToString());
                    var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                    var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                    operatorTypeValue = valueAttributes.Length > 0
                        ? ((EnumMemberAttribute)valueAttributes[0]).Value
                        : operatorType.ToString();
                }
                else
                {
                    operatorTypeValue = operatorType?.ToString();
                }

                string filterKey = $"filter[{fieldName}]{operatorTypeValue}";
                string filterExpression = string.Join(",", values);

                dictionary.Add(filterKey, filterExpression);
            }
            else if (value is IList listValue)
            {
                if (listValue is List<string> stringList)
                {
                    dictionary.Add(name, string.Join(",", stringList));
                }
                else if (listValue is List<ValueTuple<string, ComparisonTypes?, List<string>>> filters)
                {
                    foreach (var filter in filters)
                    {
                        SetQueryParameter("filter", filter, dictionary);
                    }
                }
                else
                {
                    List<string> newlist = new List<string>();
                    foreach (var x in listValue)
                    {
                        var type = x.GetType();
                        var memberInfos = type.GetMember(x.ToString());
                        var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == type);
                        var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                        newlist.Add(((EnumMemberAttribute)valueAttributes[0]).Value);
                    }
                    dictionary.Add(name, string.Join(",", newlist));
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Folder>> CreateFolderAsync(string projectId, string xUserId = default(string), FolderPayload folderPayload = default(FolderPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateFolderAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(folderPayload); // http body (model) parameter


                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:create ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:create ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Folder>(response, default(Folder));
                }
                logger.LogInformation($"Exited from CreateFolderAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
        }
        /// <summary>
        /// Create a Custom Relationship for a Folder
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync(string folderId, string projectId, string xUserId = default(string), RelationshipRefsPayload relationshipRefsPayload = default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateFolderRelationshipsRefAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "folder_id", folderId},
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(relationshipRefsPayload); // http body (model) parameter


                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:create ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:create ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from CreateFolderRelationshipsRefAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Get a Folder
        /// </summary>
        /// <remarks>
        ///Returns the folder specified by the `folder_id` parameter from within the project identified by the `project_id` parameter. All folders and subfolders within a project (including the root folder) have a unique ID.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderAsync(string projectId, string folderId, DateTime ifModifiedSince = default(DateTime), string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("If-Modified-Since", ifModifiedSince, request);
                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Folder>(response, default(Folder));
                }
                logger.LogInformation($"Exited from GetFolderAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;FolderContents&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<FolderContents>> GetFolderContentsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterType> filterType = default(List<FilterType>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), List<string> filterLastModifiedTimeRollup = default(List<string>), int pageNumber = default(int), int pageLimit = default(int), bool includeHidden = default(bool), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderContentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                SetQueryParameter("filter[lastModifiedTimeRollup]", filterLastModifiedTimeRollup, queryParam);
                SetQueryParameter("page[number]", pageNumber, queryParam);
                SetQueryParameter("page[limit]", pageLimit, queryParam);
                SetQueryParameter("includeHidden", includeHidden, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/contents",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<FolderContents>(response, default(FolderContents));
                }
                logger.LogInformation($"Exited from GetFolderContentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<FolderContents>(response, await LocalMarshalling.DeserializeAsync<FolderContents>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Parent of a Folder
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified folder. In a project, folders are organized in a hierarchy. Each folder except for the root folder has a parent folder.
        ///
        ///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderParentAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderParentAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/parent",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Folder>(response, default(Folder));
                }
                logger.LogInformation($"Exited from GetFolderParentAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;FolderRefs&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<FolderRefs>> GetFolderRefsAsync(string projectId, string folderId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<FolderRefs>(response, default(FolderRefs));
                }
                logger.LogInformation($"Exited from GetFolderRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<FolderRefs>(response, await LocalMarshalling.DeserializeAsync<FolderRefs>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipLinks&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetFolderRelationshipsLinksAsync(string projectId, string folderId, string xUserId = default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderRelationshipsLinksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/relationships/links",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<RelationshipLinks>(response, default(RelationshipLinks));
                }
                logger.LogInformation($"Exited from GetFolderRelationshipsLinksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipLinks>(response, await LocalMarshalling.DeserializeAsync<RelationshipLinks>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipRefs&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetFolderRelationshipsRefsAsync(string folderId, string projectId, string xUserId = default(string), List<FilterTypeVersion> filterType = default(List<FilterTypeVersion>), List<string> filterId = default(List<string>), FilterRefType? filterRefType = null, FilterDirection? filterDirection = null, List<string> filterExtensionType = default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderRelationshipsRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[refType]", filterRefType, queryParam);
                SetQueryParameter("filter[direction]", filterDirection, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/relationships/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "folder_id", folderId},
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<RelationshipRefs>(response, default(RelationshipRefs));
                }
                logger.LogInformation($"Exited from GetFolderRelationshipsRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipRefs>(response, await LocalMarshalling.DeserializeAsync<RelationshipRefs>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <param name="filter">
        ///Filter the data. See the [Filtering](/en/docs/data/v2/overview/filtering/) section for details. (optional)
        /// </param>
        /// <param name="pageNumber">
        ///Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Search&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Search>> GetFolderSearchAsync(
                    string projectId,
                    string folderId,
                    List<(string fieldName, ComparisonTypes? operatorType, List<string> values)> filters = null,
                    int pageNumber = 0,
                    string accessToken = null,
                    bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderSearchAsync");

            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();

                SetQueryParameter("filters", filters, queryParam);
                SetQueryParameter("page[number]", pageNumber, queryParam);

                // Build the URI for the request
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/search",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId },
                            { "folder_id", folderId },
                        },
                        queryParameters: queryParam
                    );

                // Add headers
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");

                // Add the Authorization token if available
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                // Set HTTP method to GET
                request.Method = HttpMethod.Get;

                // Make the HTTP request
                var response = await this.Service.Client.SendAsync(request);

                if (throwOnError)
                {
                    try
                    {
                        await response.EnsureSuccessStatusCodeAsync();
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccessful with status code: {response.StatusCode}");
                    return new ApiResponse<Search>(response, default(Search));
                }

                logger.LogInformation($"Exited from GetFolderSearchAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Search>(response, await LocalMarshalling.DeserializeAsync<Search>(response.Content));
            }
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Folder&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Folder>> PatchFolderAsync(string projectId, string folderId, string xUserId = default(string), ModifyFolderPayload modifyFolderPayload = default(ModifyFolderPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchFolderAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(modifyFolderPayload); // http body (model) parameter


                SetHeader("x-user-id", xUserId, request);

                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
                // }
                // else
                // {
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), scopes);
                // }
                // if (scopes == null)
                // {
                // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:write ");
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
                        throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Folder>(response, default(Folder));
                }
                logger.LogInformation($"Exited from PatchFolderAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
        }
    }
}
