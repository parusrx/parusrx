// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Integration.Handlers;

/// <summary>
/// An implementation of <see cref="IIntegrationEventHandler"/> for read attachment.
/// </summary>
public class ReadAttachmentHandler : IIntegrationEventHandler
{
    private readonly IEArchiveDocumentEventService _service;
    private readonly ILogger<ReadAttachmentHandler> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="ReadAttachmentHandler"/>.
    /// </summary>
    /// <param name="service">The <see cref="IEArchiveDocumentEventService"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public ReadAttachmentHandler(IEArchiveDocumentEventService service, ILogger<ReadAttachmentHandler> logger)
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

            await _service.ReadAttachmentAsync(@event);
        }
    }
}
