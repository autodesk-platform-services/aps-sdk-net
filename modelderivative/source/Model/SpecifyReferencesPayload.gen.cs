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
    /// An object that represents the successful response of a Specify References operation.
    /// </summary>
    [DataContract]
    public partial class SpecifyReferencesPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecifyReferencesPayload" /> class.
        /// </summary>
        public SpecifyReferencesPayload()
        {
        }
        
        /// <summary>
        ///The URL safe Base64 encoded URN of the source design. Mandatory if the Base64 encoded urn in the request URL is a logical URN.
        /// </summary>
        /// <value>
        ///The URL safe Base64 encoded URN of the source design. Mandatory if the Base64 encoded urn in the request URL is a logical URN.
        /// </value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        ///Gets or Sets Region
        /// </summary>
        [DataMember(Name="region", EmitDefaultValue=true)]
        public Region Region { get; set; }

        /// <summary>
        ///The file name of the top level component. By default, it is set to `""` and the file will be download with its `urn`.
        /// </summary>
        /// <value>
        ///The file name of the top level component. By default, it is set to `""` and the file will be download with its `urn`.
        /// </value>
        [DataMember(Name="filename", EmitDefaultValue=false)]
        public string Filename { get; set; }

        /// <summary>
        ///An array of objects, where each object represents a referenced file.
        /// </summary>
        /// <value>
        ///An array of objects, where each object represents a referenced file.
        /// </value>
        [DataMember(Name="references", EmitDefaultValue=false)]
        public List<SpecifyReferencesPayloadReferences> References { get; set; }

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
