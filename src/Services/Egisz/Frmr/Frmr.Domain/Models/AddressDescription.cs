// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

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
