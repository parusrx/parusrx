// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Infrastructure.Stores;

/// <summary>
/// Default credentials store.
/// </summary>
/// <seealso cref="ICredentialsStore"/>
public class CredentialsStore : ICredentialsStore
{
    private readonly IConnection _connection;
    private readonly ILogger<CredentialsStore> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CredentialsStore"/> class.
    /// </summary>
    /// <param name="connection">The connection on database.</param>
    /// <param name="logger">The logger to use.</param>
    public CredentialsStore(IConnection connection, ILogger<CredentialsStore> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Credential>> GetAllCredentialsAsync()
    {
        try
        {
            using var connection = _connection.ConnectionFactory.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<Credential>("select * from parus.v_belmgd_credentials");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while obtaining credentials.");
            throw;
        }
    }
}
