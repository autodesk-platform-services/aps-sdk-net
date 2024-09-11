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
    /// Specifies the details of a webhook to be updated. 
    /// </summary>
    [DataContract]
    public partial class ModifyHookPayload 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyHookPayload" /> class.
        /// </summary>
        public ModifyHookPayload()
        {
        }
        
        /// <summary>
        ///Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=true)]
        public StatusRequest Status { get; set; }

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
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </summary>
        /// <value>
        ///Specifies the extent to which the event is monitored. For example, if the scope is folder, the webhooks service generates a notification for the specified event occurring in any sub folder or item within that folder.
        /// </value>
        [DataMember(Name="hookAttribute", EmitDefaultValue=false)]
        public Object HookAttribute { get; set; }

        /// <summary>
        ///A secret token that is used to generate a hash signature, which is passed along with notification requests to the callback URL.
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </summary>
        /// <value>
        ///A secret token that is used to generate a hash signature, which is passed along with notification requests to the callback URL.
///
///See the [Secret Token](/en/docs/webhooks/v1/developers_guide/basics/#secret-token) section in API Basics for more information.
        /// </value>
        [DataMember(Name="token", EmitDefaultValue=false)]
        public string Token { get; set; }

        /// <summary>
        ///The date and time the webhook will expire, formatted as an ISO 8601 date/time string. If you set this to null, the webhook will never expire.
        /// </summary>
        /// <value>
        ///The date and time the webhook will expire, formatted as an ISO 8601 date/time string. If you set this to null, the webhook will never expire.
        /// </value>
        [DataMember(Name="hookExpiry", EmitDefaultValue=false)]
        public string HookExpiry { get; set; }

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
