/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// BusinessUnitsRequest
    /// </summary>
    [DataContract]
    public partial class BusinessUnitsRequest 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitsRequest" /> class.
        /// </summary>
        public BusinessUnitsRequest()
        {
        }
        
        /// <summary>
        ///Business unit ID
///
///If specified and already existing, the existing business unit will be replaced
///with the provided attributes.
///
///If specified and not already existing, a new business unit will be created with the id.
///
///If unspecified, a new business unit will be created with a server-generated id.
        /// </summary>
        /// <value>
        ///Business unit ID
///
///If specified and already existing, the existing business unit will be replaced
///with the provided attributes.
///
///If specified and not already existing, a new business unit will be created with the id.
///
///If unspecified, a new business unit will be created with a server-generated id.
        /// </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        ///The ID of the parent business unit
///
///Note that an entire business unit hierarchy can be created by manually specifying the id
///attribute for each business unit and using it as appropriate in other parent_id
///attributes.
        /// </summary>
        /// <value>
        ///The ID of the parent business unit
///
///Note that an entire business unit hierarchy can be created by manually specifying the id
///attribute for each business unit and using it as appropriate in other parent_id
///attributes.
        /// </value>
        [DataMember(Name="parent_id", EmitDefaultValue=false)]
        public string ParentId { get; set; }

        /// <summary>
        ///The name of the business unit
        /// </summary>
        /// <value>
        ///The name of the business unit
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///The description of the business unit
        /// </summary>
        /// <value>
        ///The description of the business unit
        /// </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

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
