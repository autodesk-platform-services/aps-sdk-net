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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autodesk.Construction.Issues.Http;

namespace Autodesk.Construction.Issues
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ConstructionissuesClient and configures it with the given configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddConstructionissues(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<Configuration>(configuration.GetSection("Forge").GetSection("Constructionissues"));
            services.AddTransient<IIssueAttributeDefinitionsApi,IssueAttributeDefinitionsApi>();
            services.AddTransient<IIssueAttributeMappingsApi,IssueAttributeMappingsApi>();
            services.AddTransient<IIssueCommentsApi,IssueCommentsApi>();
            services.AddTransient<IIssueRootCauseCategoriesApi,IssueRootCauseCategoriesApi>();
            services.AddTransient<IIssueTypesApi,IssueTypesApi>();
            services.AddTransient<IIssuesApi,IssuesApi>();
            services.AddTransient<IIssuesProfileApi,IssuesProfileApi>();
            // services.AddTransient<ConstructionissuesClient>();
            return services.AddForgeService(configuration);
        }
    }
}
