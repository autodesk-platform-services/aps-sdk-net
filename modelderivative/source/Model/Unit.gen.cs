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
    /// The units the models must be translated to, when the output type is OBJ. For example, from millimeters (10, 123, 31) to centimeters (1.0, 12.3, 3.1). If the source unit or the unit you are translating to is not supported, the values remain unchanged.
    ///Possible values are: 
    ///
    ///- `meter`
    ///- `decimeter`
    ///- `centimeter`
    ///- `millimeter`
    ///- `micrometer`
    ///- `nanometer`
    ///- `yard`
    ///- `foot`
    ///- `inch`
    ///- `mil`
    ///- `microinch`
    ///
    ///**Note:** Not supported when the source design is F3D.
    /// </summary>
    ///<value>The units the models must be translated to, when the output type is OBJ. For example, from millimeters (10, 123, 31) to centimeters (1.0, 12.3, 3.1). If the source unit or the unit you are translating to is not supported, the values remain unchanged.
    ///Possible values are: 
    ///
    ///- `meter`
    ///- `decimeter`
    ///- `centimeter`
    ///- `millimeter`
    ///- `micrometer`
    ///- `nanometer`
    ///- `yard`
    ///- `foot`
    ///- `inch`
    ///- `mil`
    ///- `microinch`
    ///
    ///**Note:** Not supported when the source design is F3D.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Unit
    {

        /// <summary>
        /// Enum Meter for value: meter
        /// </summary>
        [EnumMember(Value = "meter")]
        Meter,

        /// <summary>
        /// Enum Decimeter for value: decimeter
        /// </summary>
        [EnumMember(Value = "decimeter")]
        Decimeter,

        /// <summary>
        /// Enum Centimeter for value: centimeter
        /// </summary>
        [EnumMember(Value = "centimeter")]
        Centimeter,

        /// <summary>
        /// Enum Millimeter for value: millimeter
        /// </summary>
        [EnumMember(Value = "millimeter")]
        Millimeter,

        /// <summary>
        /// Enum Micrometer for value: micrometer
        /// </summary>
        [EnumMember(Value = "micrometer")]
        Micrometer,

        /// <summary>
        /// Enum Nanometer for value: nanometer
        /// </summary>
        [EnumMember(Value = "nanometer")]
        Nanometer,

        /// <summary>
        /// Enum Yard for value: yard
        /// </summary>
        [EnumMember(Value = "yard")]
        Yard,

        /// <summary>
        /// Enum Foot for value: foot
        /// </summary>
        [EnumMember(Value = "foot")]
        Foot,

        /// <summary>
        /// Enum Inch for value: inch
        /// </summary>
        [EnumMember(Value = "inch")]
        Inch,

        /// <summary>
        /// Enum Mil for value: mil
        /// </summary>
        [EnumMember(Value = "mil")]
        Mil,

        /// <summary>
        /// Enum Microinch for value: microinch
        /// </summary>
        [EnumMember(Value = "microinch")]
        Microinch
    }

}
