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
    /// Specify objects by name starting with a specified string.
    /// </summary>
    [DataContract]
    public partial class BeginsWith : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeginsWith" /> class.
        /// </summary>
        public BeginsWith()
        {
        }

        /// <summary>
        ///Returns only the objects with their `name` attribute beginning with the specified string.
        ///
        ///The first element of the array contains the name of the attribute to match (`name`). The second element contains the string to match. The array can have only two elements. Only the objects whose name begin with the specified string are returned.
        /// </summary>
        /// <value>
        ///Returns only the objects with their `name` attribute beginning with the specified string.
        ///
        ///The first element of the array contains the name of the attribute to match (`name`). The second element contains the string to match. The array can have only two elements. Only the objects whose name begin with the specified string are returned.
        /// </value>
        [DataMember(Name = "$prefix", EmitDefaultValue = false)]
        public List<string> Prefix { get; set; }

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
