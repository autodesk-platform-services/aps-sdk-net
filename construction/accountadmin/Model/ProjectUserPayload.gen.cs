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
    /// ProjectUserPayload
    /// </summary>
    [DataContract]
    public partial class ProjectUserPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUserPayload" /> class.
        /// </summary>
        public ProjectUserPayload()
        {
        }
        
        /// <summary>
        ///The email address of the user.
///Max length: 255
        /// </summary>
        /// <value>
        ///The email address of the user.
///Max length: 255
        /// </value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        ///The ID of the company that the user is representing in the project. To obtain a list of all company IDs associated with a project, call GET projects/:projectId/companies.
        /// </summary>
        /// <value>
        ///The ID of the company that the user is representing in the project. To obtain a list of all company IDs associated with a project, call GET projects/:projectId/companies.
        /// </value>
        [DataMember(Name="companyId", EmitDefaultValue=false)]
        public string CompanyId { get; set; }

        /// <summary>
        ///A list of IDs of the roles that the user belongs to in the project.
        /// </summary>
        /// <value>
        ///A list of IDs of the roles that the user belongs to in the project.
        /// </value>
        [DataMember(Name="roleIds", EmitDefaultValue=false)]
        public List<string> RoleIds { get; set; }

        /// <summary>
        ///Gets or Sets Products
        /// </summary>
        [DataMember(Name="products", EmitDefaultValue=false)]
        public List<ProjectUserPayloadProducts> Products { get; set; }

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
