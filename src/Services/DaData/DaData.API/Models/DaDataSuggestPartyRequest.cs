// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.DaData.API.Models;

/// <summary>
/// Represents a request body for the DaData.ru.
/// </summary>
public record DaDataSuggestPartyRequest
{
    /// <summary>
    /// Gets or sets the authorization header.
    /// </summary>
    [XmlElement("Authorization")]
    public required Authorization Authorization { get; init; }

    /// <summary>
    /// Gets or sets the suggest party request.
    /// </summary>
    [XmlElement("SuggestPartyRequest")]
    public required SuggestPartyRequest SuggestPartyRequest { get; init; }
}
