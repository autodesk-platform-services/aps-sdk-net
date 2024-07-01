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
    /// An object that contains advanced options for an IGES output.
    /// </summary>
    [DataContract]
    public partial class JobPayloadFormatAdvancedIGES 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobPayloadFormatAdvancedIGES" /> class.
        /// </summary>
        public JobPayloadFormatAdvancedIGES()
        {
        }
        
        /// <summary>
        ///Possible values are between `0` and `1`. By default it is set at 0.001.
        /// </summary>
        /// <value>
        ///Possible values are between `0` and `1`. By default it is set at 0.001.
        /// </value>
        [DataMember(Name="tolerance", EmitDefaultValue=false)]
        public float? Tolerance { get; set; }

        /// <summary>
        ///Gets or Sets SurfaceType
        /// </summary>
        [DataMember(Name="surfaceType", EmitDefaultValue=true)]
        public SurfaceType SurfaceType { get; set; }

        /// <summary>
        ///Gets or Sets SheetType
        /// </summary>
        [DataMember(Name="sheetType", EmitDefaultValue=true)]
        public SheetType SheetType { get; set; }

        /// <summary>
        ///Gets or Sets SolidType
        /// </summary>
        [DataMember(Name="solidType", EmitDefaultValue=true)]
        public SolidType SolidType { get; set; }

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
