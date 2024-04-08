// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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