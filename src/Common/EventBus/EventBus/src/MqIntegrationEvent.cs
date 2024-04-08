// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.EventBus;

/// <summary>
/// Represents an integration event with a message queue body.
/// </summary>
/// <param name="Body">The message queue body.</param>
public record MqIntegrationEvent(string Body) : IntegrationEvent;