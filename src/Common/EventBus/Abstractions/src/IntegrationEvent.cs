// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.EventBus;

/// <summary>
/// Represents an event that is published to the event bus.
/// </summary>
public record IntegrationEvent
{
    /// <summary>
    /// The unique identifier of the event.
    /// </summary>
    public Guid Id { get; private init; } = Guid.NewGuid();

    /// <summary>
    /// The time at which the event was created.
    /// </summary>
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
}