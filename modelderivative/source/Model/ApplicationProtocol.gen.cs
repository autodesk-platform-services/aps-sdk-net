/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Model Derivative Service Documentation
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

namespace Autodesk.ModelDerivative.Model
{
    /// <summary>
    /// A STEP file can be generated with the following Application Protocols: &#x60;203&#x60; for configuration controlled design, &#x60;214&#x60; for core data for automotive mechanical design processes, &#x60;242&#x60; for managed model based 3D engineering. By default, &#x60;214&#x60; will be exported. 
    /// </summary>
    /// <value>A STEP file can be generated with the following Application Protocols: &#x60;203&#x60; for configuration controlled design, &#x60;214&#x60; for core data for automotive mechanical design processes, &#x60;242&#x60; for managed model based 3D engineering. By default, &#x60;214&#x60; will be exported. </value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum ApplicationProtocol
    {
        
        /// <summary>
        /// Enum _203 for value: 203
        /// </summary>
        [EnumMember(Value = "203")]
        _203,
        
        /// <summary>
        /// Enum _214 for value: 214
        /// </summary>
        [EnumMember(Value = "214")]
        _214,
        
        /// <summary>
        /// Enum _242 for value: 242
        /// </summary>
        [EnumMember(Value = "242")]
        _242
    }

}
