// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Key
{
    [XmlElement("snils")]
    [JsonPropertyName("snils")]
    public string? Snils { get; init; }

    [XmlElement("document")]
    [JsonPropertyName("document")]
    public Document? Document { get; init; }
}
