// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using ParusRx.Data.Core;

namespace ParusRx.Storage.Oracle;

/// <summary>
/// Provides methods allowing to manage the metadata in an Oracle database.
/// </summary>
internal sealed class OracleParusRxStore : IParusRxStore
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OracleParusRxStore"/> class.
    /// </summary>
    /// <param name="connection">Connection to database.</param>
    public OracleParusRxStore(IConnection connection)
    {
        Connection = connection;
    }

    /// <summary>
    /// The <see cref="IConnection"/>.
    /// </summary>
    public IConnection Connection { get; }

    /// <inheritdoc />
    public async Task<byte[]> ReadDataRequestAsync(string id)
    {
        try
        {
            using var connection = (OracleConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            var cmd = new OracleCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PARUS.PKG_PRXMB.GET_REQUEST"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sID";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramRequest = cmd.CreateParameter();
            paramRequest.OracleDbType = OracleDbType.Blob;
            paramRequest.Direction = ParameterDirection.Output;
            paramRequest.ParameterName = "bREQUEST";
            cmd.Parameters.Add(paramRequest);

            cmd.ExecuteNonQuery();

            return ((OracleBlob)paramRequest.Value).Value;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to read request with id {id}", ex);
        }
    }

    /// <inheritdoc/>
    public async Task SaveDataResponseAsync(string id, byte[] data)
    {
        try
        {
            using var connection = (OracleConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();
            var cmd = new OracleCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PARUS.PKG_PRXMB.SET_RESPONSE"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sID";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramResponse = cmd.CreateParameter();
            paramResponse.OracleDbType = OracleDbType.Blob;
            paramResponse.Direction = ParameterDirection.Input;
            paramResponse.ParameterName = "bRESPONSE";
            paramResponse.Value = data;
            cmd.Parameters.Add(paramResponse);

            cmd.ExecuteNonQuery();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to save response for request with id {id}", ex);
        }
    }

    /// <inheritdoc/>
    public async Task ErrorAsync(string id, string message)
    {
        try
        {
            using var connection = (OracleConnection)Connection.ConnectionFactory.CreateConnection();
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();
            var cmd = new OracleCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PARUS.PKG_PRXMB.SET_ERROR"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sID";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramNote = cmd.CreateParameter();
            paramNote.OracleDbType = OracleDbType.Varchar2;
            paramNote.Direction = ParameterDirection.Input;
            paramNote.ParameterName = "sNOTE";
            paramNote.Value = message;
            cmd.Parameters.Add(paramNote);

            cmd.ExecuteNonQuery();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to set error for request with id {id}", ex);
        }
    }
}