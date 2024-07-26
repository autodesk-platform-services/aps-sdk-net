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
    /// Specifies how to split the response into multiple pages, and return the response one page at a time.
    /// </summary>
    [DataContract]
    public partial class SpecificPropertiesPayloadPagination 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificPropertiesPayloadPagination" /> class.
        /// </summary>
        public SpecificPropertiesPayloadPagination()
        {
        }
        
        /// <summary>
        ///The number of properties to skip. Use this attribute with the `limit` attribute to split the properties into multiple pages. To fetch the first page, specify `offset` =0 (do not skip any properties). To fetch the second page, specify `offset` = value of `limit` you specified for the first page. So, the server skips the properties returned on the first page. In general, `offset` = `previous_offset` + `previous_limit`. This attribute is 0 by default. The minimum value is 0.
        /// </summary>
        /// <value>
        ///The number of properties to skip. Use this attribute with the `limit` attribute to split the properties into multiple pages. To fetch the first page, specify `offset` =0 (do not skip any properties). To fetch the second page, specify `offset` = value of `limit` you specified for the first page. So, the server skips the properties returned on the first page. In general, `offset` = `previous_offset` + `previous_limit`. This attribute is 0 by default. The minimum value is 0.
        /// </value>
        [DataMember(Name="offset", EmitDefaultValue=false)]
        public decimal? Offset { get; set; }

        /// <summary>
        ///The maximum number of properties to return in a single page. Use this attribute with the `offset` attribute to split the properties into multiple pages. To fetch the first page, specify `offset` =0 (do not skip any properties). To fetch the second page, specify `offset` = value of `limit` you specified for the first page. So, the server skips the search results returned on the first page. In general, `offset` = `previous_offset` + `previous_limit`. This attribute is 20 by default. The minimum value is 1 and the maximum is 1000.
        /// </summary>
        /// <value>
        ///The maximum number of properties to return in a single page. Use this attribute with the `offset` attribute to split the properties into multiple pages. To fetch the first page, specify `offset` =0 (do not skip any properties). To fetch the second page, specify `offset` = value of `limit` you specified for the first page. So, the server skips the search results returned on the first page. In general, `offset` = `previous_offset` + `previous_limit`. This attribute is 20 by default. The minimum value is 1 and the maximum is 1000.
        /// </value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public decimal? Limit { get; set; }

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
