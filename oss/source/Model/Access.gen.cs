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
    /// Access for signed resource Possible values: read, write, readwrite Default value: read
    /// </summary>
    ///<value>Access for signed resource Possible values: read, write, readwrite Default value: read</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Access
    {
        
        /// <summary>
        /// Enum Read for value: Read
        /// </summary>
        [EnumMember(Value = "Read")]
        Read,
        
        /// <summary>
        /// Enum Write for value: Write
        /// </summary>
        [EnumMember(Value = "Write")]
        Write,
        
        /// <summary>
        /// Enum ReadWrite for value: ReadWrite
        /// </summary>
        [EnumMember(Value = "ReadWrite")]
        ReadWrite
    }

}
