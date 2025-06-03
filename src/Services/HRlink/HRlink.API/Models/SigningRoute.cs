// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the participants of a stage.
/// </summary>
public record SigningRoute
{
    /// <summary>
    /// Gets or sets the identifier of the signing route template.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the signing route template.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the template identifier of the signing route.
    /// </summary>
    [XmlElement("templateId")]
    [JsonPropertyName("templateId")]
    public string? TemplateId { get; init; }

    /// <summary>
    /// Gets or sets the participans of a stage.
    /// </summary>
    [XmlArray("stages")]
    [XmlArrayItem("stage")]
    [JsonPropertyName("stages")]
    public SigningRouteStage[]? Stages { get; init; }
}