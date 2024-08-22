/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Use the Model Derivative API to translate designs from one CAD format to another. You can also use this API to extract metadata from a model.
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
    /// Specifies how storeys are translated. Applicable only when the source design is of type IFC. Possible values are:
///
///- `hide` - (Default) Storeys are translated but not visible by default.
///- `show` - Storeys are translated and are visible by default.
///- `skip` - Storeys are not translated.
///
///**Note:** These options are applicable only when `conversionMethod` is set to `modern` or `v3`.
    /// </summary>
    ///<value>Specifies how storeys are translated. Applicable only when the source design is of type IFC. Possible values are:
///
///- `hide` - (Default) Storeys are translated but not visible by default.
///- `show` - Storeys are translated and are visible by default.
///- `skip` - Storeys are not translated.
///
///**Note:** These options are applicable only when `conversionMethod` is set to `modern` or `v3`.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum BuildingStoreys
    {
        
        /// <summary>
        /// Enum Hide for value: hide
        /// </summary>
        [EnumMember(Value = "hide")]
        Hide,
        
        /// <summary>
        /// Enum Show for value: show
        /// </summary>
        [EnumMember(Value = "show")]
        Show,
        
        /// <summary>
        /// Enum Skip for value: skip
        /// </summary>
        [EnumMember(Value = "skip")]
        Skip
    }

}
