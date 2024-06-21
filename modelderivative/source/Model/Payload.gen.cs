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
    /// Specifies the format for numeric values in the response body. Possible values:
    ///
    ///- `text` - (Default) Returns all properties requested in `fields` without applying any special formatting.
    ///- `unit` - Applies a filter and returns only the properties that contain numerical values. Additionally, it formats property values as `##&lt;VALUE_OF_PROPERTY&gt;&lt;UNIT_OF_VALUE&lt;&gt;PRECISION&gt;&lt;SYSTEM_UNIT&gt;`. For example `##94.172{mm}[3]{m}`, where `94.172` is the value of the property, `{mm}` is the unit of the value, `[3]` is the precision, and `{m}` is the metric base unit for the measurement.
    /// </summary>
    ///<value>Specifies the format for numeric values in the response body. Possible values:
    ///
    ///- `text` - (Default) Returns all properties requested in `fields` without applying any special formatting.
    ///- `unit` - Applies a filter and returns only the properties that contain numerical values. Additionally, it formats property values as `##&lt;VALUE_OF_PROPERTY&gt;&lt;UNIT_OF_VALUE&lt;&gt;PRECISION&lt;&gt;SYSTEM_UNIT&gt;`. For example `##94.172{mm}[3]{m}`, where `94.172` is the value of the property, `{mm}` is the unit of the value, `[3]` is the precision, and `{m}` is the metric base unit for the measurement.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Payload
    {

        /// <summary>
        /// Enum Text for value: text
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        /// Enum Unit for value: unit
        /// </summary>
        [EnumMember(Value = "unit")]
        Unit
    }

}
