/* 
 * APS SDK
 *
 * The Autodesk Platform Services (formerly Forge Platform) contain an expanding collection of web service components that can be used with Autodesk cloud-based products or your own technologies. Take advantage of Autodesk’s expertise in design and engineering.
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
    /// Filters the list of products by product key — a machine-readable identifier for an ACC product (such as docs, build, or cost).
///You can specify one or more keys to return only those products the user is associated with.
///
///Example: filter[key]=docs,build
///
///Possible values: accountAdministration, autoSpecs, build, buildingConnected, capitalPlanning, cloudWorksharing, cost, designCollaboration, docs, financials, insight, modelCoordination, projectAdministration, takeoff, and workshopxr.
    /// </summary>
    ///<value>Filters the list of products by product key — a machine-readable identifier for an ACC product (such as docs, build, or cost).
///You can specify one or more keys to return only those products the user is associated with.
///
///Example: filter[key]=docs,build
///
///Possible values: accountAdministration, autoSpecs, build, buildingConnected, capitalPlanning, cloudWorksharing, cost, designCollaboration, docs, financials, insight, modelCoordination, projectAdministration, takeoff, and workshopxr.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum FilterProductKey
    {
        
        /// <summary>
        /// Enum AccountAdministration for value: accountAdministration
        /// </summary>
        [EnumMember(Value = "accountAdministration")]
        AccountAdministration,
        
        /// <summary>
        /// Enum AutoSpecs for value: autoSpecs
        /// </summary>
        [EnumMember(Value = "autoSpecs")]
        AutoSpecs,
        
        /// <summary>
        /// Enum Build for value: build
        /// </summary>
        [EnumMember(Value = "build")]
        Build,
        
        /// <summary>
        /// Enum BuildingConnected for value: buildingConnected
        /// </summary>
        [EnumMember(Value = "buildingConnected")]
        BuildingConnected,
        
        /// <summary>
        /// Enum CapitalPlanning for value: capitalPlanning
        /// </summary>
        [EnumMember(Value = "capitalPlanning")]
        CapitalPlanning,
        
        /// <summary>
        /// Enum CloudWorksharing for value: cloudWorksharing
        /// </summary>
        [EnumMember(Value = "cloudWorksharing")]
        CloudWorksharing,
        
        /// <summary>
        /// Enum Cost for value: cost
        /// </summary>
        [EnumMember(Value = "cost")]
        Cost,
        
        /// <summary>
        /// Enum DesignCollaboration for value: designCollaboration
        /// </summary>
        [EnumMember(Value = "designCollaboration")]
        DesignCollaboration,
        
        /// <summary>
        /// Enum Docs for value: docs
        /// </summary>
        [EnumMember(Value = "docs")]
        Docs,
        
        /// <summary>
        /// Enum Financials for value: financials
        /// </summary>
        [EnumMember(Value = "financials")]
        Financials,
        
        /// <summary>
        /// Enum Insight for value: insight
        /// </summary>
        [EnumMember(Value = "insight")]
        Insight,
        
        /// <summary>
        /// Enum ModelCoordination for value: modelCoordination
        /// </summary>
        [EnumMember(Value = "modelCoordination")]
        ModelCoordination,
        
        /// <summary>
        /// Enum ProjectAdministration for value: projectAdministration
        /// </summary>
        [EnumMember(Value = "projectAdministration")]
        ProjectAdministration,
        
        /// <summary>
        /// Enum Takeoff for value: takeoff
        /// </summary>
        [EnumMember(Value = "takeoff")]
        Takeoff,
        
        /// <summary>
        /// Enum Workshopxr for value: workshopxr
        /// </summary>
        [EnumMember(Value = "workshopxr")]
        Workshopxr
    }

}
