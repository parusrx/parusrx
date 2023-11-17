// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record EducationalOrganizationType
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("organizationType")]
    [JsonPropertyName("organizationType")]
    public string? OrganizationType { get; init; }
}
