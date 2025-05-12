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
    /// BatchcompleteuploadObjectRequests
    /// </summary>
    [DataContract]
    public partial class BatchcompleteuploadObjectRequests 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchcompleteuploadObjectRequests" /> class.
        /// </summary>
        public BatchcompleteuploadObjectRequests()
        {
        }
        
        /// <summary>
        ///The URL-encoded human friendly name of the object for which to complete an upload.
        /// </summary>
        /// <value>
        ///The URL-encoded human friendly name of the object for which to complete an upload.
        /// </value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        ///The ID uniquely identifying the upload session that was returned when you obtained the signed upload URL.
        /// </summary>
        /// <value>
        ///The ID uniquely identifying the upload session that was returned when you obtained the signed upload URL.
        /// </value>
        [DataMember(Name="uploadKey", EmitDefaultValue=false)]
        public string UploadKey { get; set; }

        /// <summary>
        ///The expected size of the object. If provided, OSS will check this against the object in S3 and return an error if the size does not match.
        /// </summary>
        /// <value>
        ///The expected size of the object. If provided, OSS will check this against the object in S3 and return an error if the size does not match.
        /// </value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public long? Size { get; set; }

        /// <summary>
        ///An array of eTags. S3 returns an eTag to each upload request, be it for a chunk or an entire file. For a single-part upload, this array contains the expected eTag of the entire object. For a multipart upload, this array contains the expected eTag of each part of the upload; the index of an eTag in the array corresponds to its part number in the upload. If provided, OSS will validate these eTags against the content in S3, and return an error if the eTags do not match.
        /// </summary>
        /// <value>
        ///An array of eTags. S3 returns an eTag to each upload request, be it for a chunk or an entire file. For a single-part upload, this array contains the expected eTag of the entire object. For a multipart upload, this array contains the expected eTag of each part of the upload; the index of an eTag in the array corresponds to its part number in the upload. If provided, OSS will validate these eTags against the content in S3, and return an error if the eTags do not match.
        /// </value>
        [DataMember(Name="eTags", EmitDefaultValue=false)]
        public List<string> ETags { get; set; }

        /// <summary>
        ///The Content-Type value for the uploaded object to record within OSS.
        /// </summary>
        /// <value>
        ///The Content-Type value for the uploaded object to record within OSS.
        /// </value>
        [DataMember(Name="x-ads-meta-Content-Type", EmitDefaultValue=false)]
        public string XAdsMetaContentType { get; set; }

        /// <summary>
        ///The Content-Disposition value for the uploaded object to record within OSS.
        /// </summary>
        /// <value>
        ///The Content-Disposition value for the uploaded object to record within OSS.
        /// </value>
        [DataMember(Name="x-ads-meta-Content-Disposition", EmitDefaultValue=false)]
        public string XAdsMetaContentDisposition { get; set; }

        /// <summary>
        ///The Content-Encoding value for the uploaded object to record within OSS.
        /// </summary>
        /// <value>
        ///The Content-Encoding value for the uploaded object to record within OSS.
        /// </value>
        [DataMember(Name="x-ads-meta-Content-Encoding", EmitDefaultValue=false)]
        public string XAdsMetaContentEncoding { get; set; }

        /// <summary>
        ///The Cache-Control value for the uploaded object to record within OSS.
        /// </summary>
        /// <value>
        ///The Cache-Control value for the uploaded object to record within OSS.
        /// </value>
        [DataMember(Name="x-ads-meta-Cache-Control", EmitDefaultValue=false)]
        public string XAdsMetaCacheControl { get; set; }

        /// <summary>
        ///Custom metadata to be stored with the object, which can be retrieved later on download or when retrieving object details. Must be a JSON object that is less than 100 bytes.
        /// </summary>
        /// <value>
        ///Custom metadata to be stored with the object, which can be retrieved later on download or when retrieving object details. Must be a JSON object that is less than 100 bytes.
        /// </value>
        [DataMember(Name="x-ads-user-defined-metadata", EmitDefaultValue=false)]
        public string XAdsUserDefinedMetadata { get; set; }

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
