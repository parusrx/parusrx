// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record EducationType
{
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public int Code { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [XmlArray("educationSpec")]
    [XmlArrayItem("educationSpecItem")]
    [JsonPropertyName("educationSpec")]
    public EducationSpec[] EducationSpec { get; init; } = [];
}
