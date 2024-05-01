// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services)
    {
        services.AddTransient<CreatePublishEventsRequestIntegrationEventHandler>();

        return services;
    }

    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string provider = configuration["Database:Provider"] ?? string.Empty;
        string connectionString = configuration["Database:ConnectionString"] ?? string.Empty;
        switch (provider)
        {
            case "Oracle":
                services
                    .AddDataAccess(options => options.UseOracle(connectionString))
                    .AddOracleParusRxStores();
                break;
            case "Postgres":
                services
                    .AddDataAccess(options => options.UseNpgsql(connectionString))
                    .AddPostgresParusRxStore();
                break;
            default:
                throw new NotSupportedException($"Database provider \"{provider}\" is not supported.");
        }

        return services;
    }
}
