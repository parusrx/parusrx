// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("response")]
public record DefaultResponse
{
    [XmlElement("requestId")]
    [JsonPropertyName("requestId")]
    [JsonPropertyOrder(-1)]
    public string RequestId { get; init; } = default!;

    [XmlElement("errorUserMessage")]
    [JsonPropertyName("errorUserMessage")]
    [JsonPropertyOrder(-1)]
    public string? Message { get; init; }
}
