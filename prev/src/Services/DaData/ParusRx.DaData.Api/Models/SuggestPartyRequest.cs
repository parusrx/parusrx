// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.DaData.Api.Models;

/// <summary>
/// Represents a request body to DaData.ru.
/// </summary>
[XmlRoot(ElementName = "SuggestPartyRequest")]
public class SuggestPartyRequest
{
    /// <summary>
    /// Gets or sets of the query.
    /// </summary>
    /// <remarks>
    /// INN or OGRN.
    /// </remarks>
    [XmlElement(ElementName = "Query")]
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    /// <summary>
    /// Gets or sets of the count results.
    /// </summary>
    [XmlElement(ElementName = "Count")]
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets of the KPP.
    /// </summary>
    [XmlElement(ElementName = "Kpp")]
    [JsonPropertyName("kpp")]
    public string? Kpp { get; set; }

    /// <summary>
    /// Gets or sets of the branch type.
    /// </summary>
    [XmlElement(ElementName = "BranchType")]
    [JsonPropertyName("branch_type")]
    public BranchType? BranchType { get; set; }

    /// <summary>
    /// Gets or sets of the type.
    /// </summary>
    [XmlElement(ElementName = "Type")]
    [JsonPropertyName("type")]
    public Type? Type { get; set; }
}
