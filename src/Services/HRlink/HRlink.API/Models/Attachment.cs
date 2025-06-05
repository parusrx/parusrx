// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record Attachment
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
    
    [XmlElement("fileId")]
    [JsonPropertyName("fileId")]
    public string? FileId { get; init; }
    
    [XmlElement("fileName")]
    [JsonPropertyName("fileName")]
    public string? FileName { get; init; }

    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; init; }

    [XmlElement("creatorClientUser")]
    [JsonPropertyName("creatorClientUser")]
    public ClientUserShortInfo? CreatorClientUser { get; init; }
}