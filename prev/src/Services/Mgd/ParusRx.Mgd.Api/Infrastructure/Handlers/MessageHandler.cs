// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Handlers;

/// <summary>
/// The messahe handler.
/// </summary>
/// <seealso cref="IMessageHandler"/>.
public class MessageHandler : IMessageHandler
{
    private readonly IDocumentStore _store;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandler"/>.
    /// </summary>
    /// <param name="store">The document store.</param>
    public MessageHandler(IDocumentStore store)
    {
        _store = store;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(long companyId, long juridicalPersonId, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        await _store.UploadDocumentAsync(companyId, juridicalPersonId, message);
    }
}
