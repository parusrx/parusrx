// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Events;

/// <summary>
/// Represents an integration event with a tenant identifier.
/// </summary>
/// <param name="TenantId">The unique identifier of the tenant.</param>
public record MultiTenantIntegrationEvent(string TenantId) : IntegrationEvent;
