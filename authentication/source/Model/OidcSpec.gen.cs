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
        ///The base URL of the openID Provider. Always `https://developer.api.autodesk.com` for APS.
        /// </summary>
        /// <value>
        ///The base URL of the openID Provider. Always `https://developer.api.autodesk.com` for APS.
        /// </value>
        [DataMember(Name="issuer", EmitDefaultValue=false)]
        public string Issuer { get; set; }

        /// <summary>
        ///The endpoint for authorizing users. It initiates the user authentication process in obtaining an authorization code grant.
        /// </summary>
        /// <value>
        ///The endpoint for authorizing users. It initiates the user authentication process in obtaining an authorization code grant.
        /// </value>
        [DataMember(Name="authorization_endpoint", EmitDefaultValue=false)]
        public string AuthorizationEndpoint { get; set; }

        /// <summary>
        ///The endpoint for acquiring access tokens and refresh tokens.
        /// </summary>
        /// <value>
        ///The endpoint for acquiring access tokens and refresh tokens.
        /// </value>
        [DataMember(Name="token_endpoint", EmitDefaultValue=false)]
        public string TokenEndpoint { get; set; }

        /// <summary>
        ///The endpoint for querying information about the authenticated user.
        /// </summary>
        /// <value>
        ///The endpoint for querying information about the authenticated user.
        /// </value>
        [DataMember(Name="userinfo_endpoint", EmitDefaultValue=false)]
        public string UserinfoEndpoint { get; set; }

        /// <summary>
        ///The endpoint for retrieving public keys used by APS, in the JWKS format.
        /// </summary>
        /// <value>
        ///The endpoint for retrieving public keys used by APS, in the JWKS format.
        /// </value>
        [DataMember(Name="jwks_uri", EmitDefaultValue=false)]
        public string JwksUri { get; set; }

        /// <summary>
        ///The endpoint for revoking an access token or refresh token.
        /// </summary>
        /// <value>
        ///The endpoint for revoking an access token or refresh token.
        /// </value>
        [DataMember(Name="revoke_endpoint", EmitDefaultValue=false)]
        public string RevokeEndpoint { get; set; }

        /// <summary>
        ///The endpoint for obtaining metadata about an access token or refresh token.
        /// </summary>
        /// <value>
        ///The endpoint for obtaining metadata about an access token or refresh token.
        /// </value>
        [DataMember(Name="introspection_endpoint", EmitDefaultValue=false)]
        public string IntrospectionEndpoint { get; set; }

        /// <summary>
        ///A list of supported scopes.
        /// </summary>
        /// <value>
        ///A list of supported scopes.
        /// </value>
        [DataMember(Name="scopes_supported", EmitDefaultValue=false)]
        public List<string> ScopesSupported { get; set; }

        /// <summary>
        ///A list of the response types supported by APS. Each response type represent a different flow.
        /// </summary>
        /// <value>
        ///A list of the response types supported by APS. Each response type represent a different flow.
        /// </value>
        [DataMember(Name="response_types_supported", EmitDefaultValue=false)]
        public List<string> ResponseTypesSupported { get; set; }

        /// <summary>
        ///A list of response modes supported by APS. Each response mode defines a different way of delivering an authorization response.
        /// </summary>
        /// <value>
        ///A list of response modes supported by APS. Each response mode defines a different way of delivering an authorization response.
        /// </value>
        [DataMember(Name="response_modes_supported", EmitDefaultValue=false)]
        public List<string> ResponseModesSupported { get; set; }

        /// <summary>
        ///A list of grant types supported by APS. Each grant type represents a different way an application can obtain an access token.
        /// </summary>
        /// <value>
        ///A list of grant types supported by APS. Each grant type represents a different way an application can obtain an access token.
        /// </value>
        [DataMember(Name="grant_types_supported", EmitDefaultValue=false)]
        public List<string> GrantTypesSupported { get; set; }

        /// <summary>
        ///A list of subject identifier types supported by APS.
        /// </summary>
        /// <value>
        ///A list of subject identifier types supported by APS.
        /// </value>
        [DataMember(Name="subject_types_supported", EmitDefaultValue=false)]
        public List<string> SubjectTypesSupported { get; set; }

        /// <summary>
        ///A list of all the token signing algorithms supported by APS.
        /// </summary>
        /// <value>
        ///A list of all the token signing algorithms supported by APS.
        /// </value>
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
