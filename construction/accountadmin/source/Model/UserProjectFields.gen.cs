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
    /// Possible values: accessLevels, accountId, addressLine1, addressLine2, city, constructionType, country, createdAt, classification, deliveryMethod, endDate, imageUrl, jobNumber, latitude, longitude, name, platform, postalCode, projectValue, sheetCount, startDate, stateOrProvince, status, thumbnailImageUrl, timezone, type, updatedAt, contractType and currentPhase.
    /// </summary>
    ///<value>Possible values: accessLevels, accountId, addressLine1, addressLine2, city, constructionType, country, createdAt, classification, deliveryMethod, endDate, imageUrl, jobNumber, latitude, longitude, name, platform, postalCode, projectValue, sheetCount, startDate, stateOrProvince, status, thumbnailImageUrl, timezone, type, updatedAt, contractType and currentPhase.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum UserProjectFields
    {
        
        /// <summary>
        /// Enum AccessLevels for value: accessLevels
        /// </summary>
        [EnumMember(Value = "accessLevels")]
        AccessLevels,
        
        /// <summary>
        /// Enum AccountId for value: accountId
        /// </summary>
        [EnumMember(Value = "accountId")]
        AccountId,
        
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
        /// Enum ConstructionType for value: constructionType
        /// </summary>
        [EnumMember(Value = "constructionType")]
        ConstructionType,
        
        /// <summary>
        /// Enum Country for value: country
        /// </summary>
        [EnumMember(Value = "country")]
        Country,
        
        /// <summary>
        /// Enum CreatedAt for value: createdAt
        /// </summary>
        [EnumMember(Value = "createdAt")]
        CreatedAt,
        
        /// <summary>
        /// Enum Classification for value: classification
        /// </summary>
        [EnumMember(Value = "classification")]
        Classification,
        
        /// <summary>
        /// Enum DeliveryMethod for value: deliveryMethod
        /// </summary>
        [EnumMember(Value = "deliveryMethod")]
        DeliveryMethod,
        
        /// <summary>
        /// Enum EndDate for value: endDate
        /// </summary>
        [EnumMember(Value = "endDate")]
        EndDate,
        
        /// <summary>
        /// Enum ImageUrl for value: imageUrl
        /// </summary>
        [EnumMember(Value = "imageUrl")]
        ImageUrl,
        
        /// <summary>
        /// Enum JobNumber for value: jobNumber
        /// </summary>
        [EnumMember(Value = "jobNumber")]
        JobNumber,
        
        /// <summary>
        /// Enum Latitude for value: latitude
        /// </summary>
        [EnumMember(Value = "latitude")]
        Latitude,
        
        /// <summary>
        /// Enum Longitude for value: longitude
        /// </summary>
        [EnumMember(Value = "longitude")]
        Longitude,
        
        /// <summary>
        /// Enum Name for value: name
        /// </summary>
        [EnumMember(Value = "name")]
        Name,
        
        /// <summary>
        /// Enum Platform for value: platform
        /// </summary>
        [EnumMember(Value = "platform")]
        Platform,
        
        /// <summary>
        /// Enum PostalCode for value: postalCode
        /// </summary>
        [EnumMember(Value = "postalCode")]
        PostalCode,
        
        /// <summary>
        /// Enum ProjectValue for value: projectValue
        /// </summary>
        [EnumMember(Value = "projectValue")]
        ProjectValue,
        
        /// <summary>
        /// Enum SheetCount for value: sheetCount
        /// </summary>
        [EnumMember(Value = "sheetCount")]
        SheetCount,
        
        /// <summary>
        /// Enum StartDate for value: startDate
        /// </summary>
        [EnumMember(Value = "startDate")]
        StartDate,
        
        /// <summary>
        /// Enum StateOrProvince for value: stateOrProvince
        /// </summary>
        [EnumMember(Value = "stateOrProvince")]
        StateOrProvince,
        
        /// <summary>
        /// Enum Status for value: status
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
        
        /// <summary>
        /// Enum ThumbnailImageUrl for value: thumbnailImageUrl
        /// </summary>
        [EnumMember(Value = "thumbnailImageUrl")]
        ThumbnailImageUrl,
        
        /// <summary>
        /// Enum Timezone for value: timezone
        /// </summary>
        [EnumMember(Value = "timezone")]
        Timezone,
        
        /// <summary>
        /// Enum Type for value: type
        /// </summary>
        [EnumMember(Value = "type")]
        Type,
        
        /// <summary>
        /// Enum UpdatedAt for value: updatedAt
        /// </summary>
        [EnumMember(Value = "updatedAt")]
        UpdatedAt,
        
        /// <summary>
        /// Enum ContractType for value: contractType
        /// </summary>
        [EnumMember(Value = "contractType")]
        ContractType,
        
        /// <summary>
        /// Enum CurrentPhase for value: currentPhase
        /// </summary>
        [EnumMember(Value = "currentPhase")]
        CurrentPhase
    }

}
