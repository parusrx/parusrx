// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a route template response.
/// </summary>
[XmlRoot("routeTemplateResponse")]
public record RouteTemplateResponse
{
    /// <summary>
    /// Gets or sets the result of the files upload.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    [XmlArray("signingRouteTemplates")]
    [XmlArrayItem("signingRouteTemplate")]
    [JsonPropertyName("signingRouteTemplates")]
    public required SigningRouteTemplate[] SigningRouteTemplates { get; init; } = [];
}
