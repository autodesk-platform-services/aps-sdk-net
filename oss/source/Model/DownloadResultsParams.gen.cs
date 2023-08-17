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
    /// The values for the updatable params that were used in the creation of the returned S3 signed URL.
    /// </summary>
    [DataContract]
    public partial class DownloadResultsParams 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadResultsParams" /> class.
        /// </summary>
        public DownloadResultsParams()
        {
        }
        
        /// <summary>
        /// The Content-Type value to expect when downloading the object, either echoing the response-content-type provided in this request, or defaulting to the Content-Type associated with the stored object record in OSS.
        /// </summary>
        /// <value>The Content-Type value to expect when downloading the object, either echoing the response-content-type provided in this request, or defaulting to the Content-Type associated with the stored object record in OSS.</value>
        [DataMember(Name="Content-Type", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// The Content-Disposition value to expect when downloading the object, either echoing the response-content-disposition provided in this request, or defaulting to the Content-Disposition associated with the stored object record in OSS.
        /// </summary>
        /// <value>The Content-Disposition value to expect when downloading the object, either echoing the response-content-disposition provided in this request, or defaulting to the Content-Disposition associated with the stored object record in OSS.</value>
        [DataMember(Name="Content-Disposition", EmitDefaultValue=false)]
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The Cache-Control value to expect when downloading the object, either echoing the response-cache-control provided in this request, or defaulting to the Cache-Control associated with the stored object record in OSS.
        /// </summary>
        /// <value>The Cache-Control value to expect when downloading the object, either echoing the response-cache-control provided in this request, or defaulting to the Cache-Control associated with the stored object record in OSS.</value>
        [DataMember(Name="Cache-Control", EmitDefaultValue=false)]
        public string CacheControl { get; set; }

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
