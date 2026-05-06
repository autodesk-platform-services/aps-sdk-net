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
using Newtonsoft.Json.Converters;

namespace Autodesk.SecureServiceAccount.Model
{
    /// <summary>
    /// Defines scopes
    /// </summary>
    ///<value></value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Scopes
    {

        /// <summary>
        /// Enum UserRead for value: user:read
        /// </summary>
        [EnumMember(Value = "user:read")]
        UserRead,

        /// <summary>
        /// Enum UserWrite for value: user:write
        /// </summary>
        [EnumMember(Value = "user:write")]
        UserWrite,

        /// <summary>
        /// Enum UserProfileRead for value: user-profile:read
        /// </summary>
        [EnumMember(Value = "user-profile:read")]
        UserProfileRead,

        /// <summary>
        /// Enum ViewablesRead for value: viewables:read
        /// </summary>
        [EnumMember(Value = "viewables:read")]
        ViewablesRead,

        /// <summary>
        /// Enum DataRead for value: data:read
        /// </summary>
        [EnumMember(Value = "data:read")]
        DataRead,

        /// <summary>
        /// Enum DataReadUrnOfResource for value: data:read:&lt;URN_OF_RESOURCE&gt;
        /// </summary>
        [EnumMember(Value = "data:read:<URN_OF_RESOURCE>")]
        DataReadUrnOfResource,

        /// <summary>
        /// Enum DataWrite for value: data:write
        /// </summary>
        [EnumMember(Value = "data:write")]
        DataWrite,

        /// <summary>
        /// Enum DataCreate for value: data:create
        /// </summary>
        [EnumMember(Value = "data:create")]
        DataCreate,

        /// <summary>
        /// Enum DataSearch for value: data:search
        /// </summary>
        [EnumMember(Value = "data:search")]
        DataSearch,

        /// <summary>
        /// Enum BucketCreate for value: bucket:create
        /// </summary>
        [EnumMember(Value = "bucket:create")]
        BucketCreate,

        /// <summary>
        /// Enum BucketRead for value: bucket:read
        /// </summary>
        [EnumMember(Value = "bucket:read")]
        BucketRead,

        /// <summary>
        /// Enum BucketUpdate for value: bucket:update
        /// </summary>
        [EnumMember(Value = "bucket:update")]
        BucketUpdate,

        /// <summary>
        /// Enum BucketDelete for value: bucket:delete
        /// </summary>
        [EnumMember(Value = "bucket:delete")]
        BucketDelete,

        /// <summary>
        /// Enum CodeAll for value: code:all
        /// </summary>
        [EnumMember(Value = "code:all")]
        CodeAll,

        /// <summary>
        /// Enum AccountRead for value: account:read
        /// </summary>
        [EnumMember(Value = "account:read")]
        AccountRead,

        /// <summary>
        /// Enum AccountWrite for value: account:write
        /// </summary>
        [EnumMember(Value = "account:write")]
        AccountWrite,

        /// <summary>
        /// Enum OpenId for value: openid
        /// </summary>
        [EnumMember(Value = "openid")]
        OpenId,

        /// <summary>
        /// Enum ApplicationServiceAccountWrite for value: application:service_account:write
        /// </summary>
        [EnumMember(Value = "application:service_account:write")]
        ApplicationServiceAccountWrite,

        /// <summary>
        /// Enum ApplicationServiceAccountRead for value: application:service_account:read
        /// </summary>
        [EnumMember(Value = "application:service_account:read")]
        ApplicationServiceAccountRead,

        /// <summary>
        /// Enum ApplicationServiceAccountKeyWrite for value: application:service_account_key:write
        /// </summary>
        [EnumMember(Value = "application:service_account_key:write")]
        ApplicationServiceAccountKeyWrite,

        /// <summary>
        /// Enum ApplicationServiceAccountKeyRead for value: application:service_account_key:read
        /// </summary>
        [EnumMember(Value = "application:service_account_key:read")]
        ApplicationServiceAccountKeyRead
    }

}
