/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Use the Model Derivative API to translate designs from one CAD format to another. You can also use this API to extract metadata from a model.
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
    /// Options for SVF2 outputs.
    /// </summary>
    [DataContract]
    public partial class JobPayloadFormatSVF2 : IJobPayloadFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobPayloadFormatSVF2" /> class.
        /// </summary>
        public JobPayloadFormatSVF2()
        {
        }

        /// <summary>
        ///Specifies the type of view to generate. Possible values are `2d` and `3d`.
        /// </summary>
        /// <value>
        ///Specifies the type of view to generate. Possible values are `2d` and `3d`.
        /// </value>
        [DataMember(Name = "views", EmitDefaultValue = false)]
        public List<View> Views { get; set; }

        /// <summary>
        ///The requested output type. `svf2` in this case.
        /// </summary>
        /// <value>
        ///The requested output type. `svf2` in this case.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = true)]
        public OutputType Type { get; set; } = OutputType.Svf2;

        /// <summary>
        ///Gets or Sets Advanced
        /// </summary>
        [DataMember(Name = "advanced", EmitDefaultValue = false)]
        public IJobPayloadFormatSVF2Advanced Advanced { get; set; }

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
