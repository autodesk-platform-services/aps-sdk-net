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
    /// Contains links to resources related to this project.
    /// </summary>
    [DataContract]
    public partial class ProjectDataRelationships 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectDataRelationships" /> class.
        /// </summary>
        public ProjectDataRelationships()
        {
        }
        
        /// <summary>
        ///Gets or Sets Hub
        /// </summary>
        [DataMember(Name="hub", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksInternalResource Hub { get; set; }

        /// <summary>
        ///Gets or Sets RootFolder
        /// </summary>
        [DataMember(Name="rootFolder", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksRootFolder RootFolder { get; set; }

        /// <summary>
        ///Gets or Sets TopFolders
        /// </summary>
        [DataMember(Name="topFolders", EmitDefaultValue=false)]
        public ProjectDataRelationshipsTopFolders TopFolders { get; set; }

        /// <summary>
        ///Gets or Sets Issues
        /// </summary>
        [DataMember(Name="issues", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Issues { get; set; }

        /// <summary>
        ///Gets or Sets Submittals
        /// </summary>
        [DataMember(Name="submittals", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Submittals { get; set; }

        /// <summary>
        ///Gets or Sets Rfis
        /// </summary>
        [DataMember(Name="rfis", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Rfis { get; set; }

        /// <summary>
        ///Gets or Sets Markups
        /// </summary>
        [DataMember(Name="markups", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Markups { get; set; }

        /// <summary>
        ///Gets or Sets Checklists
        /// </summary>
        [DataMember(Name="checklists", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Checklists { get; set; }

        /// <summary>
        ///Gets or Sets Cost
        /// </summary>
        [DataMember(Name="cost", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Cost { get; set; }

        /// <summary>
        ///Gets or Sets Locations
        /// </summary>
        [DataMember(Name="locations", EmitDefaultValue=false)]
        public JsonApiRelationshipsLinksOnlyBim Locations { get; set; }

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
