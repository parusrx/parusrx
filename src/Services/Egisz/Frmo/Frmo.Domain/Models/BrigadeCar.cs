// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record BrigadeCar
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("VIN")]
    [JsonPropertyName("VIN")]
    public string Vin { get; init; } = default!;

    [XmlElement("carMark")]
    [JsonPropertyName("carMark")]
    public string CarMark { get; init; } = default!;

    [XmlElement("carModel")]
    [JsonPropertyName("carModel")]
    public string CarModel { get; init; } = default!;

    [XmlElement("releaseDate")]
    [JsonPropertyName("releaseDate")]
    public DateTime? ReleaseDate { get; init; }

    [XmlElement("useDate")]
    [JsonPropertyName("useDate")]
    public DateTime? UseDate { get; init; }

    [XmlElement("mileage")]
    [JsonPropertyName("mileage")]
    public double? Mileage { get; init; }

    [XmlElement("isNavigation")]
    [JsonPropertyName("isNavigation")]
    public bool IsNavigation { get; init; }

    [XmlElement("codeNavigation")]
    [JsonPropertyName("codeNavigation")]
    public string? CodeNavigation { get; init; }

    [XmlArray("equipment")]
    [XmlArrayItem("equipmentItem")]
    [JsonPropertyName("equipment")]
    public string[] Equipment { get; init; } = [];

    [XmlElement("isForPacient")]
    [JsonPropertyName("isForPacient")]
    public bool? IsForPacient { get; init; }

    [XmlElement("isParamedic")]
    [JsonPropertyName("isParamedic")]
    public bool? IsParamedic { get; init; }

    [XmlElement("ownerOrg")]
    [JsonPropertyName("ownerOrg")]
    public string? OwnerOrg { get; init; }

    [XmlElement("rightToUse")]
    [JsonPropertyName("rightToUse")]
    public string? RightToUse { get; init; }
}
