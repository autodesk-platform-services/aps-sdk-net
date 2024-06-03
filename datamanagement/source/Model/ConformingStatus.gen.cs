/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Data Management
 *
 * The Data Management API provides a unified and consistent way to access data across BIM 360 Team, Fusion Team (formerly known as A360 Team), BIM 360 Docs, A360 Personal, and the Object Storage Service. With this API, you can accomplish a number of workflows, including accessing a Fusion model in Fusion Team and getting an ordered structure of items, IDs, and properties for generating a bill of materials in a 3rd-party process. Or, you might want to superimpose a Fusion model and a building model to use in the Viewer.
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
    /// A status indicating whether or not this version conforms to its parent folder’s file naming standard.
///Possible values:
///
///NONE: The conforming status is not applicable for the version.
///CONFORMING: The version conforms to its parent folder’s file naming standard.
///NON_CONFORMING: The version does not conform to its parent folder’s file naming standard.
///In the event of a NON_CONFORMING status, call GET folders/folder_id to get the file naming standards IDs that have been applied to the version’s parent folder, and then use the ID to call GET naming-standards to get the details of the file naming standard.
///
///Note that this feature is only available for BIM 360 projects.
///
///To learn more about the file naming standard feature, see the BIM 360 File Naming Standard help documentation.
    /// </summary>
    ///<value>A status indicating whether or not this version conforms to its parent folder’s file naming standard.
///Possible values:
///
///NONE: The conforming status is not applicable for the version.
///CONFORMING: The version conforms to its parent folder’s file naming standard.
///NON_CONFORMING: The version does not conform to its parent folder’s file naming standard.
///In the event of a NON_CONFORMING status, call GET folders/folder_id to get the file naming standards IDs that have been applied to the version’s parent folder, and then use the ID to call GET naming-standards to get the details of the file naming standard.
///
///Note that this feature is only available for BIM 360 projects.
///
///To learn more about the file naming standard feature, see the BIM 360 File Naming Standard help documentation.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum ConformingStatus
    {
        
        /// <summary>
        /// Enum NONE for value: NONE
        /// </summary>
        [EnumMember(Value = "NONE")]
        NONE,
        
        /// <summary>
        /// Enum CONFORMING for value: CONFORMING
        /// </summary>
        [EnumMember(Value = "CONFORMING")]
        CONFORMING,
        
        /// <summary>
        /// Enum NONCONFORMING for value: NON_CONFORMING
        /// </summary>
        [EnumMember(Value = "NON_CONFORMING")]
        NONCONFORMING
    }

}
