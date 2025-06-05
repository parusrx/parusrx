// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an employee participant in a signing route template.
/// </summary>
public record SigningRouteParticipantEmployee
{
    /// <summary>
    /// Gets or sets the identifier of the employee.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
