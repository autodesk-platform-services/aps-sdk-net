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
        ///Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public DownloadStatus Status { get; set; }

        /// <summary>
        ///A S3 signed URL with which to download the object. This attribute is returned when `status` is `complete` or `fallback`; in the latter case, this will return an OSS signed URL, not an S3 signed URL.
        /// </summary>
        /// <value>
        ///A S3 signed URL with which to download the object. This attribute is returned when `status` is `complete` or `fallback`; in the latter case, this will return an OSS signed URL, not an S3 signed URL.
        /// </value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }

        /// <summary>
        ///A map of S3 signed URLs, one for each chunk of an unmerged resumable upload. This attribute is returned when `status` is `chunked`. The key of each entry is the byte range of the total file which the chunk comprises.
        /// </summary>
        /// <value>
        ///A map of S3 signed URLs, one for each chunk of an unmerged resumable upload. This attribute is returned when `status` is `chunked`. The key of each entry is the byte range of the total file which the chunk comprises.
        /// </value>
        [DataMember(Name="urls", EmitDefaultValue=false)]
        public Object Urls { get; set; }

        /// <summary>
        ///The values that were requested for the following parameters when requesting the S3 signed URL.
///
///- `Content-Type`
///- `Content-Disposition`
///- `Cache-Control`.
        /// </summary>
        /// <value>
        ///The values that were requested for the following parameters when requesting the S3 signed URL.
///
///- `Content-Type`
///- `Content-Disposition`
///- `Cache-Control`.
        /// </value>
        [DataMember(Name="params", EmitDefaultValue=false)]
        public Object Params { get; set; }

        /// <summary>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </summary>
        /// <value>
        ///The total amount of storage space occupied by the object, in bytes.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public long? Size { get; set; }

        /// <summary>
        ///A hash value computed from the data of the object, if available.
        /// </summary>
        /// <value>
        ///A hash value computed from the data of the object, if available.
        /// </value>
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
