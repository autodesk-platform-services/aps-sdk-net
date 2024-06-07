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
    /// Type of Model View.
    ///Possible values are: `2d`, `3d`.
    /// </summary>
    ///<value>Type of Model View.
    ///Possible values are: `2d`, `3d`.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Role
    {

        /// <summary>
        /// Enum _2d for value: 2d
        /// </summary>
        [EnumMember(Value = "2d")]
        _2d,

        /// <summary>
        /// Enum _3d for value: 3d
        /// </summary>
        [EnumMember(Value = "3d")]
        _3d
    }

}
