// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Data;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Parus.Data.Abstractions;

namespace ParusRx.Stores.Postgres;

/// <summary>
/// Provides methods allowing to manage the metadata stored in a PostgreSQL database.
/// </summary>
public class PostgresParusRxStore : IParusRxStore
{
    /// <summary>
    /// Initializes a new instance of <see cref="PostgresParusRxStore"/>.
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
        param.Add("sid", id);
        param.Add("smessage", message);

        await connection.QueryAsync<int>("parus.pkg_prxmb$set_error", param, commandType: CommandType.StoredProcedure);

        await transaction.CommitAsync();
    }

    /// <inheritdoc/>
    public async Task<byte[]> ReadDataRequestAsync(string id)
    {
        using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        var param = new DynamicParameters();
        param.Add("sid", id);
        param.Add("brequest", dbType: DbType.Binary, direction: ParameterDirection.Output);

        await connection.QueryAsync<int>("parus.pkg_prxmb$get_request", param, commandType: CommandType.StoredProcedure);

        return param.Get<byte[]>("brequest");
    }

    /// <inheritdoc/>
    public async Task SaveDataResponseAsync(string id, byte[] data)
    {
        using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
        await connection.OpenAsync();

        using var transaction = connection.BeginTransaction();

        var param = new DynamicParameters();
        param.Add("sid", id);
        param.Add("bresponse", value: data, dbType: DbType.Binary, direction: ParameterDirection.Input);

        await connection.QueryAsync<int>("parus.pkg_prxmb$set_response", param, commandType: CommandType.StoredProcedure);

        await transaction.CommitAsync();
    }
}
