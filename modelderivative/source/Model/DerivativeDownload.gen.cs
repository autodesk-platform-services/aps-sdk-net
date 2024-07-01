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
    /// An object that represents the successful response of a Fetch Derivative Download operation.
    /// </summary>
    [DataContract]
    public partial class DerivativeDownload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DerivativeDownload" /> class.
        /// </summary>
        public DerivativeDownload()
        {
        }
        
        /// <summary>
        ///The calculated ETag hash of the derivative/file, if available.
        /// </summary>
        /// <value>
        ///The calculated ETag hash of the derivative/file, if available.
        /// </value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public string Etag { get; set; }

        /// <summary>
        ///The size of the derivative/file, in bytes.
        /// </summary>
        /// <value>
        ///The size of the derivative/file, in bytes.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public decimal? Size { get; set; }

        /// <summary>
        ///The download URL.
        /// </summary>
        /// <value>
        ///The download URL.
        /// </value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        ///The content type of the derivative/file.
        /// </summary>
        /// <value>
        ///The content type of the derivative/file.
        /// </value>
        [DataMember(Name="content-type", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        ///The 13-digit epoch time stamp indicating the time the signed cookies expire.
        /// </summary>
        /// <value>
        ///The 13-digit epoch time stamp indicating the time the signed cookies expire.
        /// </value>
        [DataMember(Name="expiration", EmitDefaultValue=false)]
        public decimal? Expiration { get; set; }

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
