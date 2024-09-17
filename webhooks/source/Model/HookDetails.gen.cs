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
    /// Contains the details of a webhook.
    /// </summary>
    [DataContract]
    public partial class HookDetails 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HookDetails" /> class.
        /// </summary>
        public HookDetails()
        {
        }
        
        /// <summary>
        ///The ID that uniquely identifies the webhook.
        /// </summary>
        /// <value>
        ///The ID that uniquely identifies the webhook.
        /// </value>
        [DataMember(Name="hookId", EmitDefaultValue=false)]
        public string HookId { get; set; }

        /// <summary>
        ///The ID of the tenant from which the event 
///originates.
        /// </summary>
        /// <value>
        ///The ID of the tenant from which the event 
///originates.
        /// </value>
        [DataMember(Name="tenant", EmitDefaultValue=false)]
        public string Tenant { get; set; }

        /// <summary>
        ///The URL to send notifications to when the 
///event is triggered. 
        /// </summary>
        /// <value>
        ///The URL to send notifications to when the 
///event is triggered. 
        /// </value>
        [DataMember(Name="callbackUrl", EmitDefaultValue=false)]
        public string CallbackUrl { get; set; }

        /// <summary>
        ///The ID of the entity that created the webhook. It can be one of the following:
///
///- Client ID of an app: If created using a Client Credentials flow (two-legged OAuth). 
///- User ID of a user: If created using an Authorization Code flow (three-legged OAuth).
        /// </summary>
        /// <value>
        ///The ID of the entity that created the webhook. It can be one of the following:
///
///- Client ID of an app: If created using a Client Credentials flow (two-legged OAuth). 
///- User ID of a user: If created using an Authorization Code flow (three-legged OAuth).
        /// </value>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events and wildcard patterns.
        /// </summary>
        /// <value>
        ///The ID of the event the webhook monitors.  See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of events and wildcard patterns.
        /// </value>
        [DataMember(Name="event", EmitDefaultValue=false)]
        public string Event { get; set; }

        /// <summary>
        ///The date and time when the webhook was created, formatted as an ISO 8601 date/time string.
        /// </summary>
        /// <value>
        ///The date and time when the webhook was created, formatted as an ISO 8601 date/time string.
        /// </value>
        [DataMember(Name="createdDate", EmitDefaultValue=false)]
        public string CreatedDate { get; set; }

        /// <summary>
        ///The date and time when the webhook was last modified, formatted as an ISO 8601 date/time string.
        /// </summary>
        /// <value>
        ///The date and time when the webhook was last modified, formatted as an ISO 8601 date/time string.
        /// </value>
        [DataMember(Name="lastUpdatedDate", EmitDefaultValue=false)]
        public string LastUpdatedDate { get; set; }

        /// <summary>
        ///The ID of the system the webhook applies to. For example `data` for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of systems.
        /// </summary>
        /// <value>
        ///The ID of the system the webhook applies to. For example `data` for Data Management. See [Supported Events](/en/docs/webhooks/v1/reference/events/) for a full list of systems.
        /// </value>
        [DataMember(Name="system", EmitDefaultValue=false)]
        public string System { get; set; }

        /// <summary>
        ///Indicates what type of an entity created the webhooks. Possible values:
///
///- `O2User` - Created by a user through an Authorization Code flow (three-legged OAuth).
///- `Application` - Created by an application using a Client Credentials flow (two-legged OAuth).
        /// </summary>
        /// <value>
        ///Indicates what type of an entity created the webhooks. Possible values:
///
///- `O2User` - Created by a user through an Authorization Code flow (three-legged OAuth).
///- `Application` - Created by an application using a Client Credentials flow (two-legged OAuth).
        /// </value>
        [DataMember(Name="creatorType", EmitDefaultValue=false)]
        public string CreatorType { get; set; }

        /// <summary>
        ///Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public Status Status { get; set; }

        /// <summary>
        ///`true` - Automatically reactivate the webhook if it becomes `inactive`.
///
///`false` - (Default) Do not reactivate the webhook if it becomes `inactive`.
///
///See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the webhooks service handles reactivation.
        /// </summary>
        /// <value>
        ///`true` - Automatically reactivate the webhook if it becomes `inactive`.
///
///`false` - (Default) Do not reactivate the webhook if it becomes `inactive`.
///
///See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the webhooks service handles reactivation.
        /// </value>
        [DataMember(Name="autoReactivateHook", EmitDefaultValue=false)]
        public bool? AutoReactivateHook { get; set; }

        /// <summary>
        ///The date and time when the webhook will expire, formatted as an ISO 8601 date/time string. A missing or null value indicates that the webhook will never expire.
///
///`hookExpiry` is returned only if it was specified when the webhook was created.
        /// </summary>
        /// <value>
        ///The date and time when the webhook will expire, formatted as an ISO 8601 date/time string. A missing or null value indicates that the webhook will never expire.
///
///`hookExpiry` is returned only if it was specified when the webhook was created.
        /// </value>
        [DataMember(Name="hookExpiry", EmitDefaultValue=false)]
        public string HookExpiry { get; set; }

        /// <summary>
        ///Gets or Sets Scope
        /// </summary>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public HookDetailsScope Scope { get; set; }

        /// <summary>
        ///The URN of the webhook.
        /// </summary>
        /// <value>
        ///The URN of the webhook.
        /// </value>
        [DataMember(Name="urn", EmitDefaultValue=false)]
        public string Urn { get; set; }

        /// <summary>
        ///`true` - The callback request payload will only contain information about the event. It will not contain any information about the webhook.
///
///`false` - The callback request payload will contain information about the event as well as the webhook.
        /// </summary>
        /// <value>
        ///`true` - The callback request payload will only contain information about the event. It will not contain any information about the webhook.
///
///`false` - The callback request payload will contain information about the event as well as the webhook.
        /// </value>
        [DataMember(Name="callbackWithEventPayloadOnly", EmitDefaultValue=false)]
        public string CallbackWithEventPayloadOnly { get; set; }

        /// <summary>
        ///A link to itself.
        /// </summary>
        /// <value>
        ///A link to itself.
        /// </value>
        [DataMember(Name="__self__", EmitDefaultValue=false)]
        public string Self { get; set; }

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
