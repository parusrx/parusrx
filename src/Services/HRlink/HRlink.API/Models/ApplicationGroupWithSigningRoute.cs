// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

[XmlRoot("applicationGroup")]
public record ApplicationGroupWithSigningRoute
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("creator")]
    [JsonPropertyName("creator")]
    public ApplicationCreator? Creator { get; init; }

    [XmlElement("applicationType")]
    [JsonPropertyName("applicationType")]
    public ShortType? ApplicationType { get; init; }

    [XmlElement("date")]
    [JsonPropertyName("date")]
    public DateTime? Date { get; init; }

    [XmlElement("number")]
    [JsonPropertyName("number")]
    public string? Number { get; init; }

    [XmlElement("templateFieldData")]
    [JsonPropertyName("templateFieldData")]
    public ApplicationGroupTemplateFieldData? TemplateFieldData { get; set; }

    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [XmlElement("sentDate")]
    [JsonPropertyName("sentDate")]
    public DateTime? SentDate { get; set; }

    //[XmlElement("route")]
    //[JsonPropertyName("route")]
    //public required SigningRoute Route { get; set; } = default!;

    [XmlArray("applications")]
    [XmlArrayItem("applicationsItem")]
    [JsonPropertyName("applications")]
    public required Application[] Applications { get; init; } = [];

    [XmlArray("attachments")]
    [XmlArrayItem("attachmentsItem")]
    [JsonPropertyName("attachments")]
    public Attachment[]? Attachments { get; init; }

    [XmlElement("version")]
    [JsonPropertyName("version")]
    public long? Version { get; init; }

    [XmlElement("attachmentUploadingAllowed")]
    [JsonPropertyName("attachmentUploadingAllowed")]
    public bool? AttachmentUploadingAllowed { get; init; }
}
