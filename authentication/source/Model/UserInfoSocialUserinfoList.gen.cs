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
    /// UserInfoSocialUserinfoList
    /// </summary>
    [DataContract]
    public partial class UserInfoSocialUserinfoList 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoSocialUserinfoList" /> class.
        /// </summary>
        public UserInfoSocialUserinfoList()
        {
        }
        
        /// <summary>
        ///The ID of the user within the social media platform.
        /// </summary>
        /// <value>
        ///The ID of the user within the social media platform.
        /// </value>
        [DataMember(Name="socialUserId", EmitDefaultValue=false)]
        public string SocialUserId { get; set; }

        /// <summary>
        ///The ID of the social media platform.
        /// </summary>
        /// <value>
        ///The ID of the social media platform.
        /// </value>
        [DataMember(Name="providerId", EmitDefaultValue=false)]
        public string ProviderId { get; set; }

        /// <summary>
        ///The name of teh social media platform.
        /// </summary>
        /// <value>
        ///The name of teh social media platform.
        /// </value>
        [DataMember(Name="providerName", EmitDefaultValue=false)]
        public string ProviderName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
