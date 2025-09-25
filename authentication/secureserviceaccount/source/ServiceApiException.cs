/* 
 * APS SDK
 *
 * Autodesk Platform Services contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Authentication.SecureServiceAccount
 *
 * OAuth2 server-to-server account, key, and token management API.
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

namespace Autodesk.Authentication.SecureServiceAccount;

/// <summary>
/// An object that is returned when an API call fails.
/// </summary>
public abstract class ServiceApiException : HttpRequestException
{
	public HttpResponseMessage HttpResponseMessage { get; set; }

	public ServiceApiException(string message) : base(message) { }

	public ServiceApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, exception)
	{
		HttpResponseMessage = httpResponseMessage;
	}
}

/// <summary>
/// An object that is returned when an API call to the <see cref="SecureServiceAccount"/> service fails.
/// </summary>
public class SecureServiceAccountApiException : ServiceApiException
{
	public SecureServiceAccountApiException(string message) : base(message) { }

	public SecureServiceAccountApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, httpResponseMessage, exception) { }
}
