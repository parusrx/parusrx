// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record Substitution 
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }
    
    [XmlElement("startDate")]
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [XmlElement("endDate")]
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [XmlElement("substitutorClientUser")]
    [JsonPropertyName("substitutorClientUser")]
    public SubstitutorClientUser? SubstitutorClientUser { get; init; }
}
