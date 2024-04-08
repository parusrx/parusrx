// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

/// <summary>
/// Represents the files upload request.
/// </summary>
[XmlRoot("filesUploadRequest")]
public record FilesUploadRequest
{
    /// <summary>
    /// Gets or sets the authorization context.
    /// </summary>
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    [XmlArray("files")]
    [XmlArrayItem("file")]
    public required FileDto[] Files { get; init; } = [];
}

/// <summary>
/// Represents the file DTO.
/// </summary>
[XmlRoot("file")]
public record FileDto
{
    /// <summary>
    /// Gets or sets the file name.
    /// </summary>
    [XmlElement("fileName")]
    public required string FileName { get; init; }

    /// <summary>
    /// Gets or sets the file content.
    /// </summary>
    [XmlElement("content")]
    public required string Content { get; init; }
}
