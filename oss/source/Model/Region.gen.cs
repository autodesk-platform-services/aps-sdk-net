/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
 *
 * oss
 *
 * The Object Storage Service (OSS) allows your application to download and upload raw files (such as PDF, XLS, DWG, or RVT) that are managed by the Data service.
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

namespace Autodesk.Oss.Model
{
    /// <summary>
    /// Specifies where the bucket containing the object is stored. Possible values are:
    ///
    ///- `US` : (Default) Data center for the US region.
    ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
    ///- `AUS` : (Beta) Data center for Australia.
    ///- `CAN` : Data center for the Canada region.
    ///- `DEU` : Data center for the Germany region.
    ///- `IND` : Data center for the India region.
    ///- `JPN` : Data center for the Japan region.
    ///- `GBR` : Data center for the United Kingdom region.
    ///
    ///**Note:** Beta features are subject to change. Please do not use in production environments.     
    /// </summary>
    ///<value>Specifies where the bucket containing the object is stored. Possible values are:
    ///
    ///- `US` : (Default) Data center for the US region.
    ///- `EMEA` : Data center for the European Union, Middle East, and Africa.
    ///- `AUS` : (Beta) Data center for Australia.
    ///- `CAN` : Data center for the Canada region.
    ///- `DEU` : Data center for the Germany region.
    ///- `IND` : Data center for the India region.
    ///- `JPN` : Data center for the Japan region.
    ///- `GBR` : Data center for the United Kingdom region.
    ///
    ///**Note:** Beta features are subject to change. Please do not use in production environments.     </value>

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
        /// Enum AUS for value: AUS
        /// </summary>
        [EnumMember(Value = "AUS")]
        AUS,

        /// <summary>
        /// Enum APAC for value: APAC
        /// </summary>
        [Obsolete("Please use AUS instead.")]
        [EnumMember(Value = "APAC")]
        APAC,

        /// <summary>
        /// Enum CAN for value: CAN
        /// </summary>
        [EnumMember(Value = "CAN")]
        CAN,

        /// <summary>
        /// Enum DEU for value: DEU
        /// </summary>
        [EnumMember(Value = "DEU")]
        DEU,

        /// <summary>
        /// Enum IND for value: IND
        /// </summary>
        [EnumMember(Value = "IND")]
        IND,

        /// <summary>
        /// Enum JPN for value: JPN
        /// </summary>
        [EnumMember(Value = "JPN")]
        JPN,

        /// <summary>
        /// Enum GBR for value: GBR
        /// </summary>
        [EnumMember(Value = "GBR")]
        GBR
    }

}
