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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace sdk.manager
{
    public class SDKManager : ISDKManager
    {
        public SDKManager(IApsConfiguration apsConfiguration, IResiliencyConfiguration resiliencyConfiguration, IAuthClient authClient, ILogger logger )
        {
           // Default option is important for simplest case.
           _apsConfiguration =  apsConfiguration ?? new ApsConfiguration();
           var currentResiliencyConfiguration = resiliencyConfiguration ?? ResiliencyConfiguration.CreateDefault();

           _aPSClient = new ApsClient(currentResiliencyConfiguration);
           _aPSClient.Service.Client.BaseAddress = _apsConfiguration.BaseAddress;

           _authClient = authClient; // There is no default auth client so far.
           _logger = logger ?? NullLogger.Instance;
        }

        public IApsClient ApsClient { get => _aPSClient; }
        public IAuthClient AuthClient { get => _authClient;}
        public ILogger Logger { get => _logger; }
        public IApsConfiguration ApsConfiguration { get => _apsConfiguration; set => _apsConfiguration = value; }

        ILogger _logger = NullLogger.Instance;
        IAuthClient _authClient;
        IApsConfiguration _apsConfiguration;
        IApsClient _aPSClient;
    }
}