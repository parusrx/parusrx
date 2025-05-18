// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the application type request.
/// </summary>
[XmlRoot("applicationTypeRequest")]
public record ApplicationTypeRequest
{
    /// <summary>
    /// The authorization context.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }
}
