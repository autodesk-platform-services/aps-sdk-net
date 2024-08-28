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
    public interface IProjectsApi
    {
        /// <summary>
        /// Create a Storage Location in OSS
        /// </summary>
        /// <remarks>
        ///Creates a placeholder for an item or a version of an item in the OSS. Later, you can upload the binary content for the item or version to this storage location.
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
         /// <param name="storagePayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Storage&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Storage>> CreateStorageAsync (string projectId, string xUserId= default(string), StoragePayload storagePayload= default(StoragePayload),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Download Details
        /// </summary>
        /// <remarks>
        ///Returns the details of a downloadable format of a version of an item.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Download&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Download>> GetDownloadAsync (string projectId, string downloadId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Check Download Creation Progress
        /// </summary>
        /// <remarks>
        ///Checks the status of a job that generates a downloadable format of a version of an item. 
///
///**Note**: If the job has finished, this operation returns a HTTP status 303, with the `location` return header set to the URI that returns the details of the download.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Job&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Job>> GetDownloadJobAsync (string projectId, string jobId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Projects&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Projects>> GetHubProjectsAsync (string hubId, string xUserId= default(string), List<string> filterId= default(List<string>), List<string> filterExtensionType= default(List<string>), int pageNumber= default(int), int pageLimit= default(int),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Project&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Project>> GetProjectAsync (string hubId, string projectId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Get Hub for Project
        /// </summary>
        /// <remarks>
        ///Returns the hub that contains the project specified by the  `project_id` parameter.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Hub&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<Hub>> GetProjectHubAsync (string hubId, string projectId, string xUserId= default(string),  string accessToken = null, bool throwOnError = true);
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;TopFolders&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<TopFolders>> GetProjectTopFoldersAsync (string hubId, string projectId, string xUserId= default(string), bool excludeDeleted= default(bool), bool projectFilesOnly= default(bool),  string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Create Download
        /// </summary>
        /// <remarks>
        ///Kicks off a job to generate the specified download format of the version. Once the job completes, the specified format becomes available for download. 
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
         /// <param name="downloadPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;CreatedDownload&gt;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<CreatedDownload>> StartDownloadAsync (string projectId, string xUserId= default(string), DownloadPayload downloadPayload= default(DownloadPayload),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProjectsApi : IProjectsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public ProjectsApi(SDKManager.SDKManager sdkManager)
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
        /// Create a Storage Location in OSS
        /// </summary>
        /// <remarks>
        ///Creates a placeholder for an item or a version of an item in the OSS. Later, you can upload the binary content for the item or version to this storage location.
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
         /// <param name="storagePayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;Storage&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Storage>> CreateStorageAsync (string projectId,string xUserId= default(string),StoragePayload storagePayload= default(StoragePayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateStorageAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/storage",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(storagePayload); // http body (model) parameter


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
                    return new ApiResponse<Storage>(response, default(Storage));
                }
                logger.LogInformation($"Exited from CreateStorageAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Storage>(response, await LocalMarshalling.DeserializeAsync<Storage>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Download Details
        /// </summary>
        /// <remarks>
        ///Returns the details of a downloadable format of a version of an item.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Download&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Download>> GetDownloadAsync (string projectId,string downloadId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetDownloadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/downloads/{download_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "download_id", downloadId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<Download>(response, default(Download));
                }
                logger.LogInformation($"Exited from GetDownloadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Download>(response, await LocalMarshalling.DeserializeAsync<Download>(response.Content));

            } // using
        }
        /// <summary>
        /// Check Download Creation Progress
        /// </summary>
        /// <remarks>
        ///Checks the status of a job that generates a downloadable format of a version of an item. 
