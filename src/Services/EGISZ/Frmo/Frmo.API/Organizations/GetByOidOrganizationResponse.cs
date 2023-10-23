// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

[XmlRoot("getByOidOrganizationResponse")]
public record GetByOidOrganizationResponse : BaseResponse
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public Organization? Content { get; init; }
}
