/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication
 *
 * OAuth2 token management APIs.
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
using Autodesk.Authentication.Http;

namespace Autodesk.Authentication
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds AuthenticationClient and configures it with the given configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<Configuration>(configuration.GetSection("Forge").GetSection("Authentication"));
            services.AddTransient<ITokenApi,TokenApi>();
            services.AddTransient<IUsersApi,UsersApi>();
            // services.AddTransient<AuthenticationClient>();
            return services.AddForgeService(configuration);
        }
    }
}
