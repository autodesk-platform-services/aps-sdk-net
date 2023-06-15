/* 
 * Forge SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * oss
 *
 * The Object Storage Service (OSS) allows your application to download and upload raw files (such as PDF, XLS, DWG, or RVT) that are managed by the Data service.
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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace sdk.manager
{
    public class ApsClient : IApsClient
    {
        ILogger _logger = NullLogger.Instance;
        private ForgeService _service;
        private IResiliencyConfiguration _resiliencyConfig;
        public ApsClient(IResiliencyConfiguration resiliencyConfig)
        {
            _service = ForgeService.CreateDefault();
            // TBD: Make resiliency config work with ForgeService.
            _resiliencyConfig = resiliencyConfig;
            _logger.LogInformation($"Initializing resiliency config: {_resiliencyConfig.ToString()}");
        }

        public ForgeService Service { get => _service;}

        public void Add(IResiliencyConfiguration resiliencyConfiguration)
        {
            _resiliencyConfig = resiliencyConfiguration;
        }
        public void Add(ILogger logger)
        {
            _logger = logger;
        }
    }
}