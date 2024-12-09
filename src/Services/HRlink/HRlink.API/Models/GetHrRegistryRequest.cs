// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a get HR registry request.
/// </summary>
[XmlRoot("getHrRegistryRequest")]
public record GetHrRegistryRequest
{
    /// <summary>
    /// Gets or sets the authorization context.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    /// <summary>
    /// Gets or sets the filter.
    /// </summary>
    [XmlElement("filter")]
    public required DocumentGroupRegistryFilter Filter { get; init; }
}
