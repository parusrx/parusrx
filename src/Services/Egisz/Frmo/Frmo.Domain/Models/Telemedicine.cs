// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Telemedicine
{
    [XmlElement("telemedicineId")]
    [JsonPropertyName("telemedicineId")]
    public string? TelemedicineId { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [XmlElement("depart")]
    [JsonPropertyName("depart")]
    public TelemedicineDepart Depart { get; init; } = default!;

    [XmlElement("subdivision")]
    [JsonPropertyName("subdivision")]
    public TelemedicineSubdivision? Subdivision { get; init; }

    [XmlElement("cabinet")]
    [JsonPropertyName("cabinet")]
    public TelemedicineCabinet? Cabinet { get; init; }

    [XmlArray("buildings")]
    [XmlArrayItem("buildingsItem")]
    [JsonPropertyName("buildings")]
    public TelemedicineBuilding[] Buildings { get; init; } = [];

    [XmlElement("schedule")]
    [JsonPropertyName("schedule")]
    public string Schedule { get; init; } = default!;

    [XmlElement("isSecure")]
    [JsonPropertyName("isSecure")]
    public bool IsSecure { get; init; }
}
