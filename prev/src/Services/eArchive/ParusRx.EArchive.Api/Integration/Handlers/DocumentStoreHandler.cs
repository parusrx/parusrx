// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.EventBus.Abstractions;

namespace ParusRx.EArchive.Api.Integration.Handlers;

/// <summary>
/// An implementation of <see cref="IIntegrationEventHandler"/> for store document.
/// </summary>
public class DocumentStoreHandler : IIntegrationEventHandler
{
    private readonly IEArchiveDocumentEventService _service;
    private readonly ILogger<DocumentStoreHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="DocumentStoreHandler"/>.
    /// </summary>
    /// <param name="service">The <see cref="IEArchiveDocumentEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public DocumentStoreHandler(IEArchiveDocumentEventService service, ILogger<DocumentStoreHandler> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(IntegrationEvent @event)
    {
        using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
        {
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

            await _service.StoreAsync(@event);
        }
    }
}
