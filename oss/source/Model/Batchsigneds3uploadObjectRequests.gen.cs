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
    /// Batchsigneds3uploadObjectRequests
    /// </summary>
    [DataContract]
    public partial class Batchsigneds3uploadObjectRequests 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Batchsigneds3uploadObjectRequests" /> class.
        /// </summary>
        public Batchsigneds3uploadObjectRequests()
        {
        }
        
        /// <summary>
        ///A URL-encoded human friendly name of the object to upload.
        /// </summary>
        /// <value>
        ///A URL-encoded human friendly name of the object to upload.
        /// </value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        ///The index of first chunk to be uploaded.
        /// </summary>
        /// <value>
        ///The index of first chunk to be uploaded.
        /// </value>
        [DataMember(Name="firstPart", EmitDefaultValue=false)]
        public int? FirstPart { get; set; }

        /// <summary>
        ///The number of parts you intend to chunk the object for uploading. OSS will return that many signed URLs, one URL for each chunk. If you do not specify a value you'll get only one URL to upload the entire object.
        /// </summary>
        /// <value>
        ///The number of parts you intend to chunk the object for uploading. OSS will return that many signed URLs, one URL for each chunk. If you do not specify a value you'll get only one URL to upload the entire object.
        /// </value>
        [DataMember(Name="parts", EmitDefaultValue=false)]
        public int? Parts { get; set; }

        /// <summary>
        ///The `uploadKey` of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. If you do not specify a value, OSS will initiate a new upload entirely.
        /// </summary>
        /// <value>
        ///The `uploadKey` of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. If you do not specify a value, OSS will initiate a new upload entirely.
        /// </value>
        [DataMember(Name="uploadKey", EmitDefaultValue=false)]
        public string UploadKey { get; set; }

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
