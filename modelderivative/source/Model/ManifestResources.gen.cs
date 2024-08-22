/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative
 *
 * Use the Model Derivative API to translate designs from one CAD format to another. You can also use this API to extract metadata from a model.
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

namespace Autodesk.ModelDerivative.Model
{
    /// <summary>
    /// Represents a resource generated for a derivative.
    /// </summary>
    [DataContract]
    public partial class ManifestResources
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManifestResources" /> class.
        /// </summary>
        public ManifestResources()
        {
        }

        /// <summary>
        ///An ID that uniquely identifies the resource.
        /// </summary>
        /// <value>
        ///An ID that uniquely identifies the resource.
        /// </value>
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string Guid { get; set; }

        /// <summary>
        ///Type of resource this JSON object represents.
        /// </summary>
        /// <value>
        ///Type of resource this JSON object represents.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        ///The URN that you can use to access the resource.
        /// </summary>
        /// <value>
        ///The URN that you can use to access the resource.
        /// </value>
        [DataMember(Name = "urn", EmitDefaultValue = false)]
        public string Urn { get; set; }

        /// <summary>
        ///File type of the resource.
        /// </summary>
        /// <value>
        ///File type of the resource.
        /// </value>
        [DataMember(Name = "role", EmitDefaultValue = false)]
        public string Role { get; set; }

        /// <summary>
        ///MIME type of the content of the resource.
        /// </summary>
        /// <value>
        ///MIME type of the content of the resource.
        /// </value>
        [DataMember(Name = "mime", EmitDefaultValue = false)]
        public string Mime { get; set; }

        /// <summary>
        ///An ID assigned to a resource that can be displayed in a viewer.
        /// </summary>
        /// <value>
        ///An ID assigned to a resource that can be displayed in a viewer.
        /// </value>
        [DataMember(Name = "viewableID", EmitDefaultValue = false)]
        public string ViewableID { get; set; }

        /// <summary>
        ///The name of the resource.
        /// </summary>
        /// <value>
        ///The name of the resource.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        ///Status of the task generating this resource; Possible values are:  `pending`, `inprogress`, `success`, `failed`, `timeout`
        /// </summary>
        /// <value>
        ///Status of the task generating this resource; Possible values are:  `pending`, `inprogress`, `success`, `failed`, `timeout`
        /// </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        /// <summary>
        ///- `true`: There is a thumbnail for the resource.
        ///- `false`: There is no thumbnail for the resource.
        /// </summary>
        /// <value>
        ///- `true`: There is a thumbnail for the resource.
        ///- `false`: There is no thumbnail for the resource.
        /// </value>
        [DataMember(Name = "hasThumbnail", EmitDefaultValue = false)]
        public string HasThumbnail { get; set; }

        /// <summary>
        ///Indicates the progress of the process generating this resource, as a percentage. Once complete, the value changes to `complete`.
        /// </summary>
        /// <value>
        ///Indicates the progress of the process generating this resource, as a percentage. Once complete, the value changes to `complete`.
        /// </value>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public string Progress { get; set; }

        /// <summary>
        ///The name of the phase the resource file was generated from. This attribute is present only on Model Views (Viewables) generated from a Revit source design. This attribute can be a string (for Revit non-sheet 2D or 3D views) or an array of strings (for Revit sheet views).
        /// </summary>
        /// <value>
        ///The name of the phase the resource file was generated from. This attribute is present only on Model Views (Viewables) generated from a Revit source design. This attribute can be a string (for Revit non-sheet 2D or 3D views) or an array of strings (for Revit sheet views).
        /// </value>
        [DataMember(Name = "phaseNames", EmitDefaultValue = false)]
        public Object PhaseNames { get; set; }

        /// <summary>
        ///The unique ID of the phase the resource file was generated from. This attribute is present only on Model Views (Viewables) generated from a Revit source design. This attribute can be a string (for Revit non-sheet 2D or 3D views) or an array of strings (for Revit sheet views).
        /// </summary>
        /// <value>
        ///The unique ID of the phase the resource file was generated from. This attribute is present only on Model Views (Viewables) generated from a Revit source design. This attribute can be a string (for Revit non-sheet 2D or 3D views) or an array of strings (for Revit sheet views).
        /// </value>
        [DataMember(Name = "phaseIds", EmitDefaultValue = false)]
        public object PhaseIds { get; set; }

        /// <summary>
        ///The default viewpoint of a viewable 3D resource.
        /// </summary>
        /// <value>
        ///The default viewpoint of a viewable 3D resource.
        /// </value>
        [DataMember(Name = "camera", EmitDefaultValue = false)]
        public List<decimal?> Camera { get; set; }

        /// <summary>
        ///An array of two integers where the first number represents the width of a thumbnail in pixels, and the second the height. Available only for thumbnail resources.
        /// </summary>
        /// <value>
        ///An array of two integers where the first number represents the width of a thumbnail in pixels, and the second the height. Available only for thumbnail resources.
        /// </value>
        [DataMember(Name = "resolution", EmitDefaultValue = false)]
        public List<int?> Resolution { get; set; }

        /// <summary>
        ///Gets or Sets Messages
        /// </summary>
        [DataMember(Name = "messages", EmitDefaultValue = false)]
        public List<Messages> Messages { get; set; }

        /// <summary>
        ///An optional array of objects, where each object (of type `children`) represents another resource generated for this resource.
        /// </summary>
        /// <value>
        ///An optional array of objects, where each object (of type `children`) represents another resource generated for this resource.
        /// </value>
        [DataMember(Name = "children", EmitDefaultValue = false)]
        public List<ManifestResources> Children { get; set; }

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
