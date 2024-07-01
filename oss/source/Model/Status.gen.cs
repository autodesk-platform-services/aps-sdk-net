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
    /// Indicates whether this particular part uploaded to S3 is valid. Possible values are:
///
///- `Pending` - No such part was uploaded to S3 for this index. 
///- `Unexpected` - The eTag of the part in S3 does not match the one provided in the request. 
///- `TooSmall` - A chunk uploaded to S3 is smaller than 5MB. Only the final chunk can be smaller than 5MB. 
///- `Unexpected+TooSmall` - The chunk is both too small and has an eTag mismatch. 
///- `Ok` - The chunk has no issues.'
    /// </summary>
    ///<value>Indicates whether this particular part uploaded to S3 is valid. Possible values are:
///
///- `Pending` - No such part was uploaded to S3 for this index. 
///- `Unexpected` - The eTag of the part in S3 does not match the one provided in the request. 
///- `TooSmall` - A chunk uploaded to S3 is smaller than 5MB. Only the final chunk can be smaller than 5MB. 
///- `Unexpected+TooSmall` - The chunk is both too small and has an eTag mismatch. 
///- `Ok` - The chunk has no issues.'</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Status
    {
        
        /// <summary>
        /// Enum Pending for value: Pending
        /// </summary>
        [EnumMember(Value = "Pending")]
        Pending,
        
        /// <summary>
        /// Enum Unexpected for value: Unexpected
        /// </summary>
        [EnumMember(Value = "Unexpected")]
        Unexpected,
        
        /// <summary>
        /// Enum TooSmall for value: TooSmall
        /// </summary>
        [EnumMember(Value = "TooSmall")]
        TooSmall,
        
        /// <summary>
        /// Enum UnexpectedTooSmall for value: Unexpected+TooSmall
        /// </summary>
        [EnumMember(Value = "Unexpected+TooSmall")]
        UnexpectedTooSmall,
        
        /// <summary>
        /// Enum Ok for value: Ok
        /// </summary>
        [EnumMember(Value = "Ok")]
        Ok
    }

}
