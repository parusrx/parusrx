// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.


namespace ParusRx.DaData.Api.Models;

/// <summary>
/// Represents a request to DaData.ru.
/// </summary>
[XmlRoot(ElementName = "DaDataSuggestPartyRequest")]
public class DaDataSuggestPartyRequest
{
    /// <summary>
    /// Gets or sets of the authorization header.
    /// </summary>
    [XmlElement(ElementName = "Authorization")]
    public Authorization? Authorization { get; set; }

    /// <summary>
    /// Gets or sets of the request body.
    /// </summary>
    [XmlElement(ElementName = "SuggestPartyRequest")]
    public SuggestPartyRequest? SuggestPartyRequest { get; set; }
}
