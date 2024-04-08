// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

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
