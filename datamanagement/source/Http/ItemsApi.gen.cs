/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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

namespace Autodesk.DataManagement.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IItemsApi
    {
        /// <summary>
        /// Creates the first version of a file (item)
        /// </summary>
        /// <remarks>
        /// Creates the first version of a file (item). To create additional versions of an item, use POST versions.  Before you create the first version you need to create a storage location for the file, and upload the file to the storage object. For more details about the workflow, see the tutorial on uploading a file.  This endpoint also copies versions of items to other folders in the same project. The endpoint creates a new item and a first version of the item in the target folder. You cannot copy versions of items across different projects and accounts.  To copy versions of items to existng items in other folders, use POST versions. POST versions creates a new version of the existing item in the target folder.  Note that to access BIM 360 Docs files using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="copyFrom">Only relevant for copying files to BIM 360 Docs - the version ID (URN) of the file to copy. For details about finding the URN, follow the initial steps in the Download a File tutorial.  You can only copy files to the Plans folder or to subfolders of the Plans folder with an item:autodesk.bim360:Document item extension type, and you can only copy files to the Project Files folder or to subfolders of the Project Files folder with an item:autodesk.bim360:File item extension type.  To verify an item’s extension type, use GET item, and check the attributes.extension.type attribute.  Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if the end user did not have permission to download files in the source folder, but does have permission to download files in the target folder, he/she will not be able to download the copied file.  Note that you cannot copy a file if it is in the middle of being uploaded, updated, or copied. To verify the current process state of a file, call GET item, and check the attributes.extension.data.processState attribute. (optional)</param>/// <param name="itemPayload">Describe the item to be created. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Item>> CreateItemAsync (string projectId, string xUserId= default(string), string copyFrom= default(string), ItemPayload itemPayload= default(ItemPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsPayload">Describe the ref to be created. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateItemRelationshipsRefAsync (string projectId, string itemId, string xUserId= default(string), RelationshipRefsPayload relationshipRefsPayload= default(RelationshipRefsPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Retrieves metadata for a specified item
        /// </summary>
        /// <remarks>
        /// Retrieves metadata for a specified item. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for the item is included in the included array of the payload. To retrieve metadata for multiple items, see the ListItems command. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="includePathInProject">Specify whether to return pathInProject attribute in response for BIM 360 Docs projects. pathInProject is the relative path of the item starting from project’s root folder. true: response will include pathInProject attribute for BIM 360 Docs projects.  false (default): response will not include pathInProject attribute for BIM 360 Docs projects. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Item>> GetItemAsync (string projectId, string itemId, string xUserId= default(string), bool? includePathInProject= default(bool?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the \&quot;parent\&quot; folder for the given item
        /// </summary>
        /// <remarks>
        /// Returns the \"parent\" folder for the given item.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> GetItemParentFolderAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<Refs></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Refs>> GetItemRefsAsync (string projectId, string itemId, string xUserId= default(string), List<string> filterType= default(List<string>), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns a collection of links for the given item_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given item_id. Custom relationships can be established between an item and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipLinks></returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetItemRelationshipsLinksAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the custom relationships that are associated with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipRefs></returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetItemRelationshipsRefsAsync (string projectId, string itemId, string xUserId= default(string), List<string> filterType= default(List<string>), List<string> filterId= default(List<string>), string filterRefType= null, string filterDirection= null, List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the “tip” version for the given item
        /// </summary>
        /// <remarks>
        /// Returns the “tip” version for the given item. Multiple versions of a resource item can be uploaded in a project. The tip version is the most recent one.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<ItemTip></returns>
        
        System.Threading.Tasks.Task<ApiResponse<ItemTip>> GetItemTipAsync (string projectId, string itemId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns versions for the given item
        /// </summary>
        /// <remarks>
        /// Returns versions for the given item. Multiple versions of a resource item can be uploaded in a project.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterVersionNumber">Filter by versionNumber. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>
        /// <returns>Task of ApiResponse<Versions></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Versions>> GetItemVersionsAsync (string projectId, string itemId, string xUserId= default(string), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>), List<int?> filterVersionNumber= default(List<int?>), int? pageNumber= default(int?), int? pageLimit= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Updates the properties of the given item_id object
        /// </summary>
        /// <remarks>
        /// Updates the properties of the given item_id object.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="modifyItemPayload">Describe the item to be patched. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
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
        /// Creates the first version of a file (item)
        /// </summary>
        /// <remarks>
        /// Creates the first version of a file (item). To create additional versions of an item, use POST versions.  Before you create the first version you need to create a storage location for the file, and upload the file to the storage object. For more details about the workflow, see the tutorial on uploading a file.  This endpoint also copies versions of items to other folders in the same project. The endpoint creates a new item and a first version of the item in the target folder. You cannot copy versions of items across different projects and accounts.  To copy versions of items to existng items in other folders, use POST versions. POST versions creates a new version of the existing item in the target folder.  Note that to access BIM 360 Docs files using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="copyFrom">Only relevant for copying files to BIM 360 Docs - the version ID (URN) of the file to copy. For details about finding the URN, follow the initial steps in the Download a File tutorial.  You can only copy files to the Plans folder or to subfolders of the Plans folder with an item:autodesk.bim360:Document item extension type, and you can only copy files to the Project Files folder or to subfolders of the Project Files folder with an item:autodesk.bim360:File item extension type.  To verify an item’s extension type, use GET item, and check the attributes.extension.type attribute.  Note that if you copy a file to the Plans folder or to a subfolder of the Plans folder, the copied file inherits the permissions of the source file. For example, if the end user did not have permission to download files in the source folder, but does have permission to download files in the target folder, he/she will not be able to download the copied file.  Note that you cannot copy a file if it is in the middle of being uploaded, updated, or copied. To verify the current process state of a file, call GET item, and check the attributes.extension.data.processState attribute. (optional)</param>/// <param name="itemPayload">Describe the item to be created. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Item>> CreateItemAsync (string projectId,string xUserId= default(string),string copyFrom= default(string),ItemPayload itemPayload= default(ItemPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateItemAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("copyFrom", copyFrom, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(itemPayload); // http body (model) parameter


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
                    return new ApiResponse<Item>(response, default(Item));
                }
                logger.LogInformation($"Exited from CreateItemAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Item>(response, await LocalMarshalling.DeserializeAsync<Item>(response.Content));

            } // using
        }
        /// <summary>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between an item and another resource within the data domain service (folder, item, or version)
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsPayload">Describe the ref to be created. (optional)</param>
        
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Retrieves metadata for a specified item
        /// </summary>
        /// <remarks>
        /// Retrieves metadata for a specified item. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for the item is included in the included array of the payload. To retrieve metadata for multiple items, see the ListItems command. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="includePathInProject">Specify whether to return pathInProject attribute in response for BIM 360 Docs projects. pathInProject is the relative path of the item starting from project’s root folder. true: response will include pathInProject attribute for BIM 360 Docs projects.  false (default): response will not include pathInProject attribute for BIM 360 Docs projects. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Item>> GetItemAsync (string projectId,string itemId,string xUserId= default(string),bool? includePathInProject= default(bool?), string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns the \&quot;parent\&quot; folder for the given item
        /// </summary>
        /// <remarks>
        /// Returns the \"parent\" folder for the given item.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<Refs></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Refs>> GetItemRefsAsync (string projectId,string itemId,string xUserId= default(string),List<string> filterType= default(List<string>),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter_type", filterType, queryParam);
                SetQueryParameter("filter_id", filterId, queryParam);
                SetQueryParameter("filter_extension_type", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns a collection of links for the given item_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given item_id. Custom relationships can be established between an item and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipLinks></returns>
        
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns the custom relationships that are associated with the given item_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given item_id. Custom relationships can be established between an item and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/items/:item_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipRefs></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetItemRelationshipsRefsAsync (string projectId,string itemId,string xUserId= default(string),List<string> filterType= default(List<string>),List<string> filterId= default(List<string>),string filterRefType= null,string filterDirection= null,List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemRelationshipsRefsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter_type", filterType, queryParam);
                SetQueryParameter("filter_id", filterId, queryParam);
                SetQueryParameter("filter_refType", filterRefType, queryParam);
                SetQueryParameter("filter_direction", filterDirection, queryParam);
                SetQueryParameter("filter_extension_type", filterExtensionType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/relationships/refs",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns the “tip” version for the given item
        /// </summary>
        /// <remarks>
        /// Returns the “tip” version for the given item. Multiple versions of a resource item can be uploaded in a project. The tip version is the most recent one.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<ItemTip></returns>
        
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Returns versions for the given item
        /// </summary>
        /// <remarks>
        /// Returns versions for the given item. Multiple versions of a resource item can be uploaded in a project.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterVersionNumber">Filter by versionNumber. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>
        /// <returns>Task of ApiResponse<Versions></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Versions>> GetItemVersionsAsync (string projectId,string itemId,string xUserId= default(string),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>),List<int?> filterVersionNumber= default(List<int?>),int? pageNumber= default(int?),int? pageLimit= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetItemVersionsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter_id", filterId, queryParam);
                SetQueryParameter("filter_extension_type", filterExtensionType, queryParam);
                SetQueryParameter("filter_versionNumber", filterVersionNumber, queryParam);
                SetQueryParameter("page_number", pageNumber, queryParam);
                SetQueryParameter("page_limit", pageLimit, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/items/{item_id}/versions",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "item_id", itemId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
        /// Updates the properties of the given item_id object
        /// </summary>
        /// <remarks>
        /// Updates the properties of the given item_id object.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="itemId">The unique identifier of an item.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="modifyItemPayload">Describe the item to be patched. (optional)</param>
        /// <returns>Task of ApiResponse<Item></returns>
        
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
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
