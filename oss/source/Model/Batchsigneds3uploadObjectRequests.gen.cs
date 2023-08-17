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
        /// The key/name of the object for which to create an S3 upload URL. If neither the \&quot;part\&quot; nor \&quot;parts\&quot; attribute is provided, OSS will return a single upload URL with which to upload the entire object.
        /// </summary>
        /// <value>The key/name of the object for which to create an S3 upload URL. If neither the \&quot;part\&quot; nor \&quot;parts\&quot; attribute is provided, OSS will return a single upload URL with which to upload the entire object.</value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        /// The index of an individual part for which to retrieve a chunk upload URL.
        /// </summary>
        /// <value>The index of an individual part for which to retrieve a chunk upload URL.</value>
        [DataMember(Name="firstPart", EmitDefaultValue=false)]
        public int? FirstPart { get; set; }

        /// <summary>
        /// For a multipart upload, the number of chunk URLs to return. If X is provided, the response will include chunk URLs from 1 to X. If none provided, the response will include only a single URL with which to upload an entire object.
        /// </summary>
        /// <value>For a multipart upload, the number of chunk URLs to return. If X is provided, the response will include chunk URLs from 1 to X. If none provided, the response will include only a single URL with which to upload an entire object.</value>
        [DataMember(Name="parts", EmitDefaultValue=false)]
        public int? Parts { get; set; }

        /// <summary>
        /// The identifier of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. This must match the uploadKey returned by a previous call to this endpoint where the client requested more than one part URL.
        /// </summary>
        /// <value>The identifier of a previously-initiated upload, in order to request more chunk upload URLs for the same upload. This must match the uploadKey returned by a previous call to this endpoint where the client requested more than one part URL.</value>
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
