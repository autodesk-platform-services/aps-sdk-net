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
    /// Batchsigneds3downloadObjectRequests
    /// </summary>
    [DataContract]
    public partial class Batchsigneds3downloadObjectRequests 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Batchsigneds3downloadObjectRequests" /> class.
        /// </summary>
        public Batchsigneds3downloadObjectRequests()
        {
        }
        
        /// <summary>
        ///The URL-encoded human friendly name of the object to download.
        /// </summary>
        /// <value>
        ///The URL-encoded human friendly name of the object to download.
        /// </value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        ///The value of the Content-Type header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Type header defaults to the value stored with OSS.
        /// </summary>
        /// <value>
        ///The value of the Content-Type header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Type header defaults to the value stored with OSS.
        /// </value>
        [DataMember(Name="response-content-type", EmitDefaultValue=false)]
        public string ResponseContentType { get; set; }

        /// <summary>
        ///The value of the Content-Disposition header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Disposition header defaults to the value stored with OSS.
        /// </summary>
        /// <value>
        ///The value of the Content-Disposition header you want to receive when you download the object using the signed URL. If you do not specify a value, the Content-Disposition header defaults to the value stored with OSS.
        /// </value>
        [DataMember(Name="response-content-disposition", EmitDefaultValue=false)]
        public string ResponseContentDisposition { get; set; }

        /// <summary>
        ///The value of the Cache-Control header you want to receive when you download the object using the signed URL. If you do not specify a value, the Cache-Control header defaults to the value stored with OSS.
        /// </summary>
        /// <value>
        ///The value of the Cache-Control header you want to receive when you download the object using the signed URL. If you do not specify a value, the Cache-Control header defaults to the value stored with OSS.
        /// </value>
        [DataMember(Name="response-cache-control", EmitDefaultValue=false)]
        public string ResponseCacheControl { get; set; }

        /// <summary>
        ///The last known ETag value of the object. OSS returns the signed URL only if the `If-None-Match` header differs from the ETag value of the object on S3. If not, it returns a 304 "Not Modified" HTTP status.
        /// </summary>
        /// <value>
        ///The last known ETag value of the object. OSS returns the signed URL only if the `If-None-Match` header differs from the ETag value of the object on S3. If not, it returns a 304 "Not Modified" HTTP status.
        /// </value>
        [DataMember(Name="If-None-Match", EmitDefaultValue=false)]
        public string IfNoneMatch { get; set; }

        /// <summary>
        ///A timestamp in the HTTP date format (Mon, DD Month YYYY HH:MM:SS GMT). A signed URL is returned only if the object has been modified since the specified timestamp. If not, a 304 (Not Modified) HTTP status is returned.
        /// </summary>
        /// <value>
        ///A timestamp in the HTTP date format (Mon, DD Month YYYY HH:MM:SS GMT). A signed URL is returned only if the object has been modified since the specified timestamp. If not, a 304 (Not Modified) HTTP status is returned.
        /// </value>
        [DataMember(Name="If-Modified-Since", EmitDefaultValue=false)]
        public string IfModifiedSince { get; set; }

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
