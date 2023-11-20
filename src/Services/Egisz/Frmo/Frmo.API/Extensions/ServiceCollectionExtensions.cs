// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIntegrationEventHandlers(this IServiceCollection services)
    {
        services.AddTransient<ListPagedOrganizationIntegrationEventHandler>();
        services.AddTransient<GetByOidOrganizationIntegrationEventHandler>();
        services.AddTransient<UpdateOrganizationIntegrationEventHandler>();
        services.AddTransient<DeleteOrganizationIntegrationEventHandler>();

        services.AddTransient<GetStaffIntegrationEventHandler>();
        services.AddTransient<GetByEntityStaffIntegrationEventHandler>();
        services.AddTransient<CreateStaffIntegrationEventHandler>();
        services.AddTransient<UpdateStaffIntegrationEventHandler>();
        services.AddTransient<DeleteStaffIntegrationEventHandler>();

        services.AddTransient<GetByOidDepartmentIntegrationEventHandler>();
        services.AddTransient<ListPagedDepartmentIntegrationEventHandler>();
        services.AddTransient<CreateDepartmentIntegrationEventHandler>();
        services.AddTransient<UpdateDepartmentIntegrationEventHandler>();
        services.AddTransient<DeleteDepartmentIntegrationEventHandler>();

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
