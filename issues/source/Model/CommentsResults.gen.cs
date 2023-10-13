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
    /// CommentsResults
    /// </summary>
    [DataContract]
    public partial class CommentsResults 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsResults" /> class.
        /// </summary>
        public CommentsResults()
        {
        }
        
        /// <summary>
        /// The comment ID.
        /// </summary>
        /// <value>The comment ID.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The comment content. A \\n indicates a new line, e.g.: Hey\\nAharon will be a 2 lines comment. Max length: 10000
        /// </summary>
        /// <value>The comment content. A \\n indicates a new line, e.g.: Hey\\nAharon will be a 2 lines comment. Max length: 10000</value>
        [DataMember(Name="body", EmitDefaultValue=false)]
        public string Body { get; set; }

        /// <summary>
        /// The date and time the custom attribute was created, in the following format: YYYY-MM-DDThh:mm:ss.sz.
        /// </summary>
        /// <value>The date and time the custom attribute was created, in the following format: YYYY-MM-DDThh:mm:ss.sz.</value>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who created the comment.
        /// </summary>
        /// <value>The Autodesk ID of the user who created the comment.</value>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="deletedAt", EmitDefaultValue=false)]
        public string DeletedAt { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="clientCreatedAt", EmitDefaultValue=false)]
        public string ClientCreatedAt { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="clientUpdatedAt", EmitDefaultValue=false)]
        public string ClientUpdatedAt { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permittedActions", EmitDefaultValue=false)]
        public List<string> PermittedActions { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permittedAttributes", EmitDefaultValue=false)]
        public List<string> PermittedAttributes { get; set; }

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
