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
    /// Completes3uploadResponse400Parts
    /// </summary>
    [DataContract]
    public partial class Completes3uploadResponse400Parts 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Completes3uploadResponse400Parts" /> class.
        /// </summary>
        public Completes3uploadResponse400Parts()
        {
        }
        
        /// <summary>
        /// The index of the part in the multipart upload.
        /// </summary>
        /// <value>The index of the part in the multipart upload.</value>
        [DataMember(Name="part", EmitDefaultValue=false)]
        public int? Part { get; set; }

        /// <summary>
        /// Indicates whether this particular part uploaded to S3 is valid. If no part has been uploaded to S3 for a particular index, the status will be &#39;Pending&#39;. If the eTag of the part in S3 does not match the one provided in the request, the status will be &#39;Unexpected&#39;. If the blob uploaded to S3 is smaller than the minimum chunk size (5MB for all parts except the final one), the status will be &#39;TooSmall&#39;. If both of the latter conditions are true, the status will be &#39;Unexpected+TooSmall&#39;. If none of these issues exist, the status will be &#39;Ok&#39;.
        /// </summary>
        /// <value>Indicates whether this particular part uploaded to S3 is valid. If no part has been uploaded to S3 for a particular index, the status will be &#39;Pending&#39;. If the eTag of the part in S3 does not match the one provided in the request, the status will be &#39;Unexpected&#39;. If the blob uploaded to S3 is smaller than the minimum chunk size (5MB for all parts except the final one), the status will be &#39;TooSmall&#39;. If both of the latter conditions are true, the status will be &#39;Unexpected+TooSmall&#39;. If none of these issues exist, the status will be &#39;Ok&#39;.</value>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public string Status { get; set; }

        /// <summary>
        /// The size of the corresponding part detected in S3.
        /// </summary>
        /// <value>The size of the corresponding part detected in S3.</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        /// The eTag of the detected part in S3.
        /// </summary>
        /// <value>The eTag of the detected part in S3.</value>
        [DataMember(Name="eTag", EmitDefaultValue=false)]
        public string ETag { get; set; }

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
