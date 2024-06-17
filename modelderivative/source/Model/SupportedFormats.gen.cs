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
    /// An object that represents the successful response of a List Supported Formats operation.
    /// </summary>
    [DataContract]
    public partial class SupportedFormats 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupportedFormats" /> class.
        /// </summary>
        public SupportedFormats()
        {
        }
        
        /// <summary>
        ///A dictionary object that contains a collection of key-value pairs, where each pair represents the target file format and the corresponding source file formats.
        /// </summary>
        /// <value>
        ///A dictionary object that contains a collection of key-value pairs, where each pair represents the target file format and the corresponding source file formats.
        /// </value>
        [DataMember(Name="formats", EmitDefaultValue=false)]
        public Dictionary<string, List<string>> Formats { get; set; }

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
