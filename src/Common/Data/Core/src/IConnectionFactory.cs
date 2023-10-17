// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Data.Core;

/// <summary>
/// Represents a factory for creating database connections.
/// </summary>
public interface IConnectionFactory
{
    /// <summary>
    /// Creates a new database connection.
    /// </summary>
    DbConnection CreateConnection();

    /// <summary>
    /// Gets the type of the database connection.
    /// </summary>
    Type DbConnectionType { get; }
}
