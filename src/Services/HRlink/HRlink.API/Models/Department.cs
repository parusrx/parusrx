// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a department.
/// </summary>
[XmlRoot("department")]
public record Department
{
    /// <summary>
    /// Gets or sets the identifier of the parent department associated with the department.
    /// </summary>
    [XmlElement("parentDepartmentId")]
    [JsonPropertyName("parentDepartmentId")]
    public string? ParentDepartmentId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the parent department associated with the department.
    /// </summary>
    [XmlElement("parentDepartmentExternalId")]
    [JsonPropertyName("parentDepartmentExternalId")]
    public string? ParentDepartmentExternalId { get; init; }

    /// <summary>
    /// Gets or sets the name of the department.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the department.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the legal entity associated with the department.
    /// </summary>
    [XmlElement("legalEntityId")]
    [JsonPropertyName("legalEntityId")]
    public string? LegalEntityId { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the legal entity associated with the department.
    /// </summary>
    [XmlElement("legalEntityExternalId")]
    [JsonPropertyName("legalEntityExternalId")]
    public string? LegalEntityExternalId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the head manager associated with the department.
    /// </summary>
    [XmlElement("headManagerId")]
    [JsonPropertyName("headManagerId")]
    public string? HeadManagerId { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the head manager associated with the department.
    /// </summary>
    [XmlElement("headManagerExternalId")]
    [JsonPropertyName("headManagerExternalId")]
    public string? HeadManagerExternalId { get; set; }
}
