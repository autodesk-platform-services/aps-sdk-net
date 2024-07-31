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
    /// The request payload for a Generate OSS Signed URL operation.
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
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
///
///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL.
        /// </summary>
        /// <value>
        ///The time window (in minutes) the signed URL will remain usable. Acceptable values = 1-60 minutes. Default = 2 minutes.
///
///**Tip:** Use the smallest possible time window to minimize exposure of the signed URL.
        /// </value>
        [DataMember(Name="minutesExpiration", EmitDefaultValue=false)]
        public int? MinutesExpiration { get; set; }

        /// <summary>
        ///`true` : The signed URL will expire immediately after use. For example, when downloading an object, URL will expire once the download is complete.
///
///`false` : (Default) The signed URL will remain usable for the entire time window specified by `minutesExpiration`. 
        /// </summary>
        /// <value>
        ///`true` : The signed URL will expire immediately after use. For example, when downloading an object, URL will expire once the download is complete.
///
///`false` : (Default) The signed URL will remain usable for the entire time window specified by `minutesExpiration`. 
        /// </value>
        [DataMember(Name="singleUse", EmitDefaultValue=false)]
        public bool? SingleUse { get; set; }

            
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
