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
    /// An element of the array.
    /// </summary>
    [DataContract]
    public partial class References 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="References" /> class.
        /// </summary>
        public References()
        {
        }
        
        /// <summary>
        /// The reference urn.
        /// </summary>
        /// <value>The reference urn.</value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        /// The file path relative to the root design. By default, it is set to “”. It means the reference and its root file are in the same folder.
        /// </summary>
        /// <value>The file path relative to the root design. By default, it is set to “”. It means the reference and its root file are in the same folder.</value>
        [DataMember(Name="relativePath", EmitDefaultValue=false)]
        public string RelativePath { get; set; }

        /// <summary>
        /// The reference filename. By default, it is set to “” and the reference will be downloaded with its urn and relativePath.
        /// </summary>
        /// <value>The reference filename. By default, it is set to “” and the reference will be downloaded with its urn and relativePath.</value>
        [DataMember(Name="filename", EmitDefaultValue=false)]
        public string Filename { get; set; }

        /// <summary>
        /// Custom metadata with key value pairs.
        /// </summary>
        /// <value>Custom metadata with key value pairs.</value>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public Dictionary<string,string> Metadata { get; set; }


         /// <summary>
        /// Group of references.
        /// </summary>
        /// <value>Group of references.</value>
        [DataMember(Name="references", EmitDefaultValue=false)]
        public List<References> ChildReferences { get; set; }

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
