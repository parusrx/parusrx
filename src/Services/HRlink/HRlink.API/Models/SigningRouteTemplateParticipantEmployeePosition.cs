// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the position of an employee participant in a signing route template.
/// </summary>
[XmlRoot("position")]
public record SigningRouteTemplateParticipantEmployeePosition
{
    /// <summary>
    /// Gets or sets the identifier of the position.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the position.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
