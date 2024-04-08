// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the user.
/// </summary>
public record User
{
    /// <summary>
    /// Gets or sets the identifier of the user.
    /// </summary>
    [XmlElement("externalId")]
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; init; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; } 

    /// <summary>
    /// Gets or sets the patronymic of the user.
    /// </summary>
    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    /// <summary>
    /// Gets or sets the gender of the user.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [XmlElement("gender")]
    [JsonPropertyName("gender")]
    public Gender? Gender { get; init; }

    /// <summary>
    /// Gets or sets the birth date of the user.
    /// </summary>
    [XmlElement("birthdate")]
    [JsonPropertyName("birthdate")]
    public DateTime? BirthDate { get; init; }

    /// <summary>
    /// Gets or sets the phone of the user.
    /// </summary>
    [XmlElement("phone")]
    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    [XmlElement("email")]
    [JsonPropertyName("email")]
    public string? Email { get; init; }

    /// <summary>
    /// Gets or sets the pesronal documents of the user.
    /// </summary>
    [XmlArray("personalDocuments")]
    [XmlArrayItem("personalDocument")]
    [JsonPropertyName("personalDocuments")]
    public List<PersonalDocument>? PersonalDocuments { get; init; }

    /// <summary>
    /// Gets or sets the employees of the user.
    /// </summary>
    [XmlArray("employees")]
    [XmlArrayItem("employee")]
    [JsonPropertyName("employees")]
    public List<Employee>? Employees { get; init; }
}

/// <summary>
/// The gender type of the user.
/// </summary>
public enum Gender 
{
    /// <summary>
    /// The male.
    /// </summary>
    [XmlEnum("MALE")]
    MALE,

    /// <summary>
    /// The female.
    /// </summary>
    [XmlEnum("FEMALE")]
    FEMALE
}
