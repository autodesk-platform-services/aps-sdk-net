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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Construction.AccountAdmin.Model
{
    /// <summary>
    /// Defines currency
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Currency
    {
        
        /// <summary>
        /// Enum AED for value: AED
        /// </summary>
        [EnumMember(Value = "AED")]
        AED,
        
        /// <summary>
        /// Enum AFN for value: AFN
        /// </summary>
        [EnumMember(Value = "AFN")]
        AFN,
        
        /// <summary>
        /// Enum ALL for value: ALL
        /// </summary>
        [EnumMember(Value = "ALL")]
        ALL,
        
        /// <summary>
        /// Enum AMD for value: AMD
        /// </summary>
        [EnumMember(Value = "AMD")]
        AMD,
        
        /// <summary>
        /// Enum ANG for value: ANG
        /// </summary>
        [EnumMember(Value = "ANG")]
        ANG,
        
        /// <summary>
        /// Enum AOA for value: AOA
        /// </summary>
        [EnumMember(Value = "AOA")]
        AOA,
        
        /// <summary>
        /// Enum ARS for value: ARS
        /// </summary>
        [EnumMember(Value = "ARS")]
        ARS,
        
        /// <summary>
        /// Enum AUD for value: AUD
        /// </summary>
        [EnumMember(Value = "AUD")]
        AUD,
        
        /// <summary>
        /// Enum AWG for value: AWG
        /// </summary>
        [EnumMember(Value = "AWG")]
        AWG,
        
        /// <summary>
        /// Enum AZN for value: AZN
        /// </summary>
        [EnumMember(Value = "AZN")]
        AZN,
        
        /// <summary>
        /// Enum BAM for value: BAM
        /// </summary>
        [EnumMember(Value = "BAM")]
        BAM,
        
        /// <summary>
        /// Enum BBD for value: BBD
        /// </summary>
        [EnumMember(Value = "BBD")]
        BBD,
        
        /// <summary>
        /// Enum BDT for value: BDT
        /// </summary>
        [EnumMember(Value = "BDT")]
        BDT,
        
        /// <summary>
        /// Enum BGN for value: BGN
        /// </summary>
        [EnumMember(Value = "BGN")]
        BGN,
        
        /// <summary>
        /// Enum BHD for value: BHD
        /// </summary>
        [EnumMember(Value = "BHD")]
        BHD,
        
        /// <summary>
        /// Enum BIF for value: BIF
        /// </summary>
        [EnumMember(Value = "BIF")]
        BIF,
        
        /// <summary>
        /// Enum BMD for value: BMD
        /// </summary>
        [EnumMember(Value = "BMD")]
        BMD,
        
        /// <summary>
        /// Enum BND for value: BND
        /// </summary>
        [EnumMember(Value = "BND")]
        BND,
        
        /// <summary>
        /// Enum BOB for value: BOB
        /// </summary>
        [EnumMember(Value = "BOB")]
        BOB,
        
        /// <summary>
        /// Enum BOV for value: BOV
        /// </summary>
        [EnumMember(Value = "BOV")]
        BOV,
        
        /// <summary>
        /// Enum BRL for value: BRL
        /// </summary>
        [EnumMember(Value = "BRL")]
        BRL,
        
        /// <summary>
        /// Enum BSD for value: BSD
        /// </summary>
        [EnumMember(Value = "BSD")]
        BSD,
        
        /// <summary>
        /// Enum BTN for value: BTN
        /// </summary>
        [EnumMember(Value = "BTN")]
        BTN,
        
        /// <summary>
        /// Enum BWP for value: BWP
        /// </summary>
        [EnumMember(Value = "BWP")]
        BWP,
        
        /// <summary>
        /// Enum BYN for value: BYN
        /// </summary>
        [EnumMember(Value = "BYN")]
        BYN,
        
        /// <summary>
        /// Enum BYR for value: BYR
        /// </summary>
        [EnumMember(Value = "BYR")]
        BYR,
        
        /// <summary>
        /// Enum BZD for value: BZD
        /// </summary>
        [EnumMember(Value = "BZD")]
        BZD,
        
        /// <summary>
        /// Enum CAD for value: CAD
        /// </summary>
        [EnumMember(Value = "CAD")]
        CAD,
        
        /// <summary>
        /// Enum CDF for value: CDF
        /// </summary>
        [EnumMember(Value = "CDF")]
        CDF,
        
        /// <summary>
        /// Enum CHE for value: CHE
        /// </summary>
        [EnumMember(Value = "CHE")]
        CHE,
        
        /// <summary>
        /// Enum CHF for value: CHF
        /// </summary>
        [EnumMember(Value = "CHF")]
        CHF,
        
        /// <summary>
        /// Enum CHW for value: CHW
        /// </summary>
        [EnumMember(Value = "CHW")]
        CHW,
        
        /// <summary>
        /// Enum CLF for value: CLF
        /// </summary>
        [EnumMember(Value = "CLF")]
        CLF,
        
        /// <summary>
        /// Enum CLP for value: CLP
        /// </summary>
        [EnumMember(Value = "CLP")]
        CLP,
        
        /// <summary>
        /// Enum CNY for value: CNY
        /// </summary>
        [EnumMember(Value = "CNY")]
        CNY,
        
        /// <summary>
        /// Enum COP for value: COP
        /// </summary>
        [EnumMember(Value = "COP")]
        COP,
        
        /// <summary>
        /// Enum COU for value: COU
        /// </summary>
        [EnumMember(Value = "COU")]
        COU,
        
        /// <summary>
        /// Enum CRC for value: CRC
        /// </summary>
        [EnumMember(Value = "CRC")]
        CRC,
        
        /// <summary>
        /// Enum CUC for value: CUC
        /// </summary>
        [EnumMember(Value = "CUC")]
        CUC,
        
        /// <summary>
        /// Enum CUP for value: CUP
        /// </summary>
        [EnumMember(Value = "CUP")]
        CUP,
        
        /// <summary>
        /// Enum CVE for value: CVE
        /// </summary>
        [EnumMember(Value = "CVE")]
        CVE,
        
        /// <summary>
        /// Enum CZK for value: CZK
        /// </summary>
        [EnumMember(Value = "CZK")]
        CZK,
        
        /// <summary>
        /// Enum DJF for value: DJF
        /// </summary>
        [EnumMember(Value = "DJF")]
        DJF,
        
        /// <summary>
        /// Enum DKK for value: DKK
        /// </summary>
        [EnumMember(Value = "DKK")]
        DKK,
        
        /// <summary>
        /// Enum DOP for value: DOP
        /// </summary>
        [EnumMember(Value = "DOP")]
        DOP,
        
        /// <summary>
        /// Enum DZD for value: DZD
        /// </summary>
        [EnumMember(Value = "DZD")]
        DZD,
        
        /// <summary>
        /// Enum EEK for value: EEK
        /// </summary>
        [EnumMember(Value = "EEK")]
        EEK,
        
        /// <summary>
        /// Enum EGP for value: EGP
        /// </summary>
        [EnumMember(Value = "EGP")]
        EGP,
        
        /// <summary>
        /// Enum ERN for value: ERN
        /// </summary>
        [EnumMember(Value = "ERN")]
        ERN,
        
        /// <summary>
        /// Enum ETB for value: ETB
        /// </summary>
        [EnumMember(Value = "ETB")]
        ETB,
        
        /// <summary>
        /// Enum EUR for value: EUR
        /// </summary>
        [EnumMember(Value = "EUR")]
        EUR,
        
        /// <summary>
        /// Enum FJD for value: FJD
        /// </summary>
        [EnumMember(Value = "FJD")]
        FJD,
        
        /// <summary>
        /// Enum FKP for value: FKP
        /// </summary>
        [EnumMember(Value = "FKP")]
        FKP,
        
        /// <summary>
        /// Enum GBP for value: GBP
        /// </summary>
        [EnumMember(Value = "GBP")]
        GBP,
        
        /// <summary>
        /// Enum GEL for value: GEL
        /// </summary>
        [EnumMember(Value = "GEL")]
        GEL,
        
        /// <summary>
        /// Enum GHS for value: GHS
        /// </summary>
        [EnumMember(Value = "GHS")]
        GHS,
        
        /// <summary>
        /// Enum GIP for value: GIP
        /// </summary>
        [EnumMember(Value = "GIP")]
        GIP,
        
        /// <summary>
        /// Enum GMD for value: GMD
        /// </summary>
        [EnumMember(Value = "GMD")]
        GMD,
        
        /// <summary>
        /// Enum GNF for value: GNF
        /// </summary>
        [EnumMember(Value = "GNF")]
        GNF,
        
        /// <summary>
        /// Enum GTQ for value: GTQ
        /// </summary>
        [EnumMember(Value = "GTQ")]
        GTQ,
        
        /// <summary>
        /// Enum GYD for value: GYD
        /// </summary>
        [EnumMember(Value = "GYD")]
        GYD,
        
        /// <summary>
        /// Enum HKD for value: HKD
        /// </summary>
        [EnumMember(Value = "HKD")]
        HKD,
        
        /// <summary>
        /// Enum HNL for value: HNL
        /// </summary>
        [EnumMember(Value = "HNL")]
        HNL,
        
        /// <summary>
        /// Enum HRK for value: HRK
        /// </summary>
        [EnumMember(Value = "HRK")]
        HRK,
        
        /// <summary>
        /// Enum HTG for value: HTG
        /// </summary>
        [EnumMember(Value = "HTG")]
        HTG,
        
        /// <summary>
        /// Enum HUF for value: HUF
        /// </summary>
        [EnumMember(Value = "HUF")]
        HUF,
        
        /// <summary>
        /// Enum IDR for value: IDR
        /// </summary>
        [EnumMember(Value = "IDR")]
        IDR,
        
        /// <summary>
        /// Enum ILS for value: ILS
        /// </summary>
        [EnumMember(Value = "ILS")]
        ILS,
        
        /// <summary>
        /// Enum INR for value: INR
        /// </summary>
        [EnumMember(Value = "INR")]
        INR,
        
        /// <summary>
        /// Enum IQD for value: IQD
        /// </summary>
        [EnumMember(Value = "IQD")]
        IQD,
        
        /// <summary>
        /// Enum IRR for value: IRR
        /// </summary>
        [EnumMember(Value = "IRR")]
        IRR,
        
        /// <summary>
        /// Enum ISK for value: ISK
        /// </summary>
        [EnumMember(Value = "ISK")]
        ISK,
        
        /// <summary>
        /// Enum JMD for value: JMD
        /// </summary>
        [EnumMember(Value = "JMD")]
        JMD,
        
        /// <summary>
        /// Enum JOD for value: JOD
        /// </summary>
        [EnumMember(Value = "JOD")]
        JOD,
        
        /// <summary>
        /// Enum JPY for value: JPY
        /// </summary>
        [EnumMember(Value = "JPY")]
        JPY,
        
        /// <summary>
        /// Enum KES for value: KES
        /// </summary>
        [EnumMember(Value = "KES")]
        KES,
        
        /// <summary>
        /// Enum KGS for value: KGS
        /// </summary>
        [EnumMember(Value = "KGS")]
        KGS,
        
        /// <summary>
        /// Enum KHR for value: KHR
        /// </summary>
        [EnumMember(Value = "KHR")]
        KHR,
        
        /// <summary>
        /// Enum KMF for value: KMF
        /// </summary>
        [EnumMember(Value = "KMF")]
        KMF,
        
        /// <summary>
        /// Enum KPW for value: KPW
        /// </summary>
        [EnumMember(Value = "KPW")]
        KPW,
        
        /// <summary>
        /// Enum KRW for value: KRW
        /// </summary>
        [EnumMember(Value = "KRW")]
        KRW,
        
        /// <summary>
        /// Enum KWD for value: KWD
        /// </summary>
        [EnumMember(Value = "KWD")]
        KWD,
        
        /// <summary>
        /// Enum KYD for value: KYD
        /// </summary>
        [EnumMember(Value = "KYD")]
        KYD,
        
        /// <summary>
        /// Enum KZT for value: KZT
        /// </summary>
        [EnumMember(Value = "KZT")]
        KZT,
        
        /// <summary>
        /// Enum LAK for value: LAK
        /// </summary>
        [EnumMember(Value = "LAK")]
        LAK,
        
        /// <summary>
        /// Enum LBP for value: LBP
        /// </summary>
        [EnumMember(Value = "LBP")]
        LBP,
        
        /// <summary>
        /// Enum LKR for value: LKR
        /// </summary>
        [EnumMember(Value = "LKR")]
        LKR,
        
        /// <summary>
        /// Enum LRD for value: LRD
        /// </summary>
        [EnumMember(Value = "LRD")]
        LRD,
        
        /// <summary>
        /// Enum LSL for value: LSL
        /// </summary>
        [EnumMember(Value = "LSL")]
        LSL,
        
        /// <summary>
        /// Enum LTL for value: LTL
        /// </summary>
        [EnumMember(Value = "LTL")]
        LTL,
        
        /// <summary>
        /// Enum LVL for value: LVL
        /// </summary>
        [EnumMember(Value = "LVL")]
        LVL,
        
        /// <summary>
        /// Enum LYD for value: LYD
        /// </summary>
        [EnumMember(Value = "LYD")]
        LYD,
        
        /// <summary>
        /// Enum MAD for value: MAD
        /// </summary>
        [EnumMember(Value = "MAD")]
        MAD,
        
        /// <summary>
        /// Enum MDL for value: MDL
        /// </summary>
        [EnumMember(Value = "MDL")]
        MDL,
        
        /// <summary>
        /// Enum MGA for value: MGA
        /// </summary>
        [EnumMember(Value = "MGA")]
        MGA,
        
        /// <summary>
        /// Enum MKD for value: MKD
        /// </summary>
        [EnumMember(Value = "MKD")]
        MKD,
        
        /// <summary>
        /// Enum MMK for value: MMK
        /// </summary>
        [EnumMember(Value = "MMK")]
        MMK,
        
        /// <summary>
        /// Enum MNT for value: MNT
        /// </summary>
        [EnumMember(Value = "MNT")]
        MNT,
        
        /// <summary>
        /// Enum MOP for value: MOP
        /// </summary>
        [EnumMember(Value = "MOP")]
        MOP,
        
        /// <summary>
        /// Enum MRU for value: MRU
        /// </summary>
        [EnumMember(Value = "MRU")]
        MRU,
        
        /// <summary>
        /// Enum MUR for value: MUR
        /// </summary>
        [EnumMember(Value = "MUR")]
        MUR,
        
        /// <summary>
        /// Enum MVR for value: MVR
        /// </summary>
        [EnumMember(Value = "MVR")]
        MVR,
        
        /// <summary>
        /// Enum MWK for value: MWK
        /// </summary>
        [EnumMember(Value = "MWK")]
        MWK,
        
        /// <summary>
        /// Enum MXN for value: MXN
        /// </summary>
        [EnumMember(Value = "MXN")]
        MXN,
        
        /// <summary>
        /// Enum MXV for value: MXV
        /// </summary>
        [EnumMember(Value = "MXV")]
        MXV,
        
        /// <summary>
        /// Enum MYR for value: MYR
        /// </summary>
        [EnumMember(Value = "MYR")]
        MYR,
        
        /// <summary>
        /// Enum MZN for value: MZN
        /// </summary>
        [EnumMember(Value = "MZN")]
        MZN,
        
        /// <summary>
        /// Enum NAD for value: NAD
        /// </summary>
        [EnumMember(Value = "NAD")]
        NAD,
        
        /// <summary>
        /// Enum NGN for value: NGN
        /// </summary>
        [EnumMember(Value = "NGN")]
        NGN,
        
        /// <summary>
        /// Enum NIO for value: NIO
        /// </summary>
        [EnumMember(Value = "NIO")]
        NIO,
        
        /// <summary>
        /// Enum NOK for value: NOK
        /// </summary>
        [EnumMember(Value = "NOK")]
        NOK,
        
        /// <summary>
        /// Enum NPR for value: NPR
        /// </summary>
        [EnumMember(Value = "NPR")]
        NPR,
        
        /// <summary>
        /// Enum NZD for value: NZD
        /// </summary>
        [EnumMember(Value = "NZD")]
        NZD,
        
        /// <summary>
        /// Enum OMR for value: OMR
        /// </summary>
        [EnumMember(Value = "OMR")]
        OMR,
        
        /// <summary>
        /// Enum PAB for value: PAB
        /// </summary>
        [EnumMember(Value = "PAB")]
        PAB,
        
        /// <summary>
        /// Enum PEN for value: PEN
        /// </summary>
        [EnumMember(Value = "PEN")]
        PEN,
        
        /// <summary>
        /// Enum PGK for value: PGK
        /// </summary>
        [EnumMember(Value = "PGK")]
        PGK,
        
        /// <summary>
        /// Enum PHP for value: PHP
        /// </summary>
        [EnumMember(Value = "PHP")]
        PHP,
        
        /// <summary>
        /// Enum PKR for value: PKR
        /// </summary>
        [EnumMember(Value = "PKR")]
        PKR,
        
        /// <summary>
        /// Enum PLN for value: PLN
        /// </summary>
        [EnumMember(Value = "PLN")]
        PLN,
        
        /// <summary>
        /// Enum PYG for value: PYG
        /// </summary>
        [EnumMember(Value = "PYG")]
        PYG,
        
        /// <summary>
        /// Enum QAR for value: QAR
        /// </summary>
        [EnumMember(Value = "QAR")]
        QAR,
        
        /// <summary>
        /// Enum RON for value: RON
        /// </summary>
        [EnumMember(Value = "RON")]
        RON,
        
        /// <summary>
        /// Enum RSD for value: RSD
        /// </summary>
        [EnumMember(Value = "RSD")]
        RSD,
        
        /// <summary>
        /// Enum RUB for value: RUB
        /// </summary>
        [EnumMember(Value = "RUB")]
        RUB,
        
        /// <summary>
        /// Enum RWF for value: RWF
        /// </summary>
        [EnumMember(Value = "RWF")]
        RWF,
        
        /// <summary>
        /// Enum SAR for value: SAR
        /// </summary>
        [EnumMember(Value = "SAR")]
        SAR,
        
        /// <summary>
        /// Enum SBD for value: SBD
        /// </summary>
        [EnumMember(Value = "SBD")]
        SBD,
        
        /// <summary>
        /// Enum SCR for value: SCR
        /// </summary>
        [EnumMember(Value = "SCR")]
        SCR,
        
        /// <summary>
        /// Enum SDG for value: SDG
        /// </summary>
        [EnumMember(Value = "SDG")]
        SDG,
        
        /// <summary>
        /// Enum SEK for value: SEK
        /// </summary>
        [EnumMember(Value = "SEK")]
        SEK,
        
        /// <summary>
        /// Enum SGD for value: SGD
        /// </summary>
        [EnumMember(Value = "SGD")]
        SGD,
        
        /// <summary>
        /// Enum SHP for value: SHP
        /// </summary>
        [EnumMember(Value = "SHP")]
        SHP,
        
        /// <summary>
        /// Enum SLE for value: SLE
        /// </summary>
        [EnumMember(Value = "SLE")]
        SLE,
        
        /// <summary>
        /// Enum SLL for value: SLL
        /// </summary>
        [EnumMember(Value = "SLL")]
        SLL,
        
        /// <summary>
        /// Enum SOS for value: SOS
        /// </summary>
        [EnumMember(Value = "SOS")]
        SOS,
        
        /// <summary>
        /// Enum SRD for value: SRD
        /// </summary>
        [EnumMember(Value = "SRD")]
        SRD,
        
        /// <summary>
        /// Enum SSP for value: SSP
        /// </summary>
        [EnumMember(Value = "SSP")]
        SSP,
        
        /// <summary>
        /// Enum STN for value: STN
        /// </summary>
        [EnumMember(Value = "STN")]
        STN,
        
        /// <summary>
        /// Enum SVC for value: SVC
        /// </summary>
        [EnumMember(Value = "SVC")]
        SVC,
        
        /// <summary>
        /// Enum SYP for value: SYP
        /// </summary>
        [EnumMember(Value = "SYP")]
        SYP,
        
        /// <summary>
        /// Enum SZL for value: SZL
        /// </summary>
        [EnumMember(Value = "SZL")]
        SZL,
        
        /// <summary>
        /// Enum THB for value: THB
        /// </summary>
        [EnumMember(Value = "THB")]
        THB,
        
        /// <summary>
        /// Enum TJS for value: TJS
        /// </summary>
        [EnumMember(Value = "TJS")]
        TJS,
        
        /// <summary>
        /// Enum TMT for value: TMT
        /// </summary>
        [EnumMember(Value = "TMT")]
        TMT,
        
        /// <summary>
        /// Enum TND for value: TND
        /// </summary>
        [EnumMember(Value = "TND")]
        TND,
        
        /// <summary>
        /// Enum TOP for value: TOP
        /// </summary>
        [EnumMember(Value = "TOP")]
        TOP,
        
        /// <summary>
        /// Enum TRL for value: TRL
        /// </summary>
        [EnumMember(Value = "TRL")]
        TRL,
        
        /// <summary>
        /// Enum TRY for value: TRY
        /// </summary>
        [EnumMember(Value = "TRY")]
        TRY,
        
        /// <summary>
        /// Enum TTD for value: TTD
        /// </summary>
        [EnumMember(Value = "TTD")]
        TTD,
        
        /// <summary>
        /// Enum TWD for value: TWD
        /// </summary>
        [EnumMember(Value = "TWD")]
        TWD,
        
        /// <summary>
        /// Enum TZS for value: TZS
        /// </summary>
        [EnumMember(Value = "TZS")]
        TZS,
        
        /// <summary>
        /// Enum UAH for value: UAH
        /// </summary>
        [EnumMember(Value = "UAH")]
        UAH,
        
        /// <summary>
        /// Enum UGX for value: UGX
        /// </summary>
        [EnumMember(Value = "UGX")]
        UGX,
        
        /// <summary>
        /// Enum USD for value: USD
        /// </summary>
        [EnumMember(Value = "USD")]
        USD,
        
        /// <summary>
        /// Enum USN for value: USN
        /// </summary>
        [EnumMember(Value = "USN")]
        USN,
        
        /// <summary>
        /// Enum UYI for value: UYI
        /// </summary>
        [EnumMember(Value = "UYI")]
        UYI,
        
        /// <summary>
        /// Enum UYU for value: UYU
        /// </summary>
        [EnumMember(Value = "UYU")]
        UYU,
        
        /// <summary>
        /// Enum UYW for value: UYW
        /// </summary>
        [EnumMember(Value = "UYW")]
        UYW,
        
        /// <summary>
        /// Enum UZS for value: UZS
        /// </summary>
        [EnumMember(Value = "UZS")]
        UZS,
        
        /// <summary>
        /// Enum VED for value: VED
        /// </summary>
        [EnumMember(Value = "VED")]
        VED,
        
        /// <summary>
        /// Enum VES for value: VES
        /// </summary>
        [EnumMember(Value = "VES")]
        VES,
        
        /// <summary>
        /// Enum VND for value: VND
        /// </summary>
        [EnumMember(Value = "VND")]
        VND,
        
        /// <summary>
        /// Enum VUV for value: VUV
        /// </summary>
        [EnumMember(Value = "VUV")]
        VUV,
        
        /// <summary>
        /// Enum WST for value: WST
        /// </summary>
        [EnumMember(Value = "WST")]
        WST,
        
        /// <summary>
        /// Enum XAF for value: XAF
        /// </summary>
        [EnumMember(Value = "XAF")]
        XAF,
        
        /// <summary>
        /// Enum XAG for value: XAG
        /// </summary>
        [EnumMember(Value = "XAG")]
        XAG,
        
        /// <summary>
        /// Enum XAU for value: XAU
        /// </summary>
        [EnumMember(Value = "XAU")]
        XAU,
        
        /// <summary>
        /// Enum XBA for value: XBA
        /// </summary>
        [EnumMember(Value = "XBA")]
        XBA,
        
        /// <summary>
        /// Enum XBB for value: XBB
        /// </summary>
        [EnumMember(Value = "XBB")]
        XBB,
        
        /// <summary>
        /// Enum XBC for value: XBC
        /// </summary>
        [EnumMember(Value = "XBC")]
        XBC,
        
        /// <summary>
        /// Enum XBD for value: XBD
        /// </summary>
        [EnumMember(Value = "XBD")]
        XBD,
        
        /// <summary>
        /// Enum XCD for value: XCD
        /// </summary>
        [EnumMember(Value = "XCD")]
        XCD,
        
        /// <summary>
        /// Enum XDR for value: XDR
        /// </summary>
        [EnumMember(Value = "XDR")]
        XDR,
        
        /// <summary>
        /// Enum XOF for value: XOF
        /// </summary>
        [EnumMember(Value = "XOF")]
        XOF,
        
        /// <summary>
        /// Enum XPD for value: XPD
        /// </summary>
        [EnumMember(Value = "XPD")]
        XPD,
        
        /// <summary>
        /// Enum XPF for value: XPF
        /// </summary>
        [EnumMember(Value = "XPF")]
        XPF,
        
        /// <summary>
        /// Enum XPT for value: XPT
        /// </summary>
        [EnumMember(Value = "XPT")]
        XPT,
        
        /// <summary>
        /// Enum XSU for value: XSU
        /// </summary>
        [EnumMember(Value = "XSU")]
        XSU,
        
        /// <summary>
        /// Enum XTS for value: XTS
        /// </summary>
        [EnumMember(Value = "XTS")]
        XTS,
        
        /// <summary>
        /// Enum XUA for value: XUA
        /// </summary>
        [EnumMember(Value = "XUA")]
        XUA,
        
        /// <summary>
        /// Enum XXX for value: XXX
        /// </summary>
        [EnumMember(Value = "XXX")]
        XXX,
        
        /// <summary>
        /// Enum YER for value: YER
        /// </summary>
        [EnumMember(Value = "YER")]
        YER,
        
        /// <summary>
        /// Enum ZAR for value: ZAR
        /// </summary>
        [EnumMember(Value = "ZAR")]
        ZAR,
        
        /// <summary>
        /// Enum ZMW for value: ZMW
        /// </summary>
        [EnumMember(Value = "ZMW")]
        ZMW,
        
        /// <summary>
        /// Enum ZWL for value: ZWL
        /// </summary>
        [EnumMember(Value = "ZWL")]
        ZWL
    }

}
