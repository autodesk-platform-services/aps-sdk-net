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
    /// ProjectCompanies
    /// </summary>
    [DataContract]
    public partial class ProjectCompanies 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectCompanies" /> class.
        /// </summary>
        public ProjectCompanies()
        {
        }
        
        /// <summary>
        ///Company ID
        /// </summary>
        /// <value>
        ///Company ID
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
        ///Project ID
        /// </summary>
        /// <value>
        ///Project ID
        /// </value>
        [DataMember(Name="project_id", EmitDefaultValue=false)]
        public string ProjectId { get; set; }

        /// <summary>
        ///Company name should be unique under an account
        /// </summary>
        /// <value>
        ///Company name should be unique under an account
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///Trade type based on specialization
        /// </summary>
        /// <value>
        ///Trade type based on specialization
        /// </value>
        [DataMember(Name="trade", EmitDefaultValue=false)]
        public string Trade { get; set; }

        /// <summary>
        ///Company address line 1
        /// </summary>
        /// <value>
        ///Company address line 1
        /// </value>
        [DataMember(Name="address_line_1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///Company address line 2
        /// </summary>
        /// <value>
        ///Company address line 2
        /// </value>
        [DataMember(Name="address_line_2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        ///City in which company is located
        /// </summary>
        /// <value>
        ///City in which company is located
        /// </value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        ///State or province in which company is located
        /// </summary>
        /// <value>
        ///State or province in which company is located
        /// </value>
        [DataMember(Name="state_or_province", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///Postal code for the company location
        /// </summary>
        /// <value>
        ///Postal code for the company location
        /// </value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///Country for this company
        /// </summary>
        /// <value>
        ///Country for this company
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        ///Business phone number for the company
        /// </summary>
        /// <value>
        ///Business phone number for the company
        /// </value>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        ///Company website
        /// </summary>
        /// <value>
        ///Company website
        /// </value>
        [DataMember(Name="website_url", EmitDefaultValue=false)]
        public string WebsiteUrl { get; set; }

        /// <summary>
        ///Short description or overview for company
        /// </summary>
        /// <value>
        ///Short description or overview for company
        /// </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        ///Used to associate a company in BIM 360 with the company data in an ERP system
        /// </summary>
        /// <value>
        ///Used to associate a company in BIM 360 with the company data in an ERP system
        /// </value>
        [DataMember(Name="erp_id", EmitDefaultValue=false)]
        public string ErpId { get; set; }

        /// <summary>
        ///Used to associate a company in BIM 360 with the company data from public and industry sources
        /// </summary>
        /// <value>
        ///Used to associate a company in BIM 360 with the company data from public and industry sources
        /// </value>
        [DataMember(Name="tax_id", EmitDefaultValue=false)]
        public string TaxId { get; set; }

        /// <summary>
        ///The Autodesk ID of the company; used to identify which company is assigned to an RFI or Issue.
        /// </summary>
        /// <value>
        ///The Autodesk ID of the company; used to identify which company is assigned to an RFI or Issue.
        /// </value>
        [DataMember(Name="member_group_id", EmitDefaultValue=false)]
        public string MemberGroupId { get; set; }

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
