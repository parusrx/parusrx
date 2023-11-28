// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
