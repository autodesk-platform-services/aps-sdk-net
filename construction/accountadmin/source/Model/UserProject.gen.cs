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
    /// User Project
    /// </summary>
    [DataContract]
    public partial class UserProject
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProject" /> class.
        /// </summary>
        public UserProject()
        { }
        
        /// <summary>
        /// The internally generated ID for the project.
        /// </summary>
        /// <value>
        /// The internally generated ID for the project.
        /// </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the project.
        /// Max length: 255
        /// </summary>
        /// <value>
        /// The name of the project.
        /// Max length: 255
        /// </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The estimated start date for the project, in ISO 8601 format.
        /// </summary>
        /// <value>
        /// The estimated start date for the project, in ISO 8601 format.
        /// </value>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        /// The estimated end date for the project, in ISO 8601 format.
        /// </summary>
        /// <value>
        /// The estimated end date for the project, in ISO 8601 format.
        /// </value>
        [DataMember(Name="endDate", EmitDefaultValue=false)]
        public string EndDate { get; set; }

        /// <summary>
        /// The type of the project.
        /// </summary>
        /// <value>
        /// The type of the project.
        /// </value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// The project’s purpose. Possible values: production, template, component, sample.
        /// </summary>
        /// <value>
        /// The project’s purpose. Possible values: production, template, component, sample.
        /// </value>
        [DataMember(Name="classification", EmitDefaultValue=false)]
        public string Classification { get; set; }

        /// <summary>
        /// The value of the project. When updating the project value, both the value and currency parameters are required.
        /// </summary>
        /// <value>
        /// The value of the project. When updating the project value, both the value and currency parameters are required.
        /// </value>
        [DataMember(Name="projectValue", EmitDefaultValue=false)]
        public object ProjectValue { get; set; }

        /// <summary>
        /// The status of the project.
        /// </summary>
        /// <value>
        /// The status of the project.
        /// </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// A job identifier that’s defined for the project by the user. This ID was defined when the project was created.
        /// Max length: 100
        /// </summary>
        /// <value>
        /// A job identifier that’s defined for the project by the user. This ID was defined when the project was created.
        /// Max length: 100
        /// </value>
        [DataMember(Name="jobNumber", EmitDefaultValue=false)]
        public string JobNumber { get; set; }

        /// <summary>
        /// Address line 1 for the project.
        /// Max length: 255
        /// </summary>
        /// <value>
        /// Address line 1 for the project.
        /// Max length: 255
        /// </value>
        [DataMember(Name="addressLine1", EmitDefaultValue=false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2 for the project.
        /// Max length: 255
        /// </summary>
        /// <value>
        /// Address line 2 for the project.
        /// Max length: 255
        /// </value>
        [DataMember(Name="addressLine2", EmitDefaultValue=false)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// The city in which the project is located.
        /// </summary>
        /// <value>
        /// The city in which the project is located.
        /// </value>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// The state or province in which the project is located. Only valid state/province names and ISO 3166-1 alpha-2 codes is accepted. The provided state or province must exist in the country of the project.
        /// </summary>
        /// <value>
        /// The state or province in which the project is located. Only valid state/province names and ISO 3166-1 alpha-2 codes is accepted. The provided state or province must exist in the country of the project.
        /// </value>
        [DataMember(Name="stateOrProvince", EmitDefaultValue=false)]
        public string StateOrProvince { get; set; }

        /// <summary>
        /// The zip or postal code in which the project is located.
        /// </summary>
        /// <value>
        /// The zip or postal code in which the project is located.
        /// </value>
        [DataMember(Name="postalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country in which the project is located. Only valid country names and ISO 3166-1 alpha-2 codes is accepted.
        /// </summary>
        /// <value>
        /// The country in which the project is located. Only valid country names and ISO 3166-1 alpha-2 codes is accepted.
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// The latitude of the location of the project.
        /// </summary>
        /// <value>
        /// The latitude of the location of the project.
        /// </value>
        [DataMember(Name="latitude", EmitDefaultValue=false)]
        public string Latitude { get; set; }

        /// <summary>
        /// The longitude of the location of the project.
        /// </summary>
        /// <value>
        /// The longitude of the location of the project.
        /// </value>
        [DataMember(Name="longitude", EmitDefaultValue=false)]
        public string Longitude { get; set; }

        /// <summary>
        /// The time zone in which the project is located. Note that this field can be NULL.
        /// </summary>
        /// <value>
        /// The time zone in which the project is located. Note that this field can be NULL.
        /// </value>
        [DataMember(Name="timezone", EmitDefaultValue=false)]
        public string Timezone { get; set; }

        /// <summary>
        /// The construction type of the project. Following is a list of recommended values; however, any value is accepted.
        /// </summary>
        /// <value>
        /// The construction type of the project. Following is a list of recommended values; however, any value is accepted.
        /// </value>
        [DataMember(Name="constructionType", EmitDefaultValue=false)]
        public string ConstructionType { get; set; }

        /// <summary>
        /// The delivery method of the project. Following is a list of recommended values; however, any value is accepted.
        /// </summary>
        /// <value>
        /// The delivery method of the project. Following is a list of recommended values; however, any value is accepted.
        /// </value>
        [DataMember(Name="deliveryMethod", EmitDefaultValue=false)]
        public string DeliveryMethod { get; set; }

        /// <summary>
        /// The contract type of the project. Following is a list of recommended values; however, any value is accepted.
        /// </summary>
        /// <value>
        /// The contract type of the project. Following is a list of recommended values; however, any value is accepted.
        /// </value>
        [DataMember(Name="contractType", EmitDefaultValue=false)]
        public string ContractType { get; set; }

        /// <summary>
        /// The current phase of the project. Following is a list of recommended values; however, any value is accepted.
        /// </summary>
        /// <value>
        /// The current phase of the project. Following is a list of recommended values; however, any value is accepted.
        /// </value>
        [DataMember(Name="currentPhase", EmitDefaultValue=false)]
        public string CurrentPhase { get; set; }

        /// <summary>
        /// The URL of the project image.
        /// </summary>
        /// <value>
        /// The URL of the project image.
        /// </value>
        [DataMember(Name="imageUrl", EmitDefaultValue=false)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The URL of the project thumbnail image.
        /// </summary>
        /// <value>
        /// The URL of the project thumbnail image.
        /// </value>
        [DataMember(Name="thumbnailImageUrl", EmitDefaultValue=false)]
        public string ThumbnailImageUrl { get; set; }

        /// <summary>
        /// The timestamp when the project was created, in ISO 8601 format.
        /// </summary>
        /// <value>
        /// The timestamp when the project was created, in ISO 8601 format.
        /// </value>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The timestamp when the project was last updated, in ISO 8601 format.
        /// </summary>
        /// <value>
        /// The timestamp when the project was last updated, in ISO 8601 format.
        /// </value>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The ID of the account the project is associated with.
        /// </summary>
        /// <value>
        /// The ID of the account the project is associated with.
        /// </value>
        [DataMember(Name="accountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }

        /// <summary>
        /// The total number of sheets associated with the project.
        /// </summary>
        /// <value>
        /// The total number of sheets associated with the project.
        /// </value>
        [DataMember(Name="sheetCount", EmitDefaultValue=false)]
        public int? SheetCount { get; set; }

        /// <summary>
        /// The APS platform that the project belongs to.
        /// </summary>
        /// <value>
        /// The APS platform that the project belongs to.
        /// </value>
        [DataMember(Name="platform", EmitDefaultValue=false)]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or Sets AccessLevels.
        /// </summary>
        /// <value>
        /// Gets or Sets AccessLevels.
        /// </value>
        [DataMember(Name="accessLevels", EmitDefaultValue=false)]
        public ProjectUserAccessLevels AccessLevels { get; set; }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>
        /// String presentation of the object.
        /// </returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
