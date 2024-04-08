// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
