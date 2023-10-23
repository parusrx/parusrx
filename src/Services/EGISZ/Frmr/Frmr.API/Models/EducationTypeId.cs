// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

public record EducationTypeId
{
    [JsonPropertyName("code")]
    [XmlElement("code")]
    public required string Code { get; init; }

    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string? Name { get; init; }
}
