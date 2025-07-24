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
using System.ComponentModel;

namespace Autodesk.Construction.Issues.Model
{
        /// <summary>
        /// IssuePayload
        /// </summary>
        [DataContract]
        public partial class IssuePayload
        {
                private string _assignedTo;
                private AssignedToType? _assignedToType;
                private string _title;
                private string _description;
                private string _snapshotUrn;
                private string _issueSubtypeId;
                private Status? _status;
                private bool _assignedToWasSet = false;
                private bool _assignedToTypeWasSet = false;
                private string _dueDate;
                private string _startDate;
                private string _locationId;
                private string _locationDetails;
                private string _rootCauseId;
                private string _issueTemplateId;
                private bool? _published;
                private Object _permittedActions;
                private List<string> _watchers;
                private List<IssuePayloadCustomAttributes> _customAttributes;
                private IssuePayloadGpsCoordinates _gpsCoordinates;
                private bool _titleWasSet = false;
                private bool _descriptionWasSet = false;
                private bool _snapshotUrnWasSet = false;
                private bool _issueSubtypeIdWasSet = false;
                private bool _statusWasSet = false;
                private bool _dueDateWasSet = false;
                private bool _startDateWasSet = false;
                private bool _locationIdWasSet = false;
                private bool _locationDetailsWasSet = false;
                private bool _rootCauseIdWasSet = false;
                private bool _issueTemplateIdWasSet = false;
                private bool _publishedWasSet = false;
                private bool _permittedActionsWasSet = false;
                private bool _watchersWasSet = false;
                private bool _customAttributesWasSet = false;
                private bool _gpsCoordinatesWasSet = false;
                /// <summary>
                /// Initializes a new instance of the <see cref="IssuePayload" /> class.
                /// </summary>
                public IssuePayload()
                {
                }

