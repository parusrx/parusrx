// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Oracle.ManagedDataAccess.Client;

using ParusRx.Data.Core;

using AuthorizationContextExt = (long company, long hrlinteraction, string url, string clientId, string apiToken);

namespace ParusRx.HRlink.API.Services;

public sealed class OracleAutoReceiveApplicationGroupService(IConnection connection, ILogger<OracleAutoReceiveApplicationGroupService> logger)
    : IAutoReceiveApplicationGroupService
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        foreach(AuthorizationContextExt context in await GetCredentials()) 
        {
            try
            {
                using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
                using var command = conn.CreateCommand();
                command.CommandText = """
                    begin PARUS.PKG_HRLINK.GET_APPLICATION_REGISTRY(:nCOMPANY, :nHRLINTERACTION); end;
                    """;
                command.Parameters.Add("nCOMPANY", OracleDbType.Int64).Value = context.company;
                command.Parameters.Add("nHRLINTERACTION", OracleDbType.Int64).Value = context.hrlinteraction;
                await conn.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                logger.LogInformation("Received application group for company {Company} and HrlInteraction {HrlInteraction}", context.company, context.hrlinteraction);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error receiving application group for company {Company} and HrlInteraction {HrlInteraction}", context.company, context.hrlinteraction);
            }
        }
    }

    private async ValueTask<List<AuthorizationContextExt>> GetCredentials()
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
}
