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
    /// Batchsigneds3uploadResponseResultsValue
    /// </summary>
    [DataContract]
    public partial class Batchsigneds3uploadResponseResultsValue 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Batchsigneds3uploadResponseResultsValue" /> class.
        /// </summary>
        public Batchsigneds3uploadResponseResultsValue()
        {
        }
        
        /// <summary>
        ///Describes an error that was encountered. Returned only if the signed URL request for that object failed.
        /// </summary>
        /// <value>
        ///Describes an error that was encountered. Returned only if the signed URL request for that object failed.
        /// </value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public string Reason { get; set; }

        /// <summary>
        ///Returned only if the signed URL request for that object failed.
        /// </summary>
        /// <value>
        ///Returned only if the signed URL request for that object failed.
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///The deadline to call [Complete Batch Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-signeds3upload-POST/) for the object. If not completed by this time, all uploaded data for this session will be discarded.
        /// </summary>
        /// <value>
        ///The deadline to call [Complete Batch Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-signeds3upload-POST/) for the object. If not completed by this time, all uploaded data for this session will be discarded.
        /// </value>
        [DataMember(Name="uploadExpiration", EmitDefaultValue=false)]
        public string UploadExpiration { get; set; }

        /// <summary>
        ///An ID that uniquely identifies the upload session. It allows OSS to differentiate between fresh upload attempts from attempts to resume uploading data for an active upload session, in case of network interruptions. You must provide this value when:
///
///- Re-requesting chunk URLs for an active upload session. 
///- When calling the [Complete Batch Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-signeds3upload-POST/) operation to end an active upload session.
        /// </summary>
        /// <value>
        ///An ID that uniquely identifies the upload session. It allows OSS to differentiate between fresh upload attempts from attempts to resume uploading data for an active upload session, in case of network interruptions. You must provide this value when:
///
///- Re-requesting chunk URLs for an active upload session. 
///- When calling the [Complete Batch Upload to S3 Signed URL](/en/docs/data/v2/reference/http/buckets-:bucketKey-objects-:objectKey-signeds3upload-POST/) operation to end an active upload session.
        /// </value>
        [DataMember(Name="uploadKey", EmitDefaultValue=false)]
        public string UploadKey { get; set; }

        /// <summary>
        ///The date and time, in the ISO 8601 format, indicating when the signed URLs will expire.
        /// </summary>
        /// <value>
        ///The date and time, in the ISO 8601 format, indicating when the signed URLs will expire.
        /// </value>
        [DataMember(Name="urlExpiration", EmitDefaultValue=false)]
        public string UrlExpiration { get; set; }

        /// <summary>
        ///An array of signed URLs. For a single-part upload, this will only include a single URL. For a multipart upload, there will be one for each chunk of a multipart upload; the index of the URL in the array corresponds to the part number of the chunk.
        /// </summary>
        /// <value>
        ///An array of signed URLs. For a single-part upload, this will only include a single URL. For a multipart upload, there will be one for each chunk of a multipart upload; the index of the URL in the array corresponds to the part number of the chunk.
        /// </value>
        [DataMember(Name="urls", EmitDefaultValue=false)]
        public List<string> Urls { get; set; }

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
