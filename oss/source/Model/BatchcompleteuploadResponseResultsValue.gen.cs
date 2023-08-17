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
    /// BatchcompleteuploadResponseResultsValue
    /// </summary>
    [DataContract]
    public partial class BatchcompleteuploadResponseResultsValue 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchcompleteuploadResponseResultsValue" /> class.
        /// </summary>
        public BatchcompleteuploadResponseResultsValue()
        {
        }
        
        /// <summary>
        /// A string indicating whether the object completion failed. If this is not present, assume the completion succeeded. If this is \&quot;error\&quot;, then the object completion failed.
        /// </summary>
        /// <value>A string indicating whether the object completion failed. If this is not present, assume the completion succeeded. If this is \&quot;error\&quot;, then the object completion failed.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// The key of the bucket into which the object was uploaded.
        /// </summary>
        /// <value>The key of the bucket into which the object was uploaded.</value>
        [DataMember(Name="bucketKey", EmitDefaultValue=false)]
        public string BucketKey { get; set; }

        /// <summary>
        /// The key of the object.
        /// </summary>
        /// <value>The key of the object.</value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        /// The URN of the object.
        /// </summary>
        /// <value>The URN of the object.</value>
        [DataMember(Name="objectId", EmitDefaultValue=false)]
        public string ObjectId { get; set; }

        /// <summary>
        /// The size of the object in bytes, if successful. If unsuccessful due to a size mismatch, this is an object with information about the mismatch.
        /// </summary>
        /// <value>The size of the object in bytes, if successful. If unsuccessful due to a size mismatch, this is an object with information about the mismatch.</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        /// The Content-Type stored for the object, if provided.
        /// </summary>
        /// <value>The Content-Type stored for the object, if provided.</value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// The Content-Disposition stored for the object, if provided.
        /// </summary>
        /// <value>The Content-Disposition stored for the object, if provided.</value>
        [DataMember(Name="contentDisposition", EmitDefaultValue=false)]
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The Content-Encoding stored for the object, if provided.
        /// </summary>
        /// <value>The Content-Encoding stored for the object, if provided.</value>
        [DataMember(Name="contentEncoding", EmitDefaultValue=false)]
        public string ContentEncoding { get; set; }

        /// <summary>
        /// The Cache-Control stored for the object, if provided.
        /// </summary>
        /// <value>The Cache-Control stored for the object, if provided.</value>
        [DataMember(Name="cacheControl", EmitDefaultValue=false)]
        public string CacheControl { get; set; }

        /// <summary>
        /// An array containing the status of each part, indicating any issues in eTag mismatch or size issues.
        /// </summary>
        /// <value>An array containing the status of each part, indicating any issues in eTag mismatch or size issues.</value>
        [DataMember(Name="parts", EmitDefaultValue=false)]
        public List<BatchcompleteuploadResponseResultsValueParts> Parts { get; set; }

        /// <summary>
        /// The reason for the failure, if the status is \&quot;error\&quot;.
        /// </summary>
        /// <value>The reason for the failure, if the status is \&quot;error\&quot;.</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }

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
