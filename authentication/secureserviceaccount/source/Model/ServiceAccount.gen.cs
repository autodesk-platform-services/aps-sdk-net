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
using System.Runtime.Serialization;

namespace Autodesk.Authentication.SecureServiceAccount.Model;

/// <summary>
/// Represents a service account.
/// </summary>
[DataContract]
public partial class ServiceAccount
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ServiceAccount" /> class.
	/// </summary>
	public ServiceAccount()
	{ }

	/// <summary>
	/// The Autodesk ID of the service account.
	/// </summary>
	/// <value>
	/// The Autodesk ID of the service account.
	/// </value>
	[DataMember(Name = "serviceAccountId", EmitDefaultValue = false)]
	public string ServiceAccountId { get; set; }

	/// <summary>
	/// The email address of the service account.
	/// </summary>
	/// <value>
	/// The email address of the service account.
	/// </value>
	[DataMember(Name = "email", EmitDefaultValue = false)]
	public string Email { get; set; }

	/// <summary>
	/// The client ID used to create the service account.
	/// </summary>
	/// <value>
	/// The client ID used to create the service account.
	/// </value>
	[DataMember(Name = "createdBy", EmitDefaultValue = false)]
	public string CreatedBy { get; set; }

	/// <summary>
	/// The status of the service account. Possible values:
	/// 
	/// - `ENABLED` -
	/// - `DISABLED` -
	/// 
	/// </summary>
	/// <value>
	/// The status of the service account. Possible values:
	/// 
	/// - `ENABLED` -
	/// - `DISABLED` -
	/// 
	/// </value>
	[DataMember(Name = "status", EmitDefaultValue = true)]
	public ServiceAccountStatus Status { get; set; }

	/// <summary>
	/// The creation time of the service account, in UTC format.
	/// </summary>
	/// <value>
	/// The creation time of the service account, in UTC format.
	/// </value>
	[DataMember(Name = "createdAt", EmitDefaultValue = false)]
	public string CreatedAt { get; set; }

	/// <summary>
	/// This is the most recent time an access token was generated for this service account, in UTC format.
	/// </summary>
	/// <value>
	/// This is the most recent time an access token was generated for this service account, in UTC format.
	/// </value>
	[DataMember(Name = "accessedAt", EmitDefaultValue = false)]
	public string AccessedAt { get; set; }

	/// <summary>
	/// The expiration time of the service account, in UTC format.
	/// </summary>
	/// <value>
	/// The expiration time of the service account, in UTC format.
	/// </value>
	[DataMember(Name = "expiresAt", EmitDefaultValue = false)]
	public string ExpiresAt { get; set; }

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
