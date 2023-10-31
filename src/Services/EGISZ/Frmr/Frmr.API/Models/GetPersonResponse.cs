// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

[XmlRoot("getPersonResponse")]
public record GetPersonResponse : BaseResponse
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public Person? Content { get; init; }
}
