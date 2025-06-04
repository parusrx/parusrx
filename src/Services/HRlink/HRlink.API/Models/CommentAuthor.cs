// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record CommentAuthor
{
    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; set; }

    [XmlElement("userId")]
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
}