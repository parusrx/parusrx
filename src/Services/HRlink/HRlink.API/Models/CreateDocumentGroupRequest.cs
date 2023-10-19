// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a create document group request.
/// </summary>
[XmlRoot("createDocumentGroupRequest")]
public record CreateDocumentGroupRequest
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
