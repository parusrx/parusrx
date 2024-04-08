// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ParusRx.Egisz.Common;

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
