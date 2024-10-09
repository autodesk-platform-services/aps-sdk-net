/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// The properties of a folder.
    /// </summary>
    [DataContract]
    public partial class FolderAttributesWithExtensions 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderAttributesWithExtensions" /> class.
        /// </summary>
        public FolderAttributesWithExtensions()
        {
        }
        
        /// <summary>
        ///The name of the folder.
        /// </summary>
        /// <value>
        ///The name of the folder.
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///Reserved for future Use. Do not use. Use `attributes.name` for the folder name.
        /// </summary>
        /// <value>
        ///Reserved for future Use. Do not use. Use `attributes.name` for the folder name.
        /// </value>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        ///The number of objects inside the folder.
        /// </summary>
        /// <value>
        ///The number of objects inside the folder.
        /// </value>
        [DataMember(Name="objectCount", EmitDefaultValue=false)]
        public decimal ObjectCount { get; set; }

        /// <summary>
        ///The time the folder was created, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </summary>
        /// <value>
        ///The time the folder was created, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </value>
        [DataMember(Name="createTime", EmitDefaultValue=false)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///The unique identifier of the user who created the folder.
        /// </summary>
        /// <value>
        ///The unique identifier of the user who created the folder.
        /// </value>
        [DataMember(Name="createUserId", EmitDefaultValue=false)]
        public string CreateUserId { get; set; }

        /// <summary>
        ///The name of the user who created the folder.
        /// </summary>
        /// <value>
        ///The name of the user who created the folder.
        /// </value>
        [DataMember(Name="createUserName", EmitDefaultValue=false)]
        public string CreateUserName { get; set; }

        /// <summary>
        ///The last time the folder was modified, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </summary>
        /// <value>
        ///The last time the folder was modified, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </value>
        [DataMember(Name="lastModifiedTime", EmitDefaultValue=false)]
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        ///The last time the folder was modified, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </summary>
        /// <value>
        ///The last time the folder was modified, in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </value>
        [DataMember(Name="lastModifiedUserId", EmitDefaultValue=false)]
        public string LastModifiedUserId { get; set; }

        /// <summary>
        ///The name of the user who last modified the folder.
        /// </summary>
        /// <value>
        ///The name of the user who last modified the folder.
        /// </value>
        [DataMember(Name="lastModifiedUserName", EmitDefaultValue=false)]
        public string LastModifiedUserName { get; set; }

        /// <summary>
        ///The date and time the folder or any of its children were last updated.
        /// </summary>
        /// <value>
        ///The date and time the folder or any of its children were last updated.
        /// </value>
        [DataMember(Name="lastModifiedTimeRollup", EmitDefaultValue=false)]
        public string LastModifiedTimeRollup { get; set; }

        /// <summary>
        ///The folder’s current visibility state.
        /// </summary>
        /// <value>
        ///The folder’s current visibility state.
        /// </value>
        [DataMember(Name="hidden", EmitDefaultValue=false)]
        public bool Hidden { get; set; }

        /// <summary>
        ///Gets or Sets Extensions
        /// </summary>
        [DataMember(Name="extensions", EmitDefaultValue=false)]
        public FolderExtensionWithSchemaLink Extensions { get; set; }

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
