// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record AttachmentType
{
    [XmlElement("siteAttachmentTypeId")]
    [JsonPropertyName("siteAttachmentTypeId")]
    public string? SiteAttachmentTypeId { get; init; }

    [XmlElement("type")]
    [JsonPropertyName("type")]
    public int? Type { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("omsMarkId")]
    [JsonPropertyName("omsMarkId")]
    public string OmsMarkId { get; init; } = default!;
}
