// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
