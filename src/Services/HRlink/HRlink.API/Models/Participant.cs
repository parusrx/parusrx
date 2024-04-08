// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a participant.
/// </summary>
[XmlRoot("participant")]
public record Participant
{
    /// <summary>
    /// Gets or sets the identifier of the participant.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Gets or sets the employee identifier of the participant.
    /// </summary>
    [XmlElement("employeeId")]
    [JsonPropertyName("employeeId")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the employee external identifier of the participant.
    /// </summary>
    [XmlElement("employeeExternalId")]
    [JsonPropertyName("employeeExternalId")]
    public string? EmployeeExternalId { get; set; }
}
