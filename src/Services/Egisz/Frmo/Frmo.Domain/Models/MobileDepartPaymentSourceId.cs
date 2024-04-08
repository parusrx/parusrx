// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record MobileDepartPaymentSourceId
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
