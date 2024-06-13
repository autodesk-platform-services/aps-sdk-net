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
    /// Use this to retrieve only the properties of objects where a specified attribute is between two specified values. 
    /// </summary>
    [DataContract]
    public partial class Between : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Between" /> class.
        /// </summary>
        public Between()
        {
        }

        /// <summary>
        ///Returns only the objects where the value of the specified numerical property lies between the specified values.
        ///
        ///The first element of the array contains the name of the property. The next two elements specify the values that the property must lie between. The array can only be three elements long.
        ///
        ///For example, if you specify an array as: `"$between":["properties.Dimensions.Width1",1,10]`, the request returns the properties of all objects whose `properties.Dimensions.Width1` property is between `1` and `10`.
        ///
        ///**Note:** The Model Derivative service converts numeric values from their native units to metric base units for comparison. So, you must specify the values to compare with in metric base units. For example, if the property you are comparing is a length measurement, you must specify the values  in `m`.  Not in `cm`, `mm`, or `ft`.
        /// </summary>
        /// <value>
        ///Returns only the objects where the value of the specified numerical property lies between the specified values.
        ///
        ///The first element of the array contains the name of the property. The next two elements specify the values that the property must lie between. The array can only be three elements long.
        ///
        ///For example, if you specify an array as: `"$between":["properties.Dimensions.Width1",1,10]`, the request returns the properties of all objects whose `properties.Dimensions.Width1` property is between `1` and `10`.
        ///
        ///**Note:** The Model Derivative service converts numeric values from their native units to metric base units for comparison. So, you must specify the values to compare with in metric base units. For example, if the property you are comparing is a length measurement, you must specify the values  in `m`.  Not in `cm`, `mm`, or `ft`.
        /// </value>
        [DataMember(Name = "$between", EmitDefaultValue = false)]
        public List<object> _Between { get; set; }

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
