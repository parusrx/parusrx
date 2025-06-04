// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record Application
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("legalEntity")]
    [JsonPropertyName("legalEntity")]
    public ShortLegalEntity? LegalEntity { get; init; }

    [XmlElement("originalFile")]
    [JsonPropertyName("originalFile")]
    public ShortEntity? OriginalFile { get; init; }

    [XmlElement("fileId")]
    [JsonPropertyName("fileId")]
    public string? FileId { get; init; }

    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    [XmlElement("fileProcessedDate")]
    [JsonPropertyName("fileProcessedDate")]
    public DateTime? FileProcessedDate { get; init; }

    [XmlElement("fileConversionFailedDate")]
    [JsonPropertyName("fileConversionFailedDate")]
    public DateTime? FileConversionFailedDate { get; init; }

    [XmlElement("deletedDate")]
    [JsonPropertyName("deletedDate")]
    public DateTime? DeletedDate { get; init; }

    [XmlElement("rejectedDate")]
    [JsonPropertyName("rejectedDate")]
    public DateTime? RejectedDate { get; init; }

    [XmlElement("docflowFinishedDate")]
    [JsonPropertyName("docflowFinishedDate")]
    public DateTime? DocflowFinishedDate { get; init; }

    [XmlArray("signers")]
    [XmlArrayItem("signersItem")]
    [JsonPropertyName("signers")]
    public ApplicationSigner[]? Signers { get; init; }

    [XmlArray("responsibles")]
    [XmlArrayItem("responsiblesItem")]
    [JsonPropertyName("responsibles")]
    public ApplicationResponsible[]? Responsibles { get; init; }

    [XmlElement("lastSignedDate")]
    [JsonPropertyName("lastSignedDate")]
    public DateTime? LastSignedDate { get; init; }

    [XmlElement("printFormUpdatedDate")]
    [JsonPropertyName("printFormUpdatedDate")]
    public DateTime? PrintFormUpdatedDate { get; init; }

    [XmlElement("version")]
    [JsonPropertyName("version")]
    public long? Version { get; init; }

    [XmlArray("eventDates")]
    [XmlArrayItem("eventDatesItem")]
    [JsonPropertyName("eventDates")]
    public ApplicationEventDateShortInfo[]? EventDates { get; init; }

    [XmlArray("comments")]
    [XmlArrayItem("commentsItem")]
    [JsonPropertyName("comments")]
    public ChatComment[]? Comments { get; init; }

    [XmlArray("recipients")]
    [XmlArrayItem("recipientsItem")]
    [JsonPropertyName("recipients")]
    public ApplicationRecipient[]? Recipients { get; init; }
}
