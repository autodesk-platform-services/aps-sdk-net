/* 
 * APS SDK
 *
 * Autodesk Platform Services contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication.SecureServiceAccount
 *
 * OAuth2 server-to-server account, key, and token management API.
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

namespace Autodesk.Authentication.SecureServiceAccount.Model;

/// <summary>
/// Represents a key associated with the service account.
/// </summary>
[DataContract]
public partial class Key
{
   /// <summary>
   /// Initializes a new instance of the <see cref="Key" /> class.
   /// </summary>
   public Key()
   { }

   /// <summary>
   /// The ID of the private key.
   /// </summary>
   /// <value>
   /// The ID of the private key.
   /// </value>
   [DataMember(Name = "kid", EmitDefaultValue = false)]
   public string Kid { get; set; }

   /// <summary>
   /// The status of the key. Possible values:
   /// 
   /// - `ENABLED` -
   /// - `DISABLED` -
   /// 
   /// </summary>
   /// <value>
   /// The status of the key. Possible values:
   /// 
   /// - `ENABLED` -
   /// - `DISABLED` -
   /// 
   /// </value>
   [DataMember(Name = "status", EmitDefaultValue = true)]
   public KeyStatus Status { get; set; }

   /// <summary>
   /// The creation time of the key, in UTC format.
   /// </summary>
   /// <value>
   /// The creation time of the key, in UTC format.
   /// </value>
   [DataMember(Name = "createdAt", EmitDefaultValue = false)]
   public string CreatedAt { get; set; }

   /// <summary>
   /// This is the most recent time an access token was generated for this service account key, in UTC format.
   /// </summary>
   /// <value>
   /// This is the most recent time an access token was generated for this service account key, in UTC format.
   /// </value>
   [DataMember(Name = "accessedAt", EmitDefaultValue = false)]
   public string AccessedAt { get; set; }
}
