// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Events;

/// <summary>
/// Represents an integration event.
/// </summary>
public record IntegrationEvent
{
    /// <summary>
    /// The unique identifier of the event.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the tenant.
    /// </summary>
    public string TenantId { get; init; } = null!;

    /// <summary>
    /// The creation date of the event.
    /// </summary>
    public DateTime CreationDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// The payload of the event.
    /// </summary>
    public object Payload { get; init; } = null!;
}