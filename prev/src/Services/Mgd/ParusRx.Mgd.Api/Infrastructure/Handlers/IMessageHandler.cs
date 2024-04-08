// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Handlers;

/// <summary>
/// Represents a message handler.
/// </summary>
public interface IMessageHandler
{
    /// <summary>
    /// Handle message.
    /// </summary>
    /// <param name="companyId">The company identifier.</param>
    /// <param name="juridicalPersonId">The juridical person identifier.</param>
    /// <param name="message">The <see cref="Message"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous handle operation.</returns>
    Task HandleAsync(long companyId, long juridicalPersonId, Message message);
}
