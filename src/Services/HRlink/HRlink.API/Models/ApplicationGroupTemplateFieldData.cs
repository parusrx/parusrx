// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationGroupTemplateFieldData
{
    [XmlArray("userFields")]
    [XmlArrayItem("userFieldsItem")]
    [JsonPropertyName("userFields")]
    public ApplicationGroupTemplateField[]? UserFields { get; init; }

    [XmlArray("systemFields")]
    [XmlArrayItem("systemFieldsItem")]
    [JsonPropertyName("systemFields")]
    public ApplicationGroupTemplateField[]? SystemFields { get; init; }
}
