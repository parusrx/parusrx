// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Data;
using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;

using AuthorizationContextExt = (long company, long hrlinteraction, string url, string clientId, string apiToken);

namespace ParusRx.HRlink.API.Services;

public sealed class OracleAutoReceiveRouteTemplateService(IConnection connection, IRouteTemplateService service, ILogger<OracleAutoReceiveRouteTemplateService> logger)
    : IAutoReceiveRouteTemplateService
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        foreach (var context in await GetCredentialsAsync())
        {
            var request = new RouteTemplateRequest
            {
                Authorization = new()
                {
                    Url = context.url,
                    ClientId = context.clientId,
                    ApiToken = context.apiToken
                }
            };
            RouteTemplateResponse? response = await service.GetRouteTemplatesAsync(request, cancellationToken);
            if (response != null)
            {
                byte[]? data = XmlSerializerUtility.Serialize(response);
                if (data != null)
                {
                    await RouteTemplateHandlerAsync(context.company, context.hrlinteraction, data);
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
    private async ValueTask<List<AuthorizationContextExt>> GetCredentialsAsync()
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = """
            select COMPANY, RN, URL, CLIENT_ID, API_TOKEN
              from PARUS.HRLINTERACTION
            """;

        List<AuthorizationContextExt> result = [];

        await conn.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (reader.Read())
        {
            result.Add((reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
        }

        return result;
    }

    private async ValueTask RouteTemplateHandlerAsync(long company, long hrlinteraction, byte[] data)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = "PARUS.PKG_HRLINK.GET_ROUTETEMPLATES_HANDLER";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("nHRLINTERACTION", OracleDbType.Int64) { Value = hrlinteraction });
        command.Parameters.Add(new OracleParameter("bRESPONSE", OracleDbType.Blob) { Value = data });

        await conn.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}
