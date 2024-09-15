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
    /// BusinessUnit
    /// </summary>
    [DataContract]
    public partial class BusinessUnit 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnit" /> class.
        /// </summary>
        public BusinessUnit()
        {
        }
        
        /// <summary>
        ///Business unit ID
        /// </summary>
        /// <value>
        ///Business unit ID
        /// </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        ///Account ID
        /// </summary>
        /// <value>
        ///Account ID
        /// </value>
        [DataMember(Name="account_id", EmitDefaultValue=false)]
        public string AccountId { get; set; }

        /// <summary>
        ///The ID of the parent business unit;
///used to configure the tree structure of business units
        /// </summary>
        /// <value>
        ///The ID of the parent business unit;
///used to configure the tree structure of business units
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
        ///The path of the business unit in the tree structure
        /// </summary>
        /// <value>
        ///The path of the business unit in the tree structure
        /// </value>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        ///The description of the business unit
        /// </summary>
        /// <value>
        ///The description of the business unit
        /// </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        ///Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        ///Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

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
