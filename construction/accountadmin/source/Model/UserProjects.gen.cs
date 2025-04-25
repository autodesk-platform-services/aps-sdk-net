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
    /// User Projects
    /// </summary>
    [DataContract]
    public partial class UserProjects 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjects" /> class.
        /// </summary>
        public UserProjects()
        { }
        
        /// <summary>
        /// Gets or sets pagination.
        /// </summary>
        /// <value>
        /// Gets or sets pagination.
        /// </value>
        [DataMember(Name="pagination", EmitDefaultValue=false)]
        public UserProjectsPagination Pagination { get; set; }

        /// <summary>
        /// The requested page of the user’s projects.
        /// </summary>
        /// <value>
        /// The requested page of the user’s projects.
        /// </value>
        [DataMember(Name="results", EmitDefaultValue=false)]
        public List<UserProject> Results { get; set; }

        /// <summary>
        /// The string presentation of the object.
        /// </summary>
        /// <returns>
        /// The string presentation of the object.
        /// </returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
