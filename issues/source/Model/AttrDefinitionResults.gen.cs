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
    /// AttrDefinitionResults
    /// </summary>
    [DataContract]
    public partial class AttrDefinitionResults 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttrDefinitionResults" /> class.
        /// </summary>
        public AttrDefinitionResults()
        {
        }
        
        /// <summary>
        /// The ID of the custom attribute.
        /// </summary>
        /// <value>The ID of the custom attribute.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the custom attribute definition.
        /// </summary>
        /// <value>The ID of the custom attribute definition.</value>
        [DataMember(Name="attributeDefinitionId", EmitDefaultValue=false)]
        public string AttributeDefinitionId { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="containerId", EmitDefaultValue=false)]
        public string ContainerId { get; set; }

        /// <summary>
        /// Gets or Sets MappedItemType
        /// </summary>
        [DataMember(Name="mappedItemType", EmitDefaultValue=false)]
        public string MappedItemType { get; set; }

        /// <summary>
        /// The ID of the item (type, or subtype) the custom attribute is mapped to.
        /// </summary>
        /// <value>The ID of the item (type, or subtype) the custom attribute is mapped to.</value>
        [DataMember(Name="mappedItemId", EmitDefaultValue=false)]
        public string MappedItemId { get; set; }

        /// <summary>
        /// The order that the custom attributes were mapped to the item (type, subtype). This is only relevant to non-inherited mappings.
        /// </summary>
        /// <value>The order that the custom attributes were mapped to the item (type, subtype). This is only relevant to non-inherited mappings.</value>
        [DataMember(Name="order", EmitDefaultValue=false)]
        public int? Order { get; set; }

        /// <summary>
        /// Gets or Sets DataType
        /// </summary>
        [DataMember(Name="dataType", EmitDefaultValue=false)]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue=false)]
        public AttrDefinitionResultsMetadata Metadata { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permittedActions", EmitDefaultValue=false)]
        public List<string> PermittedActions { get; set; }

        /// <summary>
        /// Not relevant
        /// </summary>
        /// <value>Not relevant</value>
        [DataMember(Name="permittedAttributes", EmitDefaultValue=false)]
        public List<string> PermittedAttributes { get; set; }

        /// <summary>
        /// The date and time the custom attribute was created, in the following format: YYYY-MM-DDThh:mm:ss.sz.
        /// </summary>
        /// <value>The date and time the custom attribute was created, in the following format: YYYY-MM-DDThh:mm:ss.sz.</value>
        [DataMember(Name="createdAt", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who created the custom attribute.
        /// </summary>
        /// <value>The Autodesk ID of the user who created the custom attribute.</value>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// The last date and time the custom attribute was updated, in the following format: YYYY-MM-DDThh:mm:ss.sz.
        /// </summary>
        /// <value>The last date and time the custom attribute was updated, in the following format: YYYY-MM-DDThh:mm:ss.sz.</value>
        [DataMember(Name="updatedAt", EmitDefaultValue=false)]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who last updated the custom attribute.
        /// </summary>
        /// <value>The Autodesk ID of the user who last updated the custom attribute.</value>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// The date and time the custom attribute was deleted, in the following format: YYYY-MM-DDThh:mm:ss.sz.
        /// </summary>
        /// <value>The date and time the custom attribute was deleted, in the following format: YYYY-MM-DDThh:mm:ss.sz.</value>
        [DataMember(Name="deletedAt", EmitDefaultValue=false)]
        public string DeletedAt { get; set; }

        /// <summary>
        /// The Autodesk ID of the user who deleted the custom attribute.
        /// </summary>
        /// <value>The Autodesk ID of the user who deleted the custom attribute.</value>
        [DataMember(Name="deletedBy", EmitDefaultValue=false)]
        public string DeletedBy { get; set; }

        /// <summary>
        /// The title of the custom attribute. 
        /// </summary>
        /// <value>The title of the custom attribute. </value>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// The description of the custom attribute.
        /// </summary>
        /// <value>The description of the custom attribute.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

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
