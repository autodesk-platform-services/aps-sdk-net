/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Webhooks
 *
 * The Webhooks API enables applications to listen to APS events and receive notifications when they occur. When an event is triggered, the Webhooks service sends a notification to a callback URL you have defined.  You can customize the types of events and resources for which you receive notifications. For example, you can set up a webhook to send notifications when files are modified or deleted in a specified hub or project.  Below is quick summary of this workflow:  1. Identify the data for which you want to receive notifications. 2. Use the Webhooks API to create one or more hooks. 3. The Webhooks service will notify the webhook when there is a change in the data. 
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
  public abstract class ServiceApiException : HttpRequestException
  {
    public HttpResponseMessage HttpResponseMessage {get; set;}

    public ServiceApiException(string message) : base(message) {}
    public ServiceApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, exception)
    {
      this.HttpResponseMessage = httpResponseMessage;
    }
  }

  public class WebhooksApiException : ServiceApiException
  {
    public WebhooksApiException(string message) : base(message) {}
    public WebhooksApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, httpResponseMessage, exception) {}
  }
}
