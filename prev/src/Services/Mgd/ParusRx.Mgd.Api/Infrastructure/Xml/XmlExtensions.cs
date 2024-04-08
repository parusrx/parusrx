// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Xml;

/// <summary>
/// Extensions methods fot <see cref="XmlDocument"/>.
/// </summary>
public static class XmlExtensions
{
    /// <summary>
    /// Encodes into an array of bytes the XML document.
    /// </summary>
    /// <param name="document">The XML document.</param>
    /// <param name="encoding">The used encoding.</param>
    /// <returns>A byte array containing the XML document.</returns>
    public static Task<byte[]> GetBytesAsync(this XmlDocument document, Encoding encoding) =>
        Task.FromResult(encoding.GetBytes(document.OuterXml));

    /// <summary>
    /// Gets attached files.
    /// </summary>
    /// <param name="document">The XML document.</param>
    /// <param name="encoding">The used encoding.</param>
    /// <returns>Returns attached files; otherwise the empty collection.</returns>
    public static Task<IEnumerable<AttachedFile>> GetAttachedFilesAsync(this XmlDocument document, Encoding encoding)
    {
        var files = new List<AttachedFile>();
        var navigator = document.CreateNavigator();

        var attachNodes = navigator.Select("//ATTACH/ATTACH");

        while (attachNodes.MoveNext())
        {
            var currentNavigator = attachNodes.Current;
            if (currentNavigator != null)
            {
                files.Add(new AttachedFile
                {
                    FileName = currentNavigator.GetAttribute("ATTACH_NAME", ""),
                    Content = Convert.FromBase64String(currentNavigator.Value)
                });
            }
        }

        return Task.FromResult<IEnumerable<AttachedFile>>(files);
    }

    /// <summary>
    /// Gets attachments.
    /// </summary>
    /// <param name="document">The XML document.</param>
    /// <param name="encoding">The used encoding.</param>
    /// <returns>Returns attachments; otherwise the empty collection.</returns>
    public static Task<IEnumerable<Attach>> GetAttachesAsync(this XmlDocument document, Encoding encoding)
    {
        var attaches = new List<Attach>();
        var navigator = document.CreateNavigator();

        var attachNodes = navigator.Select("//ATTACH/ATTACH");

        while (attachNodes.MoveNext())
        {
            var currentNavigator = attachNodes.Current;
            if (currentNavigator != null)
            {
                attaches.Add(new Attach
                {
                    DocumentId = currentNavigator.GetAttribute("DOCUMENT_ID", ""),
                    DocTypeCode = currentNavigator.GetAttribute("DOC_TYPE_CODE", ""),
                    SystemCode = currentNavigator.GetAttribute("SYSTEM_CODE", ""),
                    FileUUID = currentNavigator.GetAttribute("FILE_UUID", ""),
                    AttachName = currentNavigator.GetAttribute("ATTACH_NAME", ""),
                    ExtId = currentNavigator.GetAttribute("ID", "")
                });
            }
        }

        return Task.FromResult<IEnumerable<Attach>>(attaches);
    }

    /// <summary>
    /// Gets the XML format.
    /// </summary>
    /// <param name="document">The XML document.</param>
    /// <returns>Returns the used format.</returns>
    public static XmlDocumentFormat GetXmlDocumentFormat(this XmlDocument document)
    {
        var navigator = document.CreateNavigator();

        if (navigator.Select("//ATTACH/ATTACH[@ATTACH_NAME and @FILE_UUID]").Count > 0)
        {
            return XmlDocumentFormat.AttachmentsAsEArchive;
        }
        else if (navigator.Select("//ATTACH/ATTACH[@ATTACH_NAME]").Count > 0)
        {
            return XmlDocumentFormat.Attachments;
        }

        return XmlDocumentFormat.WithoutAttachments;
    }
}
