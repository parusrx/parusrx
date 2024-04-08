// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus;

/// <summary>
/// Provides default implementation on Dapr.
/// </summary>
public class DaprEventBus : IEventBus
{
    private const string DAPR_PUBSUB_NAME = "pubsub";

    private readonly DaprClient _dapr;
    private readonly ILogger<DaprEventBus> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="DaprEventBus"/>.
    /// </summary>
    /// <param name="dapr">The Dapr client.</param>
    /// <param name="logger">The logger.</param>
    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        _dapr = dapr;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event)
        where TIntegrationEvent : IntegrationEvent
    {
        _logger.LogInformation("Publishing event {@Event} to {PubsubName}.{TopicName}", @event, DAPR_PUBSUB_NAME, topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await _dapr.PublishEventAsync(DAPR_PUBSUB_NAME, topicName, (dynamic)@event);
    }
}
