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
    /// CreateBucketsPayloadAllow
    /// </summary>
    [DataContract]
    public partial class CreateBucketsPayloadAllow 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBucketsPayloadAllow" /> class.
        /// </summary>
        public CreateBucketsPayloadAllow()
        {
        }
        
        /// <summary>
        ///The Client ID of the application.
        /// </summary>
        /// <value>
        ///The Client ID of the application.
        /// </value>
        [DataMember(Name="authId", EmitDefaultValue=false)]
        public string AuthId { get; set; }

        /// <summary>
        ///Specifies the level of permission the application has. Required when `allow` is specified. Possible values are:
///
/// - `full` - Unrestricted access to objects within the bucket.
///- `read_only` - Read only access to the objects within the bucket. Modification or deletion of objects is not allowed.
        /// </summary>
        /// <value>
        ///Specifies the level of permission the application has. Required when `allow` is specified. Possible values are:
///
/// - `full` - Unrestricted access to objects within the bucket.
///- `read_only` - Read only access to the objects within the bucket. Modification or deletion of objects is not allowed.
        /// </value>
        [DataMember(Name="access", EmitDefaultValue=true)]
        public string Access { get; set; }

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
