// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record PersonCard
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string Oid { get; init; } = default!;

    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("organization")]
    [JsonPropertyName("organization")]
    public string Organization { get; init; } = default!;

    [XmlElement("nrPmuDepartId")]
    [JsonPropertyName("nrPmuDepartId")]
    public string NrPmuDepartId { get; init; } = default!;

    [XmlElement("nrPmuDepartName")]
    [JsonPropertyName("nrPmuDepartName")]
    public string? NrPmuDepartName { get; init; }

    [XmlElement("nrPmuDepartHospitalSubdivisionId")]
    [JsonPropertyName("nrPmuDepartHospitalSubdivisionId")]
    public string? NrPmuDepartHospitalSubdivisionId { get; init; }

    [XmlElement("nrPmuDepartHospitalSubdivisionName")]
    [JsonPropertyName("nrPmuDepartHospitalSubdivisionName")]
    public string? NrPmuDepartHospitalSubdivisionName { get; init; }

    [XmlElement("roomOid")]
    [JsonPropertyName("roomOid")]
    public string? RoomOid { get; init; }

    [XmlElement("roomName")]
    [JsonPropertyName("roomName")]
    public string? RoomName { get; init; }

    [XmlElement("contractNumber")]
    [JsonPropertyName("contractNumber")]
    public string ContractNumber { get; init; } = default!;

    [XmlElement("contractDate")]
    [JsonPropertyName("contractDate")]
    public DateTime ContractDate { get; init; }

    [XmlElement("serviceNumber")]
    [JsonPropertyName("serviceNumber")]
    public string ServiceNumber { get; init; } = default!;

    [XmlElement("fedPositionId")]
    [JsonPropertyName("fedPositionId")]
    public int FedPositionId { get; init; }

    [XmlElement("fedPosition")]
    [JsonPropertyName("fedPosition")]
    public string? FedPosition { get; init; }

    [XmlElement("seniority")]
    [JsonPropertyName("seniority")]
    public int? Seniority { get; init; }

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];

    [XmlElement("positionTypeId")]
    [JsonPropertyName("positionTypeId")]
    public int PositionTypeId { get; init; }

    [XmlElement("positionTypeName")]
    [JsonPropertyName("positionTypeName")]
    public string? PositionTypeName { get; init; }

    [XmlElement("postId")]
    [JsonPropertyName("postId")]
    public int PostId { get; init; }

    [XmlElement("postName")]
    [JsonPropertyName("postName")]
    public string? PostName { get; init; }

    [XmlElement("rate")]
    [JsonPropertyName("rate")]
    public double? Rate { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("endTypeId")]
    [JsonPropertyName("endTypeId")]
    public int? EndTypeId { get; init; }

    [XmlElement("fireReasonId")]
    [JsonPropertyName("fireReasonId")]
    public int? FireReasonId { get; init; }

    [XmlElement("targeted")]
    [JsonPropertyName("targeted")]
    public bool? Targeted { get; init; }

    [XmlArray("temporaryDerelictions")]
    [XmlArrayItem("temporaryDerelictionsItem")]
    [JsonPropertyName("temporaryDerelictions")]
    public TemporaryDereliction[]? TemporaryDerelictions { get; init; }

    [XmlElement("personalFileNumber")]
    [JsonPropertyName("personalFileNumber")]
    public string? PersonalFileNumber { get; init; }

    [XmlArray("periodsDate")]
    [XmlArrayItem("periodsDateItem")]
    [JsonPropertyName("periodsDate")]
    public PeriodDateItem[]? PeriodsDate { get; init; }

    [XmlElement("omsMarks")]
    [JsonPropertyName("omsMarks")]
    public OmsMark? OmsMarks { get; init; }
}
