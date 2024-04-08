// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an employee.
/// </summary>
[XmlRoot("employee")]
public record Employee
{
    /// <summary>
    /// Gets or sets the identifier of the employee.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the legal entity associated with the employee.
    /// </summary>
    [XmlElement("legalEntityExternalId")]
    [JsonPropertyName("legalEntityExternalId")]
    public string? LegalEntityExternalId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the department associated with the employee.
    /// </summary>
    [XmlElement("departmentExternalId")]
    [JsonPropertyName("departmentExternalId")]
    public string? DepartmentExternalId { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the position associated with the employee.
    /// </summary>
    [XmlElement("positionExternalId")]
    [JsonPropertyName("positionExternalId")]
    public string? PositionExternalId { get; init; }

    /// <summary>
    /// Gets or sets the tags associated with the employee.
    /// </summary>
    [XmlElement("tags")]
    [JsonPropertyName("tags")]
    public string[]? Tags { get; init; }

    /// <summary>
    /// Gets or sets the roles identifiers associated with the employee.
    /// </summary>
    [XmlElement("roleIds")]
    [JsonPropertyName("roleIds")]
    public string[]? RoleIds { get; init; }
}
