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
    /// JobSvf2OutputFormat
    /// </summary>
    [DataContract]
    public partial class JobSvf2OutputFormat : JobPayloadFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobSvf2OutputFormat" /> class.
        /// </summary>
        public JobSvf2OutputFormat()
        {
        }
        
        /// <summary>
        /// Gets or Sets Views
        /// </summary>
        [DataMember(Name="views", EmitDefaultValue=false)]
        public List<View> Views { get; set; }

        /// <summary>
        /// Gets or Sets Type. Default set to Svf2.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        private Type Type { get; set; } = Type.Svf2;

        /// <summary>
        /// Gets or Sets Advanced
        /// </summary>
        [DataMember(Name="advanced", EmitDefaultValue=false)]
        public JobSvfOutputFormatAdvanced Advanced { get; set; }

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
