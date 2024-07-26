/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Use the Model Derivative API to translate designs from one CAD format to another. You can also use this API to extract metadata from a model.
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
using Autodesk.ModelDerivative.Http;

namespace Autodesk.ModelDerivative
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ModelDerivativeClient and configures it with the given configuration.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IHttpClientBuilder AddModelDerivative(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<Configuration>(configuration.GetSection("Forge").GetSection("ModelDerivative"));
            services.AddTransient<IDerivativesApi,DerivativesApi>();
            services.AddTransient<IInformationalApi,InformationalApi>();
            services.AddTransient<IJobsApi,JobsApi>();
            services.AddTransient<IManifestApi,ManifestApi>();
            services.AddTransient<IMetadataApi,MetadataApi>();
            services.AddTransient<IThumbnailsApi,ThumbnailsApi>();
            // services.AddTransient<ModelDerivativeClient>();
            return services.AddForgeService(configuration);
        }
    }
}
