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
    /// A container of the results of the resources that were checked for permission.
    /// </summary>
    [DataContract]
    public partial class CheckPermissionAttributesExtensionData 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckPermissionAttributesExtensionData" /> class.
        /// </summary>
        public CheckPermissionAttributesExtensionData()
        {
        }
        
        /// <summary>
        ///An array of objects, where each object 
///represents a folder, item, or version that 
///permission was checked for.
        /// </summary>
        /// <value>
        ///An array of objects, where each object 
///represents a folder, item, or version that 
///permission was checked for.
        /// </value>
        [DataMember(Name="permissions", EmitDefaultValue=false)]
        public List<CheckPermissionAttributesExtensionDataPermissions> Permissions { get; set; }

        /// <summary>
        ///An array of keywords where each keyword 
///is an action that permission was checked
///for. Possible values:
///
///- `read` - Download and view specified resource.
///- `view` - View specified resource without downloading.
///- `download` - Download and view specified resource.
///- `collaborate` - Add comments for the specified resource.
///- `write` - Write to the specified resource.
///- `upload` - Upload to the specified resource.
///- `updateMetaData` - Update metadata of the specified resource.
///- `create` - Write and upload to the specified resource.
///- `delete` - Delete the specified resource.
///- `admin` - Perform administrative operations on specified resource.
///- `share`- Share the specified resource.
        /// </summary>
        /// <value>
        ///An array of keywords where each keyword 
///is an action that permission was checked
///for. Possible values:
///
///- `read` - Download and view specified resource.
///- `view` - View specified resource without downloading.
///- `download` - Download and view specified resource.
///- `collaborate` - Add comments for the specified resource.
///- `write` - Write to the specified resource.
///- `upload` - Upload to the specified resource.
///- `updateMetaData` - Update metadata of the specified resource.
///- `create` - Write and upload to the specified resource.
///- `delete` - Delete the specified resource.
///- `admin` - Perform administrative operations on specified resource.
///- `share`- Share the specified resource.
        /// </value>
        [DataMember(Name="requiredActions", EmitDefaultValue=false)]
        public List<string> RequiredActions { get; set; }

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
