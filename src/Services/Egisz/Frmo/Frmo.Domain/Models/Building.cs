// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Building
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("rent")]
    [JsonPropertyName("rent")]
    public bool? Rent { get; init; }

    [XmlArray("ownageDocuments")]
    [XmlArrayItem("ownageDocumentsItem")]
    [JsonPropertyName("ownageDocuments")]
    public string[]? OwnageDocuments { get; init; }

    [XmlElement("lawSubject")]
    [JsonPropertyName("lawSubject")]
    public string? LawSubject { get; init; }

    [XmlElement("lawType")]
    [JsonPropertyName("lawType")]
    public string? LawType { get; init; }

    [XmlElement("lawObject")]
    [JsonPropertyName("lawObject")]
    public string? LawObject { get; init; }

    [XmlElement("cadastralNumber")]
    [JsonPropertyName("cadastralNumber")]
    public string? CadastralNumber { get; init; }

    [XmlElement("encumbrances")]
    [JsonPropertyName("encumbrances")]
    public string? Encumbrances { get; init; }

    [XmlElement("lawDescription")]
    [JsonPropertyName("lawDescription")]
    public string? LawDescription { get; init; }

    [XmlArray("rentDocuments")]
    [XmlArrayItem("rentDocumentsItem")]
    [JsonPropertyName("rentDocuments")]
    public string[]? RentDocuments { get; init; }

    [XmlElement("regDate")]
    [JsonPropertyName("regDate")]
    public DateTime? RegDate { get; init; }

    [XmlElement("regNumber")]
    [JsonPropertyName("regNumber")]
    public string? RegNumber { get; init; }

    [XmlElement("landlord")]
    [JsonPropertyName("landlord")]
    public string? Landlord { get; init; }

    [XmlElement("renter")]
    [JsonPropertyName("renter")]
    public string? Renter { get; init; }

    [XmlElement("tenancy")]
    [JsonPropertyName("tenancy")]
    public string? Tenancy { get; init; }

    [XmlElement("capacityVisitors")]
    [JsonPropertyName("capacityVisitors")]
    public int? CapacityVisitors { get; init; }

    [XmlElement("capacityBeds")]
    [JsonPropertyName("capacityBeds")]
    public int? CapacityBeds { get; init; }

    [XmlElement("capacityHospital")]
    [JsonPropertyName("capacityHospital")]
    public int? CapacityHospital { get; init; }

    [XmlElement("buildName")]
    [JsonPropertyName("buildName")]
    public string BuildName { get; init; } = default!;

    [XmlElement("buildYear")]
    [JsonPropertyName("buildYear")]
    public int BuildYear { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("liquidationDate")]
    [JsonPropertyName("liquidationDate")]
    public DateTime? LiquidationDate { get; init; }

    [XmlElement("liquidationReasonId")]
    [JsonPropertyName("liquidationReasonId")]
    public LiquidationReasonId? LiquidationReasonId { get; init; }

    [XmlElement("floorCount")]
    [JsonPropertyName("floorCount")]
    public int FloorCount { get; init; }

    [XmlElement("hasTrouble")]
    [JsonPropertyName("hasTrouble")]
    public bool HasTrouble { get; init; }

    [XmlArray("troubleDocument")]
    [XmlArrayItem("troubleDocumentItem")]
    [JsonPropertyName("troubleDocument")]
    public string[]? TroubleDocument { get; init; }

    [XmlArray("buildingPlan")]
    [XmlArrayItem("buildingPlanItem")]
    [JsonPropertyName("buildingPlan")]
    public string[]? BuildingPlan { get; init; }

    [XmlElement("cardiologicalDepartments")]
    [JsonPropertyName("cardiologicalDepartments")]
    public int? CardiologicalDepartments { get; init; }

    [XmlElement("fundament")]
    [JsonPropertyName("fundament")]
    public string? Fundament { get; init; }

    [XmlElement("fundamentDescription")]
    [JsonPropertyName("fundamentDescription")]
    public string? FundamentDescription { get; init; }

    [XmlElement("supportingStructures")]
    [JsonPropertyName("supportingStructures")]
    public string? SupportingStructures { get; init; }

    [XmlElement("roofCovering")]
    [JsonPropertyName("roofCovering")]
    public RoofCovering? RoofCovering { get; init; }

    [XmlElement("roofCoveringDescription")]
    [JsonPropertyName("roofCoveringDescription")]
    public string? RoofCoveringDescription { get; init; }

    [XmlElement("wallsMaterial")]
    [JsonPropertyName("wallsMaterial")]
    public WallsMaterial? WallsMaterial { get; init; }

    [XmlElement("wallsMaterialDescription")]
    [JsonPropertyName("wallsMaterialDescription")]
    public string? WallsMaterialDescription { get; init; }

    [XmlElement("ceilingMaterial")]
    [JsonPropertyName("ceilingMaterial")]
    public CeilingMaterial? CeilingMaterial { get; init; }

    [XmlElement("ceilingMaterialDescription")]
    [JsonPropertyName("ceilingMaterialDescription")]
    public string? CeilingMaterialDescription { get; init; }

    [XmlElement("buildingSize")]
    [JsonPropertyName("buildingSize")]
    public double? BuildingSize { get; init; }

    [XmlElement("rightToUse")]
    [JsonPropertyName("rightToUse")]
    public RightToUse? RightToUse { get; init; }

    [XmlElement("rightToUseDescription")]
    [JsonPropertyName("rightToUseDescription")]
    public string? RightToUseDescription { get; init; }

    [XmlElement("isAdapted")]
    [JsonPropertyName("isAdapted")]
    public bool? IsAdapted { get; init; }

    [XmlElement("isAccesibleEnv")]
    [JsonPropertyName("isAccesibleEnv")]
    public bool? IsAccesibleEnv { get; init; }

    [XmlElement("isHistorical")]
    [JsonPropertyName("isHistorical")]
    public bool? IsHistorical { get; init; }

    [XmlElement("isWeb")]
    [JsonPropertyName("isWeb")]
    public bool? IsWeb { get; init; }

    [XmlElement("buildingArea")]
    [JsonPropertyName("buildingArea")]
    public double? BuildingArea { get; init; }

    [XmlElement("builtUpArea")]
    [JsonPropertyName("builtUpArea")]
    public double? BuiltUpArea { get; init; }

    [XmlElement("starCost")]
    [JsonPropertyName("starCost")]
    public double? StarCost { get; init; }

    [XmlElement("depreciationCost")]
    [JsonPropertyName("depreciationCost")]
    public double? DepreciationCost { get; init; }

    [XmlElement("deprecationFactor")]
    [JsonPropertyName("deprecationFactor")]
    public double? DeprecationFactor { get; init; }

    [XmlElement("lastTechnicalSurveyYear")]
    [JsonPropertyName("lastTechnicalSurveyYear")]
    public string? LastTechnicalSurveyYear { get; init; }

    [XmlElement("lastTechnicalSurveyAct")]
    [JsonPropertyName("lastTechnicalSurveyAct")]
    public string? LastTechnicalSurveyAct { get; init; }

    [XmlElement("reconstructionYear")]
    [JsonPropertyName("reconstructionYear")]
    public int? ReconstructionYear { get; init; }

    [XmlElement("reconstructionArea")]
    [JsonPropertyName("reconstructionArea")]
    public double? ReconstructionArea { get; init; }

    [XmlElement("troubleActDetails")]
    [JsonPropertyName("troubleActDetails")]
    public string? TroubleActDetails { get; init; }

    [XmlElement("needDestruction")]
    [JsonPropertyName("needDestruction")]
    public bool? NeedDestruction { get; init; }

    [XmlArray("destructionDocument")]
    [XmlArrayItem("destructionDocumentItem")]
    [JsonPropertyName("destructionDocument")]
    public string[]? DestructionDocument { get; init; }

    [XmlElement("destructionDocumentDate")]
    [JsonPropertyName("destructionDocumentDate")]
    public DateTime? DestructionDocumentDate { get; init; }

    [XmlElement("destructionDocumentNumber")]
    [JsonPropertyName("destructionDocumentNumber")]
    public string? DestructionDocumentNumber { get; init; }

    [XmlElement("needReconstruction")]
    [JsonPropertyName("needReconstruction")]
    public bool? NeedReconstruction { get; init; }

    [XmlElement("requiredReconstructionArea")]
    [JsonPropertyName("requiredReconstructionArea")]
    public double? RequiredReconstructionArea { get; init; }

    [XmlElement("needRepair")]
    [JsonPropertyName("needRepair")]
    public bool? NeedRepair { get; init; }

    [XmlArray("repairDocument")]
    [XmlArrayItem("repairDocumentItem")]
    [JsonPropertyName("repairDocument")]
    public string[]? RepairDocument { get; init; }

    [XmlElement("repairDocumentDate")]
    [JsonPropertyName("repairDocumentDate")]
    public DateTime? RepairDocumentDate { get; init; }

    [XmlElement("repairDocumentNumber")]
    [JsonPropertyName("repairDocumentNumber")]
    public string? RepairDocumentNumber { get; init; }

    [XmlElement("objectTarget")]
    [JsonPropertyName("objectTarget")]
    public ObjectTarget? ObjectTarget { get; init; }

    [XmlElement("objectType")]
    [JsonPropertyName("objectType")]
    public ObjectType? ObjectType { get; init; }

    [XmlArray("floors")]
    [XmlArrayItem("floorsItem")]
    [JsonPropertyName("floors")]
    public BuildingFloor[]? Floors { get; init; }

    [XmlArray("workPeriod")]
    [XmlArrayItem("workPeriodItem")]
    [JsonPropertyName("workPeriod")]
    public WorkPeriod[]? WorkPeriod { get; init; }

    [XmlElement("buildingAddress")]
    [JsonPropertyName("buildingAddress")]
    public BuildingAddress BuildingAddress { get; init; } = default!;

    [XmlElement("moTerritorialDepartId")]
    [JsonPropertyName("moTerritorialDepartId")]
    public string? MoTerritorialDepartId { get; init; }

    [XmlElement("moTerritorialDepartName")]
    [JsonPropertyName("moTerritorialDepartName")]
    public string? MoTerritorialDepartName { get; init; }

    [XmlElement("isNonUniqueAddress")]
    [JsonPropertyName("isNonUniqueAddress")]
    public bool? IsNonUniqueAddress { get; init; }
}
