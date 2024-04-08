// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents a files upload response.
/// </summary>
[XmlRoot("filesUploadResponse")]
public record FilesUploadResponse
{
    /// <summary>
    /// Gets or sets the result of the files upload.
    /// </summary>
    [XmlElement("result")]
    [JsonPropertyName("result")]
    public required bool Result { get; init; }

    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    [XmlArray("files")]
    [XmlArrayItem("file")]
    [JsonPropertyName("files")]
    public required FileItem[] Files { get; init; } = [];
}
