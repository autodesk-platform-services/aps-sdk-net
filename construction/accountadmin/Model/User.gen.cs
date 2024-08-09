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
    /// User
    /// </summary>
    [DataContract]
    public partial class User 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        public User()
        {
        }
        
        /// <summary>
        ///BIM 360 user ID
        /// </summary>
        /// <value>
        ///BIM 360 user ID
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
        ///The role of the user in the account. New user should be account_user only.
        /// </summary>
        /// <value>
        ///The role of the user in the account. New user should be account_user only.
        /// </value>
        [DataMember(Name="role", EmitDefaultValue=false)]
        public string Role { get; set; }

        /// <summary>
        ///Status of the user in the system. A new account user is always not_invited.
        /// </summary>
        /// <value>
        ///Status of the user in the system. A new account user is always not_invited.
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///The user’s default company ID in BIM 360
        /// </summary>
        /// <value>
        ///The user’s default company ID in BIM 360
        /// </value>
        [DataMember(Name="company_id", EmitDefaultValue=false)]
        public string CompanyId { get; set; }

        /// <summary>
        ///The name of the user’s default company name in BIM 360
        /// </summary>
        /// <value>
        ///The name of the user’s default company name in BIM 360
        /// </value>
        [DataMember(Name="company_name", EmitDefaultValue=false)]
        public string CompanyName { get; set; }

        /// <summary>
        ///Timestamp of the last sign in, YYYY-MM-DDThh:mm:ss.sssZ format
        /// </summary>
        /// <value>
        ///Timestamp of the last sign in, YYYY-MM-DDThh:mm:ss.sssZ format
        /// </value>
        [DataMember(Name="last_sign_in", EmitDefaultValue=false)]
        public string LastSignIn { get; set; }

        /// <summary>
        ///User’s email 
        /// </summary>
        /// <value>
        ///User’s email 
        /// </value>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        ///Default display name
        /// </summary>
        /// <value>
        ///Default display name
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///Nick name for user
        /// </summary>
        /// <value>
        ///Nick name for user
        /// </value>
        [DataMember(Name="nickname", EmitDefaultValue=false)]
        public string Nickname { get; set; }

        /// <summary>
        ///User’s first name
        /// </summary>
        /// <value>
        ///User’s first name
        /// </value>
        [DataMember(Name="first_name", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        ///User’s last name
        /// </summary>
        /// <value>
        ///User’s last name
        /// </value>
        [DataMember(Name="last_name", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        ///User’s Autodesk ID
        /// </summary>
        /// <value>
        ///User’s Autodesk ID
        /// </value>
        [DataMember(Name="uid", EmitDefaultValue=false)]
        public string Uid { get; set; }

        /// <summary>
        ///URL for user’s profile image
        /// </summary>
        /// <value>
        ///URL for user’s profile image
        /// </value>
        [DataMember(Name="image_url", EmitDefaultValue=false)]
        public string ImageUrl { get; set; }

        /// <summary>
        ///User’s address line 1
        /// </summary>
        /// <value>
        ///User’s address line 1
        /// </value>
        [DataMember(Name="address_line_1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///User’s address line 2
        /// </summary>
        /// <value>
        ///User’s address line 2
        /// </value>
        [DataMember(Name="address_line_2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        ///City in which user is located
        /// </summary>
        /// <value>
        ///City in which user is located
        /// </value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        ///State or province in which user is located
        /// </summary>
        /// <value>
        ///State or province in which user is located
        /// </value>
        [DataMember(Name="state_or_province", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///Postal code for the user’s location
        /// </summary>
        /// <value>
        ///Postal code for the user’s location
        /// </value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///Country for this user
        /// </summary>
        /// <value>
        ///Country for this user
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        ///Contact phone number for the user
        /// </summary>
        /// <value>
        ///Contact phone number for the user
        /// </value>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        ///Company information from the Autodesk user profile
        /// </summary>
        /// <value>
        ///Company information from the Autodesk user profile
        /// </value>
        [DataMember(Name="company", EmitDefaultValue=false)]
        public string Company { get; set; }

        /// <summary>
        ///User’s job title
        /// </summary>
        /// <value>
        ///User’s job title
        /// </value>
        [DataMember(Name="job_title", EmitDefaultValue=false)]
        public string JobTitle { get; set; }

        /// <summary>
        ///Industry information for user
        /// </summary>
        /// <value>
        ///Industry information for user
        /// </value>
        [DataMember(Name="industry", EmitDefaultValue=false)]
        public string Industry { get; set; }

        /// <summary>
        ///Short description about the user
        /// </summary>
        /// <value>
        ///Short description about the user
        /// </value>
        [DataMember(Name="about_me", EmitDefaultValue=false)]
        public string AboutMe { get; set; }

        /// <summary>
        ///YYYY-MM-DDThh:mm:ss.sssZ format
        /// </summary>
        /// <value>
        ///YYYY-MM-DDThh:mm:ss.sssZ format
        /// </value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        ///YYYY-MM-DDThh:mm:ss.sssZ format
        /// </summary>
        /// <value>
        ///YYYY-MM-DDThh:mm:ss.sssZ format
        /// </value>
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
