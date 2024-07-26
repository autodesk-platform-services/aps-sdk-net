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
    /// BatchCompletedResultsParts
    /// </summary>
    [DataContract]
    public partial class BatchCompletedResultsParts 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchCompletedResultsParts" /> class.
        /// </summary>
        public BatchCompletedResultsParts()
        {
        }
        
        /// <summary>
        ///The index of the first part in the multipart upload.
        /// </summary>
        /// <value>
        ///The index of the first part in the multipart upload.
        /// </value>
        [DataMember(Name="firstPart", EmitDefaultValue=false)]
        public int? FirstPart { get; set; }

        /// <summary>
        ///Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public Status Status { get; set; }

        /// <summary>
        ///The size of the corresponding part detected in S3.
        /// </summary>
        /// <value>
        ///The size of the corresponding part detected in S3.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        ///The eTag of the detected part in S3.
        /// </summary>
        /// <value>
        ///The eTag of the detected part in S3.
        /// </value>
        [DataMember(Name="eTag", EmitDefaultValue=false)]
        public string ETag { get; set; }

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
