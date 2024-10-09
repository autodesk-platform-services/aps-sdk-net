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
    /// The properties of a version.
    /// </summary>
    [DataContract]
    public partial class VersionAttributes 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionAttributes" /> class.
        /// </summary>
        public VersionAttributes()
        {
        }
        
        /// <summary>
        ///The file name to be used when synced to local disk.
        /// </summary>
        /// <value>
        ///The file name to be used when synced to local disk.
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///A human friendly name to identify the version. Note that for BIM 360 projects, this field is reserved for future releases and should not be used. Use a version's `attributes.name` for the file name.
        /// </summary>
        /// <value>
        ///A human friendly name to identify the version. Note that for BIM 360 projects, this field is reserved for future releases and should not be used. Use a version's `attributes.name` for the file name.
        /// </value>
        [DataMember(Name="displayName", EmitDefaultValue=false)]
        public string DisplayName { get; set; }

        /// <summary>
        ///The MIME type of the content of the version.
        /// </summary>
        /// <value>
        ///The MIME type of the content of the version.
        /// </value>
        [DataMember(Name="mimeType", EmitDefaultValue=false)]
        public string MimeType { get; set; }

        /// <summary>
        ///Version number of this versioned file.
        /// </summary>
        /// <value>
        ///Version number of this versioned file.
        /// </value>
        [DataMember(Name="versionNumber", EmitDefaultValue=false)]
        public int VersionNumber { get; set; }

        /// <summary>
        ///File type, only present if this version represents a file.
        /// </summary>
        /// <value>
        ///File type, only present if this version represents a file.
        /// </value>
        [DataMember(Name="fileType", EmitDefaultValue=false)]
        public string FileType { get; set; }

        /// <summary>
        ///File size in bytes, only present if this version represents a file.
        /// </summary>
        /// <value>
        ///File size in bytes, only present if this version represents a file.
        /// </value>
        [DataMember(Name="storageSize", EmitDefaultValue=false)]
        public long StorageSize { get; set; }

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
        ///Gets or Sets Extension
        /// </summary>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public VersionExtensionWithSchemaLink Extension { get; set; }

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
