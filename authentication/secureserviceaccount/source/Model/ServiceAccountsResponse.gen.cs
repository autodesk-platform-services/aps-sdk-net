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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Autodesk.Authentication.SecureServiceAccount.Model;

/// <summary>
/// Represents the response object for a collection of service accounts.
/// </summary>
[DataContract]
public partial class ServiceAccountsResponse
{
   /// <summary>
   /// Initializes a new instance of the <see cref="ServiceAccountsResponse" /> class.
   /// </summary>
   public ServiceAccountsResponse()
	{ }

   /// <summary>
   /// A collection of service accounts.
   /// </summary>
   /// <value>
   /// A collection of service accounts.
   /// </value>
   [DataMember(Name = "serviceAccounts", EmitDefaultValue = false)]
   public List<ServiceAccount> ServiceAccounts { get; set; }

	/// <summary>
	/// Returns the string presentation of the object.
	/// </summary>
	/// <returns>
	/// String presentation of the object.
	/// </returns>
	public override string ToString()
	{
		return JsonConvert.SerializeObject(this, Formatting.Indented);
	}
}
