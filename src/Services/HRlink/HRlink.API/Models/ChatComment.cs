// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ChatComment
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [XmlElement("version")]
    [JsonPropertyName("version")]
    public long? Version { get; set; }

    [XmlElement("user")]
    [JsonPropertyName("user")]
    public CommentAuthor? User { get; set; }

    [XmlElement("message")]
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }
}
