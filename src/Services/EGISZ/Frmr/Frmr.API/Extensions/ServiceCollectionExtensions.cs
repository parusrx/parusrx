﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Security.Policy;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FrmrSettings>(configuration.GetSection(FrmrSettings.Frmo));
        services.Configure<IdentitySettings>(configuration.GetSection(IdentitySettings.Identity));

        return services;
    }

    public static void AddAuthorizationHttpClient(this IServiceCollection services)
    {
        services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
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