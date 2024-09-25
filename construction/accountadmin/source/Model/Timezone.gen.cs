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
    /// Defines timezone
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Timezone
    {
        
        /// <summary>
        /// Enum PacificHonolulu for value: Pacific/Honolulu
        /// </summary>
        [EnumMember(Value = "Pacific/Honolulu")]
        PacificHonolulu,
        
        /// <summary>
        /// Enum AmericaJuneau for value: America/Juneau
        /// </summary>
        [EnumMember(Value = "America/Juneau")]
        AmericaJuneau,
        
        /// <summary>
        /// Enum AmericaLosAngeles for value: America/Los_Angeles
        /// </summary>
        [EnumMember(Value = "America/Los_Angeles")]
        AmericaLosAngeles,
        
        /// <summary>
        /// Enum AmericaPhoenix for value: America/Phoenix
        /// </summary>
        [EnumMember(Value = "America/Phoenix")]
        AmericaPhoenix,
        
        /// <summary>
        /// Enum AmericaDenver for value: America/Denver
        /// </summary>
        [EnumMember(Value = "America/Denver")]
        AmericaDenver,
        
        /// <summary>
        /// Enum AmericaChicago for value: America/Chicago
        /// </summary>
        [EnumMember(Value = "America/Chicago")]
        AmericaChicago,
        
        /// <summary>
        /// Enum AmericaNewYork for value: America/New_York
        /// </summary>
        [EnumMember(Value = "America/New_York")]
        AmericaNewYork,
        
        /// <summary>
        /// Enum AmericaIndianaIndianapolis for value: America/Indiana/Indianapolis
        /// </summary>
        [EnumMember(Value = "America/Indiana/Indianapolis")]
        AmericaIndianaIndianapolis,
        
        /// <summary>
        /// Enum PacificPagoPago for value: Pacific/Pago_Pago
        /// </summary>
        [EnumMember(Value = "Pacific/Pago_Pago")]
        PacificPagoPago,
        
        /// <summary>
        /// Enum PacificMidway for value: Pacific/Midway
        /// </summary>
        [EnumMember(Value = "Pacific/Midway")]
        PacificMidway,
        
        /// <summary>
        /// Enum AmericaTijuana for value: America/Tijuana
        /// </summary>
        [EnumMember(Value = "America/Tijuana")]
        AmericaTijuana,
        
        /// <summary>
        /// Enum AmericaChihuahua for value: America/Chihuahua
        /// </summary>
        [EnumMember(Value = "America/Chihuahua")]
        AmericaChihuahua,
        
        /// <summary>
        /// Enum AmericaMazatlan for value: America/Mazatlan
        /// </summary>
        [EnumMember(Value = "America/Mazatlan")]
        AmericaMazatlan,
        
        /// <summary>
        /// Enum AmericaGuatemala for value: America/Guatemala
        /// </summary>
        [EnumMember(Value = "America/Guatemala")]
        AmericaGuatemala,
        
        /// <summary>
        /// Enum AmericaMexicoCity for value: America/Mexico_City
        /// </summary>
        [EnumMember(Value = "America/Mexico_City")]
        AmericaMexicoCity,
        
        /// <summary>
        /// Enum AmericaMonterrey for value: America/Monterrey
        /// </summary>
        [EnumMember(Value = "America/Monterrey")]
        AmericaMonterrey,
        
        /// <summary>
        /// Enum AmericaRegina for value: America/Regina
        /// </summary>
        [EnumMember(Value = "America/Regina")]
        AmericaRegina,
        
        /// <summary>
        /// Enum AmericaBogota for value: America/Bogota
        /// </summary>
        [EnumMember(Value = "America/Bogota")]
        AmericaBogota,
        
        /// <summary>
        /// Enum AmericaLima for value: America/Lima
        /// </summary>
        [EnumMember(Value = "America/Lima")]
        AmericaLima,
        
        /// <summary>
        /// Enum AmericaCaracas for value: America/Caracas
        /// </summary>
        [EnumMember(Value = "America/Caracas")]
        AmericaCaracas,
        
        /// <summary>
        /// Enum AmericaHalifax for value: America/Halifax
        /// </summary>
        [EnumMember(Value = "America/Halifax")]
        AmericaHalifax,
        
        /// <summary>
        /// Enum AmericaGuyana for value: America/Guyana
        /// </summary>
        [EnumMember(Value = "America/Guyana")]
        AmericaGuyana,
        
        /// <summary>
        /// Enum AmericaLaPaz for value: America/La_Paz
        /// </summary>
        [EnumMember(Value = "America/La_Paz")]
        AmericaLaPaz,
        
        /// <summary>
        /// Enum AmericaSantiago for value: America/Santiago
        /// </summary>
        [EnumMember(Value = "America/Santiago")]
        AmericaSantiago,
        
        /// <summary>
        /// Enum AmericaStJohns for value: America/St_Johns
        /// </summary>
        [EnumMember(Value = "America/St_Johns")]
        AmericaStJohns,
        
        /// <summary>
        /// Enum AmericaSaoPaulo for value: America/Sao_Paulo
        /// </summary>
        [EnumMember(Value = "America/Sao_Paulo")]
        AmericaSaoPaulo,
        
        /// <summary>
        /// Enum AmericaArgentinaBuenosAires for value: America/Argentina/Buenos_Aires
        /// </summary>
        [EnumMember(Value = "America/Argentina/Buenos_Aires")]
        AmericaArgentinaBuenosAires,
        
        /// <summary>
        /// Enum AmericaGodthab for value: America/Godthab
        /// </summary>
        [EnumMember(Value = "America/Godthab")]
        AmericaGodthab,
        
        /// <summary>
        /// Enum AtlanticSouthGeorgia for value: Atlantic/South_Georgia
        /// </summary>
        [EnumMember(Value = "Atlantic/South_Georgia")]
        AtlanticSouthGeorgia,
        
        /// <summary>
        /// Enum AtlanticAzores for value: Atlantic/Azores
        /// </summary>
        [EnumMember(Value = "Atlantic/Azores")]
        AtlanticAzores,
        
        /// <summary>
        /// Enum AtlanticCapeVerde for value: Atlantic/Cape_Verde
        /// </summary>
        [EnumMember(Value = "Atlantic/Cape_Verde")]
        AtlanticCapeVerde,
        
        /// <summary>
        /// Enum AfricaCasablanca for value: Africa/Casablanca
        /// </summary>
        [EnumMember(Value = "Africa/Casablanca")]
        AfricaCasablanca,
        
        /// <summary>
        /// Enum EuropeDublin for value: Europe/Dublin
        /// </summary>
        [EnumMember(Value = "Europe/Dublin")]
        EuropeDublin,
        
        /// <summary>
        /// Enum EuropeLisbon for value: Europe/Lisbon
        /// </summary>
        [EnumMember(Value = "Europe/Lisbon")]
        EuropeLisbon,
        
        /// <summary>
        /// Enum EuropeLondon for value: Europe/London
        /// </summary>
        [EnumMember(Value = "Europe/London")]
        EuropeLondon,
        
        /// <summary>
        /// Enum AfricaMonrovia for value: Africa/Monrovia
        /// </summary>
        [EnumMember(Value = "Africa/Monrovia")]
        AfricaMonrovia,
        
        /// <summary>
        /// Enum EtcUTC for value: Etc/UTC
        /// </summary>
        [EnumMember(Value = "Etc/UTC")]
        EtcUTC,
        
        /// <summary>
        /// Enum EuropeAmsterdam for value: Europe/Amsterdam
        /// </summary>
        [EnumMember(Value = "Europe/Amsterdam")]
        EuropeAmsterdam,
        
        /// <summary>
        /// Enum EuropeBelgrade for value: Europe/Belgrade
        /// </summary>
        [EnumMember(Value = "Europe/Belgrade")]
        EuropeBelgrade,
        
        /// <summary>
        /// Enum EuropeBerlin for value: Europe/Berlin
        /// </summary>
        [EnumMember(Value = "Europe/Berlin")]
        EuropeBerlin,
        
        /// <summary>
        /// Enum EuropeBratislava for value: Europe/Bratislava
        /// </summary>
        [EnumMember(Value = "Europe/Bratislava")]
        EuropeBratislava,
        
        /// <summary>
        /// Enum EuropeBrussels for value: Europe/Brussels
        /// </summary>
        [EnumMember(Value = "Europe/Brussels")]
        EuropeBrussels,
        
        /// <summary>
        /// Enum EuropeBudapest for value: Europe/Budapest
        /// </summary>
        [EnumMember(Value = "Europe/Budapest")]
        EuropeBudapest,
        
        /// <summary>
        /// Enum EuropeCopenhagen for value: Europe/Copenhagen
        /// </summary>
        [EnumMember(Value = "Europe/Copenhagen")]
        EuropeCopenhagen,
        
        /// <summary>
        /// Enum EuropeLjubljana for value: Europe/Ljubljana
        /// </summary>
        [EnumMember(Value = "Europe/Ljubljana")]
        EuropeLjubljana,
        
        /// <summary>
        /// Enum EuropeMadrid for value: Europe/Madrid
        /// </summary>
        [EnumMember(Value = "Europe/Madrid")]
        EuropeMadrid,
        
        /// <summary>
        /// Enum EuropeParis for value: Europe/Paris
        /// </summary>
        [EnumMember(Value = "Europe/Paris")]
        EuropeParis,
        
        /// <summary>
        /// Enum EuropePrague for value: Europe/Prague
        /// </summary>
        [EnumMember(Value = "Europe/Prague")]
        EuropePrague,
        
        /// <summary>
        /// Enum EuropeRome for value: Europe/Rome
        /// </summary>
        [EnumMember(Value = "Europe/Rome")]
        EuropeRome,
        
        /// <summary>
        /// Enum EuropeSarajevo for value: Europe/Sarajevo
        /// </summary>
        [EnumMember(Value = "Europe/Sarajevo")]
        EuropeSarajevo,
        
        /// <summary>
        /// Enum EuropeSkopje for value: Europe/Skopje
        /// </summary>
        [EnumMember(Value = "Europe/Skopje")]
        EuropeSkopje,
        
        /// <summary>
        /// Enum EuropeStockholm for value: Europe/Stockholm
        /// </summary>
        [EnumMember(Value = "Europe/Stockholm")]
        EuropeStockholm,
        
        /// <summary>
        /// Enum EuropeVienna for value: Europe/Vienna
        /// </summary>
        [EnumMember(Value = "Europe/Vienna")]
        EuropeVienna,
        
        /// <summary>
        /// Enum EuropeWarsaw for value: Europe/Warsaw
        /// </summary>
        [EnumMember(Value = "Europe/Warsaw")]
        EuropeWarsaw,
        
        /// <summary>
        /// Enum AfricaAlgiers for value: Africa/Algiers
        /// </summary>
        [EnumMember(Value = "Africa/Algiers")]
        AfricaAlgiers,
        
        /// <summary>
        /// Enum EuropeZagreb for value: Europe/Zagreb
        /// </summary>
        [EnumMember(Value = "Europe/Zagreb")]
        EuropeZagreb,
        
        /// <summary>
        /// Enum EuropeAthens for value: Europe/Athens
        /// </summary>
        [EnumMember(Value = "Europe/Athens")]
        EuropeAthens,
        
        /// <summary>
        /// Enum EuropeBucharest for value: Europe/Bucharest
        /// </summary>
        [EnumMember(Value = "Europe/Bucharest")]
        EuropeBucharest,
        
        /// <summary>
        /// Enum AfricaCairo for value: Africa/Cairo
        /// </summary>
        [EnumMember(Value = "Africa/Cairo")]
        AfricaCairo,
        
        /// <summary>
        /// Enum AfricaHarare for value: Africa/Harare
        /// </summary>
        [EnumMember(Value = "Africa/Harare")]
        AfricaHarare,
        
        /// <summary>
        /// Enum EuropeHelsinki for value: Europe/Helsinki
        /// </summary>
        [EnumMember(Value = "Europe/Helsinki")]
        EuropeHelsinki,
        
        /// <summary>
        /// Enum EuropeIstanbul for value: Europe/Istanbul
        /// </summary>
        [EnumMember(Value = "Europe/Istanbul")]
        EuropeIstanbul,
        
        /// <summary>
        /// Enum AsiaJerusalem for value: Asia/Jerusalem
        /// </summary>
        [EnumMember(Value = "Asia/Jerusalem")]
        AsiaJerusalem,
        
        /// <summary>
        /// Enum EuropeKiev for value: Europe/Kiev
        /// </summary>
        [EnumMember(Value = "Europe/Kiev")]
        EuropeKiev,
        
        /// <summary>
        /// Enum AfricaJohannesburg for value: Africa/Johannesburg
        /// </summary>
        [EnumMember(Value = "Africa/Johannesburg")]
        AfricaJohannesburg,
        
        /// <summary>
        /// Enum EuropeRiga for value: Europe/Riga
        /// </summary>
        [EnumMember(Value = "Europe/Riga")]
        EuropeRiga,
        
        /// <summary>
        /// Enum EuropeSofia for value: Europe/Sofia
        /// </summary>
        [EnumMember(Value = "Europe/Sofia")]
        EuropeSofia,
        
        /// <summary>
        /// Enum EuropeTallinn for value: Europe/Tallinn
        /// </summary>
        [EnumMember(Value = "Europe/Tallinn")]
        EuropeTallinn,
        
        /// <summary>
        /// Enum EuropeVilnius for value: Europe/Vilnius
        /// </summary>
        [EnumMember(Value = "Europe/Vilnius")]
        EuropeVilnius,
        
        /// <summary>
        /// Enum AsiaBaghdad for value: Asia/Baghdad
        /// </summary>
        [EnumMember(Value = "Asia/Baghdad")]
        AsiaBaghdad,
        
        /// <summary>
        /// Enum AsiaKuwait for value: Asia/Kuwait
        /// </summary>
        [EnumMember(Value = "Asia/Kuwait")]
        AsiaKuwait,
        
        /// <summary>
        /// Enum EuropeMinsk for value: Europe/Minsk
        /// </summary>
        [EnumMember(Value = "Europe/Minsk")]
        EuropeMinsk,
        
        /// <summary>
        /// Enum AfricaNairobi for value: Africa/Nairobi
        /// </summary>
        [EnumMember(Value = "Africa/Nairobi")]
        AfricaNairobi,
        
        /// <summary>
        /// Enum AsiaRiyadh for value: Asia/Riyadh
        /// </summary>
        [EnumMember(Value = "Asia/Riyadh")]
        AsiaRiyadh,
        
        /// <summary>
        /// Enum AsiaTehran for value: Asia/Tehran
        /// </summary>
        [EnumMember(Value = "Asia/Tehran")]
        AsiaTehran,
        
        /// <summary>
        /// Enum AsiaMuscat for value: Asia/Muscat
        /// </summary>
        [EnumMember(Value = "Asia/Muscat")]
        AsiaMuscat,
        
        /// <summary>
        /// Enum AsiaBaku for value: Asia/Baku
        /// </summary>
        [EnumMember(Value = "Asia/Baku")]
        AsiaBaku,
        
        /// <summary>
        /// Enum EuropeMoscow for value: Europe/Moscow
        /// </summary>
        [EnumMember(Value = "Europe/Moscow")]
        EuropeMoscow,
        
        /// <summary>
        /// Enum AsiaTbilisi for value: Asia/Tbilisi
        /// </summary>
        [EnumMember(Value = "Asia/Tbilisi")]
        AsiaTbilisi,
        
        /// <summary>
        /// Enum AsiaYerevan for value: Asia/Yerevan
        /// </summary>
        [EnumMember(Value = "Asia/Yerevan")]
        AsiaYerevan,
        
        /// <summary>
        /// Enum AsiaKabul for value: Asia/Kabul
        /// </summary>
        [EnumMember(Value = "Asia/Kabul")]
        AsiaKabul,
        
        /// <summary>
        /// Enum AsiaKarachi for value: Asia/Karachi
        /// </summary>
        [EnumMember(Value = "Asia/Karachi")]
        AsiaKarachi,
        
        /// <summary>
        /// Enum AsiaTashkent for value: Asia/Tashkent
        /// </summary>
        [EnumMember(Value = "Asia/Tashkent")]
        AsiaTashkent,
        
        /// <summary>
        /// Enum AsiaKolkata for value: Asia/Kolkata
        /// </summary>
        [EnumMember(Value = "Asia/Kolkata")]
        AsiaKolkata,
        
        /// <summary>
        /// Enum AsiaColombo for value: Asia/Colombo
        /// </summary>
        [EnumMember(Value = "Asia/Colombo")]
        AsiaColombo,
        
        /// <summary>
        /// Enum AsiaKathmandu for value: Asia/Kathmandu
        /// </summary>
        [EnumMember(Value = "Asia/Kathmandu")]
        AsiaKathmandu,
        
        /// <summary>
        /// Enum AsiaAlmaty for value: Asia/Almaty
        /// </summary>
        [EnumMember(Value = "Asia/Almaty")]
        AsiaAlmaty,
        
        /// <summary>
        /// Enum AsiaDhaka for value: Asia/Dhaka
        /// </summary>
        [EnumMember(Value = "Asia/Dhaka")]
        AsiaDhaka,
        
        /// <summary>
        /// Enum AsiaYekaterinburg for value: Asia/Yekaterinburg
        /// </summary>
        [EnumMember(Value = "Asia/Yekaterinburg")]
        AsiaYekaterinburg,
        
        /// <summary>
        /// Enum AsiaRangoon for value: Asia/Rangoon
        /// </summary>
        [EnumMember(Value = "Asia/Rangoon")]
        AsiaRangoon,
        
        /// <summary>
        /// Enum AsiaBangkok for value: Asia/Bangkok
        /// </summary>
        [EnumMember(Value = "Asia/Bangkok")]
        AsiaBangkok,
        
        /// <summary>
        /// Enum AsiaJakarta for value: Asia/Jakarta
        /// </summary>
        [EnumMember(Value = "Asia/Jakarta")]
        AsiaJakarta,
        
        /// <summary>
        /// Enum AsiaNovosibirsk for value: Asia/Novosibirsk
        /// </summary>
        [EnumMember(Value = "Asia/Novosibirsk")]
        AsiaNovosibirsk,
        
        /// <summary>
        /// Enum AsiaShanghai for value: Asia/Shanghai
        /// </summary>
        [EnumMember(Value = "Asia/Shanghai")]
        AsiaShanghai,
        
        /// <summary>
        /// Enum AsiaChongqing for value: Asia/Chongqing
        /// </summary>
        [EnumMember(Value = "Asia/Chongqing")]
        AsiaChongqing,
        
        /// <summary>
        /// Enum AsiaHongKong for value: Asia/Hong_Kong
        /// </summary>
        [EnumMember(Value = "Asia/Hong_Kong")]
        AsiaHongKong,
        
        /// <summary>
        /// Enum AsiaKrasnoyarsk for value: Asia/Krasnoyarsk
        /// </summary>
        [EnumMember(Value = "Asia/Krasnoyarsk")]
        AsiaKrasnoyarsk,
        
        /// <summary>
        /// Enum AsiaKualaLumpur for value: Asia/Kuala_Lumpur
        /// </summary>
        [EnumMember(Value = "Asia/Kuala_Lumpur")]
        AsiaKualaLumpur,
        
        /// <summary>
        /// Enum AustraliaPerth for value: Australia/Perth
        /// </summary>
        [EnumMember(Value = "Australia/Perth")]
        AustraliaPerth,
        
        /// <summary>
        /// Enum AsiaSingapore for value: Asia/Singapore
        /// </summary>
        [EnumMember(Value = "Asia/Singapore")]
        AsiaSingapore,
        
        /// <summary>
        /// Enum AsiaTaipei for value: Asia/Taipei
        /// </summary>
        [EnumMember(Value = "Asia/Taipei")]
        AsiaTaipei,
        
        /// <summary>
        /// Enum AsiaUlaanbaatar for value: Asia/Ulaanbaatar
        /// </summary>
        [EnumMember(Value = "Asia/Ulaanbaatar")]
        AsiaUlaanbaatar,
        
        /// <summary>
        /// Enum AsiaUrumqi for value: Asia/Urumqi
        /// </summary>
        [EnumMember(Value = "Asia/Urumqi")]
        AsiaUrumqi,
        
        /// <summary>
        /// Enum AsiaIrkutsk for value: Asia/Irkutsk
        /// </summary>
        [EnumMember(Value = "Asia/Irkutsk")]
        AsiaIrkutsk,
        
        /// <summary>
        /// Enum AsiaTokyo for value: Asia/Tokyo
        /// </summary>
        [EnumMember(Value = "Asia/Tokyo")]
        AsiaTokyo,
        
        /// <summary>
        /// Enum AsiaSeoul for value: Asia/Seoul
        /// </summary>
        [EnumMember(Value = "Asia/Seoul")]
        AsiaSeoul,
        
        /// <summary>
        /// Enum AustraliaAdelaide for value: Australia/Adelaide
        /// </summary>
        [EnumMember(Value = "Australia/Adelaide")]
        AustraliaAdelaide,
        
        /// <summary>
        /// Enum AustraliaDarwin for value: Australia/Darwin
        /// </summary>
        [EnumMember(Value = "Australia/Darwin")]
        AustraliaDarwin,
        
        /// <summary>
        /// Enum AustraliaBrisbane for value: Australia/Brisbane
        /// </summary>
        [EnumMember(Value = "Australia/Brisbane")]
        AustraliaBrisbane,
        
        /// <summary>
        /// Enum AustraliaMelbourne for value: Australia/Melbourne
        /// </summary>
        [EnumMember(Value = "Australia/Melbourne")]
        AustraliaMelbourne,
        
        /// <summary>
        /// Enum PacificGuam for value: Pacific/Guam
        /// </summary>
        [EnumMember(Value = "Pacific/Guam")]
        PacificGuam,
        
        /// <summary>
        /// Enum AustraliaHobart for value: Australia/Hobart
        /// </summary>
        [EnumMember(Value = "Australia/Hobart")]
        AustraliaHobart,
        
        /// <summary>
        /// Enum PacificPortMoresby for value: Pacific/Port_Moresby
        /// </summary>
        [EnumMember(Value = "Pacific/Port_Moresby")]
        PacificPortMoresby,
        
        /// <summary>
        /// Enum AustraliaSydney for value: Australia/Sydney
        /// </summary>
        [EnumMember(Value = "Australia/Sydney")]
        AustraliaSydney,
        
        /// <summary>
        /// Enum AsiaYakutsk for value: Asia/Yakutsk
        /// </summary>
        [EnumMember(Value = "Asia/Yakutsk")]
        AsiaYakutsk,
        
        /// <summary>
        /// Enum PacificNoumea for value: Pacific/Noumea
        /// </summary>
        [EnumMember(Value = "Pacific/Noumea")]
        PacificNoumea,
        
        /// <summary>
        /// Enum AsiaVladivostok for value: Asia/Vladivostok
        /// </summary>
        [EnumMember(Value = "Asia/Vladivostok")]
        AsiaVladivostok,
        
        /// <summary>
        /// Enum PacificAuckland for value: Pacific/Auckland
        /// </summary>
        [EnumMember(Value = "Pacific/Auckland")]
        PacificAuckland,
        
        /// <summary>
        /// Enum PacificFiji for value: Pacific/Fiji
        /// </summary>
        [EnumMember(Value = "Pacific/Fiji")]
        PacificFiji,
        
        /// <summary>
        /// Enum AsiaKamchatka for value: Asia/Kamchatka
        /// </summary>
        [EnumMember(Value = "Asia/Kamchatka")]
        AsiaKamchatka,
        
        /// <summary>
        /// Enum AsiaMagadan for value: Asia/Magadan
        /// </summary>
        [EnumMember(Value = "Asia/Magadan")]
        AsiaMagadan,
        
        /// <summary>
        /// Enum PacificMajuro for value: Pacific/Majuro
        /// </summary>
        [EnumMember(Value = "Pacific/Majuro")]
        PacificMajuro,
        
        /// <summary>
        /// Enum PacificGuadalcanal for value: Pacific/Guadalcanal
        /// </summary>
        [EnumMember(Value = "Pacific/Guadalcanal")]
        PacificGuadalcanal,
        
        /// <summary>
        /// Enum PacificTongatapu for value: Pacific/Tongatapu
        /// </summary>
        [EnumMember(Value = "Pacific/Tongatapu")]
        PacificTongatapu,
        
        /// <summary>
        /// Enum PacificApia for value: Pacific/Apia
        /// </summary>
        [EnumMember(Value = "Pacific/Apia")]
        PacificApia,
        
        /// <summary>
        /// Enum PacificFakaofo for value: Pacific/Fakaofo
        /// </summary>
        [EnumMember(Value = "Pacific/Fakaofo")]
        PacificFakaofo
    }

}
