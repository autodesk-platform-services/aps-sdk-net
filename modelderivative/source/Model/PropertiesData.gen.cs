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
    /// An envelope that encapsulates the return data.
    /// </summary>
    [DataContract]
    public partial class PropertiesData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesData" /> class.
        /// </summary>
        public PropertiesData()
        {
        }

        /// <summary>
        ///The type of data that is returned. Always `properties`.
        /// </summary>
        /// <value>
        ///The type of data that is returned. Always `properties`.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        ///A non-hierarchical list of objects contained in 
        ///the specified Model View. Each object has a 
        ///`properties` attribute, which contains the 
        ///properties of that object.
        /// </summary>
        /// <value>
        ///A non-hierarchical list of objects contained in 
        ///the specified Model View. Each object has a 
        ///`properties` attribute, which contains the 
        ///properties of that object.
        /// </value>
        [DataMember(Name = "collection", EmitDefaultValue = false)]
        public List<PropertiesDataCollection> Collection { get; set; }

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
