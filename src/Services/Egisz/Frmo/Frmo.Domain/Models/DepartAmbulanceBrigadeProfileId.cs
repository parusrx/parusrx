// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record DepartAmbulanceBrigadeProfileId
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("brigadeProfile")]
    [JsonPropertyName("brigadeProfile")]
    public string? BrigadeProfile { get; init; }
}
