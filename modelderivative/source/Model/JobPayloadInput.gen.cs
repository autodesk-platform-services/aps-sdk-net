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
        /// An object describing the attributes of the source design.
        /// </summary>
        [DataContract]
        public partial class JobPayloadInput
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="JobPayloadInput" /> class.
                /// </summary>
                public JobPayloadInput()
                {
                }

                /// <summary>
                ///The URL safe Base64 encoded URN of the source design. 
                ///
                ///**Note:** The URN is returned as the [objectID` once you complete uploading the source design to APS. This value must be converted to a `Base64 (URL Safe) encoded](http://www.freeformatter.com/base64-encoder.html) string before you can specify it for this attribute.
                /// </summary>
                /// <value>
                ///The URL safe Base64 encoded URN of the source design. 
                ///
                ///**Note:** The URN is returned as the [objectID` once you complete uploading the source design to APS. This value must be converted to a `Base64 (URL Safe) encoded](http://www.freeformatter.com/base64-encoder.html) string before you can specify it for this attribute.
                /// </value>
                [DataMember(Name = "urn", EmitDefaultValue = false)]
                public string Urn { get; set; }

                /// <summary>
                ///- `true`: The source design is compressed as a zip file. If set to `true`, you need to define the `rootFilename`.'
                ///- `false`: (Default) The source design is not compressed.
                /// </summary>
                /// <value>
                ///- `true`: The source design is compressed as a zip file. If set to `true`, you need to define the `rootFilename`.'
                ///- `false`: (Default) The source design is not compressed.
                /// </value>
                [DataMember(Name = "compressedUrn", EmitDefaultValue = false)]
                public bool? CompressedUrn { get; set; }

                /// <summary>
                ///The file name of the top-level component of the source design.  Mandatory if  `compressedUrn` is set to `true`.
                /// </summary>
                /// <value>
                ///The file name of the top-level component of the source design.  Mandatory if  `compressedUrn` is set to `true`.
                /// </value>
                [DataMember(Name = "rootFilename", EmitDefaultValue = false)]
                public string RootFilename { get; set; }

                /// <summary>
                ///- `true` - Instructs the system to check for references, and if any exist, download all referenced files. Setting this parameter to `true` is mandatory when translating source designs consisting of multiple files. For example, Autodesk Inventor assemblies.
                ///- `false` - (Default) Instructs the system not to check for references.
                /// </summary>
                /// <value>
                ///- `true` - Instructs the system to check for references, and if any exist, download all referenced files. Setting this parameter to `true` is mandatory when translating source designs consisting of multiple files. For example, Autodesk Inventor assemblies.
                ///- `false` - (Default) Instructs the system not to check for references.
                /// </value>
                [DataMember(Name = "checkReferences", EmitDefaultValue = false)]
                public bool? CheckReferences { get; set; }

                /// <summary>
                /// Returns the string presentation of the object
                /// </summary>
                /// <returns>String presentation of the object</returns>
                public override string ToString()
                {
                        return JsonConvert.SerializeObject(this, Formatting.Indented);
                }
        }

}
