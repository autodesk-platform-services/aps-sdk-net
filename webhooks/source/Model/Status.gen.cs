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
    /// Indicates the current state of the webhook. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive webhook that has been reactivated. No events have occurred since reactivation.
///
///See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the system deactivates webhooks and subsequently reactivates them.    
    /// </summary>
    ///<value>Indicates the current state of the webhook. Possible values are 
///
///- `active` - Successfully delivered most recent event notifications. 
///- `inactive` - Failed to deliver most recent event notification and has been deactivated.
///- `reactivated` - Previously inactive webhook that has been reactivated. No events have occurred since reactivation.
///
///See [Event Delivery Guarantees](/en/docs/webhooks/v1/developers_guide/event-delivery-guarantees/) for more information on how the system deactivates webhooks and subsequently reactivates them.    </value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Status
    {
        
        /// <summary>
        /// Enum Active for value: active
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        
        /// <summary>
        /// Enum Inactive for value: inactive
        /// </summary>
        [EnumMember(Value = "inactive")]
        Inactive,
        
        /// <summary>
        /// Enum Reactivated for value: reactivated
        /// </summary>
        [EnumMember(Value = "reactivated")]
        Reactivated
    }

}
