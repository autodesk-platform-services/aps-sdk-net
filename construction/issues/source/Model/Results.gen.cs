/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
        /// Results
        /// </summary>
        [DataContract]
        public partial class Results
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="Results" /> class.
                /// </summary>
                public Results()
                {
                }

                /// <summary>
                ///The unique identifier of the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the issue.
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
                ///States whether the issue was deleted. Default value: false.
                /// </summary>
                /// <value>
                ///States whether the issue was deleted. Default value: false.
                /// </value>
                [DataMember(Name = "deleted", EmitDefaultValue = false)]
                public bool? Deleted { get; set; }

                /// <summary>
                ///The chronological user-friendly identifier of the issue.
                /// </summary>
                /// <value>
                ///The chronological user-friendly identifier of the issue.
                /// </value>
                [DataMember(Name = "displayId", EmitDefaultValue = false)]
                public int? DisplayId { get; set; }

                /// <summary>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </summary>
                /// <value>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </value>
                [DataMember(Name = "title", EmitDefaultValue = false)]
                public string Title { get; set; }

                /// <summary>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </summary>
                /// <value>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </value>
                [DataMember(Name = "description", EmitDefaultValue = false)]
                public string Description { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "snapshotUrn", EmitDefaultValue = false)]
                public string SnapshotUrn { get; set; }

                /// <summary>
                ///The unique identifier of the type of the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the type of the issue.
                /// </value>
                [DataMember(Name = "issueTypeId", EmitDefaultValue = false)]
                public string IssueTypeId { get; set; }

                /// <summary>
                ///The unique identifier of the subtype of the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the subtype of the issue.
                /// </value>
                [DataMember(Name = "issueSubtypeId", EmitDefaultValue = false)]
                public string IssueSubtypeId { get; set; }

                /// <summary>
                ///The current status of the issue. To check the available statuses for the project, call GET users/me and check the permitted statuses list (issue.new.permittedStatuses). For more information about statuses, see the Help documentation.
                /// </summary>
                /// <value>
                ///The current status of the issue. To check the available statuses for the project, call GET users/me and check the permitted statuses list (issue.new.permittedStatuses). For more information about statuses, see the Help documentation.
                /// </value>
                [DataMember(Name = "status", EmitDefaultValue = false)]
                public string Status { get; set; }

                /// <summary>
                ///The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).
                /// </summary>
                /// <value>
                ///The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).
                /// </value>
                [DataMember(Name = "assignedTo", EmitDefaultValue = false)]
                public string AssignedTo { get; set; }

                /// <summary>
                ///Gets or Sets AssignedToType
                /// </summary>
                [DataMember(Name = "assignedToType", EmitDefaultValue = true)]
                public string AssignedToType { get; set; }

                /// <summary>
                ///The due date of the issue, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The due date of the issue, in ISO8601 format.
                /// </value>
                [DataMember(Name = "dueDate", EmitDefaultValue = false)]
                public string DueDate { get; set; }

                /// <summary>
                ///The start date of the issue, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The start date of the issue, in ISO8601 format.
                /// </value>
                [DataMember(Name = "startDate", EmitDefaultValue = false)]
                public string StartDate { get; set; }

                /// <summary>
                ///The unique LBS (Location Breakdown Structure) identifier that relates to the issue.
                /// </summary>
                /// <value>
                ///The unique LBS (Location Breakdown Structure) identifier that relates to the issue.
                /// </value>
                [DataMember(Name = "locationId", EmitDefaultValue = false)]
                public string LocationId { get; set; }

                /// <summary>
                ///The location as plain text that relates to the issue.
                ///Max length: 8300
                /// </summary>
                /// <value>
                ///The location as plain text that relates to the issue.
                ///Max length: 8300
                /// </value>
                [DataMember(Name = "locationDetails", EmitDefaultValue = false)]
                public string LocationDetails { get; set; }

                /// <summary>
                ///Information about the files associated with issues (pushpins).
                /// </summary>
                /// <value>
                ///Information about the files associated with issues (pushpins).
                /// </value>
                [DataMember(Name = "linkedDocuments", EmitDefaultValue = false)]
                public List<ResultsLinkedDocuments> LinkedDocuments { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "links", EmitDefaultValue = false)]
                public List<Object> Links { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "ownerId", EmitDefaultValue = false)]
                public string OwnerId { get; set; }

                /// <summary>
                ///The unique identifier of the type of root cause for the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the type of root cause for the issue.
                /// </value>
                [DataMember(Name = "rootCauseId", EmitDefaultValue = false)]
                public string RootCauseId { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "officialResponse", EmitDefaultValue = false)]
                public Object OfficialResponse { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "issueTemplateId", EmitDefaultValue = false)]
                public string IssueTemplateId { get; set; }

                /// <summary>
                ///A list of statuses accessible to the current user, this is based on the current status of the issue and the user permissions.
                ///Possible Values: open, pending, in_review, closed.
                /// </summary>
                /// <value>
                ///A list of statuses accessible to the current user, this is based on the current status of the issue and the user permissions.
                ///Possible Values: open, pending, in_review, closed.
                /// </value>
                [DataMember(Name = "permittedStatuses", EmitDefaultValue = false)]
                public List<string> PermittedStatuses { get; set; }

                /// <summary>
                ///A list of attributes the current user can manipulate in the current context. issueTypeId, linkedDocument, links, ownerId, officialResponse, rootCauseId, snapshotUrn are not applicable.
                /// </summary>
                /// <value>
                ///A list of attributes the current user can manipulate in the current context. issueTypeId, linkedDocument, links, ownerId, officialResponse, rootCauseId, snapshotUrn are not applicable.
                /// </value>
                [DataMember(Name = "permittedAttributes", EmitDefaultValue = false)]
                public List<string> PermittedAttributes { get; set; }

                /// <summary>
                ///States whether the issue is published. Default value: false (e.g. unpublished).
                /// </summary>
                /// <value>
                ///States whether the issue is published. Default value: false (e.g. unpublished).
                /// </value>
                [DataMember(Name = "published", EmitDefaultValue = false)]
                public bool? Published { get; set; }

                /// <summary>
                ///The list of actions permitted for the user for this issue in its current state.
                ///Note that if a user with Create for my company permissions attempts to assign a user from a another company to the issue, it will return an error.
                ///
                ///Possible Values: assign_all (can assign another user from another company to the issue), assign_same_company (can only assign another user from the same company to the issue), clear_assignee, delete, add_comment, add_attachment, remove_attachment.
                ///
                ///The following values are not relevant: add_attachment, remove_attachment.
                /// </summary>
                /// <value>
                ///The list of actions permitted for the user for this issue in its current state.
                ///Note that if a user with Create for my company permissions attempts to assign a user from a another company to the issue, it will return an error.
                ///
                ///Possible Values: assign_all (can assign another user from another company to the issue), assign_same_company (can only assign another user from the same company to the issue), clear_assignee, delete, add_comment, add_attachment, remove_attachment.
                ///
                ///The following values are not relevant: add_attachment, remove_attachment.
                /// </value>
                [DataMember(Name = "permittedActions", EmitDefaultValue = false)]
                public Object PermittedActions { get; set; }

                /// <summary>
                ///The number of comments in this issue.
                /// </summary>
                /// <value>
                ///The number of comments in this issue.
                /// </value>
                [DataMember(Name = "commentCount", EmitDefaultValue = false)]
                public int? CommentCount { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "attachmentCount", EmitDefaultValue = false)]
                public int? AttachmentCount { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "openedBy", EmitDefaultValue = false)]
                public string OpenedBy { get; set; }

                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "openedAt", EmitDefaultValue = false)]
                public string OpenedAt { get; set; }

                /// <summary>
                ///The unique identifier of the user who closed the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the user who closed the issue.
                /// </value>
                [DataMember(Name = "closedBy", EmitDefaultValue = false)]
                public string ClosedBy { get; set; }

                /// <summary>
                ///The date and time the issue was closed, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The date and time the issue was closed, in ISO8601 format.
                /// </value>
                [DataMember(Name = "closedAt", EmitDefaultValue = false)]
                public string ClosedAt { get; set; }

                /// <summary>
                ///The unique identifier of the user who created the issue
                /// </summary>
                /// <value>
                ///The unique identifier of the user who created the issue
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
                ///The unique identifier of the user who updated the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the user who updated the issue.
                /// </value>
                [DataMember(Name = "updatedBy", EmitDefaultValue = false)]
                public string UpdatedBy { get; set; }

                /// <summary>
                ///The date and time the issue was updated, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The date and time the issue was updated, in ISO8601 format.
                /// </value>
                [DataMember(Name = "updatedAt", EmitDefaultValue = false)]
                public string UpdatedAt { get; set; }

                /// <summary>
                ///The Autodesk ID of the member you want to assign as a watcher for the issue.
                /// </summary>
                /// <value>
                ///The Autodesk ID of the member you want to assign as a watcher for the issue.
                /// </value>
                [DataMember(Name = "watchers", EmitDefaultValue = false)]
                public List<string> Watchers { get; set; }

                /// <summary>
                ///A list of custom attributes of the specific issue.
                /// </summary>
                /// <value>
                ///A list of custom attributes of the specific issue.
                /// </value>
                [DataMember(Name = "customAttributes", EmitDefaultValue = false)]
                public List<IssueCustomAttributes> CustomAttributes { get; set; }

                /// <summary>
                ///Gets or Sets GpsCoordinates
                /// </summary>
                [DataMember(Name = "gpsCoordinates", EmitDefaultValue = false)]
                public IssueGpsCoordinates GpsCoordinates { get; set; }

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
