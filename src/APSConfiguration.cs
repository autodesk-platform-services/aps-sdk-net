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
using System;

namespace Autodesk.SDKManager
{
    public enum AdskEnvironment
    {
        Dev =0,
        Stg =1,
        Prd =2,
        Local =3
    }

    /// <summary>
    /// Represents a set of configuration settings
    /// </summary>
    public partial class ApsConfiguration: IApsConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class
        /// </summary>
        public ApsConfiguration()
        {
            this.BaseAddress = new Uri("https://developer.api.autodesk.com");
        }
        public ApsConfiguration(AdskEnvironment environment)
        {
            switch (environment)
            {
                case AdskEnvironment.Local:
                {
                    this.BaseAddress = new Uri("http://localhost:1234");
                    break;
                }
                case AdskEnvironment.Dev:
                {
                    this.BaseAddress = new Uri("https://developer-dev.api.autodesk.com");
                    break;
                }
                case AdskEnvironment.Stg:
                {
                    this.BaseAddress = new Uri("https://developer-stg.api.autodesk.com");
                    break;
                }
                default:
                {
                    this.BaseAddress = new Uri("https://developer.api.autodesk.com");
                    break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the base path for API access.
        /// </summary>
        public Uri BaseAddress { get; set; }
    }
}
