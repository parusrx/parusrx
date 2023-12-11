// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EducationOrganizationDepart
{
    [XmlElement("eoDepartOid")]
    [JsonPropertyName("eoDepartOid")]
    public string? EoDepartOid { get; init; }

    [XmlElement("eoDepartName")]
    [JsonPropertyName("eoDepartName")]
    public string EoDepartName { get; init; } = default!;

    [XmlArray("educationType")]
    [XmlArrayItem("educationTypeItem")]
    [JsonPropertyName("educationType")]
    public EducationType[] EducationType { get; init; } = [];
}
