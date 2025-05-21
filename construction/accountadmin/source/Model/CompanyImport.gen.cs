/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// CompanyImport
    /// </summary>
    [DataContract]
    public partial class CompanyImport 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyImport" /> class.
        /// </summary>
        public CompanyImport()
        {
        }
        
        /// <summary>
        ///Import success company count
        /// </summary>
        /// <value>
        ///Import success company count
        /// </value>
        [DataMember(Name="success", EmitDefaultValue=false)]
        public int Success { get; set; }

        /// <summary>
        ///Import failure company count
        /// </summary>
        /// <value>
        ///Import failure company count
        /// </value>
        [DataMember(Name="failure", EmitDefaultValue=false)]
        public int Failure { get; set; }

        /// <summary>
        ///Array of company objects that were successfully imported
        /// </summary>
        /// <value>
        ///Array of company objects that were successfully imported
        /// </value>
        [DataMember(Name="success_items", EmitDefaultValue=false)]
        public List<Company> SuccessItems { get; set; }

        /// <summary>
        ///Array of company objects that failed to import, along with content and error information
        /// </summary>
        /// <value>
        ///Array of company objects that failed to import, along with content and error information
        /// </value>
        [DataMember(Name="failure_items", EmitDefaultValue=false)]
        public List<Company> FailureItems { get; set; }

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
