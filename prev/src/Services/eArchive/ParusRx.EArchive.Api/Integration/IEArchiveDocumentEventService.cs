// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Integration;

/// <summary>
/// Defines methods for integration events with the BFT e-Archive.
/// </summary>
public interface IEArchiveDocumentEventService
{
    /// <summary>
    /// Store document.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task StoreAsync(IntegrationEvent @event);

    /// <summary>
    /// Read attachment.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task ReadAttachmentAsync(IntegrationEvent @event);
}
