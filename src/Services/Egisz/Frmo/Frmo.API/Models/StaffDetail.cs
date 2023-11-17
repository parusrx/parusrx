// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public record StaffDetail
{
    [XmlElement("nrPmuDepartId")]
    [JsonPropertyName("nrPmuDepartId")]
    public string NrPmuDepartId { get; init; } = default!;

    [XmlElement("departName")]
    [JsonPropertyName("departName")]
    public string? DepartName { get; init; }

    [XmlElement("nrPmuDepartHospitalSubdivisionId")]
    [JsonPropertyName("nrPmuDepartHospitalSubdivisionId")]
    public string? NrPmuDepartHospitalSubdivisionId { get; init; }

    [XmlElement("hospitalName")]
    [JsonPropertyName("hospitalName")]
    public string? HospitalName { get; init; }

    [XmlElement("postFedCode")]
    [JsonPropertyName("postFedCode")]
    public PostFedCode PostFedCode { get; init; } = default!;

    [XmlElement("post")]
    [JsonPropertyName("post")]
    public Post Post { get; init; } = default!;

    [XmlElement("flCount")]
    [JsonPropertyName("flCount")]
    public int? FlCount { get; init; }

    [XmlElement("averageAge")]
    [JsonPropertyName("averageAge")]
    public double? AverageAge { get; init; }

    [XmlElement("rate")]
    [JsonPropertyName("rate")]
    public double Rate { get; init; }

    [XmlElement("busyRate")]
    [JsonPropertyName("busyRate")]
    public double? BusyRate { get; init; }

    [XmlElement("busyRateMain")]
    [JsonPropertyName("busyRateMain")]
    public double? BusyRateMain { get; init; }

    [XmlElement("externalRate")]
    [JsonPropertyName("externalRate")]
    public double? ExternalRate { get; init; }

    [XmlElement("vacancy")]
    [JsonPropertyName("vacancy")]
    public double? Vacancy { get; init; }

    [XmlElement("staffNote")]
    [JsonPropertyName("staffNote")]
    public string? StaffNote { get; init; }
}
