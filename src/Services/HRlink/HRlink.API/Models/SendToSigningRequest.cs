// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a send to signing request.
/// </summary>
[XmlRoot("sendToSigningRequest")]
public record SendToSigningRequest
{
    /// <summary>
    /// Gets or sets the authorization context.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    /// <summary>
    /// Gets or sets the document group.
    /// </summary>
    [XmlElement("documentGroup")]
    public required DocumentGroupRequestItem DocumentGroup { get; init; }
}
