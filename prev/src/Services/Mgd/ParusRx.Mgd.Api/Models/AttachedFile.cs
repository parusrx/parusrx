// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents an attached file.
/// </summary>
public class AttachedFile
{
    /// <summary>
    /// Gets or sets the file name.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    public byte[] Content { get; set; }
}
