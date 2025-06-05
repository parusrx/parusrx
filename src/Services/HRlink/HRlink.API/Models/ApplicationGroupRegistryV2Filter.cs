// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationGroupRegistryV2Filter
{
    [XmlArray("applicationTypeIds")]
    [XmlArrayItem("applicationTypeIdsItem")]
    [JsonPropertyName("applicationTypeIds")]
    public string[]? ApplicationTypeIds { get; init; }

    [XmlElement("applicationDateFrom")]
    [JsonPropertyName("applicationDateFrom")]
    public DateTime? ApplicationDateFrom { get; init; }

    [XmlElement("applicationDateTo")]
    [JsonPropertyName("applicationDateTo")]
    public DateTime? ApplicationDateTo { get; init; }

    [XmlElement("applicationCreatedDateFrom")]
    [JsonPropertyName("applicationCreatedDateFrom")]
    public DateTime? ApplicationCreatedDateFrom { get; init; }

    [XmlElement("applicationCreatedDateTo")]
    [JsonPropertyName("applicationCreatedDateTo")]
    public DateTime? ApplicationCreatedDateTo { get; init; }

    [XmlElement("applicationDocflowFinishedDateFrom")]
    [JsonPropertyName("applicationDocflowFinishedDateFrom")]
    public DateTime? ApplicationDocflowFinishedDateFrom { get; init; }

    [XmlElement("applicationDocflowFinishedDateTo")]
    [JsonPropertyName("applicationDocflowFinishedDateTo")]
    public DateTime? ApplicationDocflowFinishedDateTo { get; init; }

    [XmlElement("applicationEventDateFrom")]
    [JsonPropertyName("applicationEventDateFrom")]
    public DateTime? ApplicationEventDateFrom { get; init; }

    [XmlElement("applicationEventDateTo")]
    [JsonPropertyName("applicationEventDateTo")]
    public DateTime? ApplicationEventDateTo { get; init; }

    [XmlArray("employeeIds")]
    [XmlArrayItem("employeeIdsItem")]
    [JsonPropertyName("employeeIds")]
    public string[]? EmployeeIds { get; init; }

    [XmlArray("legalEntityIds")]
    [XmlArrayItem("legalEntityIdsItem")]
    [JsonPropertyName("legalEntityIds")]
    public string[]? LegalEntityIds { get; init; }

    [XmlArray("clientDepartmentIds")]
    [XmlArrayItem("clientDepartmentIdsItem")]
    [JsonPropertyName("clientDepartmentIds")]
    public string[]? ClientDepartmentIds { get; init; }

    [XmlElement("limit")]
    [JsonPropertyName("limit")]
    public int Limit { get; init; } = 3;

    [XmlElement("offset")]
    [JsonPropertyName("offset")]
    public int Offset { get; init; } = 0;

    [XmlArray("applicationIds")]
    [XmlArrayItem("applicationIdsItem")]
    [JsonPropertyName("applicationIds")]
    public string[]? ApplicationIds { get; init; }

    [XmlArray("applicationStatuses")]
    [XmlArrayItem("applicationStatusesItem")]
    [JsonPropertyName("applicationStatuses")]
    public string[]? ApplicationStatuses { get; init; }

    [XmlArray("clientUserParticipantIds")]
    [XmlArrayItem("clientUserParticipantIdsItem")]
    [JsonPropertyName("clientUserParticipantIds")]
    public string[]? ClientUserParticipantIds { get; init; }

    [XmlArray("clientUserResponsibleIds")]
    [XmlArrayItem("clientUserResponsibleIdsItem")]
    [JsonPropertyName("clientUserResponsibleIds")]
    public string[]? ClientUserResponsibleIds { get; init; }

    [XmlElement("onlyEmployeeApplications")]
    [JsonPropertyName("onlyEmployeeApplications")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OnlyEmployeeApplications { get; init; }
}
