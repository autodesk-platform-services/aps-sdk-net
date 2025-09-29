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
    /// Properties of an item.
    /// </summary>
    [DataContract]
    public partial class ItemAttributes 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAttributes" /> class.
        /// </summary>
        public ItemAttributes()
        {
        }
        
        /// <summary>
        ///A human friendly name to identify the item. 
///Note that for BIM 360 projects, this attribute is reserved for future releases and should not be used. Use a version's `attributes.name` for the file name.
        /// </summary>
        /// <value>
        ///A human friendly name to identify the item. 
///Note that for BIM 360 projects, this attribute is reserved for future releases and should not be used. Use a version's `attributes.name` for the file name.
        /// </value>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        ///The time that the resource was created at.
        /// </summary>
        /// <value>
        ///The time that the resource was created at.
        /// </value>
        [DataMember(Name="createTime", EmitDefaultValue=false)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///The ID of the user that created the version.
        /// </summary>
        /// <value>
        ///The ID of the user that created the version.
        /// </value>
        [DataMember(Name="createUserId", EmitDefaultValue=false)]
        public string CreateUserId { get; set; }

        /// <summary>
        ///The user name of the user that created the version.
        /// </summary>
        /// <value>
        ///The user name of the user that created the version.
        /// </value>
        [DataMember(Name="createUserName", EmitDefaultValue=false)]
        public string CreateUserName { get; set; }

        /// <summary>
        ///The time that the version was last modified.
        /// </summary>
        /// <value>
        ///The time that the version was last modified.
        /// </value>
        [DataMember(Name="lastModifiedTime", EmitDefaultValue=false)]
        public DateTime LastModifiedTime { get; set; }

        /// <summary>
        ///The ID of the user that last modified the version.
        /// </summary>
        /// <value>
        ///The ID of the user that last modified the version.
        /// </value>
        [DataMember(Name="lastModifiedUserId", EmitDefaultValue=false)]
        public string LastModifiedUserId { get; set; }

        /// <summary>
        ///The user name of the user that last modified the version.
        /// </summary>
        /// <value>
        ///The user name of the user that last modified the version.
        /// </value>
        [DataMember(Name="lastModifiedUserName", EmitDefaultValue=false)]
        public string LastModifiedUserName { get; set; }

        /// <summary>
        ///`true`: The file has been deleted. 
///
///`false`: The file has not been deleted.
        /// </summary>
        /// <value>
        ///`true`: The file has been deleted. 
///
///`false`: The file has not been deleted.
        /// </value>
        [DataMember(Name="hidden", EmitDefaultValue=false)]
        public bool Hidden { get; set; }

        /// <summary>
        ///`true`: The file is locked.
///
///`false` The file is not locked. 
///
///**Note:** You can lock BIM 360 Project Files folder files and A360 files, but you cannot lock BIM 360 Plans Folder files.
        /// </summary>
        /// <value>
        ///`true`: The file is locked.
///
///`false` The file is not locked. 
///
///**Note:** You can lock BIM 360 Project Files folder files and A360 files, but you cannot lock BIM 360 Plans Folder files.
        /// </value>
        [DataMember(Name="reserved", EmitDefaultValue=false)]
        public bool Reserved { get; set; }

        /// <summary>
        ///The time the item was reserved in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </summary>
        /// <value>
        ///The time the item was reserved in the following format: `YYYY-MM-DDThh:mm:ss.sz`.
        /// </value>
        [DataMember(Name="reservedTime", EmitDefaultValue=false)]
        public DateTime ReservedTime { get; set; }

        /// <summary>
        ///The unique identifier of the user who reserved the item.
        /// </summary>
        /// <value>
        ///The unique identifier of the user who reserved the item.
        /// </value>
        [DataMember(Name="reservedUserId", EmitDefaultValue=false)]
        public string ReservedUserId { get; set; }

        /// <summary>
        ///The name of the user who reserved the item.
        /// </summary>
        /// <value>
        ///The name of the user who reserved the item.
        /// </value>
        [DataMember(Name="reservedUserName", EmitDefaultValue=false)]
        public string ReservedUserName { get; set; }

        /// <summary>
        ///Gets or Sets Extension
        /// </summary>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public ItemExtensionWithSchemaLink Extension { get; set; }

        /// <summary>
        /// The relative path of the item starting from project’s root folder.
        /// </summary>
        /// <value>
        /// The relative path of the item starting from project’s root folder.
        /// </value>
        [DataMember(Name="pathInProject", EmitDefaultValue=false)]
        public string PathInProject { get; set; }

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
