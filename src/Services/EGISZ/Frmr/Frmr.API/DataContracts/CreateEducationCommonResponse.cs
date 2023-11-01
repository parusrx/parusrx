// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("createEducationCommonResponse")]
public record CreateEducationCommonResponse : BaseResponse
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public Entity? Content { get; init; }
}
