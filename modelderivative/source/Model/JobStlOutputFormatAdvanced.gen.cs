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
    /// Advanced options for &#x60;stl&#x60; type.
    /// </summary>
    [DataContract]
    public partial class JobStlOutputFormatAdvanced 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStlOutputFormatAdvanced" /> class.
        /// </summary>
        public JobStlOutputFormatAdvanced()
        {
        }
        
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name="format", EmitDefaultValue=false)]
        public Format Format { get; set; }

        /// <summary>
        /// Color is exported by default. If set to &#x60;true&#x60;, color is exported. If set to &#x60;false&#x60;, color is not exported.
        /// </summary>
        /// <value>Color is exported by default. If set to &#x60;true&#x60;, color is exported. If set to &#x60;false&#x60;, color is not exported.</value>
        [DataMember(Name="exportColor", EmitDefaultValue=false)]
        public bool? ExportColor { get; set; }

        /// <summary>
        /// Gets or Sets ExportFileStructure
        /// </summary>
        [DataMember(Name="exportFileStructure", EmitDefaultValue=false)]
        public ExportFileStructure ExportFileStructure { get; set; }

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
