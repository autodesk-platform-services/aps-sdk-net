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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autodesk.DataManagement.Http;

namespace Autodesk.DataManagement
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds DataManagementClient and configures it with the given configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddDataManagement(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<Configuration>(configuration.GetSection("Forge").GetSection("DataManagement"));
            services.AddTransient<ICommandsApi,CommandsApi>();
            services.AddTransient<IFoldersApi,FoldersApi>();
            services.AddTransient<IHubsApi,HubsApi>();
            services.AddTransient<IItemsApi,ItemsApi>();
            services.AddTransient<IProjectsApi,ProjectsApi>();
            services.AddTransient<IVersionsApi,VersionsApi>();
            // services.AddTransient<DataManagementClient>();
            return services.AddForgeService(configuration);
        }
    }
}
