// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Data;
using Dapper;
using Evolve.Data;
using Npgsql;

namespace ParusRX.Storage.Postgres;

/// <summary>
/// Provides methods allowing to manage the metadata stored in a PostgreSQL database.
/// </summary>
public class PostgresParusRxStore : IParusRxStore
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostgresParusRxStore"/>.
    /// </summary>
    /// <param name="connection">The <see cref="IConnection"/>.</param>
    public PostgresParusRxStore(IConnection connection)
    {
        Connection = connection;
    }

    /// <summary>
    /// The <see cref="IConnection"/>.
    /// </summary>
    public IConnection Connection { get; }

    /// <inheritdoc/>
    public async Task ErrorAsync(string id, string message)
    {
        using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        var param = new DynamicParameters();
        param.Add("sID", id);
        param.Add("sMESSAGE", message);

        await connection.QueryAsync<int>("PARUS.PKG_PRXMB$SET_ERROR", param, commandType: CommandType.StoredProcedure);

        await transaction.CommitAsync();
    }

    /// <inheritdoc/>
    public async Task<byte[]> ReadDataRequestAsync(string id)
    {
        using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        var param = new DynamicParameters();
        param.Add("sID", id);
        param.Add("bREQUEST", dbType: DbType.Binary, direction: ParameterDirection.Output);

        await connection.QueryAsync<int>("PARUS.PKG_PRXMB$GET_REQUEST", param, commandType: CommandType.StoredProcedure);

        return param.Get<byte[]>("bREQUEST");
    }

    /// <inheritdoc/>
    public async Task SaveDataResponseAsync(string id, byte[] data)
    {
        using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        var param = new DynamicParameters();
        param.Add("sID", id);
        param.Add("bRESPONSE", value: data, dbType: DbType.Binary, direction: ParameterDirection.Input);

        await connection.QueryAsync<int>("PARUS.PKG_PRXMB$SET_RESPONSE", param, commandType: CommandType.StoredProcedure);

        await transaction.CommitAsync();
    }
}
