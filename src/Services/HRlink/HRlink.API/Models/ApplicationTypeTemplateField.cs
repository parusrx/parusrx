// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a substitution field for an application type template.
/// </summary>
public record ApplicationTypeTemplateField
{
    /// <summary>
    /// The identifier of the substitution template field.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The key used in the template for value substitution.
    /// </summary>
    [XmlElement("substitutionKey")]
    [JsonPropertyName("substitutionKey")]
    public required string SubstitutionKey { get; init; }

    /// <summary>
    /// The indicating whether the field is mandatory.
    /// </summary>
    [XmlElement("required")]
    [JsonPropertyName("required")]
    public bool? Required { get; init; }

    /// <summary>
    /// The display label of the field in the application.
    /// </summary>
    [XmlElement("label")]
    [JsonPropertyName("label")]
    public required string Label { get; init; }

    /// <summary>
    /// The data type of the field value.
    /// </summary>
    [XmlElement("type")]
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// Any additional notes associated with the field.
    /// </summary>
    [XmlElement("note")]
    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>
    /// The list of suggested values for the field.
    /// </summary>
    [XmlArray("values")]
    [XmlArrayItem("valuesItem")]
    [JsonPropertyName("values")]
    public string[]? Values { get; init; }

    /// <summary>
    /// The value indicates whether the field should be filled in by the user.
    /// </summary>
    [XmlElement("specifiedByUser")]
    [JsonPropertyName("specifiedByUser")]
    public bool? SpecifiedByUser { get; init; }

    /// <summary>
    /// The value indicates whether the field is used as the event date.
    /// </summary>
    [XmlElement("usedAsEventDate")]
    [JsonPropertyName("usedAsEventDate")]
    public bool? UsedAsEventDate { get; init; }

    /// <summary>
    /// The input type for the field in the application type template.
    /// </summary>
    /// <remarks>
    /// Enum values: "MANUAL" (manual entry) or "CALCULATED" (auto-calculation).
    /// </remarks>
    [XmlElement("inputType")]
    [JsonPropertyName("inputType")]
    public string? InputType { get; init; }
}
