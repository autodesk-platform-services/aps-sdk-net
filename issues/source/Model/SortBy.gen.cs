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
    /// Defines sortBy
    /// </summary>
    ///<value></value>

    [JsonConverter(typeof(StringEnumConverter))]

    public enum SortBy
    {

        /// <summary>
        /// Enum CreatedAt for value: createdAt
        /// </summary>
        [EnumMember(Value = "createdAt")]
        CreatedAt,

        /// <summary>
        /// Enum UpdatedAt for value: updatedAt
        /// </summary>
        [EnumMember(Value = "updatedAt")]
        UpdatedAt,

        /// <summary>
        /// Enum CreatedBy for value: createdBy
        /// </summary>
        [EnumMember(Value = "createdBy")]
        CreatedBy,

        /// <summary>
        /// Enum DisplayId for value: displayId
        /// </summary>
        [EnumMember(Value = "displayId")]
        DisplayId,

        /// <summary>
        /// Enum Title for value: title
        /// </summary>
        [EnumMember(Value = "title")]
        Title,

        /// <summary>
        /// Enum Description for value: description
        /// </summary>
        [EnumMember(Value = "description")]
        Description,

        /// <summary>
        /// Enum Status for value: status
        /// </summary>
        [EnumMember(Value = "status")]
        Status,

        /// <summary>
        /// Enum AssignedTo for value: assignedTo
        /// </summary>
        [EnumMember(Value = "assignedTo")]
        AssignedTo,

        /// <summary>
        /// Enum AssignedToType for value: assignedToType
        /// </summary>
        [EnumMember(Value = "assignedToType")]
        AssignedToType,

        /// <summary>
        /// Enum DueDate for value: dueDate
        /// </summary>
        [EnumMember(Value = "dueDate")]
        DueDate,

        /// <summary>
        /// Enum LocationDetails for value: locationDetails
        /// </summary>
        [EnumMember(Value = "locationDetails")]
        LocationDetails,

        /// <summary>
        /// Enum Published for value: published
        /// </summary>
        [EnumMember(Value = "published")]
        Published,

        /// <summary>
        /// Enum ClosedBy for value: closedBy
        /// </summary>
        [EnumMember(Value = "closedBy")]
        ClosedBy,

        /// <summary>
        /// Enum ClosedAt for value: closedAt
        /// </summary>
        [EnumMember(Value = "closedAt")]
        ClosedAt,

        /// <summary>
        /// Enum IssueSubType for value: issueSubType
        /// </summary>
        [EnumMember(Value = "issueSubType")]
        IssueSubType,

        /// <summary>
        /// Enum IssueType for value: issueType
        /// </summary>
        [EnumMember(Value = "issueType")]
        IssueType,

        /// <summary>
        /// Enum CustomAttributes for value: customAttributes
        /// </summary>
        [EnumMember(Value = "customAttributes")]
        CustomAttributes,

        /// <summary>
        /// Enum StartDate for value: startDate
        /// </summary>
        [EnumMember(Value = "startDate")]
        StartDate
    }

}
