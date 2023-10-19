// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a create document group response.
/// </summary>
[XmlRoot("createDocumentGroupResponse")]
public record CreateDocumentGroupResponse
{
    /// <summary>
    /// Gets or sets the result of the create document group operation.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the document group.
    /// </summary>
    [XmlElement("documentGroup")]
    [JsonPropertyName("documentGroup")]
    public required DocumentGroupResultItem DocumentGroup { get; init; }
}
