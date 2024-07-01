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
    /// Defines trade
    /// </summary>
    ///<value></value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum Trade
    {
        
        /// <summary>
        /// Enum Architecture for value: Architecture
        /// </summary>
        [EnumMember(Value = "Architecture")]
        Architecture,
        
        /// <summary>
        /// Enum Communications for value: Communications
        /// </summary>
        [EnumMember(Value = "Communications")]
        Communications,
        
        /// <summary>
        /// Enum CommunicationsData for value: Communications | Data
        /// </summary>
        [EnumMember(Value = "Communications | Data")]
        CommunicationsData,
        
        /// <summary>
        /// Enum Concrete for value: Concrete
        /// </summary>
        [EnumMember(Value = "Concrete")]
        Concrete,
        
        /// <summary>
        /// Enum ConcreteCastInPlace for value: Concrete | Cast-in-Place
        /// </summary>
        [EnumMember(Value = "Concrete | Cast-in-Place")]
        ConcreteCastInPlace,
        
        /// <summary>
        /// Enum ConcretePrecast for value: Concrete | Precast
        /// </summary>
        [EnumMember(Value = "Concrete | Precast")]
        ConcretePrecast,
        
        /// <summary>
        /// Enum ConstructionManagement for value: Construction Management
        /// </summary>
        [EnumMember(Value = "Construction Management")]
        ConstructionManagement,
        
        /// <summary>
        /// Enum ConveyingEquipment for value: Conveying Equipment
        /// </summary>
        [EnumMember(Value = "Conveying Equipment")]
        ConveyingEquipment,
        
        /// <summary>
        /// Enum ConveyingEquipmentElevators for value: Conveying Equipment | Elevators
        /// </summary>
        [EnumMember(Value = "Conveying Equipment | Elevators")]
        ConveyingEquipmentElevators,
        
        /// <summary>
        /// Enum Demolition for value: Demolition
        /// </summary>
        [EnumMember(Value = "Demolition")]
        Demolition,
        
        /// <summary>
        /// Enum Earthwork for value: Earthwork
        /// </summary>
        [EnumMember(Value = "Earthwork")]
        Earthwork,
        
        /// <summary>
        /// Enum EarthworkSiteExcavationGrading for value: Earthwork | Site Excavation & Grading
        /// </summary>
        [EnumMember(Value = "Earthwork | Site Excavation & Grading")]
        EarthworkSiteExcavationGrading,
        
        /// <summary>
        /// Enum Electrical for value: Electrical
        /// </summary>
        [EnumMember(Value = "Electrical")]
        Electrical,
        
        /// <summary>
        /// Enum ElectricalPowerGeneration for value: Electrical Power Generation
        /// </summary>
        [EnumMember(Value = "Electrical Power Generation")]
        ElectricalPowerGeneration,
        
        /// <summary>
        /// Enum ElectronicSafetySecurity for value: Electronic Safety & Security
        /// </summary>
        [EnumMember(Value = "Electronic Safety & Security")]
        ElectronicSafetySecurity,
        
        /// <summary>
        /// Enum Equipment for value: Equipment
        /// </summary>
        [EnumMember(Value = "Equipment")]
        Equipment,
        
        /// <summary>
        /// Enum EquipmentKitchenAppliances for value: Equipment | Kitchen Appliances
        /// </summary>
        [EnumMember(Value = "Equipment | Kitchen Appliances")]
        EquipmentKitchenAppliances,
        
        /// <summary>
        /// Enum ExteriorImprovements for value: Exterior Improvements
        /// </summary>
        [EnumMember(Value = "Exterior Improvements")]
        ExteriorImprovements,
        
        /// <summary>
        /// Enum ExteriorFencesGates for value: Exterior | Fences & Gates
        /// </summary>
        [EnumMember(Value = "Exterior | Fences & Gates")]
        ExteriorFencesGates,
        
        /// <summary>
        /// Enum ExteriorLandscaping for value: Exterior | Landscaping
        /// </summary>
        [EnumMember(Value = "Exterior | Landscaping")]
        ExteriorLandscaping,
        
        /// <summary>
        /// Enum ExteriorIrrigation for value: Exterior | Irrigation
        /// </summary>
        [EnumMember(Value = "Exterior | Irrigation")]
        ExteriorIrrigation,
        
        /// <summary>
        /// Enum Finishes for value: Finishes
        /// </summary>
        [EnumMember(Value = "Finishes")]
        Finishes,
        
        /// <summary>
        /// Enum FinishesCarpeting for value: Finishes | Carpeting
        /// </summary>
        [EnumMember(Value = "Finishes | Carpeting")]
        FinishesCarpeting,
        
        /// <summary>
        /// Enum FinishesCeiling for value: Finishes | Ceiling
        /// </summary>
        [EnumMember(Value = "Finishes | Ceiling")]
        FinishesCeiling,
        
        /// <summary>
        /// Enum FinishesDrywall for value: Finishes | Drywall
        /// </summary>
        [EnumMember(Value = "Finishes | Drywall")]
        FinishesDrywall,
        
        /// <summary>
        /// Enum FinishesFlooring for value: Finishes | Flooring
        /// </summary>
        [EnumMember(Value = "Finishes | Flooring")]
        FinishesFlooring,
        
        /// <summary>
        /// Enum FinishesPaintingCoating for value: Finishes | Painting & Coating
        /// </summary>
        [EnumMember(Value = "Finishes | Painting & Coating")]
        FinishesPaintingCoating,
        
        /// <summary>
        /// Enum FinishesTile for value: Finishes | Tile
        /// </summary>
        [EnumMember(Value = "Finishes | Tile")]
        FinishesTile,
        
        /// <summary>
        /// Enum FireSuppression for value: Fire Suppression
        /// </summary>
        [EnumMember(Value = "Fire Suppression")]
        FireSuppression,
        
        /// <summary>
        /// Enum Furnishings for value: Furnishings
        /// </summary>
        [EnumMember(Value = "Furnishings")]
        Furnishings,
        
        /// <summary>
        /// Enum FurnishingsCaseworkCabinets for value: Furnishings | Casework & Cabinets
        /// </summary>
        [EnumMember(Value = "Furnishings | Casework & Cabinets")]
        FurnishingsCaseworkCabinets,
        
        /// <summary>
        /// Enum FurnishingsCountertops for value: Furnishings | Countertops
        /// </summary>
        [EnumMember(Value = "Furnishings | Countertops")]
        FurnishingsCountertops,
        
        /// <summary>
        /// Enum FurnishingsWindowTreatments for value: Furnishings | Window Treatments
        /// </summary>
        [EnumMember(Value = "Furnishings | Window Treatments")]
        FurnishingsWindowTreatments,
        
        /// <summary>
        /// Enum GeneralContractor for value: General Contractor
        /// </summary>
        [EnumMember(Value = "General Contractor")]
        GeneralContractor,
        
        /// <summary>
        /// Enum HVACHeatingVentilatingAirConditioning for value: HVAC Heating, Ventilating, & Air Conditioning
        /// </summary>
        [EnumMember(Value = "HVAC Heating, Ventilating, & Air Conditioning")]
        HVACHeatingVentilatingAirConditioning,
        
        /// <summary>
        /// Enum IndustrySpecificManufacturingProcessing for value: Industry-Specific Manufacturing Processing
        /// </summary>
        [EnumMember(Value = "Industry-Specific Manufacturing Processing")]
        IndustrySpecificManufacturingProcessing,
        
        /// <summary>
        /// Enum IntegratedAutomation for value: Integrated Automation
        /// </summary>
        [EnumMember(Value = "Integrated Automation")]
        IntegratedAutomation,
        
        /// <summary>
        /// Enum Masonry for value: Masonry
        /// </summary>
        [EnumMember(Value = "Masonry")]
        Masonry,
        
        /// <summary>
        /// Enum MaterialProcessingHandlingEquipment for value: Material Processing & Handling Equipment
        /// </summary>
        [EnumMember(Value = "Material Processing & Handling Equipment")]
        MaterialProcessingHandlingEquipment,
        
        /// <summary>
        /// Enum Metals for value: Metals
        /// </summary>
        [EnumMember(Value = "Metals")]
        Metals,
        
        /// <summary>
        /// Enum MetalsStructuralSteelFraming for value: Metals | Structural Steel / Framing
        /// </summary>
        [EnumMember(Value = "Metals | Structural Steel / Framing")]
        MetalsStructuralSteelFraming,
        
        /// <summary>
        /// Enum MoistureProtection for value: Moisture Protection
        /// </summary>
        [EnumMember(Value = "Moisture Protection")]
        MoistureProtection,
        
        /// <summary>
        /// Enum MoistureProtectionRoofing for value: Moisture Protection | Roofing
        /// </summary>
        [EnumMember(Value = "Moisture Protection | Roofing")]
        MoistureProtectionRoofing,
        
        /// <summary>
        /// Enum MoistureProtectionWaterproofing for value: Moisture Protection | Waterproofing
        /// </summary>
        [EnumMember(Value = "Moisture Protection | Waterproofing")]
        MoistureProtectionWaterproofing,
        
        /// <summary>
        /// Enum Openings for value: Openings
        /// </summary>
        [EnumMember(Value = "Openings")]
        Openings,
        
        /// <summary>
        /// Enum OpeningsDoorsFrames for value: Openings | Doors & Frames
        /// </summary>
        [EnumMember(Value = "Openings | Doors & Frames")]
        OpeningsDoorsFrames,
        
        /// <summary>
        /// Enum OpeningsEntrancesStorefronts for value: Openings | Entrances & Storefronts
        /// </summary>
        [EnumMember(Value = "Openings | Entrances & Storefronts")]
        OpeningsEntrancesStorefronts,
        
        /// <summary>
        /// Enum OpeningsGlazing for value: Openings | Glazing
        /// </summary>
        [EnumMember(Value = "Openings | Glazing")]
        OpeningsGlazing,
        
        /// <summary>
        /// Enum OpeningsRoofWindowsSkylights for value: Openings | Roof Windows & Skylights
        /// </summary>
        [EnumMember(Value = "Openings | Roof Windows & Skylights")]
        OpeningsRoofWindowsSkylights,
        
        /// <summary>
        /// Enum OpeningsWindows for value: Openings | Windows
        /// </summary>
        [EnumMember(Value = "Openings | Windows")]
        OpeningsWindows,
        
        /// <summary>
        /// Enum Owner for value: Owner
        /// </summary>
        [EnumMember(Value = "Owner")]
        Owner,
        
        /// <summary>
        /// Enum Plumbing for value: Plumbing
        /// </summary>
        [EnumMember(Value = "Plumbing")]
        Plumbing,
        
        /// <summary>
        /// Enum PollutionWasteControlEquipment for value: Pollution & Waste Control Equipment
        /// </summary>
        [EnumMember(Value = "Pollution & Waste Control Equipment")]
        PollutionWasteControlEquipment,
        
        /// <summary>
        /// Enum ProcessGasLiquidHandlingPurificationStorageEquipment for value: Process Gas & Liquid Handling, Purification, & Storage Equipment
        /// </summary>
        [EnumMember(Value = "Process Gas & Liquid Handling, Purification, & Storage Equipment")]
        ProcessGasLiquidHandlingPurificationStorageEquipment,
        
        /// <summary>
        /// Enum ProcessHeatingCoolingDryingEquipment for value: Process Heating, Cooling, & Drying Equipment
        /// </summary>
        [EnumMember(Value = "Process Heating, Cooling, & Drying Equipment")]
        ProcessHeatingCoolingDryingEquipment,
        
        /// <summary>
        /// Enum ProcessIntegration for value: Process Integration
        /// </summary>
        [EnumMember(Value = "Process Integration")]
        ProcessIntegration,
        
        /// <summary>
        /// Enum ProcessIntegrationPiping for value: Process Integration | Piping
        /// </summary>
        [EnumMember(Value = "Process Integration | Piping")]
        ProcessIntegrationPiping,
        
        /// <summary>
        /// Enum SpecialConstruction for value: Special Construction
        /// </summary>
        [EnumMember(Value = "Special Construction")]
        SpecialConstruction,
        
        /// <summary>
        /// Enum Specialties for value: Specialties
        /// </summary>
        [EnumMember(Value = "Specialties")]
        Specialties,
        
        /// <summary>
        /// Enum SpecialtiesSignage for value: Specialties | Signage
        /// </summary>
        [EnumMember(Value = "Specialties | Signage")]
        SpecialtiesSignage,
        
        /// <summary>
        /// Enum Utilities for value: Utilities
        /// </summary>
        [EnumMember(Value = "Utilities")]
        Utilities,
        
        /// <summary>
        /// Enum WaterWastewaterEquipment for value: Water & Wastewater Equipment
        /// </summary>
        [EnumMember(Value = "Water & Wastewater Equipment")]
        WaterWastewaterEquipment,
        
        /// <summary>
        /// Enum WaterwayMarineConstruction for value: Waterway & Marine Construction
        /// </summary>
        [EnumMember(Value = "Waterway & Marine Construction")]
        WaterwayMarineConstruction,
        
        /// <summary>
        /// Enum WoodPlastics for value: Wood & Plastics
        /// </summary>
        [EnumMember(Value = "Wood & Plastics")]
        WoodPlastics,
        
        /// <summary>
        /// Enum WoodPlasticsMillwork for value: Wood & Plastics | Millwork
        /// </summary>
        [EnumMember(Value = "Wood & Plastics | Millwork")]
        WoodPlasticsMillwork,
        
        /// <summary>
        /// Enum WoodPlasticsRoughCarpentry for value: Wood & Plastics | Rough Carpentry
        /// </summary>
        [EnumMember(Value = "Wood & Plastics | Rough Carpentry")]
        WoodPlasticsRoughCarpentry
    }

}
