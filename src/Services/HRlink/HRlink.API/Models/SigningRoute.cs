// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record SigningRoute
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [XmlElement("templateId")]
    [JsonPropertyName("templateId")]
    public string? TemplateId { get; init; }
}

public record SigningRouteStage 
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("indexNumber")]
    [JsonPropertyName("indexNumber")]
    public long? IndexNumber { get; init; }

    [XmlElement("type")]
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteStageType? Type { get; init; }

    [XmlElement("completenessCondition")]
    [JsonPropertyName("completenessCondition")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteStageCompletenessCondition? CompletenessCondition { get; init; }
}