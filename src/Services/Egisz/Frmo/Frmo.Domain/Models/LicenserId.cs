// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
