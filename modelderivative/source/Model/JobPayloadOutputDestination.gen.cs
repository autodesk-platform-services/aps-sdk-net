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
    /// Specifies where to store generated derivatives.
    /// </summary>
    [DataContract]
    public partial class JobPayloadOutputDestination
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobPayloadOutputDestination" /> class.
        /// </summary>
        public JobPayloadOutputDestination()
        {
        }

        /// <summary>
        ///Specifies where to store generated derivatives. Possible values are:
        ///
        ///- `US`: (Default) Store derivatives at a data center for the United States of America.
        ///- `EMEA`: Store derivatives at a data center for the European Union. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments.
        /// </summary>
        /// <value>
        ///Specifies where to store generated derivatives. Possible values are:
        ///
        ///- `US`: (Default) Store derivatives at a data center for the United States of America.
        ///- `EMEA`: Store derivatives at a data center for the European Union. 
        ///- `AUS` - (Beta) Data center for the Australia region.
        ///- `CAN` : Data centre for the Canada region.
        ///- `DEU` : Data centre for the Germany region.
        ///- `IND` : Data centre for the India region.
        ///- `JPN` : Data centre for the Japan region.
        ///- `GBR`  : Data centre for the United Kingdom region.
        ///
        ///**Note**: Beta features are subject to change. Please avoid using them in production environments.
        /// </value>
        [DataMember(Name = "region", EmitDefaultValue = false)]
        public Region Region { get; set; }

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
