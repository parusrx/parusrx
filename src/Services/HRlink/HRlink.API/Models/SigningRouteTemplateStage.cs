// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing route template stage.
/// </summary>
[XmlRoot("signingRouteTemplateStage")]
public record SigningRouteTemplateStage
{
    /// <summary>
    /// Gets or sets the identifier of the stage.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the signing route template.
    /// </summary>
    [XmlElement("signingRouteTemplateId")]
    [JsonPropertyName("signingRouteTemplateId")]
    public string? SigningRouteTemplateId { get; init; }

    /// <summary>
    /// Gets or sets the number of the stage.
    /// </summary>
    [XmlElement("indexNumber")]
    [JsonPropertyName("indexNumber")]
    public long? IndexNumber { get; init; }

    /// <summary>
    /// Gets or sets the type of the stage.
    /// </summary>
    [XmlElement("type")]
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteStageType? Type { get; init; }

    /// <summary>
    /// Gets or sets the condition of completeness of the stage.
    /// </summary>
    [XmlElement("completenessCondition")]
    [JsonPropertyName("completenessCondition")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteStageCompletenessCondition? CompletenessCondition { get; init; }

    /// <summary>
    /// Gets or sets whether the responsible is enabled at this stage.
    /// </summary>
    [XmlElement("responsibleEnabled")]
    [JsonPropertyName("responsibleEnabled")]
    public bool? ResponsibleEnabled { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the responsible.
    /// </summary>
    [XmlElement("canDeleteBeforeStageCompleted")]
    [JsonPropertyName("canDeleteBeforeStageCompleted")]
    public bool? CanDeleteBeforeStageCompleted { get; init; }

    /// <summary>
    /// Gets or sets participants of the stage.
    /// </summary>
    [XmlArray("participants")]
    [XmlArrayItem("participant")]
    [JsonPropertyName("participants")]
    public SigningRouteTemplateParticipant[]? Participants { get; init; }

    /// <summary>
    /// Gets or sets the version of the stage.
    /// </summary>
    [XmlElement("version")]
    [JsonPropertyName("version")]
    public long? Version { get; init; }
}
