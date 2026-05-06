/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Secure Service Account
 * Operations to manage Service accounts and keys.   A service account is an identity that an application can use to make requests to other services without a user authorizing the requests. A service account is identified by a unique email address and has an Autodesk ID.  A service account has one or more private keys. A private key is generated through an asymmetric cryptography algorithm; the paired public key is stored by Autodesk Identity.  An application can use a service account's private key to generate a JWT token. The JWT token provides proof of implicit authentication and authorization for this service account; an application can exchange it for a three-legged access token for the service service.
 *
 * Contact: aps.help@autodesk.com
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
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Autodesk.SecureServiceAccount.Client
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
                return ((DateTime)obj).ToString("o");
            }
            else
            {
                return Convert.ToString(obj);
            }
        }
        /// <summary>
        /// Asynchronously deserializes the HTTP content to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="content">The HTTP content to deserialize.</param>
        /// <returns>A task representing the asynchronous operation, with a result of the deserialized object.</returns>
        public static async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            // Don't deserialize Stream - this is fix for download scenarios.
            if (typeof(T) == typeof(System.IO.Stream))
            {
                return await (dynamic)content.ReadAsStreamAsync();
            }

            string mediaType = content.Headers.ContentType?.MediaType;
            if ((mediaType != "application/json") && (mediaType != "text/plain"))
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
        /// <param name="contentType"></param>
        /// <returns>HttpContent</returns>
        public static HttpContent Serialize(object obj, string contentType)
        {
            return new StringContent(JsonConvert.SerializeObject(obj));
        }

        /// <summary>
        /// Replaces a variable in the specified path with the given value.
        /// </summary>
        /// <param name="path">The path containing the variable to replace.</param>
        /// <param name="name">The name of the variable to replace.</param>
        /// <param name="value">The value to substitute for the variable.</param>
        /// <returns>The path with the variable replaced by the specified value.</returns>
        public static string SetPathVariable(string path, string name, object value)
        {
            return path.Replace($"", value.ToString());
        }

        /// <summary>
        /// Adds query parameters to the specified path.
        /// </summary>
        /// <param name="localVarPath">The base path to which the query will be added.</param>
        /// <param name="v">The value for the 'v' query parameter.</param>
        /// <param name="page">The value for the 'page' query parameter.</param>
        /// <returns>The path with the query parameters appended.</returns>
        public static string AddQuery(string localVarPath, string v, string page)
        {
            throw new NotImplementedException();
        }
    }
}
