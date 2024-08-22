/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Account.Admin
 *
 * The Account Admin API automates creating and managing projects, assigning and managing project users, and managing member and partner company directories. You can also synchronize data with external systems. 
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
using Autodesk.Construction.AccountAdmin.Http;

namespace Autodesk.Construction.AccountAdmin
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ConstructionaccountadminClient and configures it with the given configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddConstructionaccountadmin(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<Configuration>(configuration.GetSection("Forge").GetSection("Constructionaccountadmin"));
            services.AddTransient<IAccountUsersApi,AccountUsersApi>();
            services.AddTransient<IBusinessUnitsApi,BusinessUnitsApi>();
            services.AddTransient<ICompaniesApi,CompaniesApi>();
            services.AddTransient<IProjectUsersApi,ProjectUsersApi>();
            services.AddTransient<IProjectsApi,ProjectsApi>();
            // services.AddTransient<ConstructionaccountadminClient>();
            return services.AddForgeService(configuration);
        }
    }
}
