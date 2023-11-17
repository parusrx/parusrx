// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Persons;

public record PersonDocument : Document
{
    [XmlElement("passDate")]
    [JsonPropertyName("passDate")]
    public DateTime PassDate { get; init; }

    [XmlElement("passOrg")]
    [JsonPropertyName("passOrg")]
    public string PassOrg { get; init; } = default!;

    [XmlElement("codeOrg")]
    [JsonPropertyName("codeOrg")]
    public string? CodeOrg { get; init; }
}
