﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
