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
    /// Specifies the scope for the token you are requesting. See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a complete list of possible values.
    /// </summary>
    ///<value>Specifies the scope for the token you are requesting. See the [Developer's Guide documentation on scopes](/en/docs/oauth/v2/developers_guide/scopes/) for a complete list of possible values.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Scopes
    {
        
        /// <summary>
        /// Enum Userread for value: user:read
        /// </summary>
        [EnumMember(Value = "user:read")]
        UserRead,
        
        /// <summary>
        /// Enum Userwrite for value: user:write
        /// </summary>
        [EnumMember(Value = "user:write")]
        UserWrite,
        
        /// <summary>
        /// Enum UserProfileread for value: user-profile:read
        /// </summary>
        [EnumMember(Value = "user-profile:read")]
        UserProfileRead,
        
        /// <summary>
        /// Enum Viewablesread for value: viewables:read
        /// </summary>
        [EnumMember(Value = "viewables:read")]
        ViewablesRead,
        
        /// <summary>
        /// Enum Dataread for value: data:read
        /// </summary>
        [EnumMember(Value = "data:read")]
        DataRead,
        
        /// <summary>
        /// Enum DatareadURNOFRESOURCE for value: data:read:&lt;URN_OF_RESOURCE&gt;
        /// </summary>
        [EnumMember(Value = "data:read:<URN_OF_RESOURCE>")]
        DataReadURNOFRESOURCE,
        
        /// <summary>
        /// Enum Datawrite for value: data:write
        /// </summary>
        [EnumMember(Value = "data:write")]
        DataWrite,
        
        /// <summary>
        /// Enum Datacreate for value: data:create
        /// </summary>
        [EnumMember(Value = "data:create")]
        DataCreate,
        
        /// <summary>
        /// Enum Datasearch for value: data:search
        /// </summary>
        [EnumMember(Value = "data:search")]
        DataSearch,
        
        /// <summary>
        /// Enum Bucketcreate for value: bucket:create
        /// </summary>
        [EnumMember(Value = "bucket:create")]
        BucketCreate,
        
        /// <summary>
        /// Enum Bucketread for value: bucket:read
        /// </summary>
        [EnumMember(Value = "bucket:read")]
        BucketRead,
        
        /// <summary>
        /// Enum Bucketupdate for value: bucket:update
        /// </summary>
        [EnumMember(Value = "bucket:update")]
        BucketUpdate,
        
        /// <summary>
        /// Enum Bucketdelete for value: bucket:delete
        /// </summary>
        [EnumMember(Value = "bucket:delete")]
        BucketDelete,
        
        /// <summary>
        /// Enum Codeall for value: code:all
        /// </summary>
        [EnumMember(Value = "code:all")]
        CodeAll,
        
        /// <summary>
        /// Enum Accountread for value: account:read
        /// </summary>
        [EnumMember(Value = "account:read")]
        AccountRead,
        
        /// <summary>
        /// Enum Accountwrite for value: account:write
        /// </summary>
        [EnumMember(Value = "account:write")]
        AccountWrite,
        
        /// <summary>
        /// Enum Openid for value: openid
        /// </summary>
        [EnumMember(Value = "openid")]
        OpenId
    }

}
