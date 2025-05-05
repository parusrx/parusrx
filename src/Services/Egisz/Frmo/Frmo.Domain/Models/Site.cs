// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record Site
{
    [XmlElement("uSiteNameId")]
    [JsonPropertyName("uSiteNameId")]
    public string? USiteNameId { get; init; }

    [XmlElement("siteName")]
    [JsonPropertyName("siteName")]
    public string SiteName { get; init; } = default!;

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("type")]
    [JsonPropertyName("type")]
    public SiteType Type { get; init; } = default!;

    [XmlArray("category")]
    [XmlArrayItem("categoryItem")]
    [JsonPropertyName("category")]
    public SiteCategory[] Category { get; init; } = [];

    [XmlElement("patientAttached")]
    [JsonPropertyName("patientAttached")]
    public int? PatientAttached { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlArray("sitePersons")]
    [XmlArrayItem("sitePersonsItem")]
    [JsonPropertyName("sitePersons")]
    public SitePerson[] SitePersons { get; init; } = [];

    [XmlArray("siteAddresses")]
    [XmlArrayItem("siteAddressesItem")]
    [JsonPropertyName("siteAddresses")]
    public SiteAddress[] SiteAddresses { get; init; } = [];

    [XmlArray("attachmentType")]
    [XmlArrayItem("attachmentTypeItem")]
    [JsonPropertyName("attachmentType")]
    public AttachmentType[] AttachmentType { get; init; } = [];
}
