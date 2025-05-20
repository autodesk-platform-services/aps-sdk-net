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
    /// UserProject
    /// </summary>
    [DataContract]
    public partial class UserProject 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProject" /> class.
        /// </summary>
        public UserProject()
        {
        }
        
        /// <summary>
        ///Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        ///Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        ///Gets or Sets StartDate
        /// </summary>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        ///Gets or Sets EndDate
        /// </summary>
        [DataMember(Name="endDate", EmitDefaultValue=false)]
        public string EndDate { get; set; }

        /// <summary>
        ///Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        ///Gets or Sets Classification
        /// </summary>
        [DataMember(Name="classification", EmitDefaultValue=false)]
        public string Classification { get; set; }

        /// <summary>
        ///Gets or Sets ProjectValue
        /// </summary>
        [DataMember(Name="projectValue", EmitDefaultValue=false)]
        public UserProjectProjectValue ProjectValue { get; set; }

        /// <summary>
        ///Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        ///Gets or Sets JobNumber
        /// </summary>
        [DataMember(Name="jobNumber", EmitDefaultValue=false)]
        public string JobNumber { get; set; }

        /// <summary>
        ///Gets or Sets AddressLine1
        /// </summary>
        [DataMember(Name="addressLine1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        ///Gets or Sets AddressLine2
        /// </summary>
        [DataMember(Name="addressLine2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        ///Gets or Sets City
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        ///Gets or Sets StateOrProvince
        /// </summary>
        [DataMember(Name="stateOrProvince", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        ///Gets or Sets PostalCode
        /// </summary>
        [DataMember(Name="postalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///Gets or Sets Country
        /// </summary>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        ///Gets or Sets Latitude
        /// </summary>
        [DataMember(Name="latitude", EmitDefaultValue=false)]
        public string Latitude { get; set; }

        /// <summary>
        ///Gets or Sets Longitude
        /// </summary>
        [DataMember(Name="longitude", EmitDefaultValue=false)]
        public string Longitude { get; set; }

        /// <summary>
        ///Gets or Sets Timezone
        /// </summary>
        [DataMember(Name="timezone", EmitDefaultValue=false)]
        public string Timezone { get; set; }

        /// <summary>
        ///Gets or Sets Constructiontype
        /// </summary>
        [DataMember(Name="constructionType", EmitDefaultValue=false)]
        public string ConstructionType { get; set; }

        /// <summary>
        ///Gets or Sets DeliveryMethod
        /// </summary>
        [DataMember(Name="deliveryMethod", EmitDefaultValue=false)]
        public string DeliveryMethod { get; set; }

        /// <summary>
        ///Gets or Sets ContractType
        /// </summary>
        [DataMember(Name="contractType", EmitDefaultValue=false)]
        public string ContractType { get; set; }

        /// <summary>
        ///Gets or Sets CurrentPhase
        /// </summary>
        [DataMember(Name="currentPhase", EmitDefaultValue=false)]
        public string CurrentPhase { get; set; }

        /// <summary>
        ///Gets or Sets ImageUrl
        /// </summary>
        [DataMember(Name="imageUrl", EmitDefaultValue=false)]
        public string ImageUrl { get; set; }

        /// <summary>
        ///Gets or Sets ThumbnailImageUrl
        /// </summary>
        [DataMember(Name="thumbnailImageUrl", EmitDefaultValue=false)]
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        ///Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        ///Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        ///Gets or Sets AccountId
        /// </summary>
        [DataMember(Name="accountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }

        /// <summary>
        ///Gets or Sets SheetCount
        /// </summary>
        [DataMember(Name="sheetCount", EmitDefaultValue=false)]
        public int? SheetCount { get; set; }

        /// <summary>
        ///Gets or Sets Platform
        /// </summary>
        [DataMember(Name="platform", EmitDefaultValue=false)]
        public string Platform { get; set; }

        /// <summary>
        ///Gets or Sets AccessLevels
        /// </summary>
        [DataMember(Name="accessLevels", EmitDefaultValue=false)]
        public UserProjectAccessLevels AccessLevels { get; set; }

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
