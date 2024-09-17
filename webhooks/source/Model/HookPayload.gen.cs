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
    /// Specifies the details of a webhook to be created. 
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
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </summary>
        /// <value>
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </value>
        [DataMember(Name="scope", EmitDefaultValue=false)]
        public Object Scope { get; set; }

        /// <summary>
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </summary>
        /// <value>
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </value>
        [DataMember(Name="hookAttribute", EmitDefaultValue=false)]
        public Object HookAttribute { get; set; }

        /// <summary>
        ///The date and time the webhook will expire, formatted as an ISO 8601 date/time string. If you do not specify this attribute or set it to null, the webhook will never expire.
        /// </summary>
        /// <value>
        ///The date and time the webhook will expire, formatted as an ISO 8601 date/time string. If you do not specify this attribute or set it to null, the webhook will never expire.
        /// </value>
        [DataMember(Name="hookExpiry", EmitDefaultValue=false)]
        public string HookExpiry { get; set; }

        /// <summary>
        ///A Jsonpath expression that you can use to filter the callbacks you receive.
///
///See [Callback Filtering](/en/docs/webhooks/v1/developers_guide/callback-filtering/) for more information.
        /// </summary>
        /// <value>
        ///A Jsonpath expression that you can use to filter the callbacks you receive.
///
///See [Callback Filtering](/en/docs/webhooks/v1/developers_guide/callback-filtering/) for more information.
        /// </value>
        [DataMember(Name="filter", EmitDefaultValue=false)]
        public string Filter { get; set; }

        /// <summary>
        ///The ID of the hub that contains the entity that you want to monitor. Specify this attribute if the user calling this operation is a member of a large number of projects.
///
///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        /// </summary>
        /// <value>
        ///The ID of the hub that contains the entity that you want to monitor. Specify this attribute if the user calling this operation is a member of a large number of projects.
///
///For BIM 360 Docs and ACC Docs, a hub ID corresponds to an Account ID. To convert a BIM 360 or ACC Account ID to a hub ID, prefix the Account ID with `b.`. For example, an Account ID of ``c8b0c73d-3ae9`` translates to a hub ID of `b.c8b0c73d-3ae9`.
        /// </value>
        [DataMember(Name="hubId", EmitDefaultValue=false)]
        public string HubId { get; set; }

        /// <summary>
        ///The ID of the project that contains the entity that you want to monitor Specify this attribute if the user calling this operation is a member of a large number of projects.
///
///BIM 360 and ACC project IDs are different to Data Management project IDs. To convert a BIM 360 and ACC project IDs to  Data Management project IDs, prefix the BIM 360 or ACC Project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </summary>
        /// <value>
        ///The ID of the project that contains the entity that you want to monitor Specify this attribute if the user calling this operation is a member of a large number of projects.
///
///BIM 360 and ACC project IDs are different to Data Management project IDs. To convert a BIM 360 and ACC project IDs to  Data Management project IDs, prefix the BIM 360 or ACC Project ID with `b.`. For example, a project ID of `c8b0c73d-3ae9` translates to a project ID of `b.c8b0c73d-3ae9`.
        /// </value>
        [DataMember(Name="projectId", EmitDefaultValue=false)]
        public string ProjectId { get; set; }

        /// <summary>
        ///The tenant associated with the event. If specified on the webhook, the event's tenant must match the webhook's tenant.
        /// </summary>
        /// <value>
        ///The tenant associated with the event. If specified on the webhook, the event's tenant must match the webhook's tenant.
        /// </value>
        [DataMember(Name="tenant", EmitDefaultValue=false)]
        public string Tenant { get; set; }

        /// <summary>
        ///`true` - The callback request payload must only contain information about the event. It must not contain any information about the webhook.
///
///`false` - (Default) The callback request payload must contain information about the event as well as the webhook.
        /// </summary>
        /// <value>
        ///`true` - The callback request payload must only contain information about the event. It must not contain any information about the webhook.
///
///`false` - (Default) The callback request payload must contain information about the event as well as the webhook.
        /// </value>
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
