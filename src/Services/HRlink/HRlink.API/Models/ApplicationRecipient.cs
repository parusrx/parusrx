// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationRecipient
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("employee")]
    [JsonPropertyName("employee")]
    public EmployeeInfoWithPositionAndNumber? Employee { get; init; }

    [XmlElement("seenDate")]
    [JsonPropertyName("seenDate")]
    public DateTime? SeenDate { get; init; }

    [XmlElement("participantId")]
    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; init; }
}