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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Webhooks.Model
{
    /// <summary>
    /// Hook Payload
    /// </summary>
    [DataContract]
    public partial class HookPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HookPayload" /> class.
        /// </summary>
        public HookPayload()
        {
        }
        
        /// <summary>
        ///Gets or Sets CallbackUrl
        /// </summary>
        [DataMember(Name="callbackUrl", EmitDefaultValue=false)]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///Gets or Sets AutoReactivateHook
        /// </summary>
        [DataMember(Name="autoReactivateHook", EmitDefaultValue=false)]
        public bool? AutoReactivateHook { get; set; }

        /// <summary>
        ///Gets or Sets Scope
        /// </summary>
        [DataMember(Name="scope", EmitDefaultValue=true)]
        public Dictionary<Scopes, string> Scope { get; set; }

        /// <summary>
        ///Gets or Sets HookAttribute
        /// </summary>
        [DataMember(Name="hookAttribute", EmitDefaultValue=false)]
        public Object HookAttribute { get; set; }

        /// <summary>
        ///Gets or Sets HookExpiry
        /// </summary>
        [DataMember(Name="hookExpiry", EmitDefaultValue=false)]
        public string HookExpiry { get; set; }

        /// <summary>
        ///Gets or Sets Filter
        /// </summary>
        [DataMember(Name="filter", EmitDefaultValue=false)]
        public string Filter { get; set; }

        /// <summary>
        ///Gets or Sets HubId
        /// </summary>
        [DataMember(Name="hubId", EmitDefaultValue=false)]
        public string HubId { get; set; }

        /// <summary>
        ///Gets or Sets ProjectId
        /// </summary>
        [DataMember(Name="projectId", EmitDefaultValue=false)]
        public string ProjectId { get; set; }

        /// <summary>
        ///Gets or Sets Tenant
        /// </summary>
        [DataMember(Name="tenant", EmitDefaultValue=false)]
        public string Tenant { get; set; }

        /// <summary>
        ///Gets or Sets CallbackWithEventPayloadOnly
        /// </summary>
        [DataMember(Name="callbackWithEventPayloadOnly", EmitDefaultValue=false)]
        public bool? CallbackWithEventPayloadOnly { get; set; }

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
