// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;

namespace ParusRx.Data.Oracle;

/// <summary>
/// Extension methods for <see cref="IConnection"/> to configure Oracle.
/// </summary>
public static class OracleDataAccessExtensions
{
    /// <summary>
    /// Configures the <see cref="IConnection"/> to use Oracle.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="connectionString">The connection string.</param>
    /// <returns>The <see cref="IConnection"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="connection"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException">The <paramref name="connectionString"/> is <c>null</c>.</exception>
    public static IConnection UseOracle(this IConnection connection, string connectionString)
    {
        ArgumentNullException.ThrowIfNull(connection, nameof(connection));
        ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

        connection.ConnectionFactory = new ConnectionFactory<OracleConnection>(connectionString);

        return connection;
    }
}