// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Stores.Postgres;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add Parus RX store.
    /// </summary>
    /// <param name="services">The services available in the application.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddPostgresParusRxStores(this IServiceCollection services)
    {
        services.AddScoped<IParusRxStore, PostgresParusRxStore>();

        return services;
    }
}
