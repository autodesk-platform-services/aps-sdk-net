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

namespace Autodesk.SecureServiceAccount
{
    /// <summary>
    /// An object that is returned when an API call fails.
    /// </summary>
    public abstract class ServiceApiException : HttpRequestException
    {
        /// <summary>
        /// Gets or sets the HTTP response message associated with the exception.
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ServiceApiException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceApiException"/> class with a specified error message, HTTP response message, and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="httpResponseMessage">The HTTP response message associated with the error.</param>
        /// <param name="exception">The exception that is the cause of the current exception.</param>
        public ServiceApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, exception)
        {
            this.HttpResponseMessage = httpResponseMessage;
        }
    }

    /// <summary>
    /// An object that is returned when an API call to the SecureServiceAccount service fails.
    /// </summary>
    public class SecureServiceAccountApiException : ServiceApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecureServiceAccountApiException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SecureServiceAccountApiException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecureServiceAccountApiException"/> class with a specified error message, HTTP response message, and inner exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="httpResponseMessage">The HTTP response message associated with the error.</param>
        /// <param name="exception">The exception that is the cause of the current exception.</param>
        public SecureServiceAccountApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, httpResponseMessage, exception) { }
    }
}