                /// <summary>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </summary>
                /// <value>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </value>
                [DataMember(Name = "title", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string Title 
                {
                    get => _title;
                    set
                    {
                        _title = value;
                        _titleWasSet = true;
                    }
                }

                /// <summary>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </summary>
                /// <value>
                ///The description and purpose of the issue.
                ///Max length: 10000
                /// </value>
                [DataMember(Name = "description", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string Description
                {
                    get => _description;
                    set
                    {
                        _description = value;
                        _descriptionWasSet = true;
                    }
                }
                /// <summary>
                ///Not relevant
                /// </summary>
                /// <value>
                ///Not relevant
                /// </value>
                [DataMember(Name = "snapshotUrn", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string SnapshotUrn
                {
                    get => _snapshotUrn;
                    set
                    {
                        _snapshotUrn = value;
                        _snapshotUrnWasSet = true;
                    }
                }

                /// <summary>
                ///The unique identifier of the subtype of the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the subtype of the issue.
                /// </value>
                 [DataMember(Name = "issueSubtypeId", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string IssueSubtypeId
                {
                    get => _issueSubtypeId;
                    set
                    {
                        _issueSubtypeId = value;
                        _issueSubtypeIdWasSet = true;
                    }
                }

                /// <summary>
                ///Gets or Sets Status
                /// </summary>
                [DataMember(Name = "status", EmitDefaultValue = true)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public Status? Status
                {
                    get => _status;
                    set
                    {
                        _status = value;
                        _statusWasSet = true;
                    }
                }

                /// <summary>
                ///The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).
                /// </summary>
                /// <value>
                ///The Autodesk ID of the member, role, or company you want to assign to the issue. Note that if you select an assignee ID, you also need to select a type (assignedToType).
                /// </value>
                [DataMember(Name = "assignedTo", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string AssignedTo
                {
                        // The AssignedTo property with custom serialization handling.
                        // We need to track if this property was explicitly set to handle null values correctly during serialization.
                        // This allows us to distinguish between an unset value and an explicitly set null value.
                        get => _assignedTo;
                        set
                        {
                                _assignedTo = value;
                                _assignedToWasSet = true; // Track that this property was explicitly set
                        }
                }
                /// <summary>
                ///Gets or Sets AssignedToType
                /// </summary>
                [DataMember(Name = "assignedToType", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)] 
                public AssignedToType? AssignedToType
                {
                        // The AssignedToType property with custom serialization handling.
                        // Similar to AssignedTo, we track if this was explicitly set to handle null values correctly.
                        // This is important because AssignedTo and AssignedToType work together - if one is set, the other should also be set.
                        get => _assignedToType;
                        set
                        {
                                _assignedToType = value;
                                _assignedToTypeWasSet = true; // Track that this property was explicitly set
                        }
                }

                /// <summary>
                ///The due date of the issue, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The due date of the issue, in ISO8601 format.
                /// </value>
                [DataMember(Name = "dueDate", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string DueDate
                {
                    get => _dueDate;
                    set
                    {
                        _dueDate = value;
                        _dueDateWasSet = true;
                    }
                }

                /// <summary>
                ///The start date of the issue, in ISO8601 format.
                /// </summary>
                /// <value>
                ///The start date of the issue, in ISO8601 format.
                /// </value>
                 [DataMember(Name = "startDate", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string StartDate
                {
                    get => _startDate;
                    set
                    {
                        _startDate = value;
                        _startDateWasSet = true;
                    }
                }

                /// <summary>
                ///The unique LBS (Location Breakdown Structure) identifier that relates to the issue.
                /// </summary>
                /// <value>
                ///The unique LBS (Location Breakdown Structure) identifier that relates to the issue.
                /// </value>
                [DataMember(Name = "locationId", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string LocationId
                {
                    get => _locationId;
                    set
                    {
                        _locationId = value;
                        _locationIdWasSet = true;
                    }
                }

                /// <summary>
                ///The location as plain text that relates to the issue.
                ///Max length: 8300
                /// </summary>
                /// <value>
                ///The location as plain text that relates to the issue.
                ///Max length: 8300
                /// </value>
                [DataMember(Name = "locationDetails", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string LocationDetails
                {
                    get => _locationDetails;
                    set
                    {
                        _locationDetails = value;
                        _locationDetailsWasSet = true;
                    }
                }

                /// <summary>
                ///The unique identifier of the type of root cause for the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the type of root cause for the issue.
                /// </value>
                [DataMember(Name = "rootCauseId", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string RootCauseId
                {
                    get => _rootCauseId;
                    set
                    {
                        _rootCauseId = value;
                        _rootCauseIdWasSet = true;
                    }
                }

                /// <summary>
                ///The unique identifier of the type of root cause for the issue.
                /// </summary>
                /// <value>
                ///The unique identifier of the type of root cause for the issue.
                /// </value>
                [DataMember(Name = "issueTemplateId", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public string IssueTemplateId
                {
                    get => _issueTemplateId;
                    set
                    {
                        _issueTemplateId = value;
                        _issueTemplateIdWasSet = true;
                    }
                }

                /// <summary>
                ///States whether the issue is published. Default value: false (e.g. unpublished).
                /// </summary>
                /// <value>
                ///States whether the issue is published. Default value: false (e.g. unpublished).
                /// </value>
                [DataMember(Name = "published", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public bool? Published
                {
                    get => _published;
                    set
                    {
                        _published = value;
                        _publishedWasSet = true;
                    }
                }

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
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public Object PermittedActions
                {
                    get => _permittedActions;
                    set
                    {
                        _permittedActions = value;
                        _permittedActionsWasSet = true;
                    }
                }


                /// <summary>
                ///The Autodesk ID of the member you want to assign as a watcher for the issue.
                /// </summary>
                /// <value>
                ///The Autodesk ID of the member you want to assign as a watcher for the issue.
                /// </value>
                [DataMember(Name = "watchers", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public List<string> Watchers
                {
                    get => _watchers;
                    set
                    {
                        _watchers = value;
                        _watchersWasSet = true;
                    }
                }

                /// <summary>
                ///A list of custom attributes of the specific issue.
                /// </summary>
                /// <value>
                ///A list of custom attributes of the specific issue.
                /// </value>
                [DataMember(Name = "customAttributes", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public List<IssuePayloadCustomAttributes> CustomAttributes
                {
                    get => _customAttributes;
                    set
                    {
                        _customAttributes = value;
                        _customAttributesWasSet = true;
                    }
                }

                /// <summary>
                ///Gets or Sets GpsCoordinates
                /// </summary>
                [DataMember(Name = "gpsCoordinates", EmitDefaultValue = false)]
                [JsonProperty(NullValueHandling = NullValueHandling.Include)]
                public IssuePayloadGpsCoordinates GpsCoordinates
                {
                    get => _gpsCoordinates;
                    set
                    {
                        _gpsCoordinates = value;
                        _gpsCoordinatesWasSet = true;
                    }
                }

                // Controls serialization of  property.
                // Only serialize if the property was explicitly set, allowing proper null handling.
                // This prevents the property from being included in JSON if it was never set.
                [EditorBrowsable(EditorBrowsableState.Never)] 
                public bool ShouldSerializeAssignedTo()
                {
                        return _assignedToWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeAssignedToType()
                {
                        return _assignedToTypeWasSet;
                }
                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeTitle()
                {
                    return _titleWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeDescription()
                {
                    return _descriptionWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeSnapshotUrn()
                {
                    return _snapshotUrnWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeIssueSubtypeId()
                {
                    return _issueSubtypeIdWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeStatus()
                {
                    return _statusWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeDueDate()
                {
                    return _dueDateWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeStartDate()
                {
                    return _startDateWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeLocationId()
                {
                    return _locationIdWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeLocationDetails()
                {
                    return _locationDetailsWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeRootCauseId()
                {
                    return _rootCauseIdWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeIssueTemplateId()
                {
                    return _issueTemplateIdWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializePublished()
                {
                    return _publishedWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializePermittedActions()
                {
                    return _permittedActionsWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeWatchers()
                {
                    return _watchersWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeCustomAttributes()
                {
                    return _customAttributesWasSet;
                }

                [EditorBrowsable(EditorBrowsableState.Never)]
                public bool ShouldSerializeGpsCoordinates()
                {
                    return _gpsCoordinatesWasSet;
                }

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
