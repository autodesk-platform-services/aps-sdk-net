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
    /// BatchDeleteListProcesses
    /// </summary>
    [DataContract]
    public partial class BatchDeleteListProcesses 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchDeleteListProcesses" /> class.
        /// </summary>
        public BatchDeleteListProcesses()
        {
        }
        
        /// <summary>
        /// The ID of the batch delete process.
        /// </summary>
        /// <value>The ID of the batch delete process.</value>
        [DataMember(Name="uuid", EmitDefaultValue=false)]
        public string Uuid { get; set; }

        /// <summary>
        /// The ISO8601 date in which the process was created.
        /// </summary>
        /// <value>The ISO8601 date in which the process was created.</value>
        [DataMember(Name="created", EmitDefaultValue=false)]
        public string Created { get; set; }

        /// <summary>
        /// The ISO8601 date in which the actual deletion process was initiated.
        /// </summary>
        /// <value>The ISO8601 date in which the actual deletion process was initiated.</value>
        [DataMember(Name="initiated", EmitDefaultValue=false)]
        public string Initiated { get; set; }

        /// <summary>
        /// The ISO8601 date in which the process was completed.
        /// </summary>
        /// <value>The ISO8601 date in which the process was completed.</value>
        [DataMember(Name="completed", EmitDefaultValue=false)]
        public string Completed { get; set; }

        /// <summary>
        /// The state of the batch deletion process; can be &#39;CREATED&#39; (scheduled but not started), &#39;INITIATED&#39; (started but deletion not completed), or &#39;COMPLETED&#39; (deletion complete, full report of results should be available)
        /// </summary>
        /// <value>The state of the batch deletion process; can be &#39;CREATED&#39; (scheduled but not started), &#39;INITIATED&#39; (started but deletion not completed), or &#39;COMPLETED&#39; (deletion complete, full report of results should be available)</value>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public string Status { get; set; }

        /// <summary>
        /// The URL to poll to check for completion. Will return 200 OK when process is completed and 404 NOT FOUND otherwise. This should be taken as an opaque URL with no expected pattern as it could be subject to change.
        /// </summary>
        /// <value>The URL to poll to check for completion. Will return 200 OK when process is completed and 404 NOT FOUND otherwise. This should be taken as an opaque URL with no expected pattern as it could be subject to change.</value>
        [DataMember(Name="poll", EmitDefaultValue=false)]
        public string Poll { get; set; }

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
