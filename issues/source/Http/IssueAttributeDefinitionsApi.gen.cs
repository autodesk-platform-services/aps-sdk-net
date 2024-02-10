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
    public interface IIssueAttributeDefinitionsApi
    {
        /// <summary>
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        /// Retrieves information about issue custom attributes (custom fields) for a project, including the custom attribute title, description and type.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="limit">The number of custom attribute definitions to return in the response payload. For example, limit&#x3D;2. Acceptable values: 1-200. Default value: 200. (optional)</param>/// <param name="offset">The number of custom attribute definitions you want to begin retrieving results from. (optional)</param>/// <param name="filterCreatedAt">Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterUpdatedAt">Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterDeletedAt">Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)</param>/// <param name="filterDataType">Retrieves issue custom attribute definitions with the specified data type. Possible values: list (this corresponds to dropdown in the UI), text, paragraph, numeric. For example, filter[dataType]&#x3D;text,numeric. (optional)</param>
        /// <returns>Task of ApiResponse&#60;AttrDefinition&#62;</returns>
        
        System.Threading.Tasks.Task<ApiResponse<AttrDefinition>> GetAttributeDefinitionsAsync (string projectId, XAdsRegion xAdsRegion, int? limit= default(int?), int? offset= default(int?), string filterCreatedAt= default(string), string filterUpdatedAt= default(string), string filterDeletedAt= default(string), List<FilterdataType> filterDataType= default(List<FilterdataType>),  string accessToken = null, bool throwOnError = true);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class IssueAttributeDefinitionsApi : IIssueAttributeDefinitionsApi
    {
        ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="IssueAttributeDefinitionsApi"/> class
        /// using SDKManager object
        /// </summary>
        /// <param name="sdkManager">An instance of SDKManager</param>
        /// <returns></returns>
        public IssueAttributeDefinitionsApi(SDKManager.SDKManager sdkManager)
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
        /// Your GET endpoint
        /// </summary>
        /// <remarks>
        /// Retrieves information about issue custom attributes (custom fields) for a project, including the custom attribute title, description and type.
        /// </remarks>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>/// <param name="xAdsRegion">The region where the bucket residesAcceptable values: &#x60;US&#x60;, &#x60;EMEA&#x60;</param>/// <param name="limit">The number of custom attribute definitions to return in the response payload. For example, limit&#x3D;2. Acceptable values: 1-200. Default value: 200. (optional)</param>/// <param name="offset">The number of custom attribute definitions you want to begin retrieving results from. (optional)</param>/// <param name="filterCreatedAt">Retrieves items that were created at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterUpdatedAt">Retrieves items that were last updated at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas. (optional)</param>/// <param name="filterDeletedAt">Retrieves types that were deleted at the specified date and time, in one of the following URL-encoded formats: YYYY-MM-DDThh:mm:ss.sz or YYYY-MM-DD. Separate multiple values with commas.  (optional)</param>/// <param name="filterDataType">Retrieves issue custom attribute definitions with the specified data type. Possible values: list (this corresponds to dropdown in the UI), text, paragraph, numeric. For example, filter[dataType]&#x3D;text,numeric. (optional)</param>
        /// <returns>Task of ApiResponse&#60;AttrDefinition&#62;</returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<AttrDefinition>> GetAttributeDefinitionsAsync (string projectId,XAdsRegion xAdsRegion,int? limit= default(int?),int? offset= default(int?),string filterCreatedAt= default(string),string filterUpdatedAt= default(string),string filterDeletedAt= default(string),List<FilterdataType> filterDataType= default(List<FilterdataType>), string accessToken = null, bool throwOnError = true)
        {
            logger.LogInformation("Entered into GetAttributeDefinitionsAsync ");
            using (var request = new HttpRequestMessage())
            {
                var queryParam = new Dictionary<string, object>();
                SetQueryParameter("limit", limit, queryParam);
                SetQueryParameter("offset", offset, queryParam);
                SetQueryParameter("filter[createdAt]", filterCreatedAt, queryParam);
                SetQueryParameter("filter[updatedAt]", filterUpdatedAt, queryParam);
                SetQueryParameter("filter[deletedAt]", filterDeletedAt, queryParam);
                SetQueryParameter("filter[dataType]", filterDataType, queryParam);
                request.RequestUri =
                    Marshalling.BuildRequestUri("/construction/issues/v1/projects/{projectId}/issue-attribute-definitions",
                        routeParameters: new Dictionary<string, object> {
                            { "projectId", projectId},
                        },
                        queryParameters: queryParam
                    );

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("User-Agent", "APS SDK/CONSTRUCTION.ISSUES/C#/0.0.1");
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
                }



                SetHeader("x-ads-region", (xAdsRegion.ToString().ToLowerInvariant()), request);

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
                    } catch (HttpRequestException ex) {
                      throw new ConstructionissuesApiException(ex.Message, response, ex);
                    }
                }
                else if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"response unsuccess with status code: {response.StatusCode}");
                    return new ApiResponse<AttrDefinition>(response, default(AttrDefinition));
                }
                logger.LogInformation($"Exited from GetAttributeDefinitionsAsync with response statusCode: {response.StatusCode}");
                return new ApiResponse<AttrDefinition>(response, await LocalMarshalling.DeserializeAsync<AttrDefinition>(response.Content));

            } // using
        }
    }
}
