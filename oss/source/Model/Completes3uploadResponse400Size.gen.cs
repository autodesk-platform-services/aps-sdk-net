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
    /// Describes any discrepancy between the expected object size provided by the user, and the actual object size detected in S3. This check is skipped entirely if the user provides to size parameter in the request.
    /// </summary>
    [DataContract]
    public partial class Completes3uploadResponse400Size 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Completes3uploadResponse400Size" /> class.
        /// </summary>
        public Completes3uploadResponse400Size()
        {
        }
        
        /// <summary>
        /// The expected object size provided in the request, in bytes.
        /// </summary>
        /// <value>The expected object size provided in the request, in bytes.</value>
        [DataMember(Name="expected", EmitDefaultValue=false)]
        public int? Expected { get; set; }

        /// <summary>
        /// The actual size of the object in S3, in bytes.
        /// </summary>
        /// <value>The actual size of the object in S3, in bytes.</value>
        [DataMember(Name="detected", EmitDefaultValue=false)]
        public int? Detected { get; set; }

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
