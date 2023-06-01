// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Events;

/// <summary>
/// Represents an integration event with a message queue body.
/// </summary>
/// <param name="Body">The message queue body.</param>
public record MqIntegrationEvent(string Body) : IntegrationEvent;
