// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Represents a helpful service that provides methods for working with messages.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Gets XML document from message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>Returns an XML document.</returns>
    /// <seealso cref="Message"/>
    /// <seealso cref="XmlDocument"/>
    XmlDocument GetXmlDocument(Message message);

    /// <summary>
    /// Gets description from message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns>Returns a description.</returns>
    /// <seealso cref="Message"/>
    string GetDescription(Message message);
}
