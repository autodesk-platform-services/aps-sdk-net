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
    /// Specifies how the hierarchy of items are determined. Classic: (Default) Uses hardcoded rules to set the hierarchy of items. SystemPath: Uses a linked XML or MDB2 properties file to set hierarchy of items. You can use this option to make the organization of items consistent with SmartPlant 3D.  Notes:   1. The functioning of the SystemPath depends on the default setting of the property SP3D_SystemPath or System Path.   2. The pathing delimiter must be \\.   3. If you want to customize further, import the VUE file to Navisworks. After that, use POST job on the resulting Navisworks (nwc/nwd) file.
    /// </summary>
    /// <value>Specifies how the hierarchy of items are determined. Classic: (Default) Uses hardcoded rules to set the hierarchy of items. SystemPath: Uses a linked XML or MDB2 properties file to set hierarchy of items. You can use this option to make the organization of items consistent with SmartPlant 3D.  Notes:   1. The functioning of the SystemPath depends on the default setting of the property SP3D_SystemPath or System Path.   2. The pathing delimiter must be \\.   3. If you want to customize further, import the VUE file to Navisworks. After that, use POST job on the resulting Navisworks (nwc/nwd) file.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Hierarchy
    {
        
        /// <summary>
        /// Enum Classic for value: Classic
        /// </summary>
        [EnumMember(Value = "Classic")]
        Classic,
        
        /// <summary>
        /// Enum SystemPath for value: SystemPath
        /// </summary>
        [EnumMember(Value = "SystemPath")]
        SystemPath
    }

}
