// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
