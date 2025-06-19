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
    /// ProjectPatch
    /// </summary>
    [DataContract]
    public partial class ProjectPatch 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPatch" /> class.
        /// </summary>
        public ProjectPatch()
        {
        }
        
        /// <summary>
        ///Project ID
        /// </summary>
        /// <value>
        ///Project ID
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
        ///Name of the project
        /// </summary>
        /// <value>
        ///Name of the project
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///The starting date of a project; must be earlier than end_date
///Format: YYYY-MM-DD
        /// </summary>
        /// <value>
        ///The starting date of a project; must be earlier than end_date
///Format: YYYY-MM-DD
        /// </value>
        [DataMember(Name="start_date", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        ///The ending date of a project; must be later than start_date
///Format: YYYY-MM-DD
        /// </summary>
        /// <value>
        ///The ending date of a project; must be later than start_date
///Format: YYYY-MM-DD
        /// </value>
        [DataMember(Name="end_date", EmitDefaultValue=false)]
        public string EndDate { get; set; }

        /// <summary>
        ///The type of project; accepts preconfigured and customized project types
        /// </summary>
        /// <value>
        ///The type of project; accepts preconfigured and customized project types
        /// </value>
        [DataMember(Name="project_type", EmitDefaultValue=false)]
        public string ProjectType { get; set; }

        /// <summary>
        ///Monetary value of the project
        /// </summary>
        /// <value>
        ///Monetary value of the project
        /// </value>
        [DataMember(Name="value", EmitDefaultValue=false)]
        public decimal? Value { get; set; }

        /// <summary>
        ///Currency for project value
        /// </summary>
        /// <value>
        ///Currency for project value
        /// </value>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }

        /// <summary>
        ///The status of project.
        /// </summary>
        /// <value>
        ///The status of project.
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///Project job number to connect a BIM 360 project to project or job in a financial or ERP system.
        /// </summary>
        /// <value>
        ///Project job number to connect a BIM 360 project to project or job in a financial or ERP system.
        /// </value>
        [DataMember(Name="job_number", EmitDefaultValue=false)]
        public string JobNumber { get; set; }

        /// <summary>
        ///Project address line 1
        /// </summary>
        /// <value>
        ///Project address line 1
        /// </value>
        [DataMember(Name="address_line_1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///Project address line 2
        /// </summary>
        /// <value>
        ///Project address line 2
        /// </value>
        [DataMember(Name="address_line_2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        ///City in which project is located
        /// </summary>
        /// <value>
        ///City in which project is located
        /// </value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        ///State or province in which project is located
        /// </summary>
        /// <value>
        ///State or province in which project is located
        /// </value>
        [DataMember(Name="state_or_province", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///Postal code for the project location
        /// </summary>
        /// <value>
        ///Postal code for the project location
        /// </value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///Country for this project
        /// </summary>
        /// <value>
        ///Country for this project
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        ///The business unit ID of this project
        /// </summary>
        /// <value>
        ///The business unit ID of this project
        /// </value>
        [DataMember(Name="business_unit_id", EmitDefaultValue=false)]
        public string BusinessUnitId { get; set; }

        /// <summary>
        ///Time zone for this project
        /// </summary>
        /// <value>
        ///Time zone for this project
        /// </value>
        [DataMember(Name="timezone", EmitDefaultValue=false)]
        public string Timezone { get; set; }

        /// <summary>
        ///Language of the project; applicable to the BIM 360 Field service only
        /// </summary>
        /// <value>
        ///Language of the project; applicable to the BIM 360 Field service only
        /// </value>
        [DataMember(Name="language", EmitDefaultValue=false)]
        public string Language { get; set; }

        /// <summary>
        ///Type of construction
        /// </summary>
        /// <value>
        ///Type of construction
        /// </value>
        [DataMember(Name="construction_type", EmitDefaultValue=false)]
        public string ConstructionType { get; set; }

        /// <summary>
        ///Contract Type for your project
        /// </summary>
        /// <value>
        ///Contract Type for your project
        /// </value>
        [DataMember(Name="contract_type", EmitDefaultValue=false)]
        public string ContractType { get; set; }

        /// <summary>
        ///Timestamp of the last sign in, YYYY-MM-DDThh:mm:ss.sssZ format
        /// </summary>
        /// <value>
        ///Timestamp of the last sign in, YYYY-MM-DDThh:mm:ss.sssZ format
        /// </value>
        [DataMember(Name="last_sign_in", EmitDefaultValue=false)]
        public string LastSignIn { get; set; }

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
