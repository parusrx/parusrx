// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Gateway.FunctionalTests;

/// <summary>
/// Fake event bus.
/// </summary>
public class FakeEventBus : IEventBus
{
    /// <inheritdoc/>
    public Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IntegrationEvent
        => Task.CompletedTask;
}