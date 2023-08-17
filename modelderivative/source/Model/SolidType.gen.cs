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
    /// Export the solid body to IGES &#x60;solid&#x60;, &#x60;surface&#x60; or &#x60;wireframe&#x60;. By default, it is set to &#x60;solid&#x60;.
    /// </summary>
    /// <value>Export the solid body to IGES &#x60;solid&#x60;, &#x60;surface&#x60; or &#x60;wireframe&#x60;. By default, it is set to &#x60;solid&#x60;.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum SolidType
    {
        
        /// <summary>
        /// Enum Solid for value: solid
        /// </summary>
        [EnumMember(Value = "solid")]
        Solid,
        
        /// <summary>
        /// Enum Surface for value: surface
        /// </summary>
        [EnumMember(Value = "surface")]
        Surface,
        
        /// <summary>
        /// Enum Wireframe for value: wireframe
        /// </summary>
        [EnumMember(Value = "wireframe")]
        Wireframe
    }

}
