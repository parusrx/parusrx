﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.Storage;
using ParusRx.Storage.PostgreSQL;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up Parus RX store services in an <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add Parus RX store.
    /// </summary>
    /// <param name="services">The services available in the application.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddPostgresParusRxStore(this IServiceCollection services)
    {
        services.AddScoped<IParusRxStore, PostgresParusRxStore>();

        return services;
    }
}