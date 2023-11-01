// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("listPagedPersonResponse")]
public record ListPagedPersonResponse : BaseResponse
{
    [XmlElement("offset")]
    [JsonPropertyName("offset")]
    public int Offset { get; init; } = 0;

    [XmlElement("limit")]
    [JsonPropertyName("limit")]
    public int Limit { get; init; } = 10;

    [XmlElement("total")]
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [XmlElement("content")]
    [JsonPropertyName("content")]
    public List<Person>? Content { get; init; }
}
