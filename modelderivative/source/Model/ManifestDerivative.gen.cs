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
    /// Represents a derivative generated for the source design.
    /// </summary>
    [DataContract]
    public partial class ManifestDerivative
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestDerivative" /> class.
        /// </summary>
        public ManifestDerivative()
        {
        }

        /// <summary>
        ///The name of the resource.
        /// </summary>
        /// <value>
        ///The name of the resource.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///- `true`: The derivative has a thumbnail.
        ///- `false`: The derivative does not have a thumbnail.
        /// </summary>
        /// <value>
        ///- `true`: The derivative has a thumbnail.
        ///- `false`: The derivative does not have a thumbnail.
        /// </value>
        [DataMember(Name = "hasThumbnail", EmitDefaultValue = false)]
        public string HasThumbnail { get; set; }

        /// <summary>
        ///Indicates the progress of the process generating this derivative, as a percentage. Once complete, the value changes to `complete`.
        /// </summary>
        /// <value>
        ///Indicates the progress of the process generating this derivative, as a percentage. Once complete, the value changes to `complete`.
        /// </value>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public string Progress { get; set; }

        /// <summary>
        ///The file type/format of the derivative. Possible values are: `dwg`, `fbx`, `ifc`, `iges`, `obj` , `step`, `stl`, `svf`, `svf2`,  `thumbnail`.
        /// </summary>
        /// <value>
        ///The file type/format of the derivative. Possible values are: `dwg`, `fbx`, `ifc`, `iges`, `obj` , `step`, `stl`, `svf`, `svf2`,  `thumbnail`.
        /// </value>
        [DataMember(Name = "outputType", EmitDefaultValue = false)]
        public string OutputType { get; set; }

        /// <summary>
        ///Status of the task generating this derivative. Possible values are: `pending`, `inprogress`, `success`, `failed`, `timeout`.
        /// </summary>
        /// <value>
        ///Status of the task generating this derivative. Possible values are: `pending`, `inprogress`, `success`, `failed`, `timeout`.
        /// </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        ///Gets or Sets Messages
        /// </summary>
        [DataMember(Name = "messages", EmitDefaultValue = false)]
        public List<Messages> Messages { get; set; }

        /// <summary>
        ///An array of objects, where each object represents a resource generated for the derivative. For example, a Model View (Viewable) of the source design.
        /// </summary>
        /// <value>
        ///An array of objects, where each object represents a resource generated for the derivative. For example, a Model View (Viewable) of the source design.
        /// </value>
        [DataMember(Name = "children", EmitDefaultValue = false)]
        public List<ManifestResources> Children { get; set; }

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
