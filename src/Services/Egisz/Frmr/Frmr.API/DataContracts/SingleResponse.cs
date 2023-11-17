// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("response")]
public record SingleResponse<TContent> : DefaultResponse
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public TContent Content { get; init; } = default!;
}
