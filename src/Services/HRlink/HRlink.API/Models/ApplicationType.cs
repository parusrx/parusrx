// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an application type in the HRlink system.
/// </summary>
[XmlRoot("applicationType")]
public record ApplicationType
{
    /// <summary>
    /// The unique identifier for the application type.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The name of the application type.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The Mintrud document type data.
    /// </summary>
    [XmlElement("mintrudDocumentType")]
    [JsonPropertyName("mintrudDocumentType")]
    public MintrudDocumentType? MintrudDocumentType { get; init; }

    /// <summary>
    /// The list of custom user fields for substitution in the application type template.
    /// </summary>
    [XmlArray("templateFields")]
    [XmlArrayItem("templateFieldsItem")]
    [JsonPropertyName("templateFields")]
    public ApplicationTypeTemplateField[]? TemplateFields { get; init; }

    /// <summary>
    /// The indicator of whether the application type is a template.
    /// </summary>
    /// <remarks>
    /// Indicates whether the application type is based on a template (true) or a user-uploaded file (false).
    /// If <c>false</c>, the application is created from a user-uploaded file.
    /// If <c>true</c>, the application is created from a pre-uploaded docx template.
    /// </remarks>
    [XmlElement("templatable")]
    [JsonPropertyName("templatable")]
    public bool? Templatable { get; init; }

    /// <summary>
    /// The indicator of whether the application type is active.
    /// </summary>
    [XmlElement("active")]
    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [XmlArray("permittedByClientDepartments")]
    [XmlArrayItem("permittedByClientDepartmentsItem")]
    [JsonPropertyName("permittedByClientDepartments")]
    public PermittedByClientDepartment[]? PermittedByClientDepartments { get; init; }

    /// <summary>
    /// The list of signing route template permissions associated with the employee's department.
    /// </summary>
    [XmlArray("routesPermissions")]
    [XmlArrayItem("routePermissionsItem")]
    [JsonPropertyName("routesPermissions")]
    public RoutesPermission[]? RoutesPermissions { get; init; }

    /// <summary>
    /// The signing route template data.
    /// </summary>
    [XmlElement("signingRouteTemplate")]
    [JsonPropertyName("signingRouteTemplate")]
    public SigningRouteTemplate? SigningRouteTemplate { get; init; }
}

/// <summary>
/// Represents a short version of an application type in the HRlink system.
/// </summary>
public record ApplicationShortType
{
    /// <summary>
    /// The unique identifier for the application type.
    /// </summary>
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The name of the application type.
    /// </summary>
    [XmlElement("name")]
    [JsonPropertyName("name")]
    public string? Name { get; init; }


    /// <summary>
    /// Indicates whether the ability for the employee to sign with an electronic signature (SES) is enabled.
    /// </summary>
    [XmlElement("signingByEmployeeSesEnabled")]
    [JsonPropertyName("signingByEmployeeSesEnabled")]
    public bool? SigningByEmployeeSesEnabled { get; init; }

    
    /// <summary>
    /// Indicates whether the hint for the possibility of appointing a substitutor is enabled.
    /// </summary>
    [XmlElement("substitutorCreationHintEnabled")]
    [JsonPropertyName("substitutorCreationHintEnabled")]
    public bool? SubstitutorCreationHintEnabled { get; init; }
}
