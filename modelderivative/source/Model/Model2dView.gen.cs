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
    /// The format that 2D views must be rendered to. Available options are:  - legacy - (Default) Render to a model derivative specific file format. - pdf - Render to the PDF file format. This option applies only to Revit 2022 files and newer.
    /// </summary>
    /// <value>The format that 2D views must be rendered to. Available options are:  - legacy - (Default) Render to a model derivative specific file format. - pdf - Render to the PDF file format. This option applies only to Revit 2022 files and newer.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Model2dView
    {
        
        /// <summary>
        /// Enum Legacy for value: legacy
        /// </summary>
        [EnumMember(Value = "legacy")]
        Legacy,
        
        /// <summary>
        /// Enum Pdf for value: pdf
        /// </summary>
        [EnumMember(Value = "pdf")]
        Pdf
    }

}
