// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.Storage;
using ParusRx.Storage.Oracle;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up Parus RX store services in an <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add Parus RX store.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddOracleParusRxStores(this IServiceCollection services)
    {
        services.AddScoped<IParusRxStore, OracleParusRxStore>();

        return services;
    }
}