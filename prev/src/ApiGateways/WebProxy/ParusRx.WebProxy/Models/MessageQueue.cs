// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.WebProxy.Models;

/// <summary>
/// Represents the message.
/// </summary>
public class MessageQueue
{
    /// <summary>
    /// Gets or sets the topic name.
    /// </summary>
    public string Topic { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }
}
