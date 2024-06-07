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
    /// Specifies what version of the Revit translator/extractor to use. Applicable only when the source design is of type RVT. Possible values are:
    ///
    ///- `next` - Makes the translation job use the newest available version of the translator/extractor. This option is meant to be used by beta testers who wish to test a pre-release version of the translator. If no pre-release version is available, the system uses the current official release version.
    ///- `previous` - Makes the translation job use the previous official release version of the translator/extractor. This option is meant to be used as a workaround in case of regressions caused by a new official release of the translator/extractor. If this attribute is not specified, the system uses the current official release version.
    /// </summary>
    ///<value>Specifies what version of the Revit translator/extractor to use. Applicable only when the source design is of type RVT. Possible values are:
    ///
    ///- `next` - Makes the translation job use the newest available version of the translator/extractor. This option is meant to be used by beta testers who wish to test a pre-release version of the translator. If no pre-release version is available, the system uses the current official release version.
    ///- `previous` - Makes the translation job use the previous official release version of the translator/extractor. This option is meant to be used as a workaround in case of regressions caused by a new official release of the translator/extractor. If this attribute is not specified, the system uses the current official release version.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum ExtractorVersion
    {

        /// <summary>
        /// Enum Next for value: next
        /// </summary>
        [EnumMember(Value = "next")]
        Next,

        /// <summary>
        /// Enum Previous for value: previous
        /// </summary>
        [EnumMember(Value = "previous")]
        Previous
    }

}
