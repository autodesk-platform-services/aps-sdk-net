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
    /// Specifies what IFC loader to use during translation. Applicable only when the source design is of type IFC. Possible values are:
    ///
    ///- `legacy` - Use the Navisworks IFC loader.
    ///- `modern` - Use the Revit IFC loader (recommended over the legacy option).
    ///- `v3` - Use the newer Revit IFC loader (recommended over the modern option).
    /// </summary>
    ///<value>Specifies what IFC loader to use during translation. Applicable only when the source design is of type IFC. Possible values are:
    ///
    ///- `legacy` - Use the Navisworks IFC loader.
    ///- `modern` - Use the Revit IFC loader (recommended over the legacy option).
    ///- `v3` - Use the newer Revit IFC loader (recommended over the modern option).</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum ConversionMethod
    {

        /// <summary>
        /// Enum Legacy for value: legacy
        /// </summary>
        [EnumMember(Value = "legacy")]
        Legacy,

        /// <summary>
        /// Enum Modern for value: modern
        /// </summary>
        [EnumMember(Value = "modern")]
        Modern,

        /// <summary>
        /// Enum V3 for value: v3
        /// </summary>
        [EnumMember(Value = "v3")]
        V3
    }

}
