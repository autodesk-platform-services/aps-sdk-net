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
    /// An envelope that contains the return data.
    /// </summary>
    [DataContract]
    public partial class ModelViewsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelViewsData" /> class.
        /// </summary>
        public ModelViewsData()
        {
        }

        /// <summary>
        ///The type of data that is returned.
        /// </summary>
        /// <value>
        ///The type of data that is returned.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        ///An array of objects, where each object represents a Model View.
        /// </summary>
        /// <value>
        ///An array of objects, where each object represents a Model View.
        /// </value>
        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public List<ModelViewsDataMetadata> Metadata { get; set; }

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
