/* 
 * APS SDK
 *
 * The APS Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Model Derivative API
 *
 * Model Derivative Service Documentation
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
    /// SpecificPropertiesPayloadQuery
    /// </summary>
    public partial class SpecificPropertiesPayloadQuery 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificPropertiesPayloadQuery" /> class.
        /// </summary>
        public SpecificPropertiesPayloadQuery()
        {
        }
        

        private Dictionary<object, object> filterQuery;

        internal Dictionary<object, object> FilterQuery { get { return filterQuery ?? buildFilterQuery(); } }

        public Filter FilterType { get; set; }

        public List<object> Values { get; set; }


        private Dictionary<object, object> buildFilterQuery()
        {
            string filterParam = string.Empty;
            string valueParam = string.Empty;
            switch (FilterType)
            {
                case Filter.ObjectID:
                    filterParam = "$in";
                    valueParam = "objectid";
                    break;

                case Filter.ExternalID:
                    filterParam = "$in";
                    valueParam = "externalId";
                    break;

                case Filter.Prefix:
                    filterParam = " $prefix";
                    valueParam = "name";
                    break;

                case Filter.Equals:
                    filterParam = "$eq";
                    break;

                case Filter.Between:
                    filterParam = "$between";
                    break;

                case Filter.LessorEqual:
                    filterParam = "$le";
                    break;

                case Filter.GreaterorEqual:
                    filterParam = "$ge";
                    break;

                case Filter.Contains:
                    filterParam = "$contains";
                    break;
            }
            if (valueParam != string.Empty)
                Values.Insert(0, valueParam);
            filterQuery = new Dictionary<object, object>{
               { filterParam,Values}
             };
            return filterQuery;
        }

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
