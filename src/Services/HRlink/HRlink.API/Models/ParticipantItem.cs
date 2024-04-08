// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a participant item for a create document group request.
/// </summary>
[XmlRoot("participant")]
public record ParticipantItem
{
    /// <summary>
    /// Gets or sets the identifier of the participant.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the employee identifier of the participant.
    /// </summary>
    [XmlElement("employeeId")]
    [JsonPropertyName("employeeId")]
    public string? EmployeeId { get; init; }

    /// <summary>
    /// Gets or sets the employee external identifier of the participant.
    /// </summary>
    [XmlElement("employeeExternalId")]
    [JsonPropertyName("employeeExternalId")]
    public string? EmployeeExternalId { get; init; }
}