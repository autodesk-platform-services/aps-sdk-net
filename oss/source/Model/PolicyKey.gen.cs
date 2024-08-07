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
    /// Specifies the retention policy for the objects stored in the bucket. Possible values are: 
///            
///- `transient` - Objects are retained for 24 hours.
///- `temporary` - Objects are retained for 30 days.
///- `persistent` - Objects are retained until they are deleted.
    /// </summary>
    ///<value>Specifies the retention policy for the objects stored in the bucket. Possible values are: 
///            
///- `transient` - Objects are retained for 24 hours.
///- `temporary` - Objects are retained for 30 days.
///- `persistent` - Objects are retained until they are deleted.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum PolicyKey
    {
        
        /// <summary>
        /// Enum Transient for value: transient
        /// </summary>
        [EnumMember(Value = "transient")]
        Transient,
        
        /// <summary>
        /// Enum Temporary for value: temporary
        /// </summary>
        [EnumMember(Value = "temporary")]
        Temporary,
        
        /// <summary>
        /// Enum Persistent for value: persistent
        /// </summary>
        [EnumMember(Value = "persistent")]
        Persistent
    }

}
