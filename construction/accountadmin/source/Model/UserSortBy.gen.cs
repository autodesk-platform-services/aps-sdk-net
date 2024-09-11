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
    /// Defines userSortBy
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum UserSortBy
    {
        
        /// <summary>
        /// Enum Nameasc for value: name asc
        /// </summary>
        [EnumMember(Value = "name asc")]
        Nameasc,
        
        /// <summary>
        /// Enum Emailasc for value: email asc
        /// </summary>
        [EnumMember(Value = "email asc")]
        Emailasc,
        
        /// <summary>
        /// Enum FirstNameasc for value: firstName asc
        /// </summary>
        [EnumMember(Value = "firstName asc")]
        FirstNameasc,
        
        /// <summary>
        /// Enum LastNameasc for value: lastName asc
        /// </summary>
        [EnumMember(Value = "lastName asc")]
        LastNameasc,
        
        /// <summary>
        /// Enum AddressLine1asc for value: addressLine1 asc
        /// </summary>
        [EnumMember(Value = "addressLine1 asc")]
        AddressLine1asc,
        
        /// <summary>
        /// Enum AddressLine2asc for value: addressLine2 asc
        /// </summary>
        [EnumMember(Value = "addressLine2 asc")]
        AddressLine2asc,
        
        /// <summary>
        /// Enum Cityasc for value: city asc
        /// </summary>
        [EnumMember(Value = "city asc")]
        Cityasc,
        
        /// <summary>
        /// Enum CompanyNameasc for value: companyName asc
        /// </summary>
        [EnumMember(Value = "companyName asc")]
        CompanyNameasc,
        
        /// <summary>
        /// Enum StateOrProvinceasc for value: stateOrProvince asc
        /// </summary>
        [EnumMember(Value = "stateOrProvince asc")]
        StateOrProvinceasc,
        
        /// <summary>
        /// Enum Statusasc for value: status asc
        /// </summary>
        [EnumMember(Value = "status asc")]
        Statusasc,
        
        /// <summary>
        /// Enum Phoneasc for value: phone asc
        /// </summary>
        [EnumMember(Value = "phone asc")]
        Phoneasc,
        
        /// <summary>
        /// Enum PostalCodeasc for value: postalCode asc
        /// </summary>
        [EnumMember(Value = "postalCode asc")]
        PostalCodeasc,
        
        /// <summary>
        /// Enum Countryasc for value: country asc
        /// </summary>
        [EnumMember(Value = "country asc")]
        Countryasc,
        
        /// <summary>
        /// Enum AddedOnasc for value: addedOn asc
        /// </summary>
        [EnumMember(Value = "addedOn asc")]
        AddedOnasc,
        
        /// <summary>
        /// Enum Namedesc for value: name desc
        /// </summary>
        [EnumMember(Value = "name desc")]
        Namedesc,
        
        /// <summary>
        /// Enum Emaildesc for value: email desc
        /// </summary>
        [EnumMember(Value = "email desc")]
        Emaildesc,
        
        /// <summary>
        /// Enum FirstNamedesc for value: firstName desc
        /// </summary>
        [EnumMember(Value = "firstName desc")]
        FirstNamedesc,
        
        /// <summary>
        /// Enum LastNamedesc for value: lastName desc
        /// </summary>
        [EnumMember(Value = "lastName desc")]
        LastNamedesc,
        
        /// <summary>
        /// Enum AddressLine1desc for value: addressLine1 desc
        /// </summary>
        [EnumMember(Value = "addressLine1 desc")]
        AddressLine1desc,
        
        /// <summary>
        /// Enum AddressLine2desc for value: addressLine2 desc
        /// </summary>
        [EnumMember(Value = "addressLine2 desc")]
        AddressLine2desc,
        
        /// <summary>
        /// Enum Citydesc for value: city desc
        /// </summary>
        [EnumMember(Value = "city desc")]
        Citydesc,
        
        /// <summary>
        /// Enum CompanyNamedesc for value: companyName desc
        /// </summary>
        [EnumMember(Value = "companyName desc")]
        CompanyNamedesc,
        
        /// <summary>
        /// Enum StateOrProvincedesc for value: stateOrProvince desc
        /// </summary>
        [EnumMember(Value = "stateOrProvince desc")]
        StateOrProvincedesc,
        
        /// <summary>
        /// Enum Statusdesc for value: status desc
        /// </summary>
        [EnumMember(Value = "status desc")]
        Statusdesc,
        
        /// <summary>
        /// Enum Phonedesc for value: phone desc
        /// </summary>
        [EnumMember(Value = "phone desc")]
        Phonedesc,
        
        /// <summary>
        /// Enum PostalCodedesc for value: postalCode desc
        /// </summary>
        [EnumMember(Value = "postalCode desc")]
        PostalCodedesc,
        
        /// <summary>
        /// Enum Countrydesc for value: country desc
        /// </summary>
        [EnumMember(Value = "country desc")]
        Countrydesc,
        
        /// <summary>
        /// Enum AddedOndesc for value: addedOn desc
        /// </summary>
        [EnumMember(Value = "addedOn desc")]
        AddedOndesc
    }

}
