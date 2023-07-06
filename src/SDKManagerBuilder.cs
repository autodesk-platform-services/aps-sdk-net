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

namespace Autodesk.SDKManager
{
    public class SdkManagerBuilder : IBuilder
    {
        public static SdkManagerBuilder Create()
        {
            return new SdkManagerBuilder();
        }
        public SdkManagerBuilder Add(IResiliencyConfiguration resiliencyConfiguration)
        {
            _resiliencyConfiguration = resiliencyConfiguration;
            return this;
        }
        public SdkManagerBuilder Add(ILogger logger)
        {
            _logger = logger;
            return this;
        }
        public SdkManagerBuilder Add(IAuthClient authClient)
        {
            _authClient = authClient;
            return this;
        }
        public SdkManagerBuilder Add(IApsConfiguration apsConfiguration)
        {
            _apsConfiguration = apsConfiguration;
            return this;
        }
        public SDKManager Build()
        {
            return new SDKManager(_apsConfiguration, _resiliencyConfiguration, _authClient, _logger);
        }
        private IResiliencyConfiguration _resiliencyConfiguration;
        private ILogger _logger;
        private IAuthClient _authClient;
        private IApsConfiguration _apsConfiguration;
    }
}