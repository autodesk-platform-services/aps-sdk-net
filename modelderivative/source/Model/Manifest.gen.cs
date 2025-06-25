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
    /// An object that represents the successful response of a Fetch Manifest operation.
    /// </summary>
    [DataContract]
    public partial class Manifest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manifest" /> class.
        /// </summary>
        public Manifest()
        {
        }

        /// <summary>
        ///The URL-safe Base64 encoded URN of the source design.
        /// </summary>
        /// <value>
        ///The URL-safe Base64 encoded URN of the source design.
        /// </value>
        [DataMember(Name = "urn", EmitDefaultValue = false)]
        public string Urn { get; set; }

        /// <summary>
        ///An array of objects, where each object represents a derivative of the source design.
        /// </summary>
        /// <value>
        ///An array of objects, where each object represents a derivative of the source design.
        /// </value>
        [DataMember(Name = "derivatives", EmitDefaultValue = false)]
        public List<ManifestDerivative> Derivatives { get; set; }

        /// <summary>
        ///- `true`: There is a thumbnail for the source design.
        ///- `false`: There is no thumbnail for the source design.
        /// </summary>
        /// <value>
        ///- `true`: There is a thumbnail for the source design.
        ///- `false`: There is no thumbnail for the source design.
        /// </value>
        [DataMember(Name = "hasThumbnail", EmitDefaultValue = false)]
        public string HasThumbnail { get; set; }

        /// <summary>
        ///Indicates the overall progress of all translation jobs, as a percentage. Once all requested derivatives are generated, the value changes to `complete`.
        /// </summary>
        /// <value>
        ///Indicates the overall progress of all translation jobs, as a percentage. Once all requested derivatives are generated, the value changes to `complete`.
        /// </value>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public string Progress { get; set; }

        /// <summary>
        ///The type of data that is returned. Always `manifest`.
        /// </summary>
        /// <value>
        ///The type of data that is returned. Always `manifest`.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        ///Specifies the data center where the manifest, derivatives, and references are stored. Possible values are: 
        ///
        ///- `US` - Data center for the US region.
        ///- `EMEA` - Data center for European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data center for the Canada region.
        ///- `DEU` : Data center for the Germany region.
        ///- `IND` : Data center for the India region.
        ///- `JPN` : Data center for the Japan region.
        ///- `GBR`  : Data center for the United Kingdom region.
        /// </summary>
        /// <value>
        ///Specifies the data center where the manifest, derivatives, and references are stored. Possible values are: 
        ///
        ///- `US` - Data center for the US region.
        ///- `EMEA` - Data center for European Union, Middle East, and Africa. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data center for the Canada region.
        ///- `DEU` : Data center for the Germany region.
        ///- `IND` : Data center for the India region.
        ///- `JPN` : Data center for the Japan region.
        ///- `GBR`  : Data center for the United Kingdom region.
        /// </value>
        [DataMember(Name = "region", EmitDefaultValue = false)]
        public string Region { get; set; }

        /// <summary>
        ///Indicates the version of the schema that the manifest is based on.
        /// </summary>
        /// <value>
        ///Indicates the version of the schema that the manifest is based on.
        /// </value>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string _Version { get; set; }

        /// <summary>
        ///Overall status of all translation jobs for the source design. Possible values are: `pending`, `success`, `inprogress`, `failed`, `timeout`.
        /// </summary>
        /// <value>
        ///Overall status of all translation jobs for the source design. Possible values are: `pending`, `success`, `inprogress`, `failed`, `timeout`.
        /// </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

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
