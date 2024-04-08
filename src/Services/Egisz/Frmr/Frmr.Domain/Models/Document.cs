// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
