/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * oss
 *
 * The Object Storage Service (OSS) allows your application to download and upload raw files (such as PDF, XLS, DWG, or RVT) that are managed by the Data service.
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

namespace Autodesk.Oss.Model
{
    /// <summary>
    /// Signeds3downloadResponse
    /// </summary>
    [DataContract]
    public partial class Signeds3downloadResponse 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Signeds3downloadResponse" /> class.
        /// </summary>
        public Signeds3downloadResponse()
        {
        }
        
        /// <summary>
        /// Indicates the status of the object. &#x60;complete&#x60; indicates a raw upload or merged resumable upload; &#x60;chunked&#x60; indicates an unmerged resumable upload where the user  provide &#x60;public-resource-fallback&#x60;&#x3D;&#x60;false&#x60;; &#x60;fallback&#x60; indicates an unmerged resumable  upload where the user provides &#x60;public-resource-fallback&#x60;&#x3D;&#x60;true&#x60;.
        /// </summary>
        /// <value>Indicates the status of the object. &#x60;complete&#x60; indicates a raw upload or merged resumable upload; &#x60;chunked&#x60; indicates an unmerged resumable upload where the user  provide &#x60;public-resource-fallback&#x60;&#x3D;&#x60;false&#x60;; &#x60;fallback&#x60; indicates an unmerged resumable  upload where the user provides &#x60;public-resource-fallback&#x60;&#x3D;&#x60;true&#x60;.</value>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public string Status { get; set; }

        /// <summary>
        /// The S3 signed URL with which to download the object. This attribute is returned when &#x60;status&#x60; is &#x60;complete&#x60; or &#x60;fallback&#x60;; in the latter case, this will return an OSS Signed Resource, not an S3 signed URL.
        /// </summary>
        /// <value>The S3 signed URL with which to download the object. This attribute is returned when &#x60;status&#x60; is &#x60;complete&#x60; or &#x60;fallback&#x60;; in the latter case, this will return an OSS Signed Resource, not an S3 signed URL.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        /// A map of S3 signed URLs, one for each chunk of an unmerged resumable upload. This attribute is returned when &#x60;status&#x60; is &#x60;chunked&#x60;. The key of each entry is the byte range of the total file which the chunk comprises.
        /// </summary>
        /// <value>A map of S3 signed URLs, one for each chunk of an unmerged resumable upload. This attribute is returned when &#x60;status&#x60; is &#x60;chunked&#x60;. The key of each entry is the byte range of the total file which the chunk comprises.</value>
        [DataMember(Name="urls", EmitDefaultValue=false)]
        public Object Urls { get; set; }

        /// <summary>
        /// The values for the updatable params that were used in the creation of the returned S3 signed URL - - &#x60;Content-Type&#x60;, &#x60;Content-Disposition&#x60;, and &#x60;Cache-Control&#x60;.
        /// </summary>
        /// <value>The values for the updatable params that were used in the creation of the returned S3 signed URL - - &#x60;Content-Type&#x60;, &#x60;Content-Disposition&#x60;, and &#x60;Cache-Control&#x60;.</value>
        [DataMember(Name="params", EmitDefaultValue=false)]
        public Object Params { get; set; }

        /// <summary>
        /// The object size in bytes.
        /// </summary>
        /// <value>The object size in bytes.</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public long? Size { get; set; }

        /// <summary>
        /// The calculated sha1 of the object, if available.
        /// </summary>
        /// <value>The calculated sha1 of the object, if available.</value>
        [DataMember(Name="sha1", EmitDefaultValue=false)]
        public string Sha1 { get; set; }

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
