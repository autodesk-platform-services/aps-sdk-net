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
    /// IssuePayload
    /// </summary>
    [DataContract]
    public partial class IssuePayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuePayload" /> class.
        /// </summary>
        public IssuePayload()
        {
        }
        
        /// <summary>
        /// The description and purpose of the issue. Max length: 10000
        /// </summary>
        /// <value>The description and purpose of the issue. Max length: 10000</value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// The description and purpose of the issue. Max length: 10000
        /// </summary>
        /// <value>The description and purpose of the issue. Max length: 10000</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="snapshotUrn", EmitDefaultValue=false)]
        public string SnapshotUrn { get; set; }

        /// <summary>
        /// The unique identifier of the subtype of the issue.
        /// </summary>
        /// <value>The unique identifier of the subtype of the issue.</value>
        [DataMember(Name="issueSubtypeId", EmitDefaultValue=false)]
        public string IssueSubtypeId { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public Status Status { get; set; }

        /// <summary>
        /// The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).
        /// </summary>
        /// <value>The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).</value>
        [DataMember(Name="assignedTo", EmitDefaultValue=false)]
        public string AssignedTo { get; set; }

        /// <summary>
        /// Gets or Sets AssignedToType
        /// </summary>
        [DataMember(Name="assignedToType", EmitDefaultValue=true)]
        public AssignedToType AssignedToType { get; set; }

        /// <summary>
        /// The due date of the issue, in ISO8601 format.
        /// </summary>
        /// <value>The due date of the issue, in ISO8601 format.</value>
        [DataMember(Name="dueDate", EmitDefaultValue=false)]
        public string DueDate { get; set; }

        /// <summary>
        /// The start date of the issue, in ISO8601 format.
        /// </summary>
        /// <value>The start date of the issue, in ISO8601 format.</value>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public string StartDate { get; set; }

        /// <summary>
        /// The unique LBS (Location Breakdown Structure) identifier that relates to the issue.
        /// </summary>
        /// <value>The unique LBS (Location Breakdown Structure) identifier that relates to the issue.</value>
        [DataMember(Name="locationId", EmitDefaultValue=false)]
        public string LocationId { get; set; }

        /// <summary>
        /// The location as plain text that relates to the issue. Max length: 8300
        /// </summary>
        /// <value>The location as plain text that relates to the issue. Max length: 8300</value>
        [DataMember(Name="locationDetails", EmitDefaultValue=false)]
        public string LocationDetails { get; set; }

        /// <summary>
        /// The unique identifier of the type of root cause for the issue.
        /// </summary>
        /// <value>The unique identifier of the type of root cause for the issue.</value>
        [DataMember(Name="rootCauseId", EmitDefaultValue=false)]
        public string RootCauseId { get; set; }

        /// <summary>
        /// The unique identifier of the type of root cause for the issue.
        /// </summary>
        /// <value>The unique identifier of the type of root cause for the issue.</value>
        [DataMember(Name="issueTemplateId", EmitDefaultValue=false)]
        public string IssueTemplateId { get; set; }

        /// <summary>
        /// States whether the issue is published. Default value: false (e.g. unpublished).
        /// </summary>
        /// <value>States whether the issue is published. Default value: false (e.g. unpublished).</value>
        [DataMember(Name="published", EmitDefaultValue=false)]
        public bool? Published { get; set; }

        /// <summary>
        /// The list of actions permitted for the user for this issue in its current state. Note that if a user with Create for my company permissions attempts to assign a user from a another company to the issue, it will return an error.  Possible Values: assign_all (can assign another user from another company to the issue), assign_same_company (can only assign another user from the same company to the issue), clear_assignee, delete, add_comment, add_attachment, remove_attachment.  The following values are not relevant: add_attachment, remove_attachment.
        /// </summary>
        /// <value>The list of actions permitted for the user for this issue in its current state. Note that if a user with Create for my company permissions attempts to assign a user from a another company to the issue, it will return an error.  Possible Values: assign_all (can assign another user from another company to the issue), assign_same_company (can only assign another user from the same company to the issue), clear_assignee, delete, add_comment, add_attachment, remove_attachment.  The following values are not relevant: add_attachment, remove_attachment.</value>
        [DataMember(Name="permittedActions", EmitDefaultValue=false)]
        public Object PermittedActions { get; set; }

        /// <summary>
        /// The Autodesk ID of the member you want to assign as a watcher for the issue.
        /// </summary>
        /// <value>The Autodesk ID of the member you want to assign as a watcher for the issue.</value>
        [DataMember(Name="watchers", EmitDefaultValue=false)]
        public List<string> Watchers { get; set; }

        /// <summary>
        /// A list of custom attributes of the specific issue.
        /// </summary>
        /// <value>A list of custom attributes of the specific issue.</value>
        [DataMember(Name="customAttributes", EmitDefaultValue=false)]
        public List<IssuePayloadCustomAttributes> CustomAttributes { get; set; }

        /// <summary>
        /// Gets or Sets GpsCoordinates
        /// </summary>
        [DataMember(Name="gpsCoordinates", EmitDefaultValue=false)]
        public IssuePayloadGpsCoordinates GpsCoordinates { get; set; }

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
