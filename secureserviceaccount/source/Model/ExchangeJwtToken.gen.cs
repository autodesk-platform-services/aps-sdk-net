/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Secure Service Account
 * Operations to manage Service accounts and keys.   A service account is an identity that an application can use to make requests to other services without a user authorizing the requests. A service account is identified by a unique email address and has an Autodesk ID.  A service account has one or more private keys. A private key is generated through an asymmetric cryptography algorithm; the paired public key is stored by Autodesk Identity.  An application can use a service account's private key to generate a JWT token. The JWT token provides proof of implicit authentication and authorization for this service account; an application can exchange it for a three-legged access token for the service service.
 *
 * Contact: aps.help@autodesk.com
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
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Autodesk.SecureServiceAccount.Model
{
    /// <summary>
    /// The response for exchange JWT
    /// </summary>
    [DataContract]
    public partial class ExchangeJwtToken
    {

        private int _expiresIn;
        private long _expiresAt;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeJwtToken" /> class.
        /// </summary>
        public ExchangeJwtToken()
        {
        }

        /// <summary>
        ///access token value
        /// </summary>
        /// <value>
        ///access token value
        /// </value>
        [DataMember(Name = "access_token", EmitDefaultValue = false)]
        public string AccessToken { get; set; }

        /// <summary>
        ///type of token
        /// </summary>
        /// <value>
        ///type of token
        /// </value>
        [DataMember(Name = "token_type", EmitDefaultValue = true)]
        public string TokenType { get; set; }

        /// <summary>
        ///access token expiry time in seconds
        /// </summary>
        /// <value>
        ///access token expiry time in seconds
        /// </value>
        [DataMember(Name = "expires_in", EmitDefaultValue = false)]
        public int ExpiresIn
        {

            get { return _expiresIn; }
            set
            {
                _expiresIn = value;
                _expiresAt = DateTimeOffset.Now.ToUnixTimeSeconds() + _expiresIn;

            }
        }

        /// <summary>
        /// Time the access token will expire at, in Unix seconds.
        /// </summary>
        /// <value>
        ///Time the access token will expire at, in Unix seconds.
        /// </value>
        [DataMember(Name = "expires_at", EmitDefaultValue = false)]
        public long? ExpiresAt { get { return _expiresAt; } }

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
