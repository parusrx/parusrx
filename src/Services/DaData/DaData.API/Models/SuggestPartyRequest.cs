// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Models;

/// <summary>
/// Represents a request body for the DaData.ru.
/// </summary>
[XmlRoot("SuggestPartyRequest")]
public record SuggestPartyRequest
{
    /// <summary>
    /// Gets or sets the query.
    /// </summary>
    [XmlElement("Query")]
    [JsonPropertyName("query")]
    public string? Query { get; init; }

    /// <summary>
    /// Gets or sets the count results.
    /// </summary>
    [XmlElement("Count")]
    [JsonPropertyName("count")]
    public int Count { get; init; }

    /// <summary>
    /// Gets or sets the KPP.
    /// </summary>
    [XmlElement("KPP")]
    [JsonPropertyName("kpp")]
    public string? Kpp { get; init; }

    /// <summary>
    /// Gets or sets the branch type.
    /// </summary>
    [XmlElement("BranchType")]
    [JsonPropertyName("branch_type")]
    public BranchType? BranchType { get; init; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [XmlElement("Type")]
    [JsonPropertyName("type")]
    public Type? Type { get; init; }
}
