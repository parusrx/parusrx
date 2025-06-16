// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Data;
using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;

using AuthorizationContextExt = (long company, long hrlinteraction, long juridicalPerson, string url, string clientId, string apiToken);

namespace ParusRx.HRlink.API.Services;

public sealed class OracleAutoReceiveApplicationGroupService(IConnection connection, IApplicationGroupService service, ILogger<OracleAutoReceiveApplicationGroupService> logger)
    : IAutoReceiveApplicationGroupService
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        foreach (AuthorizationContextExt context in await GetCredentials())
        {
            int pageSize = 50;
            int offset = 0;
            int totalCount = 0;
            DateTime lastReceiveTime = await GetLastReceiveTime(context.company, context.juridicalPerson);

            do
            {
                GetHrRegistryV2ApplicationGroupsRequest request = new()
                {
                    Authorization = new()
                    {
                        Url = context.url,
                        ClientId = context.clientId,
                        ApiToken = context.apiToken
                    },
                    Filter = new()
                    {
                        ApplicationCreatedDateFrom = lastReceiveTime,
                        ApplicationCreatedDateTo = DateTime.Now,
                        Limit = pageSize,
                        Offset = offset
                    }
                };

                GetHrRegistryV2ApplicationGroupsResponse? response = await service.GetApplicationGroupsAsync(request, cancellationToken);
                
                // Ensure the response is not null before calling Serialize
                if (response is not null)
                {
                    byte[]? data = XmlSerializerUtility.Serialize(response);
                    if (data is not null)
                    {
                        await ApplicationGroudHandlerAsync(context.company, data);
                    }
                    else
                    {
                        logger.LogWarning("Serialized data is null for company {Company}, juridical person {JuridicalPerson}", context.company, context.juridicalPerson);
                    }
                
                    totalCount = response.ApplicationGroups.Length;
                    logger.LogInformation("Total count of application groups: {TotalCount}", totalCount);
                }
                else
                {
                    logger.LogWarning("Received a null response for application groups.");
                }

                // Process each application group
                offset += totalCount;
            }
            while (totalCount >= pageSize && !cancellationToken.IsCancellationRequested);

            logger.LogInformation("Finished processing application groups for company {Company}, juridical person {JuridicalPerson}", context.company, context.juridicalPerson);
        }

        logger.LogInformation("Auto-receive application groups completed successfully.");
    }

    private async ValueTask<List<AuthorizationContextExt>> GetCredentials()
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = """
            select COMPANY, RN, JUR_PERS, URL, CLIENT_ID, API_TOKEN
              from PARUS.HRLINTERACTION
            """;

        List<AuthorizationContextExt> result = [];

        await conn.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (reader.Read())
        {
            result.Add((reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
        }

        return result;
    }

    private async ValueTask<DateTime> GetLastReceiveTime(long company, long juridicalPerson)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = """
            select max(APPLICATION_CREATED_DATE)
              from PARUS.HRLAPPREG
             where COMPANY = :nCOMPANY
               and JUR_PERS = :nJUR_PERS
            """;
        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("nJUR_PERS", OracleDbType.Int64) { Value = juridicalPerson });
        await conn.OpenAsync();
        object? result = await command.ExecuteScalarAsync();
        return result is DBNull || result is null ? new DateTime(1900,1,1,0,0,0) : Convert.ToDateTime(result);
    }

    private async Task ApplicationGroudHandlerAsync(long company, byte[] data)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();

        command.CommandText = "PARUS.PKG_HRLINK.GET_APP_REGISTRY_HANDLER";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("bRESPONSE", OracleDbType.Blob) { Value = data });

        await conn.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}
