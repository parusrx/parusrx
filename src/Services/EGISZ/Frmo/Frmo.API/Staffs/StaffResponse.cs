// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("staffResponse")]
public record StaffResponse : BaseResponse
{
    [XmlArray("content")]
    [XmlArrayItem("staff")]
    [JsonPropertyName("content")]
    public Staff[]? Content { get; init; }
}
