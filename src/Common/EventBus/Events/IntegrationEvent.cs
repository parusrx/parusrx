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
    public Guid Id { get; private init; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the tenant.
    /// </summary>
    //public required string TenantId { get; init; }

    /// <summary>
    /// The creation date of the event.
    /// </summary>
    public DateTime CreationDate { get; private init; } = DateTime.UtcNow;

    /// <summary>
    /// The payload of the event.
    /// </summary>
    public required string Payload { get; init; }
}

/// <summary>
/// Represents an integration event with a tenant identifier.
/// </summary>
public record MultitenantIntegrationEvent : IntegrationEvent
{
    /// <summary>
    /// The unique identifier of the tenant.
    /// </summary>
    public required string TenantId { get; init; }
}