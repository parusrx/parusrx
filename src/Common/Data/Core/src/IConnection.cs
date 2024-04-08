﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Data.Core;

/// <summary>
/// A class implementing this interface represents a connection to a data source.
/// </summary>
public interface IConnection
{
    /// <summary>
    /// Gets or sets the <see cref="IConnectionFactory"/> used to create connections.
    /// </summary>
    IConnectionFactory ConnectionFactory { get; set; }
}
