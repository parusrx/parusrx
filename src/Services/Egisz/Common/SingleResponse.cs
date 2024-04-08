// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ParusRx.Egisz.Common;

[XmlRoot("response")]
public record SingleResponse<TContent> : DefaultResponse
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public TContent Content { get; init; } = default!;
}
