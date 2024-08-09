/* 
 * APS SDK
 *
 * The Forge Platform contains an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * Construction.Account.Admin
 *
 * The Account Admin API automates creating and managing projects, assigning and managing project users, and managing member and partner company directories. You can also synchronize data with external systems. 
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

namespace Autodesk.Construction.AccountAdmin
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

  public class ConstructionAccountAdminApiException : ServiceApiException
  {
    public ConstructionAccountAdminApiException(string message) : base(message) {}
    public ConstructionAccountAdminApiException(string message, HttpResponseMessage httpResponseMessage, Exception exception) : base(message, httpResponseMessage, exception) {}
  }
}
