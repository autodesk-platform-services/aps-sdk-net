/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication
 *
 * OAuth2 token management APIs.
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

namespace Autodesk.Authentication.Model
{
    /// <summary>
    /// A JSON object containing information of the postal address of the user.
    /// </summary>
    [DataContract]
    public partial class UserInfoAddress 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoAddress" /> class.
        /// </summary>
        public UserInfoAddress()
        {
        }
        
        /// <summary>
        ///The street address part of the address. Can contain the house number, street name, postal code, and so on.  New lines are represented as `\n`.
        /// </summary>
        /// <value>
        ///The street address part of the address. Can contain the house number, street name, postal code, and so on.  New lines are represented as `\n`.
        /// </value>
        [DataMember(Name="street_address", EmitDefaultValue=false)]
        public string StreetAddress { get; set; }

        /// <summary>
        ///The city or locality part of the address.
        /// </summary>
        /// <value>
        ///The city or locality part of the address.
        /// </value>
        [DataMember(Name="locality", EmitDefaultValue=false)]
        public string Locality { get; set; }

        /// <summary>
        ///The state, province, prefecture, or region part of the address.
        /// </summary>
        /// <value>
        ///The state, province, prefecture, or region part of the address.
        /// </value>
        [DataMember(Name="region", EmitDefaultValue=false)]
        public string Region { get; set; }

        /// <summary>
        ///The zip code or postal code part of the address.
        /// </summary>
        /// <value>
        ///The zip code or postal code part of the address.
        /// </value>
        [DataMember(Name="postal_code", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        ///The country name part of the address.
        /// </summary>
        /// <value>
        ///The country name part of the address.
        /// </value>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

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
