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
    /// PropertiesDataCollection
    /// </summary>
    [DataContract]
    public partial class PropertiesDataCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesDataCollection" /> class.
        /// </summary>
        public PropertiesDataCollection()
        {
        }

        /// <summary>
        ///Unique identifier of the object.
        ///
        ///**Note:** The `objectid` is a non-persistent ID assigned to an object when a design file is translated to SVF or SVF2. So:
        ///
        ///- The `objectid` of an object can change if the design is translated to SVF or SVF2 again.
        ///- If you require a persistent ID to reference an object, use `externalId`.
        /// </summary>
        /// <value>
        ///Unique identifier of the object.
        ///
        ///**Note:** The `objectid` is a non-persistent ID assigned to an object when a design file is translated to SVF or SVF2. So:
        ///
        ///- The `objectid` of an object can change if the design is translated to SVF or SVF2 again.
        ///- If you require a persistent ID to reference an object, use `externalId`.
        /// </value>
        [DataMember(Name = "objectid", EmitDefaultValue = false)]
        public decimal? ObjectId { get; set; }

        /// <summary>
        ///Name of the object.
        /// </summary>
        /// <value>
        ///Name of the object.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///A unique identifier of the object as defined in the source design. For example, `UniqueID` in Revit files.
        /// </summary>
        /// <value>
        ///A unique identifier of the object as defined in the source design. For example, `UniqueID` in Revit files.
        /// </value>
        [DataMember(Name = "externalId", EmitDefaultValue = false)]
        public string ExternalId { get; set; }

        /// <summary>
        ///A JSON object containing dictionary objects (key value pairs), where the key is the property name and the value is the value of the property.
        /// </summary>
        /// <value>
        ///A JSON object containing dictionary objects (key value pairs), where the key is the property name and the value is the value of the property.
        /// </value>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public Dictionary<string, Object> Properties { get; set; }

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
