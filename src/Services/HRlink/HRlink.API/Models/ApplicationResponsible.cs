// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationResponsible
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; set; }

    [XmlElement("signerId")]
    [JsonPropertyName("signerId")]
    public string? SignerId { get; set; }

    [XmlElement("clientUserId")]
    [JsonPropertyName("clientUserId")]
    public string? ClientUserId { get; set; }

    [XmlElement("employee")]
    [JsonPropertyName("employee")]
    public EmployeeWithPositionAndDepartment? Employee { get; set; }
}
