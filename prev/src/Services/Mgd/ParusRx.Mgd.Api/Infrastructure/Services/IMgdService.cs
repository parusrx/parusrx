// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Services;

/// <summary>
/// Represents an interop service with MGD.
/// </summary>
public interface IMgdService
{
    /// <summary>
    /// Gets a new message.
    /// </summary>
    /// <param name="token">The access token.</param>
    /// <returns>The message.</returns>
    /// <seealso cref="Message"/>
    Task<Message> GetMessageAsync(string token);

    /// <summary>
    /// Send ticket.
    /// </summary>
    /// <param name="ticket">The ticketm</param>
    /// <param name="token">The access token.</param>
    /// <returns>The response as a <see cref="MgdResponse"/>.</returns>
    Task<MgdResponse> SendTicketAsync(Ticket ticket, string token);
}
