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

namespace Autodesk.Construction.Issues.Model
{
    /// <summary>
    /// If this object appears in the response, it indicates that the user can create and modify issues.
    /// </summary>
    [DataContract]
    public partial class UserIssuesNew 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserIssuesNew" /> class.
        /// </summary>
        public UserIssuesNew()
        {
        }
        
        /// <summary>
        /// The list of actions permitted for the user for this issue in its current state.
        /// </summary>
        /// <value>The list of actions permitted for the user for this issue in its current state.</value>
        [DataMember(Name="permittedActions", EmitDefaultValue=false)]
        public List<string> PermittedActions { get; set; }

        /// <summary>
        /// A list of attributes you are allowed to open a new issue. issueTypeId, linkedDocument, links, ownerId, officialResponse, rootCauseId, snapshotUrn are not applicable.
        /// </summary>
        /// <value>A list of attributes you are allowed to open a new issue. issueTypeId, linkedDocument, links, ownerId, officialResponse, rootCauseId, snapshotUrn are not applicable.</value>
        [DataMember(Name="permittedAttributes", EmitDefaultValue=false)]
        public List<string> PermittedAttributes { get; set; }

        /// <summary>
        /// A list of available statuses for the project. Possible values: draft, open, pending, in_progress, completed, in_review, not_approved, in_dispute, closed.
        /// </summary>
        /// <value>A list of available statuses for the project. Possible values: draft, open, pending, in_progress, completed, in_review, not_approved, in_dispute, closed.</value>
        [DataMember(Name="permittedStatuses", EmitDefaultValue=false)]
        public List<string> PermittedStatuses { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permitted_actions", EmitDefaultValue=false)]
        public List<string> _PermittedActions { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permitted_attributes", EmitDefaultValue=false)]
        public List<string> _PermittedAttributes { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permitted_statuses", EmitDefaultValue=false)]
        public List<string> _PermittedStatuses { get; set; }

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
