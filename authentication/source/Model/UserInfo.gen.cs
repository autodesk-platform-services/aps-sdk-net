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
        /// UserInfo
        /// </summary>
        [DataContract]
        public partial class UserInfo
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="UserInfo" /> class.
                /// </summary>
                public UserInfo()
                {
                }

                /// <summary>
                ///The ID by which APS uniquely identifies the user.
                /// </summary>
                /// <value>
                ///The ID by which APS uniquely identifies the user.
                /// </value>
                [DataMember(Name = "sub", EmitDefaultValue = false)]
                public string Sub { get; set; }

                /// <summary>
                ///The full name of the user.
                /// </summary>
                /// <value>
                ///The full name of the user.
                /// </value>
                [DataMember(Name = "name", EmitDefaultValue = false)]
                public string Name { get; set; }

                /// <summary>
                ///The given name or first name of the user.
                /// </summary>
                /// <value>
                ///The given name or first name of the user.
                /// </value>
                [DataMember(Name = "given_name", EmitDefaultValue = false)]
                public string GivenName { get; set; }

                /// <summary>
                ///The surname or last name of the user.
                /// </summary>
                /// <value>
                ///The surname or last name of the user.
                /// </value>
                [DataMember(Name = "family_name", EmitDefaultValue = false)]
                public string FamilyName { get; set; }

                /// <summary>
                ///The username by which the user prefers to be addressed.
                /// </summary>
                /// <value>
                ///The username by which the user prefers to be addressed.
                /// </value>
                [DataMember(Name = "preferred_username", EmitDefaultValue = false)]
                public string PreferredUsername { get; set; }

                /// <summary>
                ///The email address by which the user prefers to be contacted.
                /// </summary>
                /// <value>
                ///The email address by which the user prefers to be contacted.
                /// </value>
                [DataMember(Name = "email", EmitDefaultValue = false)]
                public string Email { get; set; }

                /// <summary>
                ///`true` : The user's preferred email address is verified.
                ///
                ///`false`: The user's preferred email address is not verified.
                /// </summary>
                /// <value>
                ///`true` : The user's preferred email address is verified.
                ///
                ///`false`: The user's preferred email address is not verified.
                /// </value>
                [DataMember(Name = "email_verified", EmitDefaultValue = false)]
                public bool? EmailVerified { get; set; }

                /// <summary>
                ///The URL of the profile page of the user.
                /// </summary>
                /// <value>
                ///The URL of the profile page of the user.
                /// </value>
                [DataMember(Name = "profile", EmitDefaultValue = false)]
                public string Profile { get; set; }

                /// <summary>
                ///The URL of the profile picture of the user.
                /// </summary>
                /// <value>
                ///The URL of the profile picture of the user.
                /// </value>
                [DataMember(Name = "picture", EmitDefaultValue = false)]
                public string Picture { get; set; }

                /// <summary>
                ///The preferred language settings of the user. This setting is typically specified as a combination of the ISO 639 language code in lower case, and the ISO 3166 country code in upper case, separated by a dash character. For example `en-US`.
                /// </summary>
                /// <value>
                ///The preferred language settings of the user. This setting is typically specified as a combination of the ISO 639 language code in lower case, and the ISO 3166 country code in upper case, separated by a dash character. For example `en-US`.
                /// </value>
                [DataMember(Name = "locale", EmitDefaultValue = false)]
                public string Locale { get; set; }

                /// <summary>
                ///The time the user's information was most recently updated, represented as a Unix timestamp.
                /// </summary>
                /// <value>
                ///The time the user's information was most recently updated, represented as a Unix timestamp.
                /// </value>
                [DataMember(Name = "updated_at", EmitDefaultValue = false)]
                public int? UpdatedAt { get; set; }

                /// <summary>
                ///`true`: Two-factor authentication is enabled for this user. 
                ///
                ///`false`: Two-factor authentication is not enabled for this user.
                /// </summary>
                /// <value>
                ///`true`: Two-factor authentication is enabled for this user. 
                ///
                ///`false`: Two-factor authentication is not enabled for this user.
                /// </value>
                [DataMember(Name = "is_2fa_enabled", EmitDefaultValue = false)]
                public bool? Is2faEnabled { get; set; }

                /// <summary>
                ///The ISO 3166 country code that was assigned to the user when their profile was created.
                /// </summary>
                /// <value>
                ///The ISO 3166 country code that was assigned to the user when their profile was created.
                /// </value>
                [DataMember(Name = "country_code", EmitDefaultValue = false)]
                public string CountryCode { get; set; }

                /// <summary>
                ///Gets or Sets Address
                /// </summary>
                [DataMember(Name = "address", EmitDefaultValue = false)]
                public UserInfoAddress Address { get; set; }

                /// <summary>
                ///The phone number by which the user prefers to be contacted.
                /// </summary>
                /// <value>
                ///The phone number by which the user prefers to be contacted.
                /// </value>
                [DataMember(Name = "phone_number", EmitDefaultValue = false)]
                public string PhoneNumber { get; set; }

                /// <summary>
                ///`true` : The phone number is verified.
                ///
                ///`false` : The phone number is not verified.
                /// </summary>
                /// <value>
                ///`true` : The phone number is verified.
                ///
                ///`false` : The phone number is not verified.
                /// </value>
                [DataMember(Name = "phone_number_verified", EmitDefaultValue = false)]
                public bool? PhoneNumberVerified { get; set; }

                /// <summary>
                ///`true` :  Single sign-on using Lightweight Directory Access Protocol (LDAP) is enabled for this user.
                ///
                ///`false` : LDAP is not enabled for this user.
                /// </summary>
                /// <value>
                ///`true` :  Single sign-on using Lightweight Directory Access Protocol (LDAP) is enabled for this user.
                ///
                ///`false` : LDAP is not enabled for this user.
                /// </value>
                [DataMember(Name = "ldap_enabled", EmitDefaultValue = false)]
                public bool? LdapEnabled { get; set; }

                /// <summary>
                ///The domain name used by the LDAP server for user authentication. `null`, if `ldap_enabled` is `false`.
                /// </summary>
                /// <value>
                ///The domain name used by the LDAP server for user authentication. `null`, if `ldap_enabled` is `false`.
                /// </value>
                [DataMember(Name = "ldap_domain", EmitDefaultValue = false)]
                public string LdapDomain { get; set; }

                /// <summary>
                ///The job title of the user as specified in the user's profile.
                /// </summary>
                /// <value>
                ///The job title of the user as specified in the user's profile.
                /// </value>
                [DataMember(Name = "job_title", EmitDefaultValue = false)]
                public string JobTitle { get; set; }

                /// <summary>
                ///The industry the user works in, as specified in the user's profile.
                /// </summary>
                /// <value>
                ///The industry the user works in, as specified in the user's profile.
                /// </value>
                [DataMember(Name = "industry", EmitDefaultValue = false)]
                public string Industry { get; set; }

                /// <summary>
                ///A code that corresponds to the industry.
                /// </summary>
                /// <value>
                ///A code that corresponds to the industry.
                /// </value>
                [DataMember(Name = "industry_code", EmitDefaultValue = false)]
                public string IndustryCode { get; set; }

                /// <summary>
                ///A short description written by the user to introduce themselves, as specified in the user's profile.
                /// </summary>
                /// <value>
                ///A short description written by the user to introduce themselves, as specified in the user's profile.
                /// </value>
                [DataMember(Name = "about_me", EmitDefaultValue = false)]
                public string AboutMe { get; set; }

                /// <summary>
                ///The ISO 639 language code of the preferred language of the user.
                /// </summary>
                /// <value>
                ///The ISO 639 language code of the preferred language of the user.
                /// </value>
                [DataMember(Name = "language", EmitDefaultValue = false)]
                public string Language { get; set; }

                /// <summary>
                ///The company that the user works for, as specified in the user's profile.
                /// </summary>
                /// <value>
                ///The company that the user works for, as specified in the user's profile.
                /// </value>
                [DataMember(Name = "company", EmitDefaultValue = false)]
                public string Company { get; set; }

                /// <summary>
                ///The time the user profile was created, represented as a Unix timestamp.
                /// </summary>
                /// <value>
                ///The time the user profile was created, represented as a Unix timestamp.
                /// </value>
                [DataMember(Name = "created_date", EmitDefaultValue = false)]
                public string CreatedDate { get; set; }

                /// <summary>
                ///The time the user most recently signed-in to APS successfully, represented as a Unix timestamp.
                /// </summary>
                /// <value>
                ///The time the user most recently signed-in to APS successfully, represented as a Unix timestamp.
                /// </value>
                [DataMember(Name = "last_login_date", EmitDefaultValue = false)]
                public string LastLoginDate { get; set; }

                /// <summary>
                ///An ID to uniquely identify the user. For most users this will be the same as `sub`. However, for users profiles created on the now retired EIDM system `eidm_guid` will be different from `sub`.
                /// </summary>
                /// <value>
                ///An ID to uniquely identify the user. For most users this will be the same as `sub`. However, for users profiles created on the now retired EIDM system `eidm_guid` will be different from `sub`.
                /// </value>
                [DataMember(Name = "eidm_guid", EmitDefaultValue = false)]
                public string EidmGuid { get; set; }

                /// <summary>
                ///`true` : The user has agreed to receive marketing information.
                ///
                ///`false`: The user does not want to receive marketing information.
                /// </summary>
                /// <value>
                ///`true` : The user has agreed to receive marketing information.
                ///
                ///`false`: The user does not want to receive marketing information.
                /// </value>
                [DataMember(Name = "opt_in", EmitDefaultValue = false)]
                public bool? OptIn { get; set; }

                /// <summary>
                ///An array of objects, where each object represents a social media account that can be used to verify the user's identity.
                /// </summary>
                /// <value>
                ///An array of objects, where each object represents a social media account that can be used to verify the user's identity.
                /// </value>
                [DataMember(Name = "social_userinfo_list", EmitDefaultValue = false)]
                public List<UserInfoSocialUserinfoList> SocialUserinfoList { get; set; }

                /// <summary>
                ///An array of key-value pairs containing image URLs for various thumbnail sizes of the user's profile picture. The key is named `sizeX&lt;NUMBER&gt;` where `&lt;NUMBER&gt;` is the width and height of the thumbnail, in pixels. The corresponding value is the URL pointing to the thumbnail. For example, `sizeX200` would contain the URL for the 200x200 pixel thumbnail.
                /// </summary>
                /// <value>
                ///An array of key-value pairs containing image URLs for various thumbnail sizes of the user's profile picture. The key is named `sizeX&lt;NUMBER&gt;` where `&lt;NUMBER&gt;` is the width and height of the thumbnail, in pixels. The corresponding value is the URL pointing to the thumbnail. For example, `sizeX200` would contain the URL for the 200x200 pixel thumbnail.
                /// </value>
                [DataMember(Name = "thumbnails", EmitDefaultValue = false)]
                public List<Object> Thumbnails { get; set; }

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
