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
        /// The key/name of the object for which to complete an upload.
        /// </summary>
        /// <value>The key/name of the object for which to complete an upload.</value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        /// The key of the upload to complete.
        /// </summary>
        /// <value>The key of the upload to complete.</value>
        [DataMember(Name="uploadKey", EmitDefaultValue=false)]
        public string UploadKey { get; set; }

        /// <summary>
        /// The size of the object for which to complete an upload. If provided, OSS will fail the upload completion if the size does not match that of the data found in S3.
        /// </summary>
        /// <value>The size of the object for which to complete an upload. If provided, OSS will fail the upload completion if the size does not match that of the data found in S3.</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public int? Size { get; set; }

        /// <summary>
        /// The eTags of the parts uploaded to S3, exactly as returned by S3. The index of an eTag in the array corresponds to the number of the part in the entire object. If provided, OSS will fail the upload completion if any part does not match the data found in S3.
        /// </summary>
        /// <value>The eTags of the parts uploaded to S3, exactly as returned by S3. The index of an eTag in the array corresponds to the number of the part in the entire object. If provided, OSS will fail the upload completion if any part does not match the data found in S3.</value>
        [DataMember(Name="eTags", EmitDefaultValue=false)]
        public List<string> ETags { get; set; }

        /// <summary>
        /// The Content-Type value that OSS will store in the record for the uploaded object.
        /// </summary>
        /// <value>The Content-Type value that OSS will store in the record for the uploaded object.</value>
        [DataMember(Name="x-ads-meta-Content-Type", EmitDefaultValue=false)]
        public string XAdsMetaContentType { get; set; }

        /// <summary>
        /// The Content-Disposition value that OSS will store in the record for the uploaded object.
        /// </summary>
        /// <value>The Content-Disposition value that OSS will store in the record for the uploaded object.</value>
        [DataMember(Name="x-ads-meta-Content-Disposition", EmitDefaultValue=false)]
        public string XAdsMetaContentDisposition { get; set; }

        /// <summary>
        /// The Content-Encoding value that OSS will store in the record for the uploaded object.
        /// </summary>
        /// <value>The Content-Encoding value that OSS will store in the record for the uploaded object.</value>
        [DataMember(Name="x-ads-meta-Content-Encoding", EmitDefaultValue=false)]
        public string XAdsMetaContentEncoding { get; set; }

        /// <summary>
        /// The Cache-Control value that OSS will store in the record for the uploaded object.
        /// </summary>
        /// <value>The Cache-Control value that OSS will store in the record for the uploaded object.</value>
        [DataMember(Name="x-ads-meta-Cache-Control", EmitDefaultValue=false)]
        public string XAdsMetaCacheControl { get; set; }

        /// <summary>
        /// This parameter allows setting any custom metadata to be stored with the object, which can be retrieved later on download or when getting the object details. It has the following restrictions: - It must have a JSON format. - The maximum length is 100 bytes
        /// </summary>
        /// <value>This parameter allows setting any custom metadata to be stored with the object, which can be retrieved later on download or when getting the object details. It has the following restrictions: - It must have a JSON format. - The maximum length is 100 bytes</value>
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
