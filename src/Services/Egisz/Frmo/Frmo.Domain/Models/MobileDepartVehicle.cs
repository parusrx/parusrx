// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record MobileDepartVehicle
{
    [XmlElement("vehicleId")]
    [JsonPropertyName("vehicleId")]
    public string VehicleId { get; set; } = default!;

    [XmlElement("hasRegistrationCertificate")]
    [JsonPropertyName("hasRegistrationCertificate")]
    public bool HasRegistrationCertificate { get; set; }

    [XmlElement("registrationCertificate")]
    [JsonPropertyName("registrationCertificate")]
    public string? RegistrationCertificate { get; set; }

    [XmlElement("productYear")]
    [JsonPropertyName("productYear")]
    public string? ProductYear { get; set; }

    [XmlElement("beginYear")]
    [JsonPropertyName("beginYear")]
    public string? BeginYear { get; set; }

    [XmlElement("isForPacient")]
    [JsonPropertyName("isForPacient")]
    public bool IsForPacient { get; set; }

    [XmlElement("isParamedic")]
    [JsonPropertyName("isParamedic")]
    public bool IsParamedic { get; set; }

    [XmlElement("ownerOrg")]
    [JsonPropertyName("ownerOrg")]
    public string OwnerOrg { get; set; } = default!;

    [XmlElement("rightToUse")]
    [JsonPropertyName("rightToUse")]
    public string RightToUse { get; set; } = default!;

    [XmlElement("VIN")]
    [JsonPropertyName("VIN")]
    public string Vin { get; set; } = default!;

    [XmlElement("carMark")]
    [JsonPropertyName("carMark")]
    public string CarMark { get; set; } = default!;

    [XmlElement("carModel")]
    [JsonPropertyName("carModel")]
    public string CarModel { get; set; } = default!;

    [XmlElement("releaseDate")]
    [JsonPropertyName("releaseDate")]
    public string? ReleaseDate { get; set; }

    [XmlElement("useDate")]
    [JsonPropertyName("useDate")]
    public DateTime UseDate { get; set; }

    [XmlElement("mileage")]
    [JsonPropertyName("mileage")]
    public int? Mileage { get; set; }

    [XmlElement("isNavigation")]
    [JsonPropertyName("isNavigation")]
    public bool IsNavigation { get; set; }

    [XmlElement("codeNavigation")]
    [JsonPropertyName("codeNavigation")]
    public string? CodeNavigation { get; set; }
}
