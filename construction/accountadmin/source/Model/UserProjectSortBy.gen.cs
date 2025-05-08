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
    /// Possible values: name, email, firstName, lastName, addressLine1, addressLine2, city, companyName, stateOrProvince, status, phone, postalCode, country and addedOn. Default value: name.
    /// </summary>
    ///<value>Possible values: name, email, firstName, lastName, addressLine1, addressLine2, city, companyName, stateOrProvince, status, phone, postalCode, country and addedOn. Default value: name.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum UserProjectSortBy
    {
        
        /// <summary>
        /// Enum Nameasc for value: name asc
        /// </summary>
        [EnumMember(Value = "name asc")]
        Nameasc,
        
        /// <summary>
        /// Enum StartDateasc for value: startDate asc
        /// </summary>
        [EnumMember(Value = "startDate asc")]
        StartDateasc,
        
        /// <summary>
        /// Enum EndDateasc for value: endDate asc
        /// </summary>
        [EnumMember(Value = "endDate asc")]
        EndDateasc,
        
        /// <summary>
        /// Enum Typeasc for value: type asc
        /// </summary>
        [EnumMember(Value = "type asc")]
        Typeasc,
        
        /// <summary>
        /// Enum Statusasc for value: status asc
        /// </summary>
        [EnumMember(Value = "status asc")]
        Statusasc,
        
        /// <summary>
        /// Enum JobNumberasc for value: jobNumber asc
        /// </summary>
        [EnumMember(Value = "jobNumber asc")]
        JobNumberasc,
        
        /// <summary>
        /// Enum ConstructionTypeasc for value: constructionType asc
        /// </summary>
        [EnumMember(Value = "constructionType asc")]
        ConstructionTypeasc,
        
        /// <summary>
        /// Enum DeliveryMethodasc for value: deliveryMethod asc
        /// </summary>
        [EnumMember(Value = "deliveryMethod asc")]
        DeliveryMethodasc,
        
        /// <summary>
        /// Enum ContractTypeasc for value: contractType asc
        /// </summary>
        [EnumMember(Value = "contractType asc")]
        ContractTypeasc,
        
        /// <summary>
        /// Enum CurrentPhaseasc for value: currentPhase asc
        /// </summary>
        [EnumMember(Value = "currentPhase asc")]
        CurrentPhaseasc,
        
        /// <summary>
        /// Enum CreatedAtasc for value: createdAt asc
        /// </summary>
        [EnumMember(Value = "createdAt asc")]
        CreatedAtasc,
        
        /// <summary>
        /// Enum UpdatedAtasc for value: updatedAt asc
        /// </summary>
        [EnumMember(Value = "updatedAt asc")]
        UpdatedAtasc,
        
        /// <summary>
        /// Enum Platformasc for value: platform asc
        /// </summary>
        [EnumMember(Value = "platform asc")]
        Platformasc,
        
        /// <summary>
        /// Enum Namedesc for value: name desc
        /// </summary>
        [EnumMember(Value = "name desc")]
        Namedesc,
        
        /// <summary>
        /// Enum StartDatedesc for value: startDate desc
        /// </summary>
        [EnumMember(Value = "startDate desc")]
        StartDatedesc,
        
        /// <summary>
        /// Enum EndDatedesc for value: endDate desc
        /// </summary>
        [EnumMember(Value = "endDate desc")]
        EndDatedesc,
        
        /// <summary>
        /// Enum Typedesc for value: type desc
        /// </summary>
        [EnumMember(Value = "type desc")]
        Typedesc,
        
        /// <summary>
        /// Enum Statusdesc for value: status desc
        /// </summary>
        [EnumMember(Value = "status desc")]
        Statusdesc,
        
        /// <summary>
        /// Enum JobNumberdesc for value: jobNumber desc
        /// </summary>
        [EnumMember(Value = "jobNumber desc")]
        JobNumberdesc,
        
        /// <summary>
        /// Enum ConstructionTypedesc for value: constructionType desc
        /// </summary>
        [EnumMember(Value = "constructionType desc")]
        ConstructionTypedesc,
        
        /// <summary>
        /// Enum DeliveryMethoddesc for value: deliveryMethod desc
        /// </summary>
        [EnumMember(Value = "deliveryMethod desc")]
        DeliveryMethoddesc,
        
        /// <summary>
        /// Enum ContractTypedesc for value: contractType desc
        /// </summary>
        [EnumMember(Value = "contractType desc")]
        ContractTypedesc,
        
        /// <summary>
        /// Enum CurrentPhasedesc for value: currentPhase desc
        /// </summary>
        [EnumMember(Value = "currentPhase desc")]
        CurrentPhasedesc,
        
        /// <summary>
        /// Enum CreatedAtdesc for value: createdAt desc
        /// </summary>
        [EnumMember(Value = "createdAt desc")]
        CreatedAtdesc,
        
        /// <summary>
        /// Enum UpdatedAtdesc for value: updatedAt desc
        /// </summary>
        [EnumMember(Value = "updatedAt desc")]
        UpdatedAtdesc,
        
        /// <summary>
        /// Enum Platformdesc for value: platform desc
        /// </summary>
        [EnumMember(Value = "platform desc")]
        Platformdesc
    }

}
