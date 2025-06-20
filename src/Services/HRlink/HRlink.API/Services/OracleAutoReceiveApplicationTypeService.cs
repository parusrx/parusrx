// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Data;
using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;

namespace ParusRx.HRlink.API.Services;

using AuthorizationContext = (long company, long hrlinteraction, string url, string clientId, string apiToken);

public sealed class OracleAutoReceiveApplicationTypeService(IConnection connection, IApplicationTypeService service, ILogger<OracleAutoReceiveApplicationTypeService> logger)
    : IAutoReceiveApplicationTypeService
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        foreach (AuthorizationContext context in await GetCredentialsAsync())
        {
            ApplicationTypeRequest request = new()
            {
                Url = context.url,
                ApiToken = context.apiToken,
            };

            var response = await service.GetApplicationTypesAsync(request, cancellationToken);
            if (response != null)
            {
                byte[]? data = XmlSerializerUtility.Serialize(response);
                if (data != null)
                {
                    await ApplicationTypeHandlerAsync(context.company, context.hrlinteraction, data);
                }
                else
                {
                    logger.LogWarning("Serialized data is null for Company '{Company}', HRLInteraction '{HrlInteraction}'", context.company, context.hrlinteraction);
                }
            }
            else
            {
                logger.LogWarning("Response is null for Company '{Company}', HRLInteraction '{HrlInteraction}'", context.company, context.hrlinteraction);
            }
        }
    }

    private async ValueTask<List<AuthorizationContext>> GetCredentialsAsync()
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = """
        select COMPANY, RN, URL, CLIENT_ID, API_TOKEN
            from PARUS.HRLINTERACTION
        """;

        List<AuthorizationContext> result = [];

        await conn.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (reader.Read())
        {
            result.Add((reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
        }

        return result;
    }

    private async ValueTask ApplicationTypeHandlerAsync(long company, long hrlinteraction, byte[] data)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();

        using var command = conn.CreateCommand();
        command.CommandText = "PARUS.PKG_HRLINK.GET_APPLICATION_TYPES_HANDLER";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("nHRLINTERACTION", OracleDbType.Int64) { Value = hrlinteraction });
        command.Parameters.Add(new OracleParameter("bRESPONSE", OracleDbType.Blob) { Value = data });

        await conn.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}
