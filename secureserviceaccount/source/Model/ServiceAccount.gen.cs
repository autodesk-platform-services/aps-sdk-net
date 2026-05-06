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
    /// Contains the details of a newly created service account
    /// </summary>
    [DataContract]
    public partial class ServiceAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceAccount" /> class.
        /// </summary>
        public ServiceAccount()
        {
        }

        /// <summary>
        ///The Autodesk ID of the service account
        /// </summary>
        /// <value>
        ///The Autodesk ID of the service account
        /// </value>
        [DataMember(Name = "serviceAccountId", EmitDefaultValue = false)]
        public string ServiceAccountId { get; set; }

        /// <summary>
        ///The email address of the service account. It is of the form &lt;serviceAccountName&gt;@&lt;clientID&gt;.adskserviceaccount.autodesk.com.
        /// </summary>
        /// <value>
        ///The email address of the service account. It is of the form &lt;serviceAccountName&gt;@&lt;clientID&gt;.adskserviceaccount.autodesk.com.
        /// </value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

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
