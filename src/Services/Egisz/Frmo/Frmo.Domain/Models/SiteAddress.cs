// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
