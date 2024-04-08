// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Default implementation for <see cref="IMessageService"/>.
/// </summary>
public class MessageService : IMessageService
{
    /// <inheritdoc/>
    public string GetDescription(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        using var stream = new MemoryStream(Convert.FromBase64String(message.Data));
        using var xmlReader = new XmlTextReader(stream);

        var document = new XPathDocument(xmlReader);
        var navigator = document.CreateNavigator();
        var msg = navigator.SelectSingleNode("//MSG");

        return msg?.GetAttribute("DESCRIPTION", "");
    }

    /// <inheritdoc/>
    public XmlDocument GetXmlDocument(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        using var stream = new MemoryStream(Convert.FromBase64String(message.Data));
        using var xmlReader = new XmlTextReader(stream);

        var document = new XPathDocument(xmlReader);
        var navigator = document.CreateNavigator();

        var xml = navigator.SelectSingleNode("//BODY/text()");

        if (xml == null)
        {
            return null;
        }

        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml.Value);

        return xmlDocument;
    }
}
