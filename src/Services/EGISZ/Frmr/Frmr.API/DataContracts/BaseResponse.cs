// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

public abstract record BaseResponse
{
    [XmlElement("requestId")]
    [JsonPropertyName("requestId")]
    public string RequestId { get; init; } = default!;

    [XmlElement("errorUserMessage")]
    [JsonPropertyName("errorUserMessage")]
    public string? Message { get; init; }
}
