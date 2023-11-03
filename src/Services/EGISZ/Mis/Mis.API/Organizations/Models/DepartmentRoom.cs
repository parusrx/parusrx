// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public record DepartmentRoom
{
    [XmlElement("oid")]
    [JsonPropertyName("oid")]
    public string Oid { get; init; } = default!;

    [XmlElement("healthCareProfile")]
    [JsonPropertyName("healthCareProfile")]
    public HealthCareProfile[]? HealthCareProfile { get; init; }

    [XmlArray("services")]
    [XmlArrayItem("servicesItem")]
    [JsonPropertyName("services")]
    public Service[] Services { get; init; } = [];

    [XmlElement("subdivisionId")]
    public DepartmentSubdivision SubdivisionId { get; init; } = default!;

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public Building[] Buildings { get; init; } = [];
}
