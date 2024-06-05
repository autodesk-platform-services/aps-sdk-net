/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
using Autodesk.Construction.Issues.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Autodesk.SDKManager;

namespace Autodesk.Construction.Issues.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIssueCommentsApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        ///Creates a new comment under a specific issue.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="commentsPayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;CreatedComment&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<CreatedComment>> CreateCommentsAsync(string projectId, string issueId, Region? xAdsRegion = null, CommentsPayload commentsPayload = default(CommentsPayload), string accessToken = null, bool throwOnError = true);
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Get all the comments for a specific issue.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="limit">
        ///Add limit=20 to limit the results count (together with the offset to support pagination). (optional)
        /// </param>
        /// <param name="offset">
        ///Add offset=20 to get partial results (together with the limit to support pagination). (optional)
        /// </param>
        /// <param name="sortBy">
        ///Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Comments&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<Comments>> GetCommentsAsync(string projectId, string issueId, Region? xAdsRegion = null, string limit = default(string), string offset = default(string), List<SortBy> sortBy = default(List<SortBy>), string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IssueCommentsApi : IIssueCommentsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueCommentsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public IssueCommentsApi(SDKManager.SDKManager sdkManager)
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
        /// 
        /// </summary>
        /// <remarks>
        ///Creates a new comment under a specific issue.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="commentsPayload">
        /// (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;CreatedComment&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<CreatedComment>> CreateCommentsAsync(string projectId, string issueId, Region? xAdsRegion = null, CommentsPayload commentsPayload = default(CommentsPayload), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into CreateCommentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues/{issueId}/comments",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "issueId", issueId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0-beta1");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }

                request.Content = Marshalling.Serialize(commentsPayload); // http body (model) parameter


                SetHeader("x-ads-region", xAdsRegion, request);

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
                    return new ApiResponse<CreatedComment>(response, default(CreatedComment));
                }
                logger.LogInformation($"Exited from CreateCommentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<CreatedComment>(response, await LocalMarshalling.DeserializeAsync<CreatedComment>(response.Content));

            } // using
        }
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Get all the comments for a specific issue.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="issueId">
        ///The unique identifier of the issue.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="limit">
        ///Add limit=20 to limit the results count (together with the offset to support pagination). (optional)
        /// </param>
        /// <param name="offset">
        ///Add offset=20 to get partial results (together with the limit to support pagination). (optional)
        /// </param>
        /// <param name="sortBy">
        ///Sort issue comments by specified fields. Separate multiple values with commas. To sort in descending order add a - (minus sign) before the sort criteria (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;Comments&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<Comments>> GetCommentsAsync(string projectId, string issueId, Region? xAdsRegion = null, string limit = default(string), string offset = default(string), List<SortBy> sortBy = default(List<SortBy>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetCommentsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("sortBy", sortBy, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issues/{issueId}/comments",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                            { "issueId", issueId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/1.0.0-beta1");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", xAdsRegion, request);

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
                    return new ApiResponse<Comments>(response, default(Comments));
                }
                logger.LogInformation($"Exited from GetCommentsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<Comments>(response, await LocalMarshalling.DeserializeAsync<Comments>(response.Content));

            } // using
        }
    }
}
