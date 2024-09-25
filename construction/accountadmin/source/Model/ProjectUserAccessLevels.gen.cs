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
    /// Flags that identify a returned user’s access levels in the account or project.
    /// </summary>
    [DataContract]
    public partial class ProjectUserAccessLevels 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUserAccessLevels" /> class.
        /// </summary>
        public ProjectUserAccessLevels()
        {
        }
        
        /// <summary>
        ///Indicates whether the user is an account administrator for the account.
        /// </summary>
        /// <value>
        ///Indicates whether the user is an account administrator for the account.
        /// </value>
        [DataMember(Name="accountAdmin", EmitDefaultValue=false)]
        public bool? AccountAdmin { get; set; }

        /// <summary>
        ///Indicates whether the user is a project administrator for the project.
        /// </summary>
        /// <value>
        ///Indicates whether the user is a project administrator for the project.
        /// </value>
        [DataMember(Name="projectAdmin", EmitDefaultValue=false)]
        public bool? ProjectAdmin { get; set; }

        /// <summary>
        ///Indicates whether the user is an executive in the account.
        /// </summary>
        /// <value>
        ///Indicates whether the user is an executive in the account.
        /// </value>
        [DataMember(Name="executive", EmitDefaultValue=false)]
        public bool? Executive { get; set; }

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
