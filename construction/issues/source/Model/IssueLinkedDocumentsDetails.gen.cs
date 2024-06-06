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
    /// Information about the individual viewable.
    /// </summary>
    [DataContract]
    public partial class IssueLinkedDocumentsDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueLinkedDocumentsDetails" /> class.
        /// </summary>
        public IssueLinkedDocumentsDetails()
        {
        }

        /// <summary>
        ///Gets or Sets Viewable
        /// </summary>
        [DataMember(Name = "viewable", EmitDefaultValue = false)]
        public IssueLinkedDocumentsDetailsViewable Viewable { get; set; }

        /// <summary>
        ///Gets or Sets Position
        /// </summary>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        public IssueLinkedDocumentsDetailsPosition Position { get; set; }

        /// <summary>
        ///The ID of the element the pushpin is associated with in the viewable.
        /// </summary>
        /// <value>
        ///The ID of the element the pushpin is associated with in the viewable.
        /// </value>
        [DataMember(Name = "objectId", EmitDefaultValue = false)]
        public int? ObjectId { get; set; }

        /// <summary>
        ///An external identifier of the element the pushpin is associated with in the viewable.
        /// </summary>
        /// <value>
        ///An external identifier of the element the pushpin is associated with in the viewable.
        /// </value>
        [DataMember(Name = "externalId", EmitDefaultValue = false)]
        public string ExternalId { get; set; }

        /// <summary>
        ///The viewer state at the time the pushpin was created. Maximum length: 2,500,000 characters. You can get the viewer state object by calling ViewerState.getState(). To restore the viewer instance use ViewerState.restoreState(). See the `Viewer API documentation https://developer.autodesk.com/en/docs/viewer/v2/reference/javascript/viewerstate/`_ for more details.
        /// </summary>
        /// <value>
        ///The viewer state at the time the pushpin was created. Maximum length: 2,500,000 characters. You can get the viewer state object by calling ViewerState.getState(). To restore the viewer instance use ViewerState.restoreState(). See the `Viewer API documentation https://developer.autodesk.com/en/docs/viewer/v2/reference/javascript/viewerstate/`_ for more details.
        /// </value>
        [DataMember(Name = "viewerState", EmitDefaultValue = false)]
        public Object ViewerState { get; set; }

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
