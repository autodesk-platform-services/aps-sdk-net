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
    /// The type of this resource. Possible values: **folders, items, versions, objects, downloads e.t.c**
    /// </summary>
    ///<value>The type of this resource. Possible values: **folders, items, versions, objects, downloads e.t.c**</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Type
    {
        
        /// <summary>
        /// Enum Objects for value: objects
        /// </summary>
        [EnumMember(Value = "objects")]
        Objects,
        
        /// <summary>
        /// Enum Folders for value: folders
        /// </summary>
        [EnumMember(Value = "folders")]
        Folders,
        
        /// <summary>
        /// Enum Hubs for value: hubs
        /// </summary>
        [EnumMember(Value = "hubs")]
        Hubs,
        
        /// <summary>
        /// Enum Projects for value: projects
        /// </summary>
        [EnumMember(Value = "projects")]
        Projects,
        
        /// <summary>
        /// Enum Downloads for value: downloads
        /// </summary>
        [EnumMember(Value = "downloads")]
        Downloads,
        
        /// <summary>
        /// Enum Versions for value: versions
        /// </summary>
        [EnumMember(Value = "versions")]
        Versions,
        
        /// <summary>
        /// Enum Items for value: items
        /// </summary>
        [EnumMember(Value = "items")]
        Items,
        
        /// <summary>
        /// Enum DownloadFormats for value: downloadFormats
        /// </summary>
        [EnumMember(Value = "downloadFormats")]
        DownloadFormats,
        
        /// <summary>
        /// Enum ItemsautodeskBim360File for value: items:autodesk.bim360:File
        /// </summary>
        [EnumMember(Value = "items:autodesk.bim360:File")]
        ItemsautodeskBim360File,
        
        /// <summary>
        /// Enum ItemsautodeskCoreFile for value: items:autodesk.core:File
        /// </summary>
        [EnumMember(Value = "items:autodesk.core:File")]
        ItemsautodeskCoreFile,
        
        /// <summary>
        /// Enum Commands for value: commands
        /// </summary>
        [EnumMember(Value = "commands")]
        Commands,
        
        /// <summary>
        /// Enum VersionsautodeskBim360File for value: versions:autodesk.bim360:File
        /// </summary>
        [EnumMember(Value = "versions:autodesk.bim360:File")]
        VersionsautodeskBim360File,
        
        /// <summary>
        /// Enum VersionsautodeskA360CompositeDesign for value: versions:autodesk.a360:CompositeDesign
        /// </summary>
        [EnumMember(Value = "versions:autodesk.a360:CompositeDesign")]
        VersionsautodeskA360CompositeDesign,
        
        /// <summary>
        /// Enum VersionsautodeskCoreFile for value: versions:autodesk.core:File
        /// </summary>
        [EnumMember(Value = "versions:autodesk.core:File")]
        VersionsautodeskCoreFile,
        
        /// <summary>
        /// Enum XrefsautodeskCoreXref for value: xrefs:autodesk.core:Xref
        /// </summary>
        [EnumMember(Value = "xrefs:autodesk.core:Xref")]
        XrefsautodeskCoreXref,
        
        /// <summary>
        /// Enum CommandsautodeskBim360C4RModelGetPublishJob for value: commands:autodesk.bim360:C4RModelGetPublishJob
        /// </summary>
        [EnumMember(Value = "commands:autodesk.bim360:C4RModelGetPublishJob")]
        CommandsautodeskBim360C4RModelGetPublishJob,
        
        /// <summary>
        /// Enum CommandsautodeskBim360C4RPublishWithoutLinks for value: commands:autodesk.bim360:C4RPublishWithoutLinks
        /// </summary>
        [EnumMember(Value = "commands:autodesk.bim360:C4RPublishWithoutLinks")]
        CommandsautodeskBim360C4RPublishWithoutLinks,
        
        /// <summary>
        /// Enum CommandsautodeskBim360C4RModelPublish for value: commands:autodesk.bim360:C4RModelPublish
        /// </summary>
        [EnumMember(Value = "commands:autodesk.bim360:C4RModelPublish")]
        CommandsautodeskBim360C4RModelPublish,
        
        /// <summary>
        /// Enum CommandsautodeskCoreListItems for value: commands:autodesk.core:ListItems
        /// </summary>
        [EnumMember(Value = "commands:autodesk.core:ListItems")]
        CommandsautodeskCoreListItems,
        
        /// <summary>
        /// Enum CommandsautodeskCoreListRefs for value: commands:autodesk.core:ListRefs
        /// </summary>
        [EnumMember(Value = "commands:autodesk.core:ListRefs")]
        CommandsautodeskCoreListRefs,
        
        /// <summary>
        /// Enum CommandsautodeskCoreCheckPermission for value: commands:autodesk.core:CheckPermission
        /// </summary>
        [EnumMember(Value = "commands:autodesk.core:CheckPermission")]
        CommandsautodeskCoreCheckPermission,
        
        /// <summary>
        /// Enum FoldersautodeskBim360Folder for value: folders:autodesk.bim360:Folder
        /// </summary>
        [EnumMember(Value = "folders:autodesk.bim360:Folder")]
        FoldersautodeskBim360Folder,
        
        /// <summary>
        /// Enum FoldersautodeskCoreFolder for value: folders:autodesk.core:Folder
        /// </summary>
        [EnumMember(Value = "folders:autodesk.core:Folder")]
        FoldersautodeskCoreFolder,
        
        /// <summary>
        /// Enum AuxiliaryautodeskCoreAttachment for value: auxiliary:autodesk.core:Attachment
        /// </summary>
        [EnumMember(Value = "auxiliary:autodesk.core:Attachment")]
        AuxiliaryautodeskCoreAttachment
    }

}
