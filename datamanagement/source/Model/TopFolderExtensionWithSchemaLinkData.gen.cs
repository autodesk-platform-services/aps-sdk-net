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
    /// The object that contains the additional properties, which makes this resource extensible.
    /// </summary>
    [DataContract]
    public partial class TopFolderExtensionWithSchemaLinkData 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopFolderExtensionWithSchemaLinkData" /> class.
        /// </summary>
        public TopFolderExtensionWithSchemaLinkData()
        {
        }
        
        /// <summary>
        ///A list of file naming standard IDs that have been applied to the folder.
///
///Note that we currently support one file naming standard per project.
///
///Note that this feature is only available for BIM 360 projects.
///
///To get the details of a file naming standard, call [GET naming-standards](/en/docs/bim360/v1/reference/http/document-management-naming-standards-id-GET).
///
///To learn more about the file naming standard feature, see the [BIM 360 File Naming Standard](https://help.autodesk.com/view/BIM360D/ENU/?guid=Common_Data_Environment) help documentation.
        /// </summary>
        /// <value>
        ///A list of file naming standard IDs that have been applied to the folder.
///
///Note that we currently support one file naming standard per project.
///
///Note that this feature is only available for BIM 360 projects.
///
///To get the details of a file naming standard, call [GET naming-standards](/en/docs/bim360/v1/reference/http/document-management-naming-standards-id-GET).
///
///To learn more about the file naming standard feature, see the [BIM 360 File Naming Standard](https://help.autodesk.com/view/BIM360D/ENU/?guid=Common_Data_Environment) help documentation.
        /// </value>
        [DataMember(Name="namingStandardIds", EmitDefaultValue=false)]
        public List<Object> NamingStandardIds { get; set; }

        /// <summary>
        ///Determines if folder is root folder. Note that this attribute is available only for BIM 360 and ACC projects.
        /// </summary>
        /// <value>
        ///Determines if folder is root folder. Note that this attribute is available only for BIM 360 and ACC projects.
        /// </value>
        [DataMember(Name="isRoot", EmitDefaultValue=false)]
        public bool IsRoot { get; set; }

        /// <summary>
        ///Type of folder. Possible values: `normal`, `plan`, `shared`, `recycle`, `drawing`.
///
///Note that `recycle` and `drawing` only exist in old projects.
///
///Note that this feature is only available for BIM 360 and ACC projects.
        /// </summary>
        /// <value>
        ///Type of folder. Possible values: `normal`, `plan`, `shared`, `recycle`, `drawing`.
///
///Note that `recycle` and `drawing` only exist in old projects.
///
///Note that this feature is only available for BIM 360 and ACC projects.
        /// </value>
        [DataMember(Name="folderType", EmitDefaultValue=false)]
        public string FolderType { get; set; }

        /// <summary>
        ///Parent folders of the current folder. Note that this feature is only available for BIM 360 and ACC projects.
        /// </summary>
        /// <value>
        ///Parent folders of the current folder. Note that this feature is only available for BIM 360 and ACC projects.
        /// </value>
        [DataMember(Name="folderParents", EmitDefaultValue=false)]
        public List<TopFolderExtensionWithSchemaLinkDataFolderParents> FolderParents { get; set; }

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
