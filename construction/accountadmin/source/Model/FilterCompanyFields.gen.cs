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
    /// Defines filterCompanyFields
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FilterCompanyFields
    {
        
        /// <summary>
        /// Enum AccountId for value: accountId
        /// </summary>
        [EnumMember(Value = "accountId")]
        AccountId,
        
        /// <summary>
        /// Enum Name for value: name
        /// </summary>
        [EnumMember(Value = "name")]
        Name,
        
        /// <summary>
        /// Enum Trade for value: trade
        /// </summary>
        [EnumMember(Value = "trade")]
        Trade,
        
        /// <summary>
        /// Enum Addresses for value: addresses
        /// </summary>
        [EnumMember(Value = "addresses")]
        Addresses,
        
        /// <summary>
        /// Enum WebsiteUrl for value: websiteUrl
        /// </summary>
        [EnumMember(Value = "websiteUrl")]
        WebsiteUrl,
        
        /// <summary>
        /// Enum Description for value: description
        /// </summary>
        [EnumMember(Value = "description")]
        Description,
        
        /// <summary>
        /// Enum ErpId for value: erpId
        /// </summary>
        [EnumMember(Value = "erpId")]
        ErpId,
        
        /// <summary>
        /// Enum TaxId for value: taxId
        /// </summary>
        [EnumMember(Value = "taxId")]
        TaxId,
        
        /// <summary>
        /// Enum ImageUrl for value: imageUrl
        /// </summary>
        [EnumMember(Value = "imageUrl")]
        ImageUrl,
        
        /// <summary>
        /// Enum Status for value: status
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
        
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
        /// Enum ProjectSize for value: projectSize
        /// </summary>
        [EnumMember(Value = "projectSize")]
        ProjectSize,
        
        /// <summary>
        /// Enum UserSize for value: userSize
        /// </summary>
        [EnumMember(Value = "userSize")]
        UserSize,
        
        /// <summary>
        /// Enum OriginalName for value: originalName
        /// </summary>
        [EnumMember(Value = "originalName")]
        OriginalName
    }

}
