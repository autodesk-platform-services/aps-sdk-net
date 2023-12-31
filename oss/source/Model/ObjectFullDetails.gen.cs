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
    /// Object Details json response
    /// </summary>
    [DataContract]
    public partial class ObjectFullDetails 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFullDetails" /> class.
        /// </summary>
        public ObjectFullDetails()
        {
        }
        
        /// <summary>
        /// Bucket key
        /// </summary>
        /// <value>Bucket key</value>
        [DataMember(Name="bucketKey", EmitDefaultValue=false)]
        public string BucketKey { get; set; }

        /// <summary>
        /// Object URN
        /// </summary>
        /// <value>Object URN</value>
        [DataMember(Name="objectId", EmitDefaultValue=false)]
        public string ObjectId { get; set; }

        /// <summary>
        /// Object name
        /// </summary>
        /// <value>Object name</value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        /// Object SHA1
        /// </summary>
        /// <value>Object SHA1</value>
        [DataMember(Name="sha1", EmitDefaultValue=false)]
        public byte[] Sha1 { get; set; }

        /// <summary>
        /// Object size
        /// </summary>
        /// <value>Object size</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        /// Object content-type
        /// </summary>
        /// <value>Object content-type</value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// URL to download the object
        /// </summary>
        /// <value>URL to download the object</value>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public string Location { get; set; }

        /// <summary>
        /// Epoch timestamp when the object was created. Only provided if the user requests this to be included in the query parameters.
        /// </summary>
        /// <value>Epoch timestamp when the object was created. Only provided if the user requests this to be included in the query parameters.</value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public long? CreatedDate { get; set; }

        /// <summary>
        /// Epoch timestamp when the object was last accessed. Only provided if the user requests this to be included in the query parameters.
        /// </summary>
        /// <value>Epoch timestamp when the object was last accessed. Only provided if the user requests this to be included in the query parameters.</value>
        [DataMember(Name="lastAccessedDate", EmitDefaultValue=false)]
        public long? LastAccessedDate { get; set; }

        /// <summary>
        /// Epoch timestamp when the object was last modified. Only provided if the user requests this to be included in the query parameters.
        /// </summary>
        /// <value>Epoch timestamp when the object was last modified. Only provided if the user requests this to be included in the query parameters.</value>
        [DataMember(Name="lastModifiedDate", EmitDefaultValue=false)]
        public long? LastModifiedDate { get; set; }

        /// <summary>
        /// When specified, the response will include the user defined metadata in a JSON field named userDefinedMetadata, if available. The user defined metadata can be set on file uploading.
        /// </summary>
        /// <value>When specified, the response will include the user defined metadata in a JSON field named userDefinedMetadata, if available. The user defined metadata can be set on file uploading.</value>
        [DataMember(Name="userDefinedMetadata", EmitDefaultValue=false)]
        public string UserDefinedMetadata { get; set; }

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
