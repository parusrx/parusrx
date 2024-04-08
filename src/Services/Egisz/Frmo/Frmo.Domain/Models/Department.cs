// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Department
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string? Oid { get; init; }

    [XmlElement("departName")]
    [JsonPropertyName("departName")]
    public string DepartName { get; init; } = default!;

    [XmlElement("departStructure")]
    [JsonPropertyName("departStructure")]
    public DepartStructure DepartStructure { get; init; } = new();

    [XmlElement("medicalSubjectId")]
    [JsonPropertyName("medicalSubjectId")]
    public int MedicalSubjectId { get; init; }

    [XmlElement("isPlanned")]
    [JsonPropertyName("isPlanned")]
    public bool IsPlanned { get; init; }

    [XmlElement("admissionDepart")]
    [JsonPropertyName("admissionDepart")]
    public AdmissionDepart? AdmissionDepart { get; init; }

    [XmlArray("healthCareProfile")]
    [XmlArrayItem("healthCareProfileItem")]
    [JsonPropertyName("healthCareProfile")]
    public HealthCareProfile[]? HealthCareProfile { get; init; }

    [XmlArray("healthCareForm")]
    [XmlArrayItem("healthCareFormItem")]
    [JsonPropertyName("healthCareForm")]
    public HealthCareForm[]? HealthCareForm { get; init; }

    [XmlArray("healthCareConditions")]
    [XmlArrayItem("healthCareConditionsItem")]
    [JsonPropertyName("healthCareConditions")]
    public HealthCareCondition[]? HealthCareConditions { get; init; }

    [XmlElement("isNewModel")]
    [JsonPropertyName("isNewModel")]
    public bool? IsNewModel { get; init; }

    [XmlElement("pcCount")]
    [JsonPropertyName("pcCount")]
    public int? PcCount { get; init; }

    [XmlElement("ARMCount")]
    [JsonPropertyName("ARMCount")]
    public int? ArmCount { get; init; }

    [XmlElement("isElectronicPrescription")]
    [JsonPropertyName("isElectronicPrescription")]
    public bool? IsElectronicPrescription { get; init; }

    [XmlElement("isTelemedicine")]
    [JsonPropertyName("isTelemedicine")]
    public bool? IsTelemedicine { get; init; }

    [XmlElement("departServiceArea")]
    [JsonPropertyName("departServiceArea")]
    public double? DepartServiceArea { get; init; }

    [XmlElement("departServiceRadius")]
    [JsonPropertyName("departServiceRadius")]
    public double? DepartServiceRadius { get; init; }

    [XmlElement("isNorthArea")]
    [JsonPropertyName("isNorthArea")]
    public bool? IsNorthArea { get; init; }

    [XmlElement("moSecondLevelDistance")]
    [JsonPropertyName("moSecondLevelDistance")]
    public double? MoSecondLevelDistance { get; init; }

    [XmlElement("smpId")]
    [JsonPropertyName("smpId")]
    public bool? SmpId { get; init; }

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[]? Services { get; init; }

    [XmlArray("serviceLocality")]
    [XmlArrayItem("serviceLocalityItem")]
    [JsonPropertyName("serviceLocality")]
    public ServiceLocality[]? ServiceLocality { get; init; }

    [XmlArray("phones")]
    [XmlArrayItem("phonesItem")]
    [JsonPropertyName("phones")]
    public string[]? Phones { get; init; }

    [XmlElement("departKindId")]
    [JsonPropertyName("departKindId")]
    public DepartmentKindId DepartKindId { get; init; } = new();

    [XmlElement("departTypeId")]
    [JsonPropertyName("departTypeId")]
    public DepartTypeId DepartTypeId { get; init; } = new();

    [XmlElement("separateDepart")]
    [JsonPropertyName("separateDepart")]
    public bool SeparateDepart { get; init; }

    [XmlElement("brigadeCountPerShift")]
    [JsonPropertyName("brigadeCountPerShift")]
    public int? BrigadeCountPerShift { get; init; }

    [XmlArray("departBuildings")]
    [XmlArrayItem("departBuildingsItem")]
    [JsonPropertyName("departBuildings")]
    public DepartBuilding[]? DepartBuildings { get; init; }

    [XmlElement("liquidationDate")]
    [JsonPropertyName("liquidationDate")]
    public DateTime? LiquidationDate { get; init; }

    [XmlElement("departReg")]
    [JsonPropertyName("departReg")]
    public DepartReg? DepartReg { get; init; }

    [XmlElement("departHospital")]
    [JsonPropertyName("departHospital")]
    public DepartHospital? DepartHospital { get; init; }

    [XmlArray("departLabs")]
    [XmlArrayItem("departLabsItem")]
    [JsonPropertyName("departLabs")]
    public DepartLab[]? DepartLabs { get; init; }

    [XmlArray("departAmbulances")]
    [XmlArrayItem("departAmbulancesItem")]
    [JsonPropertyName("departAmbulances")]
    public DepartAmbulance[]? DepartAmbulances { get; init; }

    [XmlArray("brigadeCar")]
    [XmlArrayItem("brigadeCarItem")]
    [JsonPropertyName("brigadeCar")]
    public BrigadeCar[]? BrigadeCar { get; init; }

    [XmlArray("marks")]
    [XmlArrayItem("marksItem")]
    [JsonPropertyName("marks")]
    public Mark[]? Marks { get; init; }
}
