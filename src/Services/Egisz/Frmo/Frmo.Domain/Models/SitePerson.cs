// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record SitePerson
{
    [XmlElement("sitePersonId")]
    [JsonPropertyName("sitePersonId")]
    public string? SitePersonId { get; init; }

    [XmlElement("beginDate")]
    [JsonPropertyName("beginDate")]
    public DateTime BeginDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("regRoomSingleOid")]
    [JsonPropertyName("regRoomSingleOid")]
    public string RegRoomSingleOid { get; init; } = default!;

    [XmlElement("regRoomOid")]
    [JsonPropertyName("regRoomOid")]
    public string RegRoomOid { get; init; } = default!;

    [XmlElement("regRoomName")]
    [JsonPropertyName("regRoomName")]
    public string RegRoomName { get; init; } = default!;

    [XmlElement("personOid")]
    [JsonPropertyName("personOid")]
    public string PersonOid { get; init; } = default!;

    [XmlElement("personFio")]
    [JsonPropertyName("personFio")]
    public string PersonFio { get; init; } = default!;
}
