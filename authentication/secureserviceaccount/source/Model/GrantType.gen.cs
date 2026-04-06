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
/// Specifies the grant type you are requesting the code for. Possible values are: 
///
/// - `urn:ietf:params:oauth:grant-type:jwt-bearer` -  For a jwt-bearer access token.
///
/// </summary>
/// <value>
/// Specifies the grant type you are requesting the code for. Possible values are: 
///
/// - `urn:ietf:params:oauth:grant-type:jwt-bearer` -  For a jwt-bearer access token.
///
/// </value>
[JsonConverter(typeof(StringEnumConverter))]
public enum GrantType
{
    /// <summary>
    /// Enum <see cref="JwtBearer"/> for value: urn:ietf:params:oauth:grant-type:jwt-bearer
    /// </summary>
    [EnumMember(Value = "urn:ietf:params:oauth:grant-type:jwt-bearer")]
    JwtBearer,
}
