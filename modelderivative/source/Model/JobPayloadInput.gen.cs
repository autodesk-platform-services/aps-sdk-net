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
    /// Group of inputs
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
        /// The design URN; returned when uploading the file to APS The URN needs to be [Base64 (URL Safe) encoded](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/job-POST/#id3). 
        /// </summary>
        /// <value>The design URN; returned when uploading the file to APS The URN needs to be [Base64 (URL Safe) encoded](https://developer.autodesk.com/en/docs/model-derivative/v2/reference/http/job-POST/#id3). </value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        /// Set this to &#x60;true&#x60; if the source file is compressed. If set to &#x60;true&#x60;, you need to define the &#x60;rootFilename&#x60;.
        /// </summary>
        /// <value>Set this to &#x60;true&#x60; if the source file is compressed. If set to &#x60;true&#x60;, you need to define the &#x60;rootFilename&#x60;.</value>
        [DataMember(Name="compressedUrn", EmitDefaultValue=false)]
        public bool? CompressedUrn { get; set; }

        /// <summary>
        /// The root filename of the compressed file. Mandatory if the &#x60;compressedUrn&#x60; is set to &#x60;true&#x60;.
        /// </summary>
        /// <value>The root filename of the compressed file. Mandatory if the &#x60;compressedUrn&#x60; is set to &#x60;true&#x60;.</value>
        [DataMember(Name="rootFilename", EmitDefaultValue=false)]
        public string RootFilename { get; set; }

        /// <summary>
        /// - true - Instructs the server to check for references and download all referenced files. If the design consists of multiple files (as with Autodesk Inventor assemblies) the translation fails if this attribute is not set to true. - false - (Default) Does not check for any references.
        /// </summary>
        /// <value>- true - Instructs the server to check for references and download all referenced files. If the design consists of multiple files (as with Autodesk Inventor assemblies) the translation fails if this attribute is not set to true. - false - (Default) Does not check for any references.</value>
        [DataMember(Name="checkReferences", EmitDefaultValue=false)]
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
