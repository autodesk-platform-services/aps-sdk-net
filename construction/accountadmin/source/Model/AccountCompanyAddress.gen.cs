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
    /// AccountCompanyAddress
    /// </summary>
    [DataContract]
    public partial class AccountCompanyAddress 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCompanyAddress" /> class.
        /// </summary>
        public AccountCompanyAddress()
        {
        }
        
        /// <summary>
        ///Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=true)]
        public AddressType Type { get; set; }

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
        ///Gets or Sets Phone
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

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
