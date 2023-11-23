/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative API
 *
 * Model Derivative Service Documentation
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
    /// PostReferencesRequest
    /// </summary>
    [DataContract]
    public partial class ReferencesPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferencesPayload" /> class.
        /// </summary>
        public ReferencesPayload()
        {
        }
        
        /// <summary>
        /// The root design urn. Mandatory if the base64 encoded urn in the request URL is a logical urn.
        /// </summary>
        /// <value>The root design urn. Mandatory if the base64 encoded urn in the request URL is a logical urn.</value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        /// Gets or Sets Region
        /// </summary>
        [DataMember(Name="region", EmitDefaultValue=true)]
        public Region Region { get; set; }

        /// <summary>
        /// The root design filename. By default, it is set to “” and the file will be download with its urn.
        /// </summary>
        /// <value>The root design filename. By default, it is set to “” and the file will be download with its urn.</value>
        [DataMember(Name="filename", EmitDefaultValue=false)]
        public string Filename { get; set; }

        /// <summary>
        /// Group of references.
        /// </summary>
        /// <value>Group of references.</value>
        [DataMember(Name="references", EmitDefaultValue=false)]
        public List<References> References { get; set; }

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
