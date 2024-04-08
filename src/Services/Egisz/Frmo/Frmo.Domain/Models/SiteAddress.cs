// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record SiteAddress
{
    [XmlElement("siteAddressId")]
    [JsonPropertyName("siteAddressId")]
    public string? SiteAddressId { get; init; }

    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = default!;

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }
}
