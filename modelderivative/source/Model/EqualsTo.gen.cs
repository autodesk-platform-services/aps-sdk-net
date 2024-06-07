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
    /// Specify objects by attribute name.
    /// </summary>
    [DataContract]
    public partial class EqualsTo : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EqualsTo" /> class.
        /// </summary>
        public EqualsTo()
        {
        }

        /// <summary>
        ///Returns only the objects where the value of the specified attribute (`name` attribute or any numerical property) is exactly equal to the specified value.
        ///
        ///The first element of the array contains the name of the attribute. This can be the `name` attribute or the name of a numerical property. The second element of the array must be the value to match. If the first element is `name`, must be a string value. If the first element is a numerical property, must be a numeric. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$eq":["name","Rectangular"]`, the request will only return the properties of the object named `Rectangular`. if you specify an array as: `"$eq":["properties.Dimensions.Width1",0.6]`, the request will return the properties of all objects whose `properties.Dimensions.Width1` property is exactly equal to `0.6`.
        ///
        ///**Note:** We recommend that you  use `$between`  instead of `$eq` when testing non-integer numeric values for equality. Using `between` mitigates floating-point errors.
        /// </summary>
        /// <value>
        ///Returns only the objects where the value of the specified attribute (`name` attribute or any numerical property) is exactly equal to the specified value.
        ///
        ///The first element of the array contains the name of the attribute. This can be the `name` attribute or the name of a numerical property. The second element of the array must be the value to match. If the first element is `name`, must be a string value. If the first element is a numerical property, must be a numeric. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$eq":["name","Rectangular"]`, the request will only return the properties of the object named `Rectangular`. if you specify an array as: `"$eq":["properties.Dimensions.Width1",0.6]`, the request will return the properties of all objects whose `properties.Dimensions.Width1` property is exactly equal to `0.6`.
        ///
        ///**Note:** We recommend that you  use `$between`  instead of `$eq` when testing non-integer numeric values for equality. Using `between` mitigates floating-point errors.
        /// </value>
        [DataMember(Name = "$eq", EmitDefaultValue = false)]
        public List<object> Eq { get; set; }

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
