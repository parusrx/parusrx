// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Secretary
{
    [XmlElement("snils")]
    [JsonPropertyName("snils")]
    public string? Snils { get; init; }

    [XmlElement("document")]
    [JsonPropertyName("document")]
    public Document? Document { get; init; }
}
