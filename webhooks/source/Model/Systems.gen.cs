/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// Defines Systems
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Systems
    {
        
        /// <summary>
        /// Enum Data for value: data
        /// </summary>
        [EnumMember(Value = "data")]
        Data,
        
        /// <summary>
        /// Enum Derivative for value: derivative
        /// </summary>
        [EnumMember(Value = "derivative")]
        Derivative,
        
        /// <summary>
        /// Enum AdskC4r for value: adsk.c4r
        /// </summary>
        [EnumMember(Value = "adsk.c4r")]
        AdskC4r,
        
        /// <summary>
        /// Enum AdskFlcProduction for value: adsk.flc.production
        /// </summary>
        [EnumMember(Value = "adsk.flc.production")]
        AdskFlcProduction,
        
        /// <summary>
        /// Enum AutodeskConstructionCost for value: autodesk.construction.cost
        /// </summary>
        [EnumMember(Value = "autodesk.construction.cost")]
        AutodeskConstructionCost,
        
        /// <summary>
        /// Enum AutodeskConstructionBc for value: autodesk.construction.bc
        /// </summary>
        [EnumMember(Value = "autodesk.construction.bc")]
        AutodeskConstructionBc,
        
        /// <summary>
        /// Enum AutodeskConstructionIssues for value: autodesk.construction.issues
        /// </summary>
        [EnumMember(Value = "autodesk.construction.issues")]
        AutodeskConstructionIssues
    }

}
