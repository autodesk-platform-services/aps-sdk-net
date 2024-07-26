/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Issues
 *
 * An issue is an item that is created in ACC for tracking, managing and communicating tasks, problems and other points of concern through to resolution. You can manage different types of issues, such as design, safety, and commissioning. We currently support issues that are associated with a project.
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

namespace Autodesk.Construction.Issues.Model
{
    /// <summary>
    /// Retrieves issue custom attribute definitions with the specified data type
    /// </summary>
    ///<value>Retrieves issue custom attribute definitions with the specified data type</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum DataType
    {

        /// <summary>
        /// Enum List for value: list
        /// </summary>
        [EnumMember(Value = "list")]
        List,

        /// <summary>
        /// Enum Text for value:  text
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        /// Enum Paragraph for value:  paragraph
        /// </summary>
        [EnumMember(Value = "paragraph")]
        Paragraph,

        /// <summary>
        /// Enum Numeric for value:  numeric
        /// </summary>
        [EnumMember(Value = "numeric")]
        Numeric
    }

}
