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

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Autodesk.SecureServiceAccount.Model
{
    /// <summary>
    /// The request body for create service account
    /// </summary>
    [DataContract]
    public partial class CreateServiceAccountPayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceAccountPayload" /> class.
        /// </summary>
        public CreateServiceAccountPayload()
        {
        }

        /// <summary>
        ///The name of the service account. This name must be between 5 and 100 characters, and can contain alphanumeric characters and dashes, and include at least one alphanumeric character.
        /// </summary>
        /// <value>
        ///The name of the service account. This name must be between 5 and 100 characters, and can contain alphanumeric characters and dashes, and include at least one alphanumeric character.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///The first name of the service account. For display purposes only. Must meet the following conditions: Length between 5 and 100 characters, contain only alphanumeric characters, dashes, and underscores, include at least one alphanumeric character, avoid inappropriate words, exclude invalid characters such as % and /, and avoid the character pattern &amp;#. For more information, see Naming Guidelines.
        /// </summary>
        /// <value>
        ///The first name of the service account. For display purposes only. Must meet the following conditions: Length between 5 and 100 characters, contain only alphanumeric characters, dashes, and underscores, include at least one alphanumeric character, avoid inappropriate words, exclude invalid characters such as % and /, and avoid the character pattern &amp;#. For more information, see Naming Guidelines.
        /// </value>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        ///The last name of the service account. For display purposes only. Must meet the following conditions: Length between 5 and 100 characters, contain only alphanumeric characters and dashes, include at least one alphanumeric character, avoid inappropriate words, exclude invalid characters such as % and /, and avoid the character pattern &amp;#. For more information, see Naming Guidelines.
        /// </summary>
        /// <value>
        ///The last name of the service account. For display purposes only. Must meet the following conditions: Length between 5 and 100 characters, contain only alphanumeric characters and dashes, include at least one alphanumeric character, avoid inappropriate words, exclude invalid characters such as % and /, and avoid the character pattern &amp;#. For more information, see Naming Guidelines.
        /// </value>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

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
