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
    /// OIDC Specification
    /// </summary>
    [DataContract]
    public partial class OidcSpec 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OidcSpec" /> class.
        /// </summary>
        public OidcSpec()
        {
        }
        
        /// <summary>
        /// Gets or Sets Issuer
        /// </summary>
        [DataMember(Name="issuer", EmitDefaultValue=false)]
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or Sets AuthorizationEndpoint
        /// </summary>
        [DataMember(Name="authorization_endpoint", EmitDefaultValue=false)]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        /// Gets or Sets TokenEndpoint
        /// </summary>
        [DataMember(Name="token_endpoint", EmitDefaultValue=false)]
        public string TokenEndpoint { get; set; }

        /// <summary>
        /// Gets or Sets UserinfoEndpoint
        /// </summary>
        [DataMember(Name="userinfo_endpoint", EmitDefaultValue=false)]
        public string UserinfoEndpoint { get; set; }

        /// <summary>
        /// Gets or Sets JwksUri
        /// </summary>
        [DataMember(Name="jwks_uri", EmitDefaultValue=false)]
        public string JwksUri { get; set; }

        /// <summary>
        /// Gets or Sets RevocationEndpoint
        /// </summary>
        [DataMember(Name="revocation_endpoint", EmitDefaultValue=false)]
        public string RevocationEndpoint { get; set; }

        /// <summary>
        /// Gets or Sets IntrospectionEndpoint
        /// </summary>
        [DataMember(Name="introspection_endpoint", EmitDefaultValue=false)]
        public string IntrospectionEndpoint { get; set; }

        /// <summary>
        /// Gets or Sets ScopesSupported
        /// </summary>
        [DataMember(Name="scopes_supported", EmitDefaultValue=false)]
        public List<string> ScopesSupported { get; set; }

        /// <summary>
        /// Gets or Sets ResponseTypesSupported
        /// </summary>
        [DataMember(Name="response_types_supported", EmitDefaultValue=false)]
        public List<string> ResponseTypesSupported { get; set; }

        /// <summary>
        /// Gets or Sets ResponseModesSupported
        /// </summary>
        [DataMember(Name="response_modes_supported", EmitDefaultValue=false)]
        public List<string> ResponseModesSupported { get; set; }

        /// <summary>
        /// Gets or Sets GrantTypesSupported
        /// </summary>
        [DataMember(Name="grant_types_supported", EmitDefaultValue=false)]
        public List<string> GrantTypesSupported { get; set; }

        /// <summary>
        /// Gets or Sets SubjectTypesSupported
        /// </summary>
        [DataMember(Name="subject_types_supported", EmitDefaultValue=false)]
        public List<string> SubjectTypesSupported { get; set; }

        /// <summary>
        /// Gets or Sets IdTokenSigningAlgValuesSupported
        /// </summary>
        [DataMember(Name="id_token_signing_alg_values_supported", EmitDefaultValue=false)]
        public List<string> IdTokenSigningAlgValuesSupported { get; set; }

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
