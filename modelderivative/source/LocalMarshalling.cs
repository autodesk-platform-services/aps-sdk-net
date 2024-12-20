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
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
namespace Autodesk.ModelDerivative.Client
{
    /// <summary>
    /// Helpers for marshalling parameters
    /// </summary>
    public partial class LocalMarshalling
    {
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };

        /// <summary>
        /// If parameter is DateTime, output in a formatted string (default ISO 8601)
        /// Otherwise just return the string.
        /// </summary>
        /// <param name="obj">The parameter (header, path, query, form).</param>
        /// <returns>Formatted string.</returns>
        public static string ParameterToString(object obj)
        {
            if (obj is DateTime)
            {
                // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Roundtrip
                return ((DateTime)obj).ToString ("o");
            }
            if (obj is Boolean)
            {
                return (Boolean)obj ? "true" : "false";
            }
            else
            {
                return Convert.ToString (obj);
            }
        }
        public static async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            if (content==null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            // Don't deserialize Stream - this is fix for download scenarios.
            if(typeof(T) == typeof(System.IO.Stream))
            {
                return await (dynamic) content.ReadAsStreamAsync();
            }

            string mediaType = content.Headers.ContentType?.MediaType;
            if ((mediaType != "application/json") && (mediaType!= "text/plain"))
            {
                throw new ArgumentException($"Content-Type must be application/json. '{mediaType}' was specified.");
            }
            var str = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="content">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        public static object Deserialize(HttpContent content, Type type)
        {
            return JsonConvert.DeserializeObject(content.ReadAsStringAsync().Result, type);
        }

        /// <summary>
        /// Serialize an input (model) into JSON string
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>HttpContent</returns>
        public static HttpContent Serialize(object obj, string contentType)
        {
            return new StringContent(JsonConvert.SerializeObject(obj));
        }

        public static string SetPathVariable(string path, string name, object value)
        {
            return path.Replace($"", value.ToString());
        }

        public static string AddQuery(string localVarPath, string v, string page)
        {
            throw new NotImplementedException();
        }
    }
}
