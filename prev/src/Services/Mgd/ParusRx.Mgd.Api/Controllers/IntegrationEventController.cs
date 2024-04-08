// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Controllers;

/// <summary>
/// Represents an integration events controller.
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="IntegrationEventController"/>.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve services.</param>
    public IntegrationEventController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Gets the MGD message.
    /// </summary>
    /// <param name="event">The <see cref="IntegrationEvent"/>.</param>
    /// <returns><A <see cref="Task"/> that completes when processing has completed./returns>
    [HttpPost("mgdGetMessage")]
    [Topic(DAPR_PUBSUB_NAME, "MgdIntegrationEvent")]
    public async Task ReceiveIntegrationEventAsync(IntegrationEvent @event)
    {
        var handler = _serviceProvider.GetRequiredService<MgdIntegrationEventHandler>();
        await handler.HandleAsync(@event);
    }
}