///
///**Note**: If the job has finished, this operation returns a HTTP status 303, with the `location` return header set to the URI that returns the details of the download.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Job&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Job>> GetDownloadJobAsync (string projectId,string jobId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetDownloadJobAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/jobs/{job_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                            { "job_id", jobId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<Job>(response, default(Job));
                }
                logger.LogInformation($"Exited from GetDownloadJobAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Job>(response, await LocalMarshalling.DeserializeAsync<Job>(response.Content));

            } // using
        }
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Projects&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Projects>> GetHubProjectsAsync (string hubId,string xUserId= default(string),List<string> filterId= default(List<string>),List<string> filterExtensionType= default(List<string>),int pageNumber= default(int),int pageLimit= default(int), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetHubProjectsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("filter[id]", filterId, queryParam);
                SetQueryParameter("filter[extension.type]", filterExtensionType, queryParam);
                SetQueryParameter("page[number]", pageNumber, queryParam);
                SetQueryParameter("page[limit]", pageLimit, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs/{hub_id}/projects",
                        routeParameters: new Dictionary<string, object> {
                            { "hub_id", hubId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<Projects>(response, default(Projects));
                }
                logger.LogInformation($"Exited from GetHubProjectsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Projects>(response, await LocalMarshalling.DeserializeAsync<Projects>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Project&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Project>> GetProjectAsync (string hubId,string projectId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs/{hub_id}/projects/{project_id}",
                        routeParameters: new Dictionary<string, object> {
                            { "hub_id", hubId},
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<Project>(response, default(Project));
                }
                logger.LogInformation($"Exited from GetProjectAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Project>(response, await LocalMarshalling.DeserializeAsync<Project>(response.Content));

            } // using
        }
        /// <summary>
        /// Get Hub for Project
        /// </summary>
        /// <remarks>
        ///Returns the hub that contains the project specified by the  `project_id` parameter.
///
///**Note:** This operation supports Autodesk Construction Cloud (ACC) Projects. For more information, see the [ACC Platform API documentation](https://en.docs.acc.v1/overview/introduction/). 
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;Hub&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<Hub>> GetProjectHubAsync (string hubId,string projectId,string xUserId= default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectHubAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs/{hub_id}/projects/{project_id}/hub",
                        routeParameters: new Dictionary<string, object> {
                            { "hub_id", hubId},
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<Hub>(response, default(Hub));
                }
                logger.LogInformation($"Exited from GetProjectHubAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Hub>(response, await LocalMarshalling.DeserializeAsync<Hub>(response.Content));

            } // using
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
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
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
        /// <returns>Task of ApiResponse&lt;TopFolders&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<TopFolders>> GetProjectTopFoldersAsync (string hubId,string projectId,string xUserId= default(string),bool excludeDeleted= default(bool),bool projectFilesOnly= default(bool), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetProjectTopFoldersAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("excludeDeleted", excludeDeleted, queryParam);
                SetQueryParameter("projectFilesOnly", projectFilesOnly, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/project/v1/hubs/{hub_id}/projects/{project_id}/topFolders",
                        routeParameters: new Dictionary<string, object> {
                            { "hub_id", hubId},
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
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
                    return new ApiResponse<TopFolders>(response, default(TopFolders));
                }
                logger.LogInformation($"Exited from GetProjectTopFoldersAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<TopFolders>(response, await LocalMarshalling.DeserializeAsync<TopFolders>(response.Content));

            } // using
        }
        /// <summary>
        /// Create Download
        /// </summary>
        /// <remarks>
        ///Kicks off a job to generate the specified download format of the version. Once the job completes, the specified format becomes available for download. 
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
         /// <param name="downloadPayload">
         /// (optional)
         /// </param>
        /// <returns>Task of ApiResponse&lt;CreatedDownload&gt;></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<CreatedDownload>> StartDownloadAsync (string projectId,string xUserId= default(string),DownloadPayload downloadPayload= default(DownloadPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into StartDownloadAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/data/v1/projects/{project_id}/downloads",
                        routeParameters: new Dictionary<string, object> {
                            { "project_id", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/DATA MANAGEMENT/C#/2.0.0");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(downloadPayload); // http body (model) parameter


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
                    return new ApiResponse<CreatedDownload>(response, default(CreatedDownload));
                }
                logger.LogInformation($"Exited from StartDownloadAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<CreatedDownload>(response, await LocalMarshalling.DeserializeAsync<CreatedDownload>(response.Content));

            } // using
        }
    }
}
