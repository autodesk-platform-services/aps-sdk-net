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
    /// The data that describes what must be modified.
    /// </summary>
    [DataContract]
    public partial class ModifyFolderPayloadData 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyFolderPayloadData" /> class.
        /// </summary>
        public ModifyFolderPayloadData()
        {
        }
        
        /// <summary>
        ///Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=true)]
        public Type Type { get; set; }

        /// <summary>
        ///The URN of the folder.
///
///For information on how to find the URN, see the initial steps of the [Download a File](/en/docs/data/v2/tutorials/download-file/) tutorial.
///
///Note that this should NOT be URL-encoded.
        /// </summary>
        /// <value>
        ///The URN of the folder.
///
///For information on how to find the URN, see the initial steps of the [Download a File](/en/docs/data/v2/tutorials/download-file/) tutorial.
///
///Note that this should NOT be URL-encoded.
        /// </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        ///Gets or Sets Attributes
        /// </summary>
        [DataMember(Name="attributes", EmitDefaultValue=false)]
        public ModifyFolderPayloadDataAttributes Attributes { get; set; }

        /// <summary>
        ///Gets or Sets Relationships
        /// </summary>
        [DataMember(Name="relationships", EmitDefaultValue=false)]
        public ModifyFolderPayloadDataRelationships Relationships { get; set; }

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
