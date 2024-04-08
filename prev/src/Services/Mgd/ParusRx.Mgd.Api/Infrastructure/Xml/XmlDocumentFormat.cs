// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Xml;

/// <summary>
/// Specifies constants which define the XML format form used.
/// </summary>
public enum XmlDocumentFormat
{
    /// <summary>
    /// Without attachments.
    /// </summary>
    WithoutAttachments = 0,

    /// <summary>
    /// With attachments
    /// </summary>
    Attachments = 1,

    /// <summary>
    /// With attachments as link to BFT e-Archive.
    /// </summary>
    AttachmentsAsEArchive = 2
}
