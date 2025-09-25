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
/// Describes the creation of the service account.
/// </summary>
[DataContract]
public partial class ServiceAccountCreatePayload
{
   /// <summary>
   /// Initializes a new instance of the <see cref="ServiceAccountCreatePayload" /> class.
   /// </summary>
   public ServiceAccountCreatePayload()
	{ }

   /// <summary>
   /// The name of the service account.
   /// Must be 5-100 characters long, contain only alphanumeric characters and dashes, and include at least one alphanumeric character.
   /// </summary>
   /// <value>
   /// The name of the service account.
   /// Must be 5-100 characters long, contain only alphanumeric characters and dashes, and include at least one alphanumeric character.
   /// </value>
   [DataMember(Name = "name", EmitDefaultValue = false)]
   public string Name { get; set; }

   /// <summary>
   /// The last name of the service account. For display purposes only.
   /// Must meet the following conditions:
   /// Length between 5 and 100 characters
   /// Contain only alphanumeric characters and dashes
   /// Include at least one alphanumeric character
   /// Avoid inappropriate words
   /// Exclude invalid characters such as the special characters % and /.
   /// Avoid the character pattern of &amp;# even though the characters are allowed individually.
   /// For more information, see the [Naming Guidelines](/en/docs/ssa/v1/developers_guide/naming-guidelines/) section in the Developer's Guide.
   /// </summary>
   /// <value>
   /// The last name of the service account. For display purposes only.
   /// Must meet the following conditions:
   /// Length between 5 and 100 characters
   /// Contain only alphanumeric characters and dashes
   /// Include at least one alphanumeric character
   /// Avoid inappropriate words
   /// Exclude invalid characters such as the special characters % and /.
   /// Avoid the character pattern of &amp;# even though the characters are allowed individually.
   /// For more information, see the [Naming Guidelines](/en/docs/ssa/v1/developers_guide/naming-guidelines/) section in the Developer's Guide.
   /// </value>
   [DataMember(Name = "firstName", EmitDefaultValue = false)]
   public string FirstName { get; set; }

   /// <summary>
   /// The last name of the service account. For display purposes only.
   /// Must meet the following conditions:
   /// Length between 5 and 100 characters
   /// Contain only alphanumeric characters and dashes
   /// Include at least one alphanumeric character
   /// Avoid inappropriate words
   /// Exclude invalid characters such as the special characters % and /.
   /// Avoid the character pattern of &amp;# even though the characters are allowed individually.
   /// For more information, see the [Naming Guidelines](/en/docs/ssa/v1/developers_guide/naming-guidelines/) section in the Developer's Guide.
   /// </summary>
   /// <value>
   /// The last name of the service account. For display purposes only.
   /// Must meet the following conditions:
   /// Length between 5 and 100 characters
   /// Contain only alphanumeric characters and dashes
   /// Include at least one alphanumeric character
   /// Avoid inappropriate words
   /// Exclude invalid characters such as the special characters % and /.
   /// Avoid the character pattern of &amp;# even though the characters are allowed individually.
   /// For more information, see the [Naming Guidelines](/en/docs/ssa/v1/developers_guide/naming-guidelines/) section in the Developer's Guide.
   /// </value>
   [DataMember(Name = "lastName", EmitDefaultValue = false)]
   public string LastName { get; set; }

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
