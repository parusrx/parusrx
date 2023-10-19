// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a document request item for a create document group request.
/// </summary>
[XmlRoot("document")]
public record DocumentRequestItem 
{
    /// <summary>
    /// Gets or sets the external identifier of the document.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the file identifier associated with the document.
    /// </summary>
    [XmlElement("fileId")]
    [JsonPropertyName("fileId")]
    public string? FileId { get; init; }

    /// <summary>
    /// Gets or sets the file external identifier associated with the document.
    /// </summary>
    [XmlElement("fileExternalId")]
    [JsonPropertyName("fileExternalId")]
    public string? FileExternalId { get; init; }

    /// <summary>
    /// Gets or sets the legal entity to which the document belongs.
    /// </summary>
    [XmlElement("legalEntityId")]
    [JsonPropertyName("legalEntityId")]
    public string? LegalEntityId { get; init; }        

    /// <summary>
    /// Gets or sets the legal entity external identifier to which the document belongs.
    /// </summary>
    [XmlElement("legalEntityExternalId")]
    [JsonPropertyName("legalEntityExternalId")]
    public string? LegalEntityExternalId { get; init; }

    /// <summary>
    /// Gets or sets the type of the document.
    /// </summary>
    [XmlElement("typeId")]
    [JsonPropertyName("typeId")]
    public string? TypeId { get; init; }

    /// <summary>
    /// Gets or sets the number of the document.
    /// </summary>
    [XmlElement("number")]
    [JsonPropertyName("number")]
    public string? Number { get; init; }

    /// <summary>
    /// Gets or sets the date of the document.
    /// </summary>
    [XmlElement("date")]
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    /// <summary>
    /// Gets or sets the notice of the document.
    /// </summary>
    [XmlElement("notice")]
    [JsonPropertyName("notice")]
    public string? Notice { get; init; }

    /// <summary>
    /// Gets or sets the signing order of the document.
    /// </summary>
    [XmlElement("signingOrder")]
    [JsonPropertyName("signingOrder")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SigningOrder? SigningOrder { get; init; }

    /// <summary>
    /// Gets or sets the employee-manager identifier that signs the document from the legal entity.
    /// </summary>
    [XmlElement("headManagerId")]
    [JsonPropertyName("headManagerId")]
    public string? HeadManagerId { get; init; }

    /// <summary>
    /// Gets or sets the employee-manager external identifier that signs the document from the legal entity.
    /// </summary>
    [XmlElement("headManagerExternalId")]
    [JsonPropertyName("headManagerExternalId")]
    public string? HeadManagerExternalId { get; init; }

    /// <summary>
    /// Gets or sets the employee identifiers that signs the document.
    /// </summary>
    [XmlArray("employeeIds")]
    [XmlArrayItem("employeeId")]
    public string[]? EmployeeIds { get; init; }

    /// <summary>
    /// Gets or sets the employee external identifiers that signs the document.
    /// </summary>
    [XmlArray("employeeExternalIds")]
    [XmlArrayItem("employeeExternalId")]
    [JsonPropertyName("employeeExternalIds")]
    public string[]? EmployeeExternalIds { get; init; }

    /// <summary>
    /// Gets or sets the watcher identifiers that watches the document.
    /// </summary>
    [XmlArray("watcherIds")]
    [XmlArrayItem("watcherId")]
    public string[]? WatcherIds { get; init; }

    /// <summary>
    /// Gets or sets the watcher external identifiers that watches the document.
    /// </summary>
    [XmlArray("watcherExternalIds")]
    [XmlArrayItem("watcherExternalId")]
    [JsonPropertyName("watcherExternalIds")]
    public string[]? WatcherExternalIds { get; init; }

    /// <summary>
    /// Gets or sets the watcher client department identifiers that watches the document.
    /// </summary>
    [XmlArray("watcherClientDepartmentIds")]
    [XmlArrayItem("watcherClientDepartmentId")]
    [JsonPropertyName("watcherClientDepartmentIds")]
    public string[]? WatcherClientDepartmentIds { get; init; }

    /// <summary>
    /// Gets or sets the participants of the document.
    /// </summary>
    [XmlArray("participants")]
    [XmlArrayItem("participant")]
    [JsonPropertyName("participants")]
    public ParticipantItem[]? Participants { get; init; }

    /// <summary>
    /// Gets or sets the route template identifier.
    /// </summary>
    [XmlElement("routeTemplateId")]
    [JsonPropertyName("routeTemplateId")]
    public string? RouteTemplateId { get; init; }

    /// <summary>
    /// Gets or sets the route template external identifier.
    /// </summary>
    [XmlElement("routeTemplateExternalId")]
    [JsonPropertyName("routeTemplateExternalId")]
    public string? RouteTemplateExternalId { get; init; }

    /// <summary>
    /// Gets or sets the source document identifier.
    /// </summary>
    [XmlElement("sourceDocumentId")]
    [JsonPropertyName("sourceDocumentId")]
    public string? SourceDocumentId { get; init; }

    /// <summary>
    /// Gets or sets the source document external identifier.
    /// </summary>
    [XmlElement("sourceDocumentExternalId")]
    [JsonPropertyName("sourceDocumentExternalId")]
    public string? SourceDocumentExternalId { get; init; }
}
