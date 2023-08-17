/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Oss.Model
{
    /// <summary>
    /// CreateSignedResource
    /// </summary>
    [DataContract]
    public partial class CreateSignedResource 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSignedResource" /> class.
        /// </summary>
        public CreateSignedResource()
        {
        }
        
        /// <summary>
        /// Expiration time value. Default is 60 minutes.
        /// </summary>
        /// <value>Expiration time value. Default is 60 minutes.</value>
        [DataMember(Name="minutesExpiration", EmitDefaultValue=false)]
        public int? MinutesExpiration { get; set; }

        /// <summary>
        /// If it is true, the public URL can only be used once and will expire immediately after use. When downloading an object, URL will expire once the download is complete.
        /// </summary>
        /// <value>If it is true, the public URL can only be used once and will expire immediately after use. When downloading an object, URL will expire once the download is complete.</value>
        [DataMember(Name="singleUse", EmitDefaultValue=false)]
        public bool? SingleUse { get; set; }

        /// <summary>
        /// If set, the public URL will use that value as Content-Type when downloading
        /// </summary>
        /// <value>If set, the public URL will use that value as Content-Type when downloading</value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// If set, the public URL will use that value as Content-Disposition when downloading
        /// </summary>
        /// <value>If set, the public URL will use that value as Content-Disposition when downloading</value>
        [DataMember(Name="contentDisposition", EmitDefaultValue=false)]
        public string ContentDisposition { get; set; }

        /// <summary>
        /// If set, the public URL will be restricted to the specified IP addresses. downloads and uploads will be allowed or blocked based on the list of the IP addresses in the X-Forwarded-For header received from Apigee.
        /// </summary>
        /// <value>If set, the public URL will be restricted to the specified IP addresses. downloads and uploads will be allowed or blocked based on the list of the IP addresses in the X-Forwarded-For header received from Apigee.</value>
        [DataMember(Name="allowedIpAddresses", EmitDefaultValue=false)]
        public string AllowedIpAddresses { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
