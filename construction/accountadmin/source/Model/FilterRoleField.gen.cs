/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Account.Admin
 *
 * The Account Admin API automates creating and managing projects, assigning and managing project users, and managing member and partner company directories. You can also synchronize data with external systems. 
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

namespace Autodesk.Construction.AccountAdmin.Model
{
    /// <summary>
    /// A comma-separated list of response fields to include. Defaults to all fields if not specified.
///Use this parameter to reduce the response size by retrieving only the fields you need.
///
///Possible values:
///
///projectIds – Projects where the user holds this role
///
///name – Role name
///
///status – Role status (active or inactive)
///
///key – Internal key used to translate the role name
///
///createdAt – Timestamp when the role was created
///
///updatedAt – Timestamp when the role was last updated
    /// </summary>
    ///<value>A comma-separated list of response fields to include. Defaults to all fields if not specified.
///Use this parameter to reduce the response size by retrieving only the fields you need.
///
///Possible values:
///
///projectIds – Projects where the user holds this role
///
///name – Role name
///
///status – Role status (active or inactive)
///
///key – Internal key used to translate the role name
///
///createdAt – Timestamp when the role was created
///
///updatedAt – Timestamp when the role was last updated</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FilterRoleField
    {
        
        /// <summary>
        /// Enum ProjectIds for value: projectIds
        /// </summary>
        [EnumMember(Value = "projectIds")]
        ProjectIds,
        
        /// <summary>
        /// Enum Name for value: name
        /// </summary>
        [EnumMember(Value = "name")]
        Name,
        
        /// <summary>
        /// Enum Status for value: status
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
        
        /// <summary>
        /// Enum Key for value: key
        /// </summary>
        [EnumMember(Value = "key")]
        Key,
        
        /// <summary>
        /// Enum CreatedAt for value: createdAt
        /// </summary>
        [EnumMember(Value = "createdAt")]
        CreatedAt,
        
        /// <summary>
        /// Enum UpdatedAt for value: updatedAt
        /// </summary>
        [EnumMember(Value = "updatedAt")]
        UpdatedAt
    }

}
