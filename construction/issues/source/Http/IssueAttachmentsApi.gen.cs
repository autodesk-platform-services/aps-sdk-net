/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;
using Autodesk.Construction.Issues.Client;

namespace Autodesk.Construction.Issues.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIssueAttachmentsApi
    {
        /// <summary>
        /// Your POST endpoint
        /// </summary>
        /// <remarks>
        ///Adds attachments to an existing issue.
        ///
        ///Links one or more files in Autodesk Docs (uploaded via the Data Management OSS API) to the specified issue.
        ///
        ///Note that an issue can have up to 100 attachments. Files can include images, PDFs, or other supported formats.
        ///
        ///For more information about uploading attachments, see the Upload Issue Attachment tutorial.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="attachmentsPayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Attachments&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Attachments>> AddAttachmentsAsync(string projectId, AttachmentsPayload attachmentsPayload = default(AttachmentsPayload), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Your DELETE endpoint
        /// </summary>
        /// <remarks>
        ///Deletes a specific attachment from an issue in a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project. Use the Data Management API to retrieve the project ID. For more information, see the Retrieve a Project ID tutorial. You need to convert the project ID into a project ID for the ACC API by removing the “b." prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue. To find the ID, call GET issues.
        /// </param>
        /// <param name="attachmentId">
        ///The unique identifier of the attachment. To find the ID, call GET attachments.
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        System.Threading.Tasks.Task<HttpResponseMessage> DeleteAttachmentAsync(string projectId, string issueId, string attachmentId, string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves all attachments for a specific issue in a project.
        ///
        ///For details about retrieving metadata for a specific attachment, see the Retrieve Issue Attachment tutorial.
        ///
        ///For details about downloading an attachment, see the Download Issue Attachment tutorial.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project. Use the Data Management API to retrieve the project ID. For more information, see the Retrieve a Project ID tutorial. You need to convert the project ID into a project ID for the ACC API by removing the “b." prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue. To find the ID, call GET issues.
        /// </param>
        /// <returns>Task of ApiResponse&lt;Attachments&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Attachments>> GetAttachmentsAsync(string projectId, string issueId, string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IssueAttachmentsApi : IIssueAttachmentsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueAttachmentsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public IssueAttachmentsApi(SDKManager.SDKManager sdkManager)
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
        /// Your POST endpoint
        /// </summary>
        /// <remarks>
        ///Adds attachments to an existing issue.
        ///
        ///Links one or more files in Autodesk Docs (uploaded via the Data Management OSS API) to the specified issue.
        ///
        ///Note that an issue can have up to 100 attachments. Files can include images, PDFs, or other supported formats.
        ///
        ///For more information about uploading attachments, see the Upload Issue Attachment tutorial.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="attachmentsPayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Attachments&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Attachments>> AddAttachmentsAsync(string projectId, AttachmentsPayload attachmentsPayload = default(AttachmentsPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into AddAttachmentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/attachments",
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

                request.Content = Marshalling.Serialize(attachmentsPayload); // http body (model) parameter



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
                    return new ApiResponse<Attachments>(response, default(Attachments));
                }
                logger.LogInformation($"Exited from AddAttachmentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Attachments>(response, await LocalMarshalling.DeserializeAsync<Attachments>(response.Content));

            } // using
        }
        /// <summary>
        /// Your DELETE endpoint
        /// </summary>
        /// <remarks>
        ///Deletes a specific attachment from an issue in a project.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project. Use the Data Management API to retrieve the project ID. For more information, see the Retrieve a Project ID tutorial. You need to convert the project ID into a project ID for the ACC API by removing the “b." prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue. To find the ID, call GET issues.
        /// </param>
        /// <param name="attachmentId">
        ///The unique identifier of the attachment. To find the ID, call GET attachments.
        /// </param>

        /// <returns>Task of HttpResponseMessage</returns>
        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAttachmentAsync(string projectId, string issueId, string attachmentId, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into DeleteAttachmentAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/attachments/{issueId}/items/{attachmentId}",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "issueId", issueId},
                            { "attachmentId", attachmentId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




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

                request.Method = new HttpMethod("DELETE");

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
                    return response;
                }
                logger.LogInformation($"Exited from DeleteAttachmentAsync with response statusCode: {response.StatusCode}");
                return response;

            } // using
        }
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves all attachments for a specific issue in a project.
        ///
        ///For details about retrieving metadata for a specific attachment, see the Retrieve Issue Attachment tutorial.
        ///
        ///For details about downloading an attachment, see the Download Issue Attachment tutorial.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="issueId">
        ///The ID of the project. Use the Data Management API to retrieve the project ID. For more information, see the Retrieve a Project ID tutorial. You need to convert the project ID into a project ID for the ACC API by removing the “b." prefix. For example, a project ID of b.a4be0c34a-4ab7 translates to a project ID of a4be0c34a-4ab7.
        /// </param>
        /// <param name="projectId">
        ///The unique identifier of the issue. To find the ID, call GET issues.
        /// </param>
        /// <returns>Task of ApiResponse&lt;Attachments&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Attachments>> GetAttachmentsAsync(string projectId, string issueId, string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetAttachmentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/attachments/{issueId}/items",
                        routeParameters: new Dictionary<string, object> {
                            { "issueId", issueId},
                            { "projectId", projectId},
                        },
                        queryParameters: queryParam
                    );
            logger.LogDebug($"projectId: {projectId}");
            logger.LogDebug($"issueId: {issueId}");
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }




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
                    return new ApiResponse<Attachments>(response, default(Attachments));
                }
                logger.LogInformation($"Exited from GetAttachmentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Attachments>(response, await LocalMarshalling.DeserializeAsync<Attachments>(response.Content));

            } // using
        }
    }
}
