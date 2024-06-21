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
    /// The results returned by the Complete Batch Upload to S3 Signed URLs operation.
    /// </summary>
    [DataContract]
    public partial class BatchCompletedResults 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchCompletedResults" /> class.
        /// </summary>
        public BatchCompletedResults()
        {
        }
        
        /// <summary>
        ///If this attribute is not returned, completion has succeeded. If the value of this attribute is "error", completion failed.'
        /// </summary>
        /// <value>
        ///If this attribute is not returned, completion has succeeded. If the value of this attribute is "error", completion failed.'
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///The bucket key of the bucket the object was uploaded to.
        /// </summary>
        /// <value>
        ///The bucket key of the bucket the object was uploaded to.
        /// </value>
        [DataMember(Name="bucketKey", EmitDefaultValue=false)]
        public string BucketKey { get; set; }

        /// <summary>
        ///The URL-encoded human friendly name of the object.
        /// </summary>
        /// <value>
        ///The URL-encoded human friendly name of the object.
        /// </value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        ///An identifier (URN) that uniquely and persistently identifies the object.
        /// </summary>
        /// <value>
        ///An identifier (URN) that uniquely and persistently identifies the object.
        /// </value>
        [DataMember(Name="objectId", EmitDefaultValue=false)]
        public string ObjectId { get; set; }

        /// <summary>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </summary>
        /// <value>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        ///The format of the data stored within the object, expressed as a MIME type. This attribute is returned only if it was specified when the object was uploaded.
        /// </summary>
        /// <value>
        ///The format of the data stored within the object, expressed as a MIME type. This attribute is returned only if it was specified when the object was uploaded.
        /// </value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        ///The Content-Disposition value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </summary>
        /// <value>
        ///The Content-Disposition value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </value>
        [DataMember(Name="contentDisposition", EmitDefaultValue=false)]
        public string ContentDisposition { get; set; }

        /// <summary>
        ///The Content-Encoding value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </summary>
        /// <value>
        ///The Content-Encoding value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </value>
        [DataMember(Name="contentEncoding", EmitDefaultValue=false)]
        public string ContentEncoding { get; set; }

        /// <summary>
        ///The Cache-Control value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </summary>
        /// <value>
        ///The Cache-Control value for the uploaded object as recorded within OSS. This attribute is returned only if it was specified when the object was uploaded.
        /// </value>
        [DataMember(Name="cacheControl", EmitDefaultValue=false)]
        public string CacheControl { get; set; }

        /// <summary>
        ///An array containing the status of each part, indicating any issues with eTag or size mismatch issues.
        /// </summary>
        /// <value>
        ///An array containing the status of each part, indicating any issues with eTag or size mismatch issues.
        /// </value>
        [DataMember(Name="parts", EmitDefaultValue=false)]
        public List<BatchCompletedResultsParts> Parts { get; set; }

        /// <summary>
        ///The reason for the failure, if the status is `error`.
        /// </summary>
        /// <value>
        ///The reason for the failure, if the status is `error`.
        /// </value>
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
