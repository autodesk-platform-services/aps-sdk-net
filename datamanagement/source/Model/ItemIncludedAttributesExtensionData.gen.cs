/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// ItemIncludedAttributesExtensionData
    /// </summary>
    [DataContract]
    public partial class ItemIncludedAttributesExtensionData 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemIncludedAttributesExtensionData" /> class.
        /// </summary>
        public ItemIncludedAttributesExtensionData()
        {
        }
        
        /// <summary>
        /// Gets or Sets ModelVersion
        /// </summary>
        [DataMember(Name="modelVersion", EmitDefaultValue=false)]
        public decimal? ModelVersion { get; set; }

        /// <summary>
        /// Gets or Sets ProjectGuid
        /// </summary>
        [DataMember(Name="projectGuid", EmitDefaultValue=false)]
        public string ProjectGuid { get; set; }

        /// <summary>
        /// Gets or Sets OriginalItemUrn
        /// </summary>
        [DataMember(Name="originalItemUrn", EmitDefaultValue=false)]
        public string OriginalItemUrn { get; set; }

        /// <summary>
        /// Gets or Sets IsCompositeDesign
        /// </summary>
        [DataMember(Name="isCompositeDesign", EmitDefaultValue=false)]
        public bool? IsCompositeDesign { get; set; }

        /// <summary>
        /// Gets or Sets ModelType
        /// </summary>
        [DataMember(Name="modelType", EmitDefaultValue=false)]
        public string ModelType { get; set; }

        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [DataMember(Name="mimeType", EmitDefaultValue=false)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets ModelGuid
        /// </summary>
        [DataMember(Name="modelGuid", EmitDefaultValue=false)]
        public string ModelGuid { get; set; }

        /// <summary>
        /// Gets or Sets ProcessState
        /// </summary>
        [DataMember(Name="processState", EmitDefaultValue=false)]
        public string ProcessState { get; set; }

        /// <summary>
        /// Gets or Sets ExtractionState
        /// </summary>
        [DataMember(Name="extractionState", EmitDefaultValue=false)]
        public string ExtractionState { get; set; }

        /// <summary>
        /// Gets or Sets SplittingState
        /// </summary>
        [DataMember(Name="splittingState", EmitDefaultValue=false)]
        public string SplittingState { get; set; }

        /// <summary>
        /// Gets or Sets ReviewState
        /// </summary>
        [DataMember(Name="reviewState", EmitDefaultValue=false)]
        public string ReviewState { get; set; }

        /// <summary>
        /// Gets or Sets RevisionDisplayLabel
        /// </summary>
        [DataMember(Name="revisionDisplayLabel", EmitDefaultValue=false)]
        public string RevisionDisplayLabel { get; set; }

        /// <summary>
        /// Gets or Sets SourceFileName
        /// </summary>
        [DataMember(Name="sourceFileName", EmitDefaultValue=false)]
        public string SourceFileName { get; set; }

        /// <summary>
        /// Gets or Sets ConformingStatus
        /// </summary>
        [DataMember(Name="conformingStatus", EmitDefaultValue=false)]
        public string ConformingStatus { get; set; }

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
