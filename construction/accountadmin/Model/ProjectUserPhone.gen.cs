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
    /// The user’s phone number. This data syncs from the user’s Autodesk profile.
    /// </summary>
    [DataContract]
    public partial class ProjectUserPhone 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUserPhone" /> class.
        /// </summary>
        public ProjectUserPhone()
        {
        }
        
        /// <summary>
        ///User’s phone number
        /// </summary>
        /// <value>
        ///User’s phone number
        /// </value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }

        /// <summary>
        ///The user’s phone type.
        /// </summary>
        /// <value>
        ///The user’s phone type.
        /// </value>
        [DataMember(Name="phoneType", EmitDefaultValue=false)]
        public string PhoneType { get; set; }

        /// <summary>
        ///User’s phone extension.
        /// </summary>
        /// <value>
        ///User’s phone extension.
        /// </value>
        [DataMember(Name="extension", EmitDefaultValue=false)]
        public string Extension { get; set; }

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
