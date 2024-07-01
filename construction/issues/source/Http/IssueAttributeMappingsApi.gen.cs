/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
using System.Collections;

namespace Autodesk.Construction.Issues.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIssueAttributeMappingsApi
    {
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves information about the issue custom attributes (custom fields) that are assigned to issue categories and issue types.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="limit">
        ///The number of custom attribute mappings to return in the response payload. For example, limit=2. Acceptable values: 1-200. Default value: 200. (optional)
        /// </param>
        /// <param name="offset">
        ///The number of custom attribute mappings you want to begin retrieving results from. (optional)
        /// </param>
        /// <param name="filterCreatedAt">
        ///Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        ///Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterDeletedAt">
        ///Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAttributeDefinitionId">
        ///Retrieves issue custom attribute mappings associated with the specified issue custom attribute definitions. Separate multiple values with commas. For example: filter[attributeDefinitionId]=18ee5858-cbf1-451a-a525-7c6ff8156775. (optional)
        /// </param>
        /// <param name="filterMappedItemId">
        ///Retrieves issue custom attribute mappings associated with the specified items (project, type, or subtype). Separate multiple values with commas. For example: filter[mappedItemId]=18ee5858-cbf1-451a-a525-7c6ff8156775. Note that this does not retrieve inherited custom attribute mappings or custom attribute mappings of descendants. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;AttrMapping&gt;</returns>

        System.Threading.Tasks.Task<ApiResponse<AttrMapping>> GetAttributeMappingsAsync(string projectId, Region? xAdsRegion = null, int? limit = default(int?), int? offset = default(int?), string filterCreatedAt = default(string), string filterUpdatedAt = default(string), string filterDeletedAt = default(string), string filterAttributeDefinitionId = default(string), string filterMappedItemId = default(string), string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IssueAttributeMappingsApi : IIssueAttributeMappingsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueAttributeMappingsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public IssueAttributeMappingsApi(SDKManager.SDKManager sdkManager)
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
                    value = String.Join(",",(List<string>)value);
                     dictionary.Add(name, value);
                }
                else 
                {
                    List<string>newlist = new List<string>();
                    foreach ( var x in (IList)value)
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
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        ///Retrieves information about the issue custom attributes (custom fields) that are assigned to issue categories and issue types.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId">
        ///The ID of the project.
        /// </param>
        /// <param name="xAdsRegion">
        /// (optional)
        /// </param>
        /// <param name="limit">
        ///The number of custom attribute mappings to return in the response payload. For example, limit=2. Acceptable values: 1-200. Default value: 200. (optional)
        /// </param>
        /// <param name="offset">
        ///The number of custom attribute mappings you want to begin retrieving results from. (optional)
        /// </param>
        /// <param name="filterCreatedAt">
        ///Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterUpdatedAt">
        ///Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterDeletedAt">
        ///Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)
        /// </param>
        /// <param name="filterAttributeDefinitionId">
        ///Retrieves issue custom attribute mappings associated with the specified issue custom attribute definitions. Separate multiple values with commas. For example: filter[attributeDefinitionId]=18ee5858-cbf1-451a-a525-7c6ff8156775. (optional)
        /// </param>
        /// <param name="filterMappedItemId">
        ///Retrieves issue custom attribute mappings associated with the specified items (project, type, or subtype). Separate multiple values with commas. For example: filter[mappedItemId]=18ee5858-cbf1-451a-a525-7c6ff8156775. Note that this does not retrieve inherited custom attribute mappings or custom attribute mappings of descendants. (optional)
        /// </param>
        /// <returns>Task of ApiResponse&lt;AttrMapping&gt;></returns>

        public async System.Threading.Tasks.Task<ApiResponse<AttrMapping>> GetAttributeMappingsAsync(string projectId, Region? xAdsRegion = null, int? limit = default(int?), int? offset = default(int?), string filterCreatedAt = default(string), string filterUpdatedAt = default(string), string filterDeletedAt = default(string), string filterAttributeDefinitionId = default(string), string filterMappedItemId = default(string), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetAttributeMappingsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("filter[createdAt]", filterCreatedAt, queryParam);
                SetQueryParameter("filter[updatedAt]", filterUpdatedAt, queryParam);
                SetQueryParameter("filter[deletedAt]", filterDeletedAt, queryParam);
                SetQueryParameter("filter[attributeDefinitionId]", filterAttributeDefinitionId, queryParam);
                SetQueryParameter("filter[mappedItemId]", filterMappedItemId, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issue-attribute-mappings",
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
                    return new ApiResponse<AttrMapping>(response, default(AttrMapping));
                }
                logger.LogInformation($"Exited from GetAttributeMappingsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<AttrMapping>(response, await LocalMarshalling.DeserializeAsync<AttrMapping>(response.Content));

            } // using
        }
    }
}
