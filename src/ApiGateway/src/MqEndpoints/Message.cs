// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.ApiGateway.MqEndpoints;

/// <summary>
/// Represents message.
/// </summary>
/// <param name="Topic">The topic.</param>
/// <param name="Payload">The payload.</param>
public sealed record Message(string Topic, string Payload);