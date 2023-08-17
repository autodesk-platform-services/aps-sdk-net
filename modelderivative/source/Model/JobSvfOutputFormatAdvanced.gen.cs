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
    /// JobSvfOutputFormatAdvanced
    /// </summary>
    [DataContract]
    public partial class JobSvfOutputFormatAdvanced 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobSvfOutputFormatAdvanced" /> class.
        /// </summary>
        public JobSvfOutputFormatAdvanced()
        {
        }
        
        /// <summary>
        /// An array containing user data linkage IDs of the linkage data to be extracted from the DGN file. Linkage data is not extracted if you do not specify this attribute.
        /// </summary>
        /// <value>An array containing user data linkage IDs of the linkage data to be extracted from the DGN file. Linkage data is not extracted if you do not specify this attribute.</value>
        [DataMember(Name="requestedLinkageIDs", EmitDefaultValue=false)]
        public List<int?> RequestedLinkageIDs { get; set; }

        /// <summary>
        /// Gets or Sets Views2D
        /// </summary>
        [DataMember(Name="2dviews", EmitDefaultValue=false)]
        public Model2dView Views2D { get; set; }

        /// <summary>
        /// Gets or Sets ConversionMethod
        /// </summary>
        [DataMember(Name="conversionMethod", EmitDefaultValue=false)]
        public ConversionMethod ConversionMethod { get; set; }

        /// <summary>
        /// Gets or Sets BuildingStoreys
        /// </summary>
        [DataMember(Name="buildingStoreys", EmitDefaultValue=false)]
        public BuildingStoreys BuildingStoreys { get; set; }

        /// <summary>
        /// Gets or Sets Spaces
        /// </summary>
        [DataMember(Name="spaces", EmitDefaultValue=false)]
        public Spaces Spaces { get; set; }

        /// <summary>
        /// Gets or Sets OpeningElements
        /// </summary>
        [DataMember(Name="openingElements", EmitDefaultValue=false)]
        public OpeningElements OpeningElements { get; set; }

        /// <summary>
        /// Specifies whether hidden objects must be extracted or not. true: Extract hidden objects from the input file. false: (Default) Do not extract hidden objects from the input file. 
        /// </summary>
        /// <value>Specifies whether hidden objects must be extracted or not. true: Extract hidden objects from the input file. false: (Default) Do not extract hidden objects from the input file. </value>
        [DataMember(Name="hiddenObjects", EmitDefaultValue=false)]
        public bool? HiddenObjects { get; set; }

        /// <summary>
        /// Specifies whether basic material properties must be extracted or not. true: Extract properties for basic materials. false: (Default) Do not extract properties for basic materials. 
        /// </summary>
        /// <value>Specifies whether basic material properties must be extracted or not. true: Extract properties for basic materials. false: (Default) Do not extract properties for basic materials. </value>
        [DataMember(Name="basicMaterialProperties", EmitDefaultValue=false)]
        public bool? BasicMaterialProperties { get; set; }

        /// <summary>
        /// Specifies how to handle Autodesk material properties. true: Extract properties for Autodesk materials. false: (Default) Do not extract properties for Autodesk materials.
        /// </summary>
        /// <value>Specifies how to handle Autodesk material properties. true: Extract properties for Autodesk materials. false: (Default) Do not extract properties for Autodesk materials.</value>
        [DataMember(Name="autodeskMaterialProperties", EmitDefaultValue=false)]
        public bool? AutodeskMaterialProperties { get; set; }

        /// <summary>
        /// Specifies whether timeliner properties must be extracted or not. true: Extract timeliner properties. false: (Default) Do not extract timeliner properties.
        /// </summary>
        /// <value>Specifies whether timeliner properties must be extracted or not. true: Extract timeliner properties. false: (Default) Do not extract timeliner properties.</value>
        [DataMember(Name="timelinerProperties", EmitDefaultValue=false)]
        public bool? TimelinerProperties { get; set; }

        /// <summary>
        /// Gets or Sets ExtractorVersion
        /// </summary>
        [DataMember(Name="extractorVersion", EmitDefaultValue=false)]
        public ExtractorVersion ExtractorVersion { get; set; }

        /// <summary>
        /// Generates master views when translating from the Revit input format to SVF. This option is ignored for all other input formats. This attribute defaults to false.  Master views are 3D views that are generated for each phase of the Revit model. A master view contains all elements (including “room” elements) present in the host model for that phase. The display name of a master view defaults to the name of the phase it is generated from. However, if a view with that name already exists, the Model Derivative service appends a suffix to the default display name.  Notes: 1. Master views do not contain elements from linked models. 2. Enabling this option can increase the time it takes to translate the model.
        /// </summary>
        /// <value>Generates master views when translating from the Revit input format to SVF. This option is ignored for all other input formats. This attribute defaults to false.  Master views are 3D views that are generated for each phase of the Revit model. A master view contains all elements (including “room” elements) present in the host model for that phase. The display name of a master view defaults to the name of the phase it is generated from. However, if a view with that name already exists, the Model Derivative service appends a suffix to the default display name.  Notes: 1. Master views do not contain elements from linked models. 2. Enabling this option can increase the time it takes to translate the model.</value>
        [DataMember(Name="generateMasterViews", EmitDefaultValue=false)]
        public bool? GenerateMasterViews { get; set; }

        /// <summary>
        /// Gets or Sets MaterialMode
        /// </summary>
        [DataMember(Name="materialMode", EmitDefaultValue=false)]
        public MaterialMode MaterialMode { get; set; }

        /// <summary>
        /// Gets or Sets Hierarchy
        /// </summary>
        [DataMember(Name="hierarchy", EmitDefaultValue=false)]
        public Hierarchy Hierarchy { get; set; }

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
