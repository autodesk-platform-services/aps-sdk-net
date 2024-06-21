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
    /// An object that represents the request body of a Fetch Specific Properties operation.
    /// </summary>
    [DataContract]
    public partial class SpecificPropertiesPayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificPropertiesPayload" /> class.
        /// </summary>
        public SpecificPropertiesPayload()
        {
        }

        /// <summary>
        ///Gets or Sets Pagination
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public SpecificPropertiesPayloadPagination Pagination { get; set; }

        /// <summary>
        ///Gets or Sets Query
        /// </summary>
        [DataMember(Name = "query", EmitDefaultValue = false)]
        public ISpecificPropertiesPayloadQuery Query { get; set; }

        /// <summary>
        ///Specifies what properties of the objects to return. If you do not specify this attribute, the response returns all properties.
        ///
        ///Possible values are:
        ///
        ///- `properties` - Return all properties.
        ///- `properties.something`- Return the property named `something` and all its children.
        ///- `properties.some*` - Return all properties with names that begin with `some` and all their children.
        ///- `properties.category.*` - Return the property named `category` and all its children.
        ///- `properties.*.property` - Return any property named `property` regardless of its parent.
        /// </summary>
        /// <value>
        ///Specifies what properties of the objects to return. If you do not specify this attribute, the response returns all properties.
        ///
        ///Possible values are:
        ///
        ///- `properties` - Return all properties.
        ///- `properties.something`- Return the property named `something` and all its children.
        ///- `properties.some*` - Return all properties with names that begin with `some` and all their children.
        ///- `properties.category.*` - Return the property named `category` and all its children.
        ///- `properties.*.property` - Return any property named `property` regardless of its parent.
        /// </value>
        [DataMember(Name = "fields", EmitDefaultValue = false)]
        public Object Fields { get; set; }

        /// <summary>
        ///Gets or Sets Payload
        /// </summary>
        [DataMember(Name = "payload", EmitDefaultValue = true)]
        public Payload Payload { get; set; }

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
