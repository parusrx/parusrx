// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Document
{
    [XmlElement("documentId")]
    [JsonPropertyName("documentId")]
    public int? DocumentId { get; init; }

    [XmlElement("serial")]
    [JsonPropertyName("serial")]
    public string? Serial { get; init; }

    [XmlElement("number")]
    [JsonPropertyName("number")]
    public string? Number { get; init; }
}
