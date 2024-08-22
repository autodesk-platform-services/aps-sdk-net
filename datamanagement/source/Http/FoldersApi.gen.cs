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
    public interface IFoldersApi
    {
        /// <summary>
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint
        /// </summary>
        /// <remarks>
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint.  BIM 360 and ACC  To access Docs folders using the Data Management API you need to provision your app in the Account Administrator portal. For more details, see the Manage Access to Docs tutorial. The number of subfolder levels is limited to 25. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="folderPayload">Describe the folder to be created. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> CreateFolderAsync (string projectId, string xUserId= default(string), FolderPayload folderPayload= default(FolderPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Creates a custom relationship between a folder and another resource within the data
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsPayload">Describe the ref to be created. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync (string folderId, string projectId, string xUserId= default(string), RelationshipRefsPayload relationshipRefsPayload= default(RelationshipRefsPayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the folder by ID for any folder within a given project
        /// </summary>
        /// <remarks>
        /// Returns the folder by ID for any folder within a given project. All folders or sub-folders within a project are associated with their own unique ID, including the root folder.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="ifModifiedSince">If the resource has not been modified since, the response will be a 304 without any body; the Last-Modified response header will contain the date of last modification. (optional)</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderAsync (string projectId, string folderId, string ifModifiedSince= default(string), string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns a collection of items and folders within a folder
        /// </summary>
        /// <remarks>
        /// Returns a collection of items and folders within a folder. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for each item resource is included by default in the included array of the payload. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterLastModifiedTimeRollup">Filter by the lastModifiedTimeRollup in attributes Supported values are date-time string in the form YYYY-MM-DDTHH:MM:SS.000000Z or YYYY-MM-DDTHH:MM:SS based on RFC3339 (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>/// <param name="includeHidden">true: response will also include items and folders that were deleted from BIM 360 Docs projects. false (default): response will not include items and folders that were deleted from BIM 360 Docs projects.  To return only items and folders that were deleted from BIM 360 Docs projects, see the Filtering section. (optional)</param>
        /// <returns>Task of ApiResponse<FolderContents></returns>
        
        System.Threading.Tasks.Task<ApiResponse<FolderContents>> GetFolderContentsAsync (string projectId, string folderId, string xUserId= default(string), List<string> filterType= default(List<string>), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>), List<string> filterLastModifiedTimeRollup= default(List<string>), int? pageNumber= default(int?), int? pageLimit= default(int?), bool? includeHidden= default(bool?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// nt folder (if it exists)
        /// </summary>
        /// <remarks>
        /// Returns the parent folder (if it exists). In a project, subfolders and resource items are stored under a folder except the root folder which does not have a parent of its own.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderParentAsync (string projectId, string folderId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the resources (items, folders, and versions)
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the ref target. Supported values include folders, items, and versions. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<FolderRefs></returns>
        
        System.Threading.Tasks.Task<ApiResponse<FolderRefs>> GetFolderRefsAsync (string projectId, string folderId, string xUserId= default(string), string filterType= default(string), string filterId= default(string), string filterExtensionType= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns a collection of links for the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given folder_id. Custom relationships can be established between a folder and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipLinks></returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetFolderRelationshipsLinksAsync (string projectId, string folderId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Returns the custom relationships that are associated with the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipRefs></returns>
        
        System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetFolderRelationshipsRefsAsync (string folderId, string projectId, string xUserId= default(string), List<string> filterType= default(List<string>), List<string> filterId= default(List<string>), string filterRefType= null, string filterDirection= null, List<string> filterExtensionType= default(List<string>),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Filters the data of a folder and recursively in the subfolders
        /// </summary>
        /// <remarks>
        /// Filters the data of a folder and recursively in the subfolders of any project accessible to you, using the filter query string parameter. You can filter the following properties from the version payload: the type property, the id property, and any of the attributes object properties. For example, you can filter createTime, mimeType. It returns tip versions (latest versions) of properties where the filter conditions are satisfied. To verify the properties of the attributes object for a specific version, see the GET projects/:project_id/versions/:version_id.  To filter a folder's data without recursively filtering its subfolders, see the GET projects/:project_id/folders/:folder_id/contents endpoint.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="filter">Filter the data. See the Filtering section for details. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>
        /// <returns>Task of ApiResponse<Search></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Search>> GetFolderSearchAsync (string projectId, string folderId, string filter= default(string), int? pageNumber= default(int?),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Modifies folder names
        /// </summary>
        /// <remarks>
        /// Modifies folder names. You can also use this endpoint to delete and restore BIM 360 Docs folders by using the hidden attribute, or move BIM 360 Docs folders by using parent relationships.  Note that you cannot permanently delete BIM 360 Docs folders. They are tagged as hidden folders and are removed from the BIM 360 Docs UI and from regular Data Management API responses until you restore them. You can use the hidden filter (filter[hidden]=true) to get a list of deleted folders with the GET projects/:project_id/folders/:folder_id/contents endpoint.  Note that to access BIM 360 Docs folders using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="modifyFolderPayload">Describe the folder to be patched. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        System.Threading.Tasks.Task<ApiResponse<Folder>> PatchFolderAsync (string projectId, string folderId, string xUserId= default(string), ModifyFolderPayload modifyFolderPayload= default(ModifyFolderPayload),  string accessToken = null, bool throwOnError = true);
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
            if(value is List<string>)
            {
                dictionary.Add(name, string.Join(",",(List<string>)value));
            }
            else if(value is Enum)
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
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint
        /// </summary>
        /// <remarks>
        /// Creates a new folder. To delete and restore folders, use the PATCH projects/:project_id/folders/:folder_id endpoint.  BIM 360 and ACC  To access Docs folders using the Data Management API you need to provision your app in the Account Administrator portal. For more details, see the Manage Access to Docs tutorial. The number of subfolder levels is limited to 25. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="folderPayload">Describe the folder to be created. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Folder>> CreateFolderAsync (string projectId,string xUserId= default(string),FolderPayload folderPayload= default(FolderPayload), string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
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
        /// Creates a custom relationship between a folder and another resource within the data
        /// </summary>
        /// <remarks>
        /// Creates a custom relationship between a folder and another resource within the data domain service (folder, item, or version).
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="relationshipRefsPayload">Describe the ref to be created. (optional)</param>
        
        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateFolderRelationshipsRefAsync (string folderId,string projectId,string xUserId= default(string),RelationshipRefsPayload relationshipRefsPayload= default(RelationshipRefsPayload), string accessToken = null, bool throwOnError = true)
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
                logger.LogInformation($"Exited from CreateFolderRelationshipsRefAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Returns the folder by ID for any folder within a given project
        /// </summary>
        /// <remarks>
        /// Returns the folder by ID for any folder within a given project. All folders or sub-folders within a project are associated with their own unique ID, including the root folder.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="ifModifiedSince">If the resource has not been modified since, the response will be a 304 without any body; the Last-Modified response header will contain the date of last modification. (optional)</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderAsync (string projectId,string folderId,string ifModifiedSince= default(string),string xUserId= default(string), string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
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
        /// Returns a collection of items and folders within a folder
        /// </summary>
        /// <remarks>
        /// Returns a collection of items and folders within a folder. Items represent word documents, fusion design files, drawings, spreadsheets, etc.  Notes:  The tip version for each item resource is included by default in the included array of the payload. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>/// <param name="filterLastModifiedTimeRollup">Filter by the lastModifiedTimeRollup in attributes Supported values are date-time string in the form YYYY-MM-DDTHH:MM:SS.000000Z or YYYY-MM-DDTHH:MM:SS based on RFC3339 (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>/// <param name="pageLimit">Specifies the maximum number of elements to return in the page. The default value is 200. The min value is 1. The max value is 200. (optional)</param>/// <param name="includeHidden">true: response will also include items and folders that were deleted from BIM 360 Docs projects. false (default): response will not include items and folders that were deleted from BIM 360 Docs projects.  To return only items and folders that were deleted from BIM 360 Docs projects, see the Filtering section. (optional)</param>
        /// <returns>Task of ApiResponse<FolderContents></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<FolderContents>> GetFolderContentsAsync (string projectId,string folderId,string xUserId= default(string),List<string> filterType= default(List<string>),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>),List<string> filterLastModifiedTimeRollup= default(List<string>),int? pageNumber= default(int?),int? pageLimit= default(int?),bool? includeHidden= default(bool?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderContentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[type]", filterType, queryParam);
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension_type]", filterExtensionType, queryParam);
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
                    return new ApiResponse<FolderContents>(response, default(FolderContents));
                }
                logger.LogInformation($"Exited from GetFolderContentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<FolderContents>(response, await LocalMarshalling.DeserializeAsync<FolderContents>(response.Content));

            } // using
        }
        /// <summary>
        /// nt folder (if it exists)
        /// </summary>
        /// <remarks>
        /// Returns the parent folder (if it exists). In a project, subfolders and resource items are stored under a folder except the root folder which does not have a parent of its own.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Folder>> GetFolderParentAsync (string projectId,string folderId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
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
                logger.LogInformation($"Exited from GetFolderParentAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Folder>(response, await LocalMarshalling.DeserializeAsync<Folder>(response.Content));

            } // using
        }
        /// <summary>
        /// Returns the resources (items, folders, and versions)
        /// </summary>
        /// <remarks>
        /// Returns the resources (items, folders, and versions) that have a custom relationship with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, attributes, and relationships links. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the ref resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/relationships/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the ref target. Supported values include folders, items, and versions. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<FolderRefs></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<FolderRefs>> GetFolderRefsAsync (string projectId,string folderId,string xUserId= default(string),string filterType= default(string),string filterId= default(string),string filterExtensionType= default(string), string accessToken = null, bool throwOnError = true)
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
                    return new ApiResponse<FolderRefs>(response, default(FolderRefs));
                }
                logger.LogInformation($"Exited from GetFolderRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<FolderRefs>(response, await LocalMarshalling.DeserializeAsync<FolderRefs>(response.Content));

            } // using
        }
        /// <summary>
        /// Returns a collection of links for the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns a collection of links for the given folder_id. Custom relationships can be established between a folder and other external resources residing outside the data domain service. A link’s href defines the target URI to access a resource.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipLinks></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RelationshipLinks>> GetFolderRelationshipsLinksAsync (string projectId,string folderId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
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
                logger.LogInformation($"Exited from GetFolderRelationshipsLinksAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipLinks>(response, await LocalMarshalling.DeserializeAsync<RelationshipLinks>(response.Content));

            } // using
        }
        /// <summary>
        /// Returns the custom relationships that are associated with the given folder_id
        /// </summary>
        /// <remarks>
        /// Returns the custom relationships that are associated with the given folder_id. Custom relationships can be established between a folder and other resources within the data domain service (folders, items, and versions).  Notes:  Each relationship is defined by the id of the object at the other end of the relationship, together with type, specific reference meta including extension data. Callers will typically use a filter parameter to restrict the response to the custom relationship types (filter[meta.refType]) they are interested in. The response body will have an included array which contains the resources that are involved in the relationship, which is essentially the GET projects/:project_id/folders/:folder_id/refs endpoint. New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="folderId">The unique identifier of a folder.</param>/// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="filterType">Filter by the type of the objects in the folder. Supported values include folders and items. (optional)</param>/// <param name="filterId">Filter by the id of the ref target. (optional)</param>/// <param name="filterRefType">Filter by refType. Possible values: derived, dependencies, auxiliary, xrefs, includes (optional)</param>/// <param name="filterDirection">Filter by the direction of the reference. Possible values: from, to (optional)</param>/// <param name="filterExtensionType">Filter by the extension type. (optional)</param>
        /// <returns>Task of ApiResponse<RelationshipRefs></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<RelationshipRefs>> GetFolderRelationshipsRefsAsync (string folderId,string projectId,string xUserId= default(string),List<string> filterType= default(List<string>),List<string> filterId= default(List<string>),string filterRefType= null,string filterDirection= null,List<string> filterExtensionType= default(List<string>), string accessToken = null, bool throwOnError = true)
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
                logger.LogInformation($"Exited from GetFolderRelationshipsRefsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<RelationshipRefs>(response, await LocalMarshalling.DeserializeAsync<RelationshipRefs>(response.Content));

            } // using
        }
        /// <summary>
        /// Filters the data of a folder and recursively in the subfolders
        /// </summary>
        /// <remarks>
        /// Filters the data of a folder and recursively in the subfolders of any project accessible to you, using the filter query string parameter. You can filter the following properties from the version payload: the type property, the id property, and any of the attributes object properties. For example, you can filter createTime, mimeType. It returns tip versions (latest versions) of properties where the filter conditions are satisfied. To verify the properties of the attributes object for a specific version, see the GET projects/:project_id/versions/:version_id.  To filter a folder's data without recursively filtering its subfolders, see the GET projects/:project_id/folders/:folder_id/contents endpoint.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="filter">Filter the data. See the Filtering section for details. (optional)</param>/// <param name="pageNumber">Specifies what page to return. Page numbers are 0-based (the first page is page 0). (optional)</param>
        /// <returns>Task of ApiResponse<Search></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Search>> GetFolderSearchAsync (string projectId,string folderId,string filter= default(string),int? pageNumber= default(int?), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetFolderSearchAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter", filter, queryParam);
                SetQueryParameter("page[number]", pageNumber, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/folders/{folder_id}/search",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "folder_id", folderId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




                // tell the underlying pipeline what scope we'd like to use
                // if (scopes == null)
                // {
                    // TBD:Naren FORCE-4027 - If accessToken is null, acquire auth token using auth SDK, with defined scope.
                    // request.Properties.Add(ForgeApsConfiguration.ScopeKey.ToString(), "data:read data:search ");
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
                    return new ApiResponse<Search>(response, default(Search));
                }
                logger.LogInformation($"Exited from GetFolderSearchAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Search>(response, await LocalMarshalling.DeserializeAsync<Search>(response.Content));

            } // using
        }
        /// <summary>
        /// Modifies folder names
        /// </summary>
        /// <remarks>
        /// Modifies folder names. You can also use this endpoint to delete and restore BIM 360 Docs folders by using the hidden attribute, or move BIM 360 Docs folders by using parent relationships.  Note that you cannot permanently delete BIM 360 Docs folders. They are tagged as hidden folders and are removed from the BIM 360 Docs UI and from regular Data Management API responses until you restore them. You can use the hidden filter (filter[hidden]=true) to get a list of deleted folders with the GET projects/:project_id/folders/:folder_id/contents endpoint.  Note that to access BIM 360 Docs folders using the Data Management API you need to provision your app in the BIM 360 Account Administrator portal. For more details, see the Manage Access to Docs tutorial.  New! Autodesk Construction Cloud platform (ACC). Note that this endpoint is compatible with ACC projects. For more information about the Autodesk Construction Cloud APIs, see the Autodesk Construction Cloud documentation.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">The unique identifier of a project. For BIM 360 Docs, the project ID in the Data Management API corresponds to the project ID in the BIM 360 API. To convert a project ID in the BIM 360 API into a project ID in the Data Management API you need to add a “b.\&quot; prefix. For example, a project ID of c8b0c73d-3ae9 translates to a project ID of b.c8b0c73d-3ae9.</param>/// <param name="folderId">The unique identifier of a folder.</param>/// <param name="xUserId">In a two-legged authentication context, the app has access to all users specified by the administrator in the SaaS integrations UI. By providing this header, the API call will be limited to act on behalf of only the user specified. (optional)</param>/// <param name="modifyFolderPayload">Describe the folder to be patched. (optional)</param>
        /// <returns>Task of ApiResponse<Folder></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Folder>> PatchFolderAsync (string projectId,string folderId,string xUserId= default(string),ModifyFolderPayload modifyFolderPayload= default(ModifyFolderPayload), string accessToken = null, bool throwOnError = true)
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
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/1.0.0");
                if(!string.IsNullOrEmpty(accessToken))
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
                    } catch (HttpRequestException ex) {
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
