/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Issues
 *
 * An issue is an item that is created in ACC for tracking, managing and communicating tasks, problems and other points of concern through to resolution. You can manage different types of issues, such as design, safety, and commissioning. We currently support issues that are associated with a project.
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

namespace Autodesk.Constructionissues.Model
{
    /// <summary>
    /// The pagination object defining the limit, offset, total number of issues, next and previous URL
    /// </summary>
    [DataContract]
    public partial class IssuesPagination 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuesPagination" /> class.
        /// </summary>
        public IssuesPagination()
        {
        }
        
        /// <summary>
        /// The maximum number of issues to be returned in each page.
        /// </summary>
        /// <value>The maximum number of issues to be returned in each page.</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }

        /// <summary>
        /// The offset defining the start position from where the issues are returned
        /// </summary>
        /// <value>The offset defining the start position from where the issues are returned</value>
        [DataMember(Name="offset", EmitDefaultValue=false)]
        public int? Offset { get; set; }

        /// <summary>
        /// The total number of issues including the ones of the current page
        /// </summary>
        /// <value>The total number of issues including the ones of the current page</value>
        [DataMember(Name="totalResults", EmitDefaultValue=false)]
        public int? TotalResults { get; set; }

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
