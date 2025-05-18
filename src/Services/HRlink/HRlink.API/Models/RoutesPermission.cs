// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a route permissions.
/// </summary>
public record RoutesPermission
{
    /// <summary>
    /// The client department identifier.
    /// </summary>
    [XmlElement("clientDepartmentId")]
    [JsonPropertyName("clientDepartmentId")]
    public required string ClientDepartmentId { get; init; }

    /// <summary>
    /// The signing route template identifier.
    /// </summary>
    [XmlElement("routeId")]
    [JsonPropertyName("routeId")]
    public required string RouteId { get; init; }
}
