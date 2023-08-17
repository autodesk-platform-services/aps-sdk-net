/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative API
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
    /// The requested output types. Possible values include `svf`, `svf2`, `thumbnail`, `stl`, `step`, `iges`, `obj`, `ifc` or `dwg`. For a list of supported types, call the [GET formats](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/formats-GET) endpoint.
    /// </summary>
    /// <value>The requested output types. Possible values include `svf`, `svf2`, `thumbnail`, `stl`, `step`, `iges`, `obj`, `ifc` or `dwg`. For a list of supported types, call the [GET formats](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/formats-GET) endpoint.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type
    {

        /// <summary>
        /// Enum Svf for "svf"
        /// </summary>
        [EnumMember(Value = "svf")]
        Svf,

        /// <summary>
        /// Enum Svf2 for "svf2"
        /// </summary>
        [EnumMember(Value = "svf2")]
        Svf2,

        /// <summary>
        /// Enum Thumbnail for "thumbnail"
        /// </summary>
        [EnumMember(Value = "thumbnail")]
        Thumbnail,

        /// <summary>
        /// Enum Stl for "stl"
        /// </summary>
        [EnumMember(Value = "stl")]
        Stl,

        /// <summary>
        /// Enum Step for "step"
        /// </summary>
        [EnumMember(Value = "step")]
        Step,

        /// <summary>
        /// Enum Iges for "iges"
        /// </summary>
        [EnumMember(Value = "iges")]
        Iges,

        /// <summary>
        /// Enum Obj for "obj"
        /// </summary>
        [EnumMember(Value = "obj")]
        Obj,

        /// <summary>
        /// Enum Ifc for "ifc"
        /// </summary>
        [EnumMember(Value = "ifc")]
        Ifc,

        /// <summary>
        /// Enum Dwg for "dwg"
        /// </summary>
        [EnumMember(Value = "dwg")]
        Dwg,

        /// <summary>
        /// Enum Dwg for "fbx"
        /// </summary>
        [EnumMember(Value = "fbx")]
        Fbx
    }

}
