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
    /// ProjectUserResponse
    /// </summary>
    [DataContract]
    public partial class ProjectUserResponse 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectUserResponse" /> class.
        /// </summary>
        public ProjectUserResponse()
        {
        }
        
        /// <summary>
        ///The email of the user.
///Max length: 255
        /// </summary>
        /// <value>
        ///The email of the user.
///Max length: 255
        /// </value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        ///The ACC ID of the user.
        /// </summary>
        /// <value>
        ///The ACC ID of the user.
        /// </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        ///The full name of the user.
        /// </summary>
        /// <value>
        ///The full name of the user.
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///The user’s first name. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s first name. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        ///The user’s last name. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s last name. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="lastName", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        ///The ID of the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The ID of the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="autodeskId", EmitDefaultValue=false)]
        public string AutodeskId { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name="analyticsId", EmitDefaultValue=false)]
        public string AnalyticsId { get; set; }

        /// <summary>
        ///The user’s address line 1. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s address line 1. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="addressLine1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///The user’s address line 2. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s address line 2. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="addressLine2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        ///The User’s city. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The User’s city. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        ///The state or province of the user. The accepted values here change depending on which country is provided. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The state or province of the user. The accepted values here change depending on which country is provided. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="stateOrProvince", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///The zip or postal code of the user. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The zip or postal code of the user. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="postalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///The user’s country. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s country. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        ///The URL of the user’s avatar. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The URL of the user’s avatar. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="imageUrl", EmitDefaultValue=false)]
        public string ImageUrl { get; set; }

        /// <summary>
        ///Gets or Sets Phone
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public ProjectUserPhone Phone { get; set; }

        /// <summary>
        ///The user’s job title. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The user’s job title. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="jobTitle", EmitDefaultValue=false)]
        public string JobTitle { get; set; }

        /// <summary>
        ///The industry the user works in. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///The industry the user works in. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="industry", EmitDefaultValue=false)]
        public string Industry { get; set; }

        /// <summary>
        ///A short bio about the user. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </summary>
        /// <value>
        ///A short bio about the user. This data syncs from the user’s Autodesk profile.
///Max length: 255
        /// </value>
        [DataMember(Name="aboutMe", EmitDefaultValue=false)]
        public string AboutMe { get; set; }

        /// <summary>
        ///Gets or Sets AccessLevels
        /// </summary>
        [DataMember(Name="accessLevels", EmitDefaultValue=false)]
        public ProjectUserAccessLevels AccessLevels { get; set; }

        /// <summary>
        ///The timestamp when the user was first given access to any product on the project.
        /// </summary>
        /// <value>
        ///The timestamp when the user was first given access to any product on the project.
        /// </value>
        [DataMember(Name="addedOn", EmitDefaultValue=false)]
        public string AddedOn { get; set; }

        /// <summary>
        ///The timestamp when the project user was last updated, in ISO 8601 format.
        /// </summary>
        /// <value>
        ///The timestamp when the project user was last updated, in ISO 8601 format.
        /// </value>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        ///The ID of the company that the user is representing in the project. To obtain a list of all company IDs associated with a project, call GET projects/:projectId/companies.
        /// </summary>
        /// <value>
        ///The ID of the company that the user is representing in the project. To obtain a list of all company IDs associated with a project, call GET projects/:projectId/companies.
        /// </value>
        [DataMember(Name="companyId", EmitDefaultValue=false)]
        public string CompanyId { get; set; }

        /// <summary>
        ///The name of the company to which the user belongs.
///Max length: 255
        /// </summary>
        /// <value>
        ///The name of the company to which the user belongs.
///Max length: 255
        /// </value>
        [DataMember(Name="companyName", EmitDefaultValue=false)]
        public string CompanyName { get; set; }

        /// <summary>
        ///A list of IDs of the roles that the user belongs to in the project.
        /// </summary>
        /// <value>
        ///A list of IDs of the roles that the user belongs to in the project.
        /// </value>
        [DataMember(Name="roleIds", EmitDefaultValue=false)]
        public List<string> RoleIds { get; set; }

        /// <summary>
        ///A list of the role IDs and names that are associated with the user in the project.
        /// </summary>
        /// <value>
        ///A list of the role IDs and names that are associated with the user in the project.
        /// </value>
        [DataMember(Name="roles", EmitDefaultValue=false)]
        public List<ProjectUserRoles> Roles { get; set; }

        /// <summary>
        ///The status of the user in the project. A pending user could be waiting for their products to activate, or the user hasn’t accepted an email to create an account with Autodesk.
        /// </summary>
        /// <value>
        ///The status of the user in the project. A pending user could be waiting for their products to activate, or the user hasn’t accepted an email to create an account with Autodesk.
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///Gets or Sets Products
        /// </summary>
        [DataMember(Name="products", EmitDefaultValue=false)]
        public List<ProjectUserProducts> Products { get; set; }

        /// <summary>
        ///Not relevant - we don’t currently support this field.
        /// </summary>
        /// <value>
        ///Not relevant - we don’t currently support this field.
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
