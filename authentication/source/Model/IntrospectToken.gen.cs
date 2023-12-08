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
    /// The response body for the introspection of access token.
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
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active", EmitDefaultValue=false)]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets Scope
        /// </summary>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or Sets ClientId
        /// </summary>
        [DataMember(Name="client_id", EmitDefaultValue=false)]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or Sets Exp
        /// </summary>
        [DataMember(Name="exp", EmitDefaultValue=false)]
        public int? Exp { get; set; }

        /// <summary>
        /// Gets or Sets Userid
        /// </summary>
        [DataMember(Name="userid", EmitDefaultValue=false)]
        public string UserId { get; set; }


         /// <summary>
        /// Gets or Sets Token type
        /// </summary>
        [DataMember(Name="token_type", EmitDefaultValue=false)]
        public string TokenType { get; set; }


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
