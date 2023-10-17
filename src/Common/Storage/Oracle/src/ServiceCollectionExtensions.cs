// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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