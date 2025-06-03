// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a message for internationalization (i18n).
/// </summary>
public record I18nMessage
{
    /// <summary>
    /// Gets or sets the key of the message.
    /// </summary>
    [XmlElement("key")]
    [JsonPropertyName("key")]
    public string? Key { get; init; }
}