// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Parus.Data.Abstractions;

namespace ParusRx.Stores.Oracle;

/// <summary>
/// Provides methods allowing to manage the metadata stored in an Oracle database.
/// </summary>
public class OracleParusRxStore : IParusRxStore
{
    private readonly ILogger<OracleParusRxStore> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="OracleParusRxStore"/>.
    /// </summary>
    /// <param name="connection">The <see cref="IConnection"/>.</param>
    /// <param name="logger">The logger to use.</param>
    public OracleParusRxStore(IConnection connection, ILogger<OracleParusRxStore> logger)
    {
        Connection = connection;
        _logger = logger;
    }

    /// <summary>
    /// The <see cref="IConnection"/>.
    /// </summary>
    public IConnection Connection { get; }

    /// <inheritdoc/>
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
                CommandText = "parus.pkg_prxmb.get_request"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sid";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramRequest = cmd.CreateParameter();
            paramRequest.OracleDbType = OracleDbType.Blob;
            paramRequest.Direction = ParameterDirection.Output;
            paramRequest.ParameterName = "brequest";
            cmd.Parameters.Add(paramRequest);

            cmd.ExecuteNonQuery();

            return ((OracleBlob)paramRequest.Value).Value;
        }
        catch (Exception ex)
        {
            _logger.LogError("Request read data error.", ex);
        }

        return Array.Empty<byte>();
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
                CommandText = "parus.pkg_prxmb.set_response"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sid";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramResponse = cmd.CreateParameter();
            paramResponse.OracleDbType = OracleDbType.Blob;
            paramResponse.Direction = ParameterDirection.Input;
            paramResponse.ParameterName = "bresponse";
            paramResponse.Value = data;
            cmd.Parameters.Add(paramResponse);

            cmd.ExecuteNonQuery();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error saving response data.", ex);
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
                CommandText = "parus.pkg_prxmb.set_error"
            };

            var paramId = cmd.CreateParameter();
            paramId.OracleDbType = OracleDbType.Varchar2;
            paramId.Direction = ParameterDirection.Input;
            paramId.ParameterName = "sid";
            paramId.Value = id;
            cmd.Parameters.Add(paramId);

            var paramNote = cmd.CreateParameter();
            paramNote.OracleDbType = OracleDbType.Varchar2;
            paramNote.Direction = ParameterDirection.Input;
            paramNote.ParameterName = "snote";
            paramNote.Value = message;
            cmd.Parameters.Add(paramNote);

            cmd.ExecuteNonQuery();

            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Failed to send error.", ex);
        }
    }
}
