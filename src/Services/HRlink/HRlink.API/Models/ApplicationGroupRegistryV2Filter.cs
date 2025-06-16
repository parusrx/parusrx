// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationGroupRegistryV2Filter
{
    [XmlArray("applicationTypeIds")]
    [XmlArrayItem("applicationTypeIdsItem")]
    [JsonPropertyName("applicationTypeIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ApplicationTypeIds { get; init; }

    [XmlElement("applicationDateFrom")]
    [JsonPropertyName("applicationDateFrom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationDateFrom { get; init; }

    [XmlElement("applicationDateTo")]
    [JsonPropertyName("applicationDateTo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationDateTo { get; init; }

    [XmlElement("applicationCreatedDateFrom")]
    [JsonPropertyName("applicationCreatedDateFrom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationCreatedDateFrom { get; init; }

    [XmlElement("applicationCreatedDateTo")]
    [JsonPropertyName("applicationCreatedDateTo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationCreatedDateTo { get; init; }

    [XmlElement("applicationDocflowFinishedDateFrom")]
    [JsonPropertyName("applicationDocflowFinishedDateFrom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationDocflowFinishedDateFrom { get; init; }

    [XmlElement("applicationDocflowFinishedDateTo")]
    [JsonPropertyName("applicationDocflowFinishedDateTo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationDocflowFinishedDateTo { get; init; }

    [XmlElement("applicationEventDateFrom")]
    [JsonPropertyName("applicationEventDateFrom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationEventDateFrom { get; init; }

    [XmlElement("applicationEventDateTo")]
    [JsonPropertyName("applicationEventDateTo")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? ApplicationEventDateTo { get; init; }

    [XmlArray("employeeIds")]
    [XmlArrayItem("employeeIdsItem")]
    [JsonPropertyName("employeeIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? EmployeeIds { get; init; }

    [XmlArray("legalEntityIds")]
    [XmlArrayItem("legalEntityIdsItem")]
    [JsonPropertyName("legalEntityIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? LegalEntityIds { get; init; }

    [XmlArray("clientDepartmentIds")]
    [XmlArrayItem("clientDepartmentIdsItem")]
    [JsonPropertyName("clientDepartmentIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ClientDepartmentIds { get; init; }

    [XmlElement("limit")]
    [JsonPropertyName("limit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int Limit { get; init; } = 3;

    [XmlElement("offset")]
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int Offset { get; init; } = 0;

    [XmlArray("applicationIds")]
    [XmlArrayItem("applicationIdsItem")]
    [JsonPropertyName("applicationIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ApplicationIds { get; init; }

    [XmlArray("applicationStatuses")]
    [XmlArrayItem("applicationStatusesItem")]
    [JsonPropertyName("applicationStatuses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ApplicationStatuses { get; init; }

    [XmlArray("clientUserParticipantIds")]
    [XmlArrayItem("clientUserParticipantIdsItem")]
    [JsonPropertyName("clientUserParticipantIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ClientUserParticipantIds { get; init; }

    [XmlArray("clientUserResponsibleIds")]
    [XmlArrayItem("clientUserResponsibleIdsItem")]
    [JsonPropertyName("clientUserResponsibleIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? ClientUserResponsibleIds { get; init; }

    [XmlElement("onlyEmployeeApplications")]
    [JsonPropertyName("onlyEmployeeApplications")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OnlyEmployeeApplications { get; init; }
}
