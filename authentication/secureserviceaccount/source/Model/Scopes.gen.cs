/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
/// Specifies the scope for the token you are requesting.
/// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a complete list of possible values.
/// </summary>
///<value>
/// Specifies the scope for the token you are requesting.
/// See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a complete list of possible values.
///</value>    
[JsonConverter(typeof(StringEnumConverter))]
public enum Scopes
{

    /// <summary>
    /// Enum <see cref="UserRead"/> for value: user:read
    /// </summary>
    [EnumMember(Value = "user:read")]
    UserRead,

    /// <summary>
    /// Enum <see cref="UserWrite"/> for value: user:write
    /// </summary>
    [EnumMember(Value = "user:write")]
    UserWrite,

    /// <summary>
    /// Enum <see cref="UserProfileRead"/> for value: user-profile:read
    /// </summary>
    [EnumMember(Value = "user-profile:read")]
    UserProfileRead,

    /// <summary>
    /// Enum <see cref="ViewablesRead"/> for value: viewables:read
    /// </summary>
    [EnumMember(Value = "viewables:read")]
    ViewablesRead,

    /// <summary>
    /// Enum <see cref="DataRead"/> for value: data:read
    /// </summary>
    [EnumMember(Value = "data:read")]
    DataRead,

    /// <summary>
    /// Enum <see cref="DataReadURNOFRESOURCE"/> for value: data:read:&lt;URN_OF_RESOURCE&gt;
    /// </summary>
    [EnumMember(Value = "data:read:<URN_OF_RESOURCE>")]
    DataReadURNOFRESOURCE,

    /// <summary>
    /// Enum <see cref="DataWrite"/> for value: data:write
    /// </summary>
    [EnumMember(Value = "data:write")]
    DataWrite,

    /// <summary>
    /// Enum <see cref="DataCreate"/> for value: data:create
    /// </summary>
    [EnumMember(Value = "data:create")]
    DataCreate,

    /// <summary>
    /// Enum <see cref="DataSearch"/> for value: data:search
    /// </summary>
    [EnumMember(Value = "data:search")]
    DataSearch,

    /// <summary>
    /// Enum <see cref="BucketCreate"/> for value: bucket:create
    /// </summary>
    [EnumMember(Value = "bucket:create")]
    BucketCreate,

    /// <summary>
    /// Enum <see cref="BucketRead"/> for value: bucket:read
    /// </summary>
    [EnumMember(Value = "bucket:read")]
    BucketRead,

    /// <summary>
    /// Enum <see cref="BucketUpdate"/> for value: bucket:update
    /// </summary>
    [EnumMember(Value = "bucket:update")]
    BucketUpdate,

    /// <summary>
    /// Enum <see cref="BucketDelete"/> for value: bucket:delete
    /// </summary>
    [EnumMember(Value = "bucket:delete")]
    BucketDelete,

    /// <summary>
    /// Enum <see cref="CodeAll"/> for value: code:all
    /// </summary>
    [EnumMember(Value = "code:all")]
    CodeAll,

    /// <summary>
    /// Enum <see cref="AccountRead"/> for value: account:read
    /// </summary>
    [EnumMember(Value = "account:read")]
    AccountRead,

    /// <summary>
    /// Enum <see cref="AccountWrite"/> for value: account:write
    /// </summary>
    [EnumMember(Value = "account:write")]
    AccountWrite,

    /// <summary>
    /// Enum <see cref="OpenId"/> for value: openid
    /// </summary>
    [EnumMember(Value = "openid")]
    OpenId,

    /// <summary>
    /// Enum <see cref="ApplicationServiceAccountRead"/> for value: application:service_account:read
    /// </summary>
    [EnumMember(Value = "application:service_account:read")]
    ApplicationServiceAccountRead,

    /// <summary>
    /// Enum <see cref="ApplicationServiceAccountWrite"/> for value: application:service_account:write
    /// </summary>
    [EnumMember(Value = "application:service_account:write")]
    ApplicationServiceAccountWrite,

    /// <summary>
    /// Enum <see cref="ApplicationServiceAccountKeyRead"/> for value: application:service_account_key:read
    /// </summary>
    [EnumMember(Value = "application:service_account_key:read")]
    ApplicationServiceAccountKeyRead,

    /// <summary>
    /// Enum <see cref="ApplicationServiceAccountKeyWrite"/> for value: application:service_account_key:write
    /// </summary>
    [EnumMember(Value = "application:service_account_key:write")]
    ApplicationServiceAccountKeyWrite,
}
