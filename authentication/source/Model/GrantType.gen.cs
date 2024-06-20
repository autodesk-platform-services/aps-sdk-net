/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication
 *
 * OAuth2 token management APIs.
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
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Authentication.Model
{
    /// <summary>
    /// Specifies the grant type you are requesting the code for. Possible values are: 
    ///
    ///- `client_credentials` -  For a 2-legged access token.
    ///- `authorization_code` - For a 3-legged access token.
    ///- `refresh_token` - For a refresh token.
    /// </summary>
    ///<value>Specifies the grant type you are requesting the code for. Possible values are: 
    ///
    ///- `client_credentials` -  For a 2-legged access token.
    ///- `authorization_code` - For a 3-legged access token.
    ///- `refresh_token` - For a refresh token.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum GrantType
    {

        /// <summary>
        /// Enum Clientcredentials for value: client_credentials
        /// </summary>
        [EnumMember(Value = "client_credentials")]
        ClientCredentials,

        /// <summary>
        /// Enum Authorizationcode for value: authorization_code
        /// </summary>
        [EnumMember(Value = "authorization_code")]
        AuthorizationCode,

        /// <summary>
        /// Enum Refreshtoken for value: refresh_token
        /// </summary>
        [EnumMember(Value = "refresh_token")]
        RefreshToken
    }

}
