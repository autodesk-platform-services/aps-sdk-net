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
    /// The current status of the issue. To check the available statuses for the project, call GET users/me and check the permitted statuses list (issue.new.permittedStatuses). For more information about statuses, see the Help documentation.
    /// </summary>
    ///<value>The current status of the issue. To check the available statuses for the project, call GET users/me and check the permitted statuses list (issue.new.permittedStatuses). For more information about statuses, see the Help documentation.</value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum Status
    {

        /// <summary>
        /// Enum Draft for value: draft
        /// </summary>
        [EnumMember(Value = "draft")]
        Draft,

        /// <summary>
        /// Enum Open for value: open
        /// </summary>
        [EnumMember(Value = "open")]
        Open,

        /// <summary>
        /// Enum Pending for value: pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Enum Inprogress for value: in_progress
        /// </summary>
        [EnumMember(Value = "in_progress")]
        Inprogress,

        /// <summary>
        /// Enum Inreview for value: in_review
        /// </summary>
        [EnumMember(Value = "in_review")]
        Inreview,

        /// <summary>
        /// Enum Completed for value: completed
        /// </summary>
        [EnumMember(Value = "completed")]
        Completed,

        /// <summary>
        /// Enum Notapproved for value: not_approved
        /// </summary>
        [EnumMember(Value = "not_approved")]
        Notapproved,

        /// <summary>
        /// Enum Indispute for value: in_dispute
        /// </summary>
        [EnumMember(Value = "in_dispute")]
        Indispute,

        /// <summary>
        /// Enum Closed for value: closed
        /// </summary>
        [EnumMember(Value = "closed")]
        Closed
    }

}
