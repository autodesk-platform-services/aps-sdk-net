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
    /// SpecifyReferencesPayloadReferences
    /// </summary>
    [DataContract]
    public partial class SpecifyReferencesPayloadReferences 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecifyReferencesPayloadReferences" /> class.
        /// </summary>
        public SpecifyReferencesPayloadReferences()
        {
        }
        
        /// <summary>
        ///The URN of the referenced file.
        /// </summary>
        /// <value>
        ///The URN of the referenced file.
        /// </value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        ///The path to the referenced file, relative to the top level component. By default, it is set to `""`, which means that the referenced file and top level component are in the same folder.
        /// </summary>
        /// <value>
        ///The path to the referenced file, relative to the top level component. By default, it is set to `""`, which means that the referenced file and top level component are in the same folder.
        /// </value>
        [DataMember(Name="relativePath", EmitDefaultValue=false)]
        public string RelativePath { get; set; }

        /// <summary>
        ///The file name of the referenced file. By default, it is set to `""` and the referenced file will be downloaded by its `urn` and placed relative to the top-level component using `relativePath`.
        /// </summary>
        /// <value>
        ///The file name of the referenced file. By default, it is set to `""` and the referenced file will be downloaded by its `urn` and placed relative to the top-level component using `relativePath`.
        /// </value>
        [DataMember(Name="filename", EmitDefaultValue=false)]
        public string Filename { get; set; }

        /// <summary>
        ///An object to hold custom metadata.
        /// </summary>
        /// <value>
        ///An object to hold custom metadata.
        /// </value>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public Dictionary<string, Object> Metadata { get; set; }

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
