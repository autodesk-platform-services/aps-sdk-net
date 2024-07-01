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
    /// ProjectUsersImportResponse
    /// </summary>
    [DataContract]
    public partial class ProjectUsersImportResponse 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUsersImportResponse" /> class.
        /// </summary>
        public ProjectUsersImportResponse()
        {
        }
        
        /// <summary>
        ///We don’t currently support this field, but expect to in a future release.
///If the response returns jobId with a valid UUID value, the user import operation was successful.
        /// </summary>
        /// <value>
        ///We don’t currently support this field, but expect to in a future release.
///If the response returns jobId with a valid UUID value, the user import operation was successful.
        /// </value>
        [DataMember(Name="jobId", EmitDefaultValue=false)]
        public string JobId { get; set; }

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
