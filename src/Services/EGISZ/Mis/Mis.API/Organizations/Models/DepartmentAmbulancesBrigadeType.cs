// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public record DepartmentAmbulancesBrigadeType
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [XmlElement("brigadeType")]
    [JsonPropertyName("brigadeType")]
    public string? BrigadeType { get; init; }
}
