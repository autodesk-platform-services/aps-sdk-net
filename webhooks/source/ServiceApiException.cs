/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined. You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project. Below is quick summary of this workflow: 1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
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

namespace Autodesk.Webhooks
{
  /// <summary>
  /// An object that is returned when an API call fails.
  /// </summary>
  public abstract class ServiceApiException : HttpRequestException
  {
    /// <summary>
    /// Gets or sets the HTTP response message.
    /// </summary>
    public HttpResponseMessage HttpResponseMessage { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceApiException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public ServiceApiException(string message) : base(message) {}

    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceApiException"/> class with a specified error message, HTTP response message, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <param name="exception">The exception that is the cause of the current exception.</param>
    public ServiceApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, exception)
    {
      this.HttpResponseMessage = httpResponseMessage;
    }
  }

  /// <summary>
  /// An object that is returned when an API call to the Webhooks service fails.
  /// </summary>
  public class WebhooksApiException : ServiceApiException
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="WebhooksApiException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public WebhooksApiException(string message) : base(message) {}

    /// <summary>
    /// Initializes a new instance of the <see cref="WebhooksApiException"/> class with a specified error message, HTTP response message, and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <param name="exception">The exception that is the cause of the current exception.</param>
    public WebhooksApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, httpResponseMessage, exception) {}
  }
}