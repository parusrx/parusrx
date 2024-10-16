// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a signing route template.
/// </summary>
[XmlRoot("signingRouteTemplate")]
public record SigningRouteTemplate
{
    /// <summary>
    /// Gets or sets the identifier of the signing route template.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or sets the identifier of the client.
    /// </summary>
    [XmlElement("clientId")]
    [JsonPropertyName("clientId")]
    public string? ClientId { get; init; }

    /// <summary>
    /// Gets or sets the name of the signing route template.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the type of the signing object.
    /// </summary>
    [XmlElement("signingObjectType")]
    [JsonPropertyName("signingObjectType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningObjectType? SigningObjectType { get; init; }

    /// <summary>
    /// Gets or sets the external identifier of the signing route template.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets keys of system signing routes for application.
    /// </summary>
    [XmlElement("templateKey")]
    [JsonPropertyName("templateKey")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TemplateKey? TemplateKey { get; init; }

    /// <summary>
    /// Gets or sets the created date of the signing route template.
    /// </summary>
    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; init; }

    /// <summary>
    /// Gets or sets the deactivated date of the signing route template.
    /// </summary>
    [XmlElement("deactivatedDate")]
    [JsonPropertyName("deactivatedDate")]
    public DateTime? DeactivatedDate { get; init; }

    /// <summary>
    /// Gets or sets the stages of the signing route template.
    /// </summary>
    [XmlArray("stages")]
    [XmlArrayItem("stage")]
    [JsonPropertyName("stages")]
    public SigningRouteTemplateStage[]? Stages { get; init; }

    [XmlArray("legalEntities")]
    [XmlArrayItem("legalEntity")]
    [JsonPropertyName("legalEntities")]
    public ShortLegalEntity[]? LegalEntities { get; init; }

    /// <summary>
    /// Gets or sets the version of the signing route template.
    /// </summary>
    [XmlElement("version")]
    [JsonPropertyName("version")]
    public int? Version { get; init; }
}
