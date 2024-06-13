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
    /// Use this to retrieve only the properties of objects where a specified property is greater than a specified value. 
    /// </summary>
    [DataContract]
    public partial class GreaterThan : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreaterThan" /> class.
        /// </summary>
        public GreaterThan()
        {
        }

        /// <summary>
        ///Returns only the objects where the value of the specified numerical property is greater than or equal to the specified value.
        ///
        ///The first element of the array contains the name of the property. The next element specifies the values that the property must be greater than or equal to. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$ge":["properties.Dimensions.Width1",0.1]`, the request returns the properties of all objects whose `properties.Dimensions.Width1` property is greater than or equal to  `0.1`.
        ///
        ///**Note:** The Model Derivative service converts numeric values from their native units to metric base units for comparison. So, the value to compare with must be specified in metric base units. For example, if the property you are comparing is a length measurement, you must specify the value  in `m`.  Not in `cm`, `mm`, or `ft`.
        /// </summary>
        /// <value>
        ///Returns only the objects where the value of the specified numerical property is greater than or equal to the specified value.
        ///
        ///The first element of the array contains the name of the property. The next element specifies the values that the property must be greater than or equal to. The array can only be two elements long.
        ///
        ///For example, if you specify an array as: `"$ge":["properties.Dimensions.Width1",0.1]`, the request returns the properties of all objects whose `properties.Dimensions.Width1` property is greater than or equal to  `0.1`.
        ///
        ///**Note:** The Model Derivative service converts numeric values from their native units to metric base units for comparison. So, the value to compare with must be specified in metric base units. For example, if the property you are comparing is a length measurement, you must specify the value  in `m`.  Not in `cm`, `mm`, or `ft`.
        /// </value>
        [DataMember(Name = "$ge", EmitDefaultValue = false)]
        public List<object> Ge { get; set; }

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
