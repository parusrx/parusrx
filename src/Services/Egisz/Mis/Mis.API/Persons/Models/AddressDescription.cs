// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Persons;

public record AddressDescription
{
    [XmlElement("addressId")]
    [JsonPropertyName("addressId")]
    public string? AddressId { get; init; }

    [XmlElement("regDate")]
    [JsonPropertyName("regDate")]
    public DateTime RegDate { get; init; }

    [XmlElement("addressTypeId")]
    [JsonPropertyName("addressTypeId")]
    public int AddressTypeId { get; init; }

    [XmlElement("address")]
    [JsonPropertyName("address")]
    public Address Address { get; init; } = new();
}
