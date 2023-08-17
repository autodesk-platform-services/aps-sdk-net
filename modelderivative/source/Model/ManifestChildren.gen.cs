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
    /// ManifestChildren
    /// </summary>
    [DataContract]
    public partial class ManifestChildren
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestChildren" /> class.
        /// </summary>
        public ManifestChildren()
        {
        }

        /// <summary>
        /// Gets or Sets Guid
        /// </summary>
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string Guid { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Role
        /// </summary>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public string Role { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Progress
        /// </summary>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public string Progress { get; set; }

        /// <summary>
        /// Gets or Sets Camera
        /// </summary>
        [DataMember(Name = "camera", EmitDefaultValue = false)]
        public List<Double> Camera { get; set; }

        /// <summary>
        /// Gets or Sets PhaseNames
        /// </summary>
        [DataMember(Name = "phaseNames", EmitDefaultValue = false)]
        public string PhaseNames { get; set; }

        /// <summary>
        /// Gets or Sets HasThumbnail
        /// </summary>
        [DataMember(Name = "hasThumbnail", EmitDefaultValue = false)]
        public bool HasThumbnail { get; set; }

        /// <summary>
        /// Gets or Sets Children
        /// </summary>
        [DataMember(Name = "children", EmitDefaultValue = false)]
        public List<ManifestChildren> Children { get; set; }

        /// <summary>
        /// Gets or Sets ViewableID
        /// </summary>
        [DataMember(Name = "viewableID", EmitDefaultValue = false)]
        public string ViewableID { get; set; }

        /// <summary>
        /// Gets or Sets MIME type of the generated file
        /// </summary>
        [DataMember(Name = "mime", EmitDefaultValue = false)]
        public string Mime { get; set; }

          /// <summary>
        /// Gets or Sets Urn
        /// </summary>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }


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
