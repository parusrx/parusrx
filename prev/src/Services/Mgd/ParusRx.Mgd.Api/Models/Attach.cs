// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents an attachment.
/// </summary>
public class Attach
{
    /// <summary>
    /// Gets or sets the document identifier of the attachment.
    /// </summary>
    public string DocumentId { get; set; }

    /// <summary>
    /// Gets or sets the document type code of the attachment.
    /// </summary>
    public string DocTypeCode { get; set; }

    /// <summary>
    /// Gets or sets the system code of the document.
    /// </summary>
    public string SystemCode { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the file.
    /// </summary>
    public string FileUUID { get; set; }

    /// <summary>
    /// Gets or sets the name of the attachment.
    /// </summary>
    public string AttachName { get; set; }

    /// <summary>
    /// Gets or sets the external identifier of the attachment.
    /// </summary>
    public string ExtId { get; set; }
}
