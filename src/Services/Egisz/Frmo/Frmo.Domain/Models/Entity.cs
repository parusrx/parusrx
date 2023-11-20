// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record Entity
{
    [XmlElement("entityId")]
    [JsonPropertyName("entityId")]
    public string EntityId { get; init; } = default!;
}
