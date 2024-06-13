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
    /// An array of objects where each object represents a message logged to the manifest during translation. For example, error messages and warning messages.
    /// </summary>
    [DataContract]
    public partial class Messages 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Messages" /> class.
        /// </summary>
        public Messages()
        {
        }
        
        /// <summary>
        ///Indicates the type of the message. For example, warning indicates a warning message and error indicates an error message.
        /// </summary>
        /// <value>
        ///Indicates the type of the message. For example, warning indicates a warning message and error indicates an error message.
        /// </value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        ///The ID of the message. For example, the error code reported by an error message.
        /// </summary>
        /// <value>
        ///The ID of the message. For example, the error code reported by an error message.
        /// </value>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        ///A human-readable explanation of the event being reported. Can be a string or an array of string.
        /// </summary>
        /// <value>
        ///A human-readable explanation of the event being reported. Can be a string or an array of string.
        /// </value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public Object Message { get; set; }

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
