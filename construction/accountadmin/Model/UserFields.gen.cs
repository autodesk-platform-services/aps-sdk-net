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
    /// Defines userFields
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum UserFields
    {
        
        /// <summary>
        /// Enum Name for value: name
        /// </summary>
        [EnumMember(Value = "name")]
        Name,
        
        /// <summary>
        /// Enum Email for value: email
        /// </summary>
        [EnumMember(Value = "email")]
        Email,
        
        /// <summary>
        /// Enum FirstName for value: firstName
        /// </summary>
        [EnumMember(Value = "firstName")]
        FirstName,
        
        /// <summary>
        /// Enum LastName for value: lastName
        /// </summary>
        [EnumMember(Value = "lastName")]
        LastName,
        
        /// <summary>
        /// Enum AutodeskId for value: autodeskId
        /// </summary>
        [EnumMember(Value = "autodeskId")]
        AutodeskId,
        
        /// <summary>
        /// Enum AddressLine1 for value: addressLine1
        /// </summary>
        [EnumMember(Value = "addressLine1")]
        AddressLine1,
        
        /// <summary>
        /// Enum AddressLine2 for value: addressLine2
        /// </summary>
        [EnumMember(Value = "addressLine2")]
        AddressLine2,
        
        /// <summary>
        /// Enum City for value: city
        /// </summary>
        [EnumMember(Value = "city")]
        City,
        
        /// <summary>
        /// Enum StateOrProvince for value: stateOrProvince
        /// </summary>
        [EnumMember(Value = "stateOrProvince")]
        StateOrProvince,
        
        /// <summary>
        /// Enum PostalCode for value: postalCode
        /// </summary>
        [EnumMember(Value = "postalCode")]
        PostalCode,
        
        /// <summary>
        /// Enum Country for value: country
        /// </summary>
        [EnumMember(Value = "country")]
        Country,
        
        /// <summary>
        /// Enum ImageUrl for value: imageUrl
        /// </summary>
        [EnumMember(Value = "imageUrl")]
        ImageUrl,
        
        /// <summary>
        /// Enum LastSignIn for value: lastSignIn
        /// </summary>
        [EnumMember(Value = "lastSignIn")]
        LastSignIn,
        
        /// <summary>
        /// Enum Phone for value: phone
        /// </summary>
        [EnumMember(Value = "phone")]
        Phone,
        
        /// <summary>
        /// Enum JobTitle for value: jobTitle
        /// </summary>
        [EnumMember(Value = "jobTitle")]
        JobTitle,
        
        /// <summary>
        /// Enum Industry for value: industry
        /// </summary>
        [EnumMember(Value = "industry")]
        Industry,
        
        /// <summary>
        /// Enum AboutMe for value: aboutMe
        /// </summary>
        [EnumMember(Value = "aboutMe")]
        AboutMe,
        
        /// <summary>
        /// Enum CreatedAt for value: createdAt
        /// </summary>
        [EnumMember(Value = "createdAt")]
        CreatedAt,
        
        /// <summary>
        /// Enum UpdatedAt for value: updatedAt
        /// </summary>
        [EnumMember(Value = "updatedAt")]
        UpdatedAt,
        
        /// <summary>
        /// Enum AccessLevels for value: accessLevels
        /// </summary>
        [EnumMember(Value = "accessLevels")]
        AccessLevels,
        
        /// <summary>
        /// Enum CompanyId for value: companyId
        /// </summary>
        [EnumMember(Value = "companyId")]
        CompanyId,
        
        /// <summary>
        /// Enum RoleIds for value: roleIds
        /// </summary>
        [EnumMember(Value = "roleIds")]
        RoleIds,
        
        /// <summary>
        /// Enum Roles for value: roles
        /// </summary>
        [EnumMember(Value = "roles")]
        Roles,
        
        /// <summary>
        /// Enum Status for value: status
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
        
        /// <summary>
        /// Enum AddedOn for value: addedOn
        /// </summary>
        [EnumMember(Value = "addedOn")]
        AddedOn,
        
        /// <summary>
        /// Enum Products for value: products
        /// </summary>
        [EnumMember(Value = "products")]
        Products
    }

}
