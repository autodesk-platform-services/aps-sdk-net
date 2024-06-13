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
    /// Use this to retrieve only the properties of objects with Object IDs or External IDs matching the specified values.   Use the &#x60;&#x60;MatchIdType&#x60;&#x60; Enum to pick between Object IDs and External IDs. 
    /// </summary>
    [DataContract]
    public partial class MatchId : ISpecificPropertiesPayloadQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatchId" /> class.
        /// </summary>
        public MatchId()
        {
        }

        /// <summary>
        ///Returns only the objects with their `objectid` or `externalId` attribute exactly matching one of the values specified in the array.
        ///
        ///The first element of the array contains the name of the attribute to match (`objectid` or `externalId`). Subsequent elements contain the values to match.
        ///
        ///For example, if you specify an array as: `"$in":["objectid",1,2]`, the request will only return the properties of the objects with `objectid` = `1` and `2`. If you specify an array as `"$in":["externalId","doc_982afc8a","doc_afd75233" ]` the request will only return the properties of the objects with `externalId` = `doc_982afc8a` and `doc_afd75233`.
        /// </summary>
        /// <value>
        ///Returns only the objects with their `objectid` or `externalId` attribute exactly matching one of the values specified in the array.
        ///
        ///The first element of the array contains the name of the attribute to match (`objectid` or `externalId`). Subsequent elements contain the values to match.
        ///
        ///For example, if you specify an array as: `"$in":["objectid",1,2]`, the request will only return the properties of the objects with `objectid` = `1` and `2`. If you specify an array as `"$in":["externalId","doc_982afc8a","doc_afd75233" ]` the request will only return the properties of the objects with `externalId` = `doc_982afc8a` and `doc_afd75233`.
        /// </value>
        [DataMember(Name = "$in", EmitDefaultValue = false)]
        public List<object> In { get; set; }

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
