// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Npgsql;
using ParusRx.Data.Core;

namespace ParusRx.Storage.PostgreSQL;

/// <summary>
/// Provides methods allowing to manage the metadata stored in a PostgreSQL database.
/// </summary>
internal sealed class PostgresParusRxStore : IParusRxStore
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
        try
        {
            using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            using var command = new NpgsqlCommand("SELECT parus.pkg_prxmb$set_error(@sid, @snote)", connection, transaction);
            command.Parameters.AddWithValue("sid", id);
            command.Parameters.AddWithValue("snote", message);

            await command.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException($"Failed to set error for request with id {id}", ex);
        }
    }

    /// <inheritdoc/>
    public async Task<byte[]> ReadDataRequestAsync(string id)
    {
        try
        {
            using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var command = new NpgsqlCommand("SELECT parus.pkg_prxmb$get_request(@sid)", connection);
            command.Parameters.AddWithValue("sid", id);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                return reader.GetFieldValue<byte[]>(0);
            }

            return [];
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException($"Failed to read request with id {id}", ex);
        }
    }

    /// <inheritdoc/>
    public async Task SaveDataResponseAsync(string id, byte[] data)
    {
        try
        {
            using var connection = (NpgsqlConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            using var command = new NpgsqlCommand("SELECT parus.pkg_prxmb$set_response(@sid, @bresponse)", connection);
            command.Parameters.AddWithValue("sid", id);
            command.Parameters.AddWithValue("bresponse", data);

            await command.ExecuteNonQueryAsync();

            await transaction.CommitAsync();
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException($"Failed to save response for request with id {id}", ex);
        }
    }
}