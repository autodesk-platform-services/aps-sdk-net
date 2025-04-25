/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Account.Admin
 *
 * The Account Admin API automates creating and managing projects, assigning and managing project users, and managing member and partner company directories. You can also synchronize data with external systems. 
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

namespace Autodesk.Construction.AccountAdmin.Model
{
    /// <summary>
    /// User Projects Pagination
    /// </summary>
    [DataContract]
    public partial class UserProjectsPagination 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProjectsPagination" /> class.
        /// </summary>
        public UserProjectsPagination()
        { }
        
        /// <summary>
        /// The number of items per page.
        /// </summary>
        /// <value>
        /// The number of items per page.
        /// </value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }

        /// <summary>
        /// The page number that the results begin from.
        /// </summary>
        /// <value>
        /// The page number that the results begin from.
        /// </value>
        [DataMember(Name="offset", EmitDefaultValue=false)]
        public int? Offset { get; set; }

        /// <summary>
        /// The number of items in the response.
        /// </summary>
        /// <value>
        /// The number of items in the response.
        /// </value>
        [DataMember(Name="totalResults", EmitDefaultValue=false)]
        public int? TotalResults { get; set; }

        /// <summary>
        /// The URL for the next page of records.
        /// Max length: 2000
        /// </summary>
        /// <value>
        /// The URL for the next page of records.
        /// Max length: 2000
        /// </value>
        [DataMember(Name="nextUrl", EmitDefaultValue=false)]
        public string NextUrl { get; set; }

        /// <summary>
        /// The URL for the previous page of records.
        /// Max length: 2000
        /// </summary>
        /// <value>
        /// The URL for the previous page of records.
        /// Max length: 2000
        /// </value>
        [DataMember(Name="previousUrl", EmitDefaultValue=false)]
        public string PreviousUrl { get; set; }

        /// <summary>
        /// The string presentation of the object.
        /// </summary>
        /// <returns>
        /// The string presentation of the object.
        /// </returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}
