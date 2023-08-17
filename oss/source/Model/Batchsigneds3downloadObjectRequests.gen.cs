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
        /// The key of the object for which to create a download signed URL.
        /// </summary>
        /// <value>The key of the object for which to create a download signed URL.</value>
        [DataMember(Name="objectKey", EmitDefaultValue=false)]
        public string ObjectKey { get; set; }

        /// <summary>
        /// The value of the Content-Type header the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.
        /// </summary>
        /// <value>The value of the Content-Type header the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.</value>
        [DataMember(Name="response-content-type", EmitDefaultValue=false)]
        public string ResponseContentType { get; set; }

        /// <summary>
        /// The value of the Content-Disposition header the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.
        /// </summary>
        /// <value>The value of the Content-Disposition header the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.</value>
        [DataMember(Name="response-content-disposition", EmitDefaultValue=false)]
        public string ResponseContentDisposition { get; set; }

        /// <summary>
        /// The value of the Cache-Control header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.
        /// </summary>
        /// <value>The value of the Cache-Control header that the client expects to receive from S3. If this attribute is not provided, it defaults to the value stored for the object itself.</value>
        [DataMember(Name="response-cache-control", EmitDefaultValue=false)]
        public string ResponseCacheControl { get; set; }

        /// <summary>
        /// The value of the ETag of the object. If they match, the response body will show the status of this item as &#x60;skipped&#x60; with the reason &#x60;Not Modified&#x60;, as the client already has the data.
        /// </summary>
        /// <value>The value of the ETag of the object. If they match, the response body will show the status of this item as &#x60;skipped&#x60; with the reason &#x60;Not Modified&#x60;, as the client already has the data.</value>
        [DataMember(Name="If-None-Match", EmitDefaultValue=false)]
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// If the requested object has not been modified since the time specified in this attribute, the response body will show the status of this item as &#x60;skipped&#x60; with the reason &#x60;Not Modified&#x60;, as the client still has the latest version of the data.
        /// </summary>
        /// <value>If the requested object has not been modified since the time specified in this attribute, the response body will show the status of this item as &#x60;skipped&#x60; with the reason &#x60;Not Modified&#x60;, as the client still has the latest version of the data.</value>
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
