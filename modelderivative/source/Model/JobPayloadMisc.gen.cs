/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative API
 *
 * Model Derivative Service Documentation
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

namespace Autodesk.ModelDerivative.Model
{
    /// <summary>
    /// JobPayloadMisc
    /// </summary>
    [DataContract]
    public partial class JobPayloadMisc 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobPayloadMisc" /> class.
        /// </summary>
        public JobPayloadMisc()
        {
        }
        
        /// <summary>
        /// The workflow id created for a webhook, used to listen to Model Derivative events. It needs to be no more than 36 chars, and only ASCII, decimal and hyphen are accepted.
        /// </summary>
        /// <value>The workflow id created for a webhook, used to listen to Model Derivative events. It needs to be no more than 36 chars, and only ASCII, decimal and hyphen are accepted.</value>
        [DataMember(Name="workflow", EmitDefaultValue=false)]
        public string Workflow { get; set; }

        /// <summary>
        /// A user-defined JSON object, which you can use to set some custom workflow information. It needs to be less than 1KB and will be ignored if misc.workflow parameter is not set.
        /// </summary>
        /// <value>A user-defined JSON object, which you can use to set some custom workflow information. It needs to be less than 1KB and will be ignored if misc.workflow parameter is not set.</value>
        [DataMember(Name="workflowAttribute", EmitDefaultValue=false)]
        public Object WorkflowAttribute { get; set; }

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
