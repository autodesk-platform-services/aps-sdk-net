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
    /// Specify object by attribute value containing specified string.
    /// </summary>
    [DataContract]
    public partial class Contains : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contains" /> class.
        /// </summary>
        public Contains()
        {
        }

        /// <summary>
        ///Returns only the objects where the value of the specified property contains the words specified in a string.
        ///
        ///The first element of the array contains the name of the property. The second element contains a string containing the words to match. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$contains":["properties.Materials and Finishes.Structural Material","Concrete Situ"]`, the request returns the properties of all objects whose `properties.Materials and Finishes.Structural Material` property contains the words  `Concrete` and `Situ`. You can specify up to 50 words.
        /// </summary>
        /// <value>
        ///Returns only the objects where the value of the specified property contains the words specified in a string.
        ///
        ///The first element of the array contains the name of the property. The second element contains a string containing the words to match. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$contains":["properties.Materials and Finishes.Structural Material","Concrete Situ"]`, the request returns the properties of all objects whose `properties.Materials and Finishes.Structural Material` property contains the words  `Concrete` and `Situ`. You can specify up to 50 words.
        /// </value>
        [DataMember(Name = "$contains", EmitDefaultValue = false)]
        public List<string> _Contains { get; set; }

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
