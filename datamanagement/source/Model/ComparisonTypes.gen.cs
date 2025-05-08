/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Data Management
 *
 * The Data Management API provides a unified and consistent way to access data across BIM 360 Team, Fusion Team (formerly known as A360 Team), BIM 360 Docs, A360 Personal, and the Object Storage Service.  With this API, you can accomplish a number of workflows, including accessing a Fusion model in Fusion Team and getting an ordered structure of items, IDs, and properties for generating a bill of materials in a 3rd-party process. Or, you might want to superimpose a Fusion model and a building model to use in the Viewer.
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

namespace Autodesk.DataManagement.Model
{
    /// <summary>
    /// The type of the resource. Possible values are `-eq`, `-le`, `-lt`.
    /// </summary>
    ///<value>The type of the resource. Possible values are `-eq`, `-le`, `-lt`.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum ComparisonTypes
    {
        
        /// <summary>
        /// Enum LessThan for value: -lt
        /// </summary>
        [EnumMember(Value = "-lt")]
        LessThan,
        
        /// <summary>
        /// Enum LessThanOrEqualTo for value: -le
        /// </summary>
        [EnumMember(Value = "-le")]
        LessThanOrEqualTo,
        
        /// <summary>
        /// Enum EqualTo for value: -eq
        /// </summary>
        [EnumMember(Value = "-eq")]
        EqualTo,

        /// <summary>
        /// Enum GreaterThanEqualTo for value: -ge
        /// </summary>
        [EnumMember(Value = "-ge")]
        GreaterThanEqualTo,

        /// <summary>
        /// Enum GreaterThan for value: -gt
        /// </summary>
        [EnumMember(Value = "-gt")]
        GreaterThan,

        /// <summary>
        /// Enum StartsWith for value: -starts
        /// </summary>
        [EnumMember(Value = "-starts")]
        StartsWith,

        /// <summary>
        /// Enum EndsWith for value: -ends
        /// </summary>
        [EnumMember(Value = "-ends")]
        EndsWith,

        /// <summary>
        /// Enum Contains for value: -contains
        /// </summary>
        [EnumMember(Value = "-contains")]
        Contains,
    }

}
