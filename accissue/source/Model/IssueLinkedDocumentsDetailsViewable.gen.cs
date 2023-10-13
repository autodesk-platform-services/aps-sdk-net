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
    /// The individual viewable associated with the issue (pushpin). This is relevant for both individual 2D sheets and views within a 3D model, and individual PDF sheets within a multi-sheet PDF file. It is only relevant if the issue is associated with a file.
    /// </summary>
    [DataContract]
    public partial class IssueLinkedDocumentsDetailsViewable 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssueLinkedDocumentsDetailsViewable" /> class.
        /// </summary>
        public IssueLinkedDocumentsDetailsViewable()
        {
        }
        
        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the viewable (guid).
        /// </summary>
        /// <value>The ID of the viewable (guid).</value>
        [DataMember(Name="guid", EmitDefaultValue=false)]
        public string Guid { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="viewableId", EmitDefaultValue=false)]
        public string ViewableId { get; set; }

        /// <summary>
        /// The name of the viewable. Max length: 1000
        /// </summary>
        /// <value>The name of the viewable. Max length: 1000</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// True if it is a 3D viewable false if it is a 2D viewable
        /// </summary>
        /// <value>True if it is a 3D viewable false if it is a 2D viewable</value>
        [DataMember(Name="is3D", EmitDefaultValue=false)]
        public bool? Is3D { get; set; }

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
