// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents an application type response.
/// </summary>
[XmlRoot("applicationTypeResponse")]
public record ApplicationTypeResponse
{
    /// <summary>
    /// The result of the files upload.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// The list of application types.
    /// </summary>
    [XmlArray("applicationTypes")]
    [XmlArrayItem("applicationTypesItem")]
    [JsonPropertyName("applicationTypes")]
    public required ApplicationType[] ApplicationTypes { get; init; } = [];
}

