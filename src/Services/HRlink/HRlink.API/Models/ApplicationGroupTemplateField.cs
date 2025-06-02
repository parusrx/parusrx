// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationGroupTemplateField
{
    [XmlElement("label")]
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [XmlElement("note")]
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [XmlElement("sortOrder")]
    [JsonPropertyName("sortOrder")]
    public int? SortOrder { get; set; }

    [XmlElement("substitutionKey")]
    [JsonPropertyName("substitutionKey")]
    public string? SubstitutionKey { get; set; }

    [XmlElement("value")]
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [XmlElement("fieldType")]
    [JsonPropertyName("fieldType")]
    public string? FieldType { get; set; }

    [XmlElement("required")]
    [JsonPropertyName("required")]
    public bool? Required { get; set; }
}
