// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document type in the Mintrud system.
/// </summary>
public record MintrudDocumentType
{
    /// <summary>
    /// Gets the unique identifier for the document type.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Gets the name of the document type.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets the code of the document type.
    /// </summary>
    [XmlElement("code")]
    [JsonPropertyName("code")]
    public required string Code { get; init; }

    /// <summary>
    /// Indicates whether the ability for the employee to sign with an electronic signature is enabled.
    /// </summary>
    [XmlElement("signingByEmployeeSesEnabled")]
    [JsonPropertyName("signingByEmployeeSesEnabled")]
    public bool? SigningByEmployeeSesEnabled { get; init; }

    /// <summary>
    /// Gets a value indicating whether the substitutor creation hint is enabled.
    /// </summary>
    [XmlElement("substitutorCreationHintEnabled")]
    [JsonPropertyName("substitutorCreationHintEnabled")]
    public bool? SubstitutorCreationHintEnabled { get; init; }
}
