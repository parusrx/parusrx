// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Data;
using Oracle.ManagedDataAccess.Client;
using ParusRx.Data.Core;
using ParusRx.HRlink.API.Helpers;

using AuthorizationContextExt = (long company, long juridicalPerson, string url, string clientId, string apiToken);

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Represents an auto-updater document status service.
/// </summary>
/// <param name="connection">The connection.</param>
/// <param name="httpClient">The HTTP client.</param>
/// <param name="logger">The logger.</param>
public sealed class OracleAutoUpdateDocumentStatusService(IConnection connection, IHttpClientFactory httpClientFactory, ILogger<OracleAutoUpdateDocumentStatusService> logger) : IAutoUpdateDocumentStatusService
{
    public async Task ExecuteAsync(CancellationToken cancellationToken = default)
    {
        foreach (var (company, hrlinkId, url, clientId, apiToken) in await GetCredentials())
        {
            int pageSize = 50;
            List<string> documentIds = await GetDocumentIds(hrlinkId);

            for (int i = 0; i < documentIds.Count; i += pageSize)
            {
                DocumentGroupRegistryFilter filter = new()
                {
                    DocumentExternalIds = [.. (documentIds.Skip(i).Take(pageSize).ToList())]
                };

                using HttpClient httpClient = httpClientFactory.CreateClient();
                string uri = $"{url}/api/v1/clients/{clientId}/documentGroups/getHrRegistry";
                httpClient.DefaultRequestHeaders.Add("User-Api-Token", apiToken);

                using var response = await httpClient.PostAsJsonAsync(uri, filter, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var getHrRegistryResponse = await response.Content.ReadFromJsonAsync<GetHrRegistryResponse>(cancellationToken);
                    if (getHrRegistryResponse is not null && getHrRegistryResponse.Result)
                    {
                        foreach (var documentGroup in getHrRegistryResponse.DocumentGroups)
                        {
                            foreach (var document in documentGroup.Documents)
                            {
                                int status = CalculateDocumentStatusHelper.GetStatus(document);
                                if (long.TryParse(document.ExternalId, out long documentId))
                                {
                                    await UpdateStatusAsync(document, company, status);
                                    logger.LogInformation("Document {DocumentId} status updated to {Status}", documentId, status);
                                }

                                List<DocumentSigner> signers = [];
                                if (document.HeadManager is not null)
                                {
                                    signers.Add(document.HeadManager);
                                }

                                if (document.Employees is not null)
                                {
                                    signers.AddRange(document.Employees);
                                }

                                if (document.Participants is not null)
                                {
                                    signers.AddRange(document.Participants);
                                }

                                foreach (var signer in signers)
                                {
                                    await UpsertSignersAsync(signer, long.Parse(document.ExternalId ?? "-1"), company);
                                    logger.LogInformation("Signer {SignerId} updated", signer.ExternalId);
                                }
                            }
                        }
                    }
                }
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

    private async ValueTask<List<string>> GetDocumentIds(long hrlinkId)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = """
            select RN
              from PARUS.HRLDOCS
             where STATUS in (1,2)
               and PRN in (select RN from PARUS.HRLPACKS where HRLINTERACTION = :hrlinkId)
            """;

        command.Parameters.Add(new OracleParameter("hrlinkId", OracleDbType.Int64) { Value = hrlinkId });

        List<string> result = [];

        await conn.OpenAsync();
        using var reader = await command.ExecuteReaderAsync();
        while (reader.Read())
        {
            result.Add(reader.GetInt64(0).ToString());
        }

        return result;
    }

    private async Task UpdateStatusAsync(Document document, long company, int status)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = "PARUS.P_HRLDOCS_BSET_STATUS";
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new OracleParameter("nRN", OracleDbType.Int64) { Value = long.Parse(document.ExternalId ?? "-1") });
        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("sID_DOC_HRL", OracleDbType.Varchar2) { Value = document.Id });
        command.Parameters.Add(new OracleParameter("nSTATUS", OracleDbType.Int32) { Value = status });

        await conn.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }

    private async Task UpsertSignersAsync(DocumentSigner signer, long documentId, long company)
    {
        using var conn = (OracleConnection)connection.ConnectionFactory.CreateConnection();
        using var command = conn.CreateCommand();
        command.CommandText = "PARUS.P_HRLDOCSSH_UPSERT";
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new OracleParameter("nCOMPANY", OracleDbType.Int64) { Value = company });
        command.Parameters.Add(new OracleParameter("nPRN", OracleDbType.Int64) { Value = documentId });
        command.Parameters.Add(new OracleParameter("nSIGNORDER", OracleDbType.Int64) { Value = signer.SigningOrder + 1 });
        command.Parameters.Add(new OracleParameter("sSIGNTYPE", OracleDbType.Varchar2) { Value = signer.SignerType });
        command.Parameters.Add(new OracleParameter("nCLNPSPFM", OracleDbType.Int64) { Value = long.Parse(signer.ExternalId ?? "-1") });
        command.Parameters.Add(new OracleParameter("dSIGNAVDATE", OracleDbType.Date) { Value = signer.SigningAvailabilityDate });
        command.Parameters.Add(new OracleParameter("dSEENDATE", OracleDbType.Date) { Value = signer.SeenDate });
        command.Parameters.Add(new OracleParameter("dSIGNEDDATE", OracleDbType.Date) { Value = signer.SignedDate });
        command.Parameters.Add(new OracleParameter("dREJECTEDDATE", OracleDbType.Date) { Value = signer.RejectedDate });
        command.Parameters.Add(new OracleParameter("sREJECTCOMMENT", OracleDbType.Varchar2) { Value = signer.RejectionComment });
        command.Parameters.Add(new OracleParameter("nRN", OracleDbType.Int64) { Direction = ParameterDirection.Output });

        await conn.OpenAsync();
        await command.ExecuteNonQueryAsync();
    }
}