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
    public interface IItemsApi
    {
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;CreatedItem&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<CreatedItem>> CreateItemAsync (string projectId, string copyFrom= default(string), string xUserId= default(string), ItemPayload itemPayload= default(ItemPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create a Custom Relationship for an Item
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateItemRelationshipsRefAsync (string projectId, string itemId, string xUserId= default(string), RelationshipRefsPayload relationshipRefsPayload= default(RelationshipRefsPayload),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Item&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Item>> GetItemAsync (string projectId, string itemId, string xUserId= default(string), bool includePathInProject= default(bool),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Parent of an Item
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified item.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Folder&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> GetItemParentFolderAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Refs&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Refs>> GetItemRefsAsync (string projectId, string itemId, string xUserId= default(string), List<FilterTypeVersion> filterType= default(List<FilterTypeVersion>), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipLinks&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetItemRelationshipsLinksAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipRefs&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetItemRelationshipsRefsAsync (string projectId, string itemId, string xUserId= default(string), List<FilterTypeVersion> filterType= default(List<FilterTypeVersion>), List<string> filterId= default(List<string>), FilterRefType? filterRefType= null, FilterDirection? filterDirection= null, List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Tip Version of an Item
        /// </summary>
        /// <remarks>
        ///Returns the latest version of the specified item. A project can contain multiple versions of a resource item. The latest version is referred to as the tip version, which is returned by this operation.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ItemTip&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<ItemTip>> GetItemTipAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// List all Versions of an Item
        /// </summary>
        /// <remarks>
        ///Lists all versions of the specified item. A project can contain multiple versions of a resource item.
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
        /// <returns>Task of ApiResponse&lt;Versions&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Versions>> GetItemVersionsAsync (string projectId, string itemId, string xUserId= default(string), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>), List<int> filterVersionNumber= default(List<int>), int pageNumber= default(int), int pageLimit= default(int),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Update an Item
        /// </summary>
        /// <remarks>
        ///Updates the `displayName` of the specified item. Note that updating the `displayName` of an item is not supported for BIM 360 Docs or ACC items.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
         /// <param name="modifyItemPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Item&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Item>> PatchItemAsync (string projectId, string itemId, string xUserId= default(string), ModifyItemPayload modifyItemPayload= default(ModifyItemPayload),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ItemsApi : IItemsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ItemsApi(SDKManager.SDKManager sdkManager)
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
                    value = String.Join(",", (List<string>)value);
                    dictionary.Add(name, value);
                }
                else
                {
                    List<string> newlist = new List<string>();
                    foreach (var x in (IList)value)
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;CreatedItem&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<CreatedItem>> CreateItemAsync (string projectId,string copyFrom= default(string),string xUserId= default(string),ItemPayload itemPayload= default(ItemPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateItemAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("copyFrom", copyFrom, queryParam);
                SetQueryParameter("x-user-id", xUserId, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(itemPayload); // http body (model) parameter



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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<CreatedItem>(response, default(CreatedItem));
                }
                logger.LogInformation($"Exited from CreateItemAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<CreatedItem>(response, await LocalMarshalling.DeserializeAsync<CreatedItem>(response.Content));

            } // using
        }
        /// <summary>
        /// Create a Custom Relationship for an Item
        /// </summary>
        /// <remarks>
        ///Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateItemRelationshipsRefAsync (string projectId,string itemId,string xUserId= default(string),RelationshipRefsPayload relationshipRefsPayload= default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateItemRelationshipsRefAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/relationships/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return response;
                }
                logger.LogInformation($"Exited from CreateItemRelationshipsRefAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Item&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Item>> GetItemAsync (string projectId,string itemId,string xUserId= default(string),bool includePathInProject= default(bool), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("includePathInProject", includePathInProject, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Item>(response, default(Item));
                }
                logger.LogInformation($"Exited from GetItemAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Item>(response, await LocalMarshalling.DeserializeAsync<Item>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Parent of an Item
        /// </summary>
        /// <remarks>
        ///Returns the parent folder of the specified item.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Folder&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Folder>> GetItemParentFolderAsync (string projectId,string itemId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemParentFolderAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/parent",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Folder>(response, default(Folder));
                }
                logger.LogInformation($"Exited from GetItemParentFolderAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Refs&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Refs>> GetItemRefsAsync (string projectId,string itemId,string xUserId= default(string),List<FilterTypeVersion> filterType= default(List<FilterTypeVersion>),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Refs>(response, default(Refs));
                }
                logger.LogInformation($"Exited from GetItemRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Refs>(response, await LocalMarshalling.DeserializeAsync<Refs>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipLinks&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetItemRelationshipsLinksAsync (string projectId,string itemId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemRelationshipsLinksAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/relationships/links",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<RelationshipLinks>(response, default(RelationshipLinks));
                }
                logger.LogInformation($"Exited from GetItemRelationshipsLinksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipLinks>(response, await LocalMarshalling.DeserializeAsync<RelationshipLinks>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;RelationshipRefs&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetItemRelationshipsRefsAsync (string projectId,string itemId,string xUserId= default(string),List<FilterTypeVersion> filterType= default(List<FilterTypeVersion>),List<string> filterId= default(List<string>),FilterRefType? filterRefType= null,FilterDirection? filterDirection= null,List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemRelationshipsRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[refType]", filterRefType, queryParam);
                SetQueryParameter("filter[direction]", filterDirection, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/relationships/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<RelationshipRefs>(response, default(RelationshipRefs));
                }
                logger.LogInformation($"Exited from GetItemRelationshipsRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipRefs>(response, await LocalMarshalling.DeserializeAsync<RelationshipRefs>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Tip Version of an Item
        /// </summary>
        /// <remarks>
        ///Returns the latest version of the specified item. A project can contain multiple versions of a resource item. The latest version is referred to as the tip version, which is returned by this operation.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;ItemTip&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<ItemTip>> GetItemTipAsync (string projectId,string itemId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemTipAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/tip",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<ItemTip>(response, default(ItemTip));
                }
                logger.LogInformation($"Exited from GetItemTipAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<ItemTip>(response, await LocalMarshalling.DeserializeAsync<ItemTip>(response.Content));

            } // using
        }
        /// <summary>
        /// List all Versions of an Item
        /// </summary>
        /// <remarks>
        ///Lists all versions of the specified item. A project can contain multiple versions of a resource item.
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
        /// <returns>Task of ApiResponse&lt;Versions&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Versions>> GetItemVersionsAsync (string projectId,string itemId,string xUserId= default(string),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>),List<int> filterVersionNumber= default(List<int>),int pageNumber= default(int),int pageLimit= default(int), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemVersionsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                SetQueryParameter("filter[versionNumber]", filterVersionNumber, queryParam);
                SetQueryParameter("page[number]", pageNumber, queryParam);
                SetQueryParameter("page[limit]", pageLimit, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/versions",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Versions>(response, default(Versions));
                }
                logger.LogInformation($"Exited from GetItemVersionsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Versions>(response, await LocalMarshalling.DeserializeAsync<Versions>(response.Content));

            } // using
        }
        /// <summary>
        /// Update an Item
        /// </summary>
        /// <remarks>
        ///Updates the `displayName` of the specified item. Note that updating the `displayName` of an item is not supported for BIM 360 Docs or ACC items.
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
         /// <param name="itemId">
         ///The unique identifier of an item.
         /// </param>
         /// <param name="xUserId">
         ///In a two-legged authentication context, an app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act only on behalf of the specified user. (optional)
         /// </param>
         /// <param name="modifyItemPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Item&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Item>> PatchItemAsync (string projectId,string itemId,string xUserId= default(string),ModifyItemPayload modifyItemPayload= default(ModifyItemPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into PatchItemAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.3");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(modifyItemPayload); // http body (model) parameter


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
                    } catch (HttpRequestException ex) {
                      throw new DataManagementApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<Item>(response, default(Item));
                }
                logger.LogInformation($"Exited from PatchItemAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Item>(response, await LocalMarshalling.DeserializeAsync<Item>(response.Content));

            } // using
        }
    }
}
