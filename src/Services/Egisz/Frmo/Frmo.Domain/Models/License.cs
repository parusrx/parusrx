// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.Domain;

public record License
{
    [XmlElement("guid")]
    [JsonPropertyName("guid")]
    public string? Guid { get; init; }

    [XmlElement("isNotification")]
    [JsonPropertyName("isNotification")]
    public bool? IsNotification { get; init; }

    [XmlElement("licenseSeries")]
    [JsonPropertyName("licenseSeries")]
    public string? LicenseSeries { get; init; }

    [XmlElement("licenseNumber")]
    [JsonPropertyName("licenseNumber")]
    public string? LicenseNumber { get; init; }

    [XmlElement("statusId")]
    [JsonPropertyName("statusId")]
    public LicenseStatusId? StatusId { get; init; }

    [XmlElement("licenseDate")]
    [JsonPropertyName("licenseDate")]
    public DateTime? LicenseDate { get; init; }

    [XmlElement("licenseBeginDate")]
    [JsonPropertyName("licenseBeginDate")]
    public DateTime? LicenseBeginDate { get; init; }

    [XmlElement("licenseEnd")]
    [JsonPropertyName("licenseEnd")]
    public DateTime? LicenseEnd { get; init; }

    [XmlElement("activityId")]
    [JsonPropertyName("activityId")]
    public LicenseActivityId? ActivityId { get; init; }

    [XmlElement("licenserId")]
    [JsonPropertyName("licenserId")]
    public LicenserId? LicenserId { get; init; }

    [XmlElement("nrPmuLicApplication")]
    [JsonPropertyName("nrPmuLicApplication")]
    public NrPmuLicApplication? NrPmuLicApplication { get; init; }
}
