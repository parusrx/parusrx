// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.Domain;

public record Entity
{
    [XmlElement("entityId")]
    [JsonPropertyName("entityId")]
    public string EntityId { get; init; } = default!;
}
