// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Data.Core;

/// <summary>
/// This class provides methods to create <see cref="DbConnection"/> instance of a concrete type.
/// </summary>
/// <typeparam name="TConnection">The concrete <see cref="DbConnection"/> implementation to instance.</typeparam>
public class ConnectionFactory<TConnection> : IConnectionFactory
    where TConnection : DbConnection, new()
{
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionFactory{TConnection}"/> class.
    /// </summary>
    /// <param name="connectionString">The connection string.</param>
    public ConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <inheritdoc />
    public Type DbConnectionType => typeof(TConnection);

    /// <inheritdoc />
    public DbConnection CreateConnection() => new TConnection { ConnectionString = _connectionString};
}