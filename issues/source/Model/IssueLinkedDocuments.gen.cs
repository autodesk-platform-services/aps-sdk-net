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
    /// IssueLinkedDocuments
    /// </summary>
    [DataContract]
    public partial class IssueLinkedDocuments 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueLinkedDocuments" /> class.
        /// </summary>
        public IssueLinkedDocuments()
        {
        }
        
        /// <summary>
        /// The type of file. Possible values: TwoDVectorPushpin (3D models) TwoDRasterPushpin (2D sheets and views)
        /// </summary>
        /// <value>The type of file. Possible values: TwoDVectorPushpin (3D models) TwoDRasterPushpin (2D sheets and views)</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// The ID of the file associated with the issue (pushpin). Note the we do not currently support data associated with the ACC Build Sheet tool.
        /// </summary>
        /// <value>The ID of the file associated with the issue (pushpin). Note the we do not currently support data associated with the ACC Build Sheet tool.</value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who created the pushpin issue.
        /// </summary>
        /// <value>The Autodesk ID of the user who created the pushpin issue.</value>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date and time the pushpin was created, in ISO8601 format.
        /// </summary>
        /// <value>The date and time the pushpin was created, in ISO8601 format.</value>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The version of the file the pushin issue was added to. For information about file versions, see the Data Management API.
        /// </summary>
        /// <value>The version of the file the pushin issue was added to. For information about file versions, see the Data Management API.</value>
        [DataMember(Name="createdAtVersion", EmitDefaultValue=false)]
        public int? CreatedAtVersion { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who closed the pushpin issue.
        /// </summary>
        /// <value>The Autodesk ID of the user who closed the pushpin issue.</value>
        [DataMember(Name="closedBy", EmitDefaultValue=false)]
        public string ClosedBy { get; set; }

        /// <summary>
        /// The date and time the pushpin issue was closed, in ISO8601 format.
        /// </summary>
        /// <value>The date and time the pushpin issue was closed, in ISO8601 format.</value>
        [DataMember(Name="closedAt", EmitDefaultValue=false)]
        public string ClosedAt { get; set; }

        /// <summary>
        /// The version of the file when the pushpin issue was closed.
        /// </summary>
        /// <value>The version of the file when the pushpin issue was closed.</value>
        [DataMember(Name="closedAtVersion", EmitDefaultValue=false)]
        public int? ClosedAtVersion { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        [DataMember(Name="details", EmitDefaultValue=false)]
        public IssueLinkedDocumentsDetails Details { get; set; }

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
