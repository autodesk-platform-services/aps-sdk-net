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
    /// Specifies the geographical location (region) of the server a request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `APAC` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** Beta features are subject to change. Please avoid using them in production environments.
    /// </summary>
    ///<value>Specifies the geographical location (region) of the server a request must be executed on. This also corresponds to the region where the Webhook data is stored. It is also the location of the server that will make requests to your callback URL. Possible values:
///
///- `US` - (Default) Data center dedicated to serve the United States region.
///- `EMEA` - Data center dedicated to serve the European Union, Middle East, and Africa regions.
///- `APAC` - (Beta) Data center dedicated to serve the Australia region.
///
///**Note:** Beta features are subject to change. Please avoid using them in production environments.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Region
    {
        
        /// <summary>
        /// Enum US for value: US
        /// </summary>
        [EnumMember(Value = "US")]
        US,
        
        /// <summary>
        /// Enum EMEA for value: EMEA
        /// </summary>
        [EnumMember(Value = "EMEA")]
        EMEA,
        
        /// <summary>
        /// Enum APAC for value: APAC
        /// </summary>
        [EnumMember(Value = "APAC")]
        APAC
    }

}
