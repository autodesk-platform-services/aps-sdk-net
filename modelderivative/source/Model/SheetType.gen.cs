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
    /// The sheet body type to export as, when the output is IGES.  Possible values are:
    ///
    ///- `open`
    ///-  `shell` 
    ///- `surface` - (Default)
    ///- `wireframe`
    /// </summary>
    ///<value>The sheet body type to export as, when the output is IGES.  Possible values are:
    ///
    ///- `open`
    ///-  `shell` 
    ///- `surface` - (Default)
    ///- `wireframe`</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum SheetType
    {

        /// <summary>
        /// Enum Open for value: open
        /// </summary>
        [EnumMember(Value = "open")]
        Open,

        /// <summary>
        /// Enum Surface for value: surface
        /// </summary>
        [EnumMember(Value = "surface")]
        Surface,

        /// <summary>
        /// Enum Shell for value: shell
        /// </summary>
        [EnumMember(Value = "shell")]
        Shell,

        /// <summary>
        /// Enum Wireframe for value: wireframe
        /// </summary>
        [EnumMember(Value = "wireframe")]
        Wireframe
    }

}
