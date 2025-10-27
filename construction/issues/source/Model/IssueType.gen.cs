/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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

namespace Autodesk.Construction.Issues.Model
{
    /// <summary>
    /// IssueType
    /// </summary>
    [DataContract]
    public partial class IssueType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueType" /> class.
        /// </summary>
        public IssueType()
        {
        }

        /// <summary>
        ///The ID of the issue type.
        /// </summary>
        /// <value>
        ///The ID of the issue type.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name = "containerId", EmitDefaultValue = false)]
        public string ContainerId { get; set; }

        /// <summary>
        ///Max length: 250
        /// </summary>
        /// <value>
        ///Max length: 250
        /// </value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        ///States whether the issue type is active.
        /// </summary>
        /// <value>
        ///States whether the issue type is active.
        /// </value>
        [DataMember(Name = "isActive", EmitDefaultValue = false)]
        public bool? IsActive { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name = "orderIndex", EmitDefaultValue = false)]
        public int? OrderIndex { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name = "permittedActions", EmitDefaultValue = false)]
        public List<string> PermittedActions { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name = "permittedAttributes", EmitDefaultValue = false)]
        public List<string> PermittedAttributes { get; set; }

        /// <summary>
        ///A list of subtypes of the specific issue type.
        /// </summary>
        /// <value>
        ///A list of subtypes of the specific issue type.
        /// </value>
        [DataMember(Name = "subtypes", EmitDefaultValue = false)]
        public List<IssueTypeSubtypes> Subtypes { get; set; }

        /// <summary>
        ///Not relevant
        /// </summary>
        /// <value>
        ///Not relevant
        /// </value>
        [DataMember(Name = "statusSet", EmitDefaultValue = false)]
        public string StatusSet { get; set; }

        /// <summary>
        ///The unique identifier of the user who created the issue type.
        /// </summary>
        /// <value>
        ///The unique identifier of the user who created the issue type.
        /// </value>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        ///The date and time the issue was created, in ISO8601 format.
        /// </summary>
        /// <value>
        ///The date and time the issue was created, in ISO8601 format.
        /// </value>
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        ///The unique identifier of the user who updated the issue type.
        /// </summary>
        /// <value>
        ///The unique identifier of the user who updated the issue type.
        /// </value>
        [DataMember(Name = "updatedBy", EmitDefaultValue = false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        ///The date and time the issue type was updated, in ISO8601 format.
        /// </summary>
        /// <value>
        ///The date and time the issue type was updated, in ISO8601 format.
        /// </value>
        [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        ///The unique identifier of the user who deleted the issue type.
        /// </summary>
        /// <value>
        ///The unique identifier of the user who deleted the issue type.
        /// </value>
        [DataMember(Name = "deletedBy", EmitDefaultValue = false)]
        public string DeletedBy { get; set; }

        /// <summary>
        ///The date and time the issue type was deleted, in ISO8601 format.
        /// </summary>
        /// <value>
        ///The date and time the issue type was deleted, in ISO8601 format.
        /// </value>
        [DataMember(Name = "deletedAt", EmitDefaultValue = false)]
        public string DeletedAt { get; set; }

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
