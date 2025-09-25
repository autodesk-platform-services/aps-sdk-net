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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Authentication.SecureServiceAccount.Model;

/// <summary>
/// Specifies the status of the key associated with the service account. Possible values:
///
/// - `ENABLED` -
/// - `DISABLED` -
///
/// </summary>
/// <value>
/// Specifies the status of the key associated with the service account. Possible values:
///
/// - `ENABLED` -
/// - `DISABLED` -
///
/// </value>
[JsonConverter(typeof(StringEnumConverter))]
public enum ServiceAccountStatus
{
	/// <summary>
	/// Enum <see cref="Enabled"/> for value: ENABLED.
	/// </summary>
	[EnumMember(Value = "ENABLED")]
	Enabled,

	/// <summary>
	/// Enum <see cref="Disabled"/> for value: DISABLED.
	/// </summary>
	[EnumMember(Value = "DISABLED")]
	Disabled,
}
