// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a participant in a signing route.
/// </summary>
public record SigningRouteParticipant
{
    /// <summary>
    /// Gets or sets the identifier of the participant.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the type of the participant.
    /// </summary
    [XmlElement("type")]
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteParticipantType? Type { get; init; }

    /// <summary>
    /// Gets or sets the action type required from the participant in the signing route stage.
    /// </summary>
    [XmlElement("actionType")]
    [JsonPropertyName("actionType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningRouteParticipantActionType? ActionType { get; init; }

    /// <summary>
    /// Gets or sets the signing type for the participant in the signing route.
    /// </summary>
    [XmlElement("signingType")]
    [JsonPropertyName("signingType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RouteSigningType? SigningType { get; init; }

    /// <summary>
    /// Gets or sets the name of the participant.
    /// </summary>
    /// </summary>
    [XmlElement("placeholder")]
    [JsonPropertyName("placeholder")]
    public string? Placeholder { get; init; }

    /// <summary>
    /// Gets or sets the employee of the participant.
    /// </summary>
    [XmlElement("employee")]
    [JsonPropertyName("employee")]
    public SigningRouteParticipantEmployee? Employee { get; init; }

    /// <summary>
    /// Gets or sets whether a set of signers is created based on the participant.
    /// </summary>
    [XmlElement("isMultipleSigners")]
    [JsonPropertyName("isMultipleSigners")]
    public bool? IsMultipleSigners { get; init; }

    /// <summary>
    /// Gets or sets the Docflow system role data.
    /// </summary>
    [XmlElement("systemRole")]
    [JsonPropertyName("systemRole")]
    public DocflowSystemRole? SystemRole { get; init; }

    /// <summary>
    /// Gets or sets the type of the rule for automatically selecting participants.
    /// </summary>
    [XmlElement("autoSelectRuleType")]
    [JsonPropertyName("autoSelectRuleType")]
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    //public AutoSelectParticipantRuleType? AutoSelectRuleType { get; init; }
    public string? AutoSelectRuleType { get; init; }

    /// <summary>
    /// Gets or sets the related participant identifier.
    /// </summary>
    [XmlElement("relatedParticipantId")]
    [JsonPropertyName("relatedParticipantId")]
    public string? RelatedParticipantId { get; init; }

    /// <summary>
    /// Gets or sets the ID of the signing route template stage to which the participant belongs.
    /// </summary>
    [XmlElement("templateId")]
    [JsonPropertyName("templateId")]
    public string? TemplateId { get; init; }

    /// <summary>
    /// Get or sets the required participant.
    /// </summary>
    [XmlElement("required")]
    [JsonPropertyName("required")]
    public bool? Required { get; init; }

    /// <summary>
    /// Gets or sets the unchangeable participant.
    /// </summary>
    [XmlElement("unchangeable")]
    [JsonPropertyName("unchangeable")]
    public bool? Unchangeable { get; init; }
}
