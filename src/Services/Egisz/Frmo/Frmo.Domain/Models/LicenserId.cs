// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record LicenserId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    [XmlElement("licenser")]
    [JsonPropertyName("licenser")]
    public string? Licenser { get; init; }

    [XmlElement("inn")]
    [JsonPropertyName("inn")]
    public string? Inn { get; init; }

    [XmlElement("ogrn")]
    [JsonPropertyName("ogrn")]
    public string? Ogrn { get; init; }
}
