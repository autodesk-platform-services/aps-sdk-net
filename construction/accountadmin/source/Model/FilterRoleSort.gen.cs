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
    /// Sorts the results by one or more fields.
///Each field can be followed by a direction modifier:
///
///asc – Ascending order (default)
///
///desc – Descending order
///
///Possible values: name, createdAt, updatedAt.
///
///Default sort: name asc
///
///Example: sort=name,updatedAt desc
    /// </summary>
    ///<value>Sorts the results by one or more fields.
///Each field can be followed by a direction modifier:
///
///asc – Ascending order (default)
///
///desc – Descending order
///
///Possible values: name, createdAt, updatedAt.
///
///Default sort: name asc
///
///Example: sort=name,updatedAt desc</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FilterRoleSort
    {
        
        /// <summary>
        /// Enum Nameasc for value: name asc
        /// </summary>
        [EnumMember(Value = "name asc")]
        Nameasc,
        
        /// <summary>
        /// Enum CreatedAtasc for value: createdAt asc
        /// </summary>
        [EnumMember(Value = "createdAt asc")]
        CreatedAtasc,
        
        /// <summary>
        /// Enum UpdatedAtasc for value: updatedAt asc
        /// </summary>
        [EnumMember(Value = "updatedAt asc")]
        UpdatedAtasc,
        
        /// <summary>
        /// Enum Namedesc for value: name desc
        /// </summary>
        [EnumMember(Value = "name desc")]
        Namedesc,
        
        /// <summary>
        /// Enum CreatedAtdesc for value: createdAt desc
        /// </summary>
        [EnumMember(Value = "createdAt desc")]
        CreatedAtdesc,
        
        /// <summary>
        /// Enum UpdatedAtdesc for value: updatedAt desc
        /// </summary>
        [EnumMember(Value = "updatedAt desc")]
        UpdatedAtdesc
    }

}
