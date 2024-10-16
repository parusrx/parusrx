// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the route template request.
/// </summary>
[XmlRoot("routeTemplateRequest")]
public record RouteTemplateRequest
{
    /// <summary>
    /// Gets or sets the authorization context.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    /// <summary>
    /// Gets or sets the signing object type.
    /// </summary>
    [XmlElement("signingObjectType")]
    public SigningObjectType? SigningObjectType { get; init; }
}
