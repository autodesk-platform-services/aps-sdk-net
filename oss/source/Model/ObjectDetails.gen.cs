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
    /// Represents an object within a bucket.
    /// </summary>
    [DataContract]
    public partial class ObjectDetails 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectDetails" /> class.
        /// </summary>
        public ObjectDetails()
        {
        }
        
        /// <summary>
        ///The bucket key of the bucket that contains the object.
        /// </summary>
        /// <value>
        ///The bucket key of the bucket that contains the object.
        /// </value>
        [DataMember(Name="bucketKey", EmitDefaultValue=false)]
        public string BucketKey { get; set; }

        /// <summary>
        ///An identifier (URN) that uniquely and persistently identifies the object.
        /// </summary>
        /// <value>
        ///An identifier (URN) that uniquely and persistently identifies the object.
        /// </value>
        [DataMember(Name="objectId", EmitDefaultValue=false)]
        public string ObjectId { get; set; }

        /// <summary>
        ///A URL-encoded human friendly name to identify the object.
        /// </summary>
        /// <value>
        ///A URL-encoded human friendly name to identify the object.
        /// </value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        ///A hash value computed from the data of the object.
        /// </summary>
        /// <value>
        ///A hash value computed from the data of the object.
        /// </value>
        [DataMember(Name="sha1", EmitDefaultValue=false)]
        public byte[] Sha1 { get; set; }

        /// <summary>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </summary>
        /// <value>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public long? Size { get; set; }

        /// <summary>
        ///The format of the data stored within the object, expressed as a MIME type.
        /// </summary>
        /// <value>
        ///The format of the data stored within the object, expressed as a MIME type.
        /// </value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        ///A URL that points to the actual location of the object.
        /// </summary>
        /// <value>
        ///A URL that points to the actual location of the object.
        /// </value>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public string Location { get; set; }

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
