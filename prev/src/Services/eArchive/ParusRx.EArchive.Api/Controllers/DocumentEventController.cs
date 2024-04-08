// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EArchive.Api.Controllers;

/// <summary>
/// This controller implements document logic.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class DocumentEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="DocumentEventController"/> class.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve services.</param>
    public DocumentEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Retrieving a document attachment file.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /readAttachment
    ///     {
    ///         "id": "1731a6d3-f5ff-4702-b34e-c27cd91942a8",
    ///         "creationDate": "2021-07-26T00:00:00",
    ///         "metadata": "1112772"
    ///     }
    ///     
    /// </remarks>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("readAttachment")]
    [Topic(DAPR_PUBSUB_NAME, "BFTeArchiveReadAttachmentIntegrationEvent")]
    public async Task ReadAttachmentIntegrationEventAsync(IntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<ReadAttachmentHandler>();
        await handler.HandleAsync(@event);
    }

    /// <summary>
    /// Store document to archive.
    /// </summary>
    /// Sample request:
    ///
    ///     POST /store
    ///     {
    ///         "id": "b797421f-0c92-441a-8292-a14aaed112ca",
    ///         "creationDate": "2021-07-26T00:00:00",
    ///         "metadata": "11199234"
    ///     }
    ///     
    /// </remarks>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns>A <see cref="Task"/> that completes when processing has completed.</returns>
    [HttpPost("store")]
    [Topic(DAPR_PUBSUB_NAME, "BFTeArchiveDocumentStoreIntegrationEvent")]
    public async Task DocumentStoreIntegrationEventAsync(IntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<DocumentStoreHandler>();
        await handler.HandleAsync(@event);
    }
}
