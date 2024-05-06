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
    /// IntrospectToken
    /// </summary>
    [DataContract]
    public partial class IntrospectToken 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntrospectToken" /> class.
        /// </summary>
        public IntrospectToken()
        {
        }
        
        /// <summary>
        ///`true`: The token is active.
///
///`false`: The token is expired, invalid, or revoked.
        /// </summary>
        /// <value>
        ///`true`: The token is active.
///
///`false`: The token is expired, invalid, or revoked.
        /// </value>
        [DataMember(Name="active", EmitDefaultValue=false)]
        public bool? Active { get; set; }

        /// <summary>
        ///A URL-encoded, space separated list of scopes associated with the token.
        /// </summary>
        /// <value>
        ///A URL-encoded, space separated list of scopes associated with the token.
        /// </value>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public string Scope { get; set; }

        /// <summary>
        ///The Client ID of the application associated with the token.
        /// </summary>
        /// <value>
        ///The Client ID of the application associated with the token.
        /// </value>
        [DataMember(Name="client_id", EmitDefaultValue=false)]
        public string ClientId { get; set; }

        /// <summary>
        ///The expiration time of the token, represented as a Unix timestamp.
        /// </summary>
        /// <value>
        ///The expiration time of the token, represented as a Unix timestamp.
        /// </value>
        [DataMember(Name="exp", EmitDefaultValue=false)]
        public int? Exp { get; set; }

        /// <summary>
        ///The ID of the user who authorized the token.
        /// </summary>
        /// <value>
        ///The ID of the user who authorized the token.
        /// </value>
        [DataMember(Name="userid", EmitDefaultValue=false)]
        public string Userid { get; set; }

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
