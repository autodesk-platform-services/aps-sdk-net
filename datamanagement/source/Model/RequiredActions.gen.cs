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
    /// An array containing the list of permitted actions to check for. Possible values: read, view, download, collaborate, write, create, upload, updateMetaData, delete, admin, share
///See the tables under the initial description of the command for details.
    /// </summary>
    ///<value>An array containing the list of permitted actions to check for. Possible values: read, view, download, collaborate, write, create, upload, updateMetaData, delete, admin, share
///See the tables under the initial description of the command for details.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum RequiredActions
    {
        
        /// <summary>
        /// Enum Read for value: read
        /// </summary>
        [EnumMember(Value = "read")]
        Read,
        
        /// <summary>
        /// Enum View for value: view
        /// </summary>
        [EnumMember(Value = "view")]
        View,
        
        /// <summary>
        /// Enum Download for value: download
        /// </summary>
        [EnumMember(Value = "download")]
        Download,
        
        /// <summary>
        /// Enum Collaborate for value: collaborate
        /// </summary>
        [EnumMember(Value = "collaborate")]
        Collaborate,
        
        /// <summary>
        /// Enum Write for value: write
        /// </summary>
        [EnumMember(Value = "write")]
        Write,
        
        /// <summary>
        /// Enum Create for value: create
        /// </summary>
        [EnumMember(Value = "create")]
        Create,
        
        /// <summary>
        /// Enum Upload for value: upload
        /// </summary>
        [EnumMember(Value = "upload")]
        Upload,
        
        /// <summary>
        /// Enum UpdateMetaData for value: updateMetaData
        /// </summary>
        [EnumMember(Value = "updateMetaData")]
        UpdateMetaData,
        
        /// <summary>
        /// Enum Delete for value: delete
        /// </summary>
        [EnumMember(Value = "delete")]
        Delete,
        
        /// <summary>
        /// Enum Admin for value: admin
        /// </summary>
        [EnumMember(Value = "admin")]
        Admin,
        
        /// <summary>
        /// Enum Share for value: share
        /// </summary>
        [EnumMember(Value = "share")]
        Share
    }

}
