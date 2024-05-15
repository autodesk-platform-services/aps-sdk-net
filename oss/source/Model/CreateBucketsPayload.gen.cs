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
    /// The request payload for the Create Bucket operation.
    /// </summary>
    [DataContract]
    public partial class CreateBucketsPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBucketsPayload" /> class.
        /// </summary>
        public CreateBucketsPayload()
        {
        }
        
        /// <summary>
        ///Bucket key: A unique name you assign to a bucket. Bucket keys must be globally unique across all applications and regions. They must consist of only lower case characters, numbers 0-9, and underscores (_).
///
///**Note:** You cannot change a bucket key once the bucket is created.
        /// </summary>
        /// <value>
        ///Bucket key: A unique name you assign to a bucket. Bucket keys must be globally unique across all applications and regions. They must consist of only lower case characters, numbers 0-9, and underscores (_).
///
///**Note:** You cannot change a bucket key once the bucket is created.
        /// </value>
        [DataMember(Name="bucketKey", EmitDefaultValue=false)]
        public string BucketKey { get; set; }

        /// <summary>
        ///An array of objects, where each object represents an application that can access the bucket.
        /// </summary>
        /// <value>
        ///An array of objects, where each object represents an application that can access the bucket.
        /// </value>
        [DataMember(Name="allow", EmitDefaultValue=false)]
        public List<CreateBucketsPayloadAllow> Allow { get; set; }

        /// <summary>
        ///Gets or Sets PolicyKey
        /// </summary>
        [DataMember(Name="policyKey", EmitDefaultValue=true)]
        public PolicyKey PolicyKey { get; set; }

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
