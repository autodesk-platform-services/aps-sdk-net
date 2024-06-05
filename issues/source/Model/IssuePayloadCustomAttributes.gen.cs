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
    /// IssuePayloadCustomAttributes
    /// </summary>
    [DataContract]
    public partial class IssuePayloadCustomAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IssuePayloadCustomAttributes" /> class.
        /// </summary>
        public IssuePayloadCustomAttributes()
        {
        }

        /// <summary>
        ///The unique identifier of the custom attribute.
        /// </summary>
        /// <value>
        ///The unique identifier of the custom attribute.
        /// </value>
        [DataMember(Name = "attributeDefinitionId", EmitDefaultValue = false)]
        public string AttributeDefinitionId { get; set; }

        /// <summary>
        ///Custom attribute value. Possible value types: string, number, null.
        /// </summary>
        /// <value>
        ///Custom attribute value. Possible value types: string, number, null.
        /// </value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public Object Value { get; set; }

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
