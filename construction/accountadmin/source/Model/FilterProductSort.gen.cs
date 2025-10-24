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
    /// The list of fields to sort by.
///Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.
///
///Possible values: name.
///
///Default is the order in database.
    /// </summary>
    ///<value>The list of fields to sort by.
///Each property can be followed by a direction modifier of either asc (ascending) or desc (descending). The default is asc.
///
///Possible values: name.
///
///Default is the order in database.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FilterProductSort
    {
        
        /// <summary>
        /// Enum Nameasc for value: name asc
        /// </summary>
        [EnumMember(Value = "name asc")]
        Nameasc,
        
        /// <summary>
        /// Enum Namedesc for value: name desc
        /// </summary>
        [EnumMember(Value = "name desc")]
        Namedesc
    }

}
