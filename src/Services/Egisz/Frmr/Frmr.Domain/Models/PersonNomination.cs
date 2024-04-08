// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record PersonNomination
{
    [XmlElement("nominationId")]
    [JsonPropertyName("nominationId")]
    public int NominationId { get; init; }

    [XmlElement("nomNumber")]
    [JsonPropertyName("nomNumber")]
    public string NomNumber { get; init; } = string.Empty;

    [XmlElement("nomDate")]
    [JsonPropertyName("nomDate")]
    public DateTime NomDate { get; init; }

    [XmlElement("entityId")]
    [JsonPropertyName("entityId")]
    public string? EntityId { get; init; }
}
