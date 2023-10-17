// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Dapr.Client;
using Microsoft.Extensions.Logging;

namespace ParusRx.EventBus.Dapr;

/// <summary>
/// Defines the implementation of the event bus that uses Dapr pub/sub.
/// </summary>
public class DaprEventBus : IEventBus
{
    private readonly DaprClient _dapr;
    private readonly ILogger<DaprEventBus> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DaprEventBus"/> class.
    /// </summary>
    /// <param name="dapr">The Dapr client.</param>
    /// <param name="logger">The logger.</param>
    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        _dapr = dapr;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IntegrationEvent
    {
        _logger.LogInformation("Publishing event {EventId} to topic {PubSubName}.{TopicName}", @event.Id, EventBusConstants.DaprPubSubName, topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await _dapr.PublishEventAsync(EventBusConstants.DaprPubSubName, topicName, @event, cancellationToken);
    }
}