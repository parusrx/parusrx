// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.Extensions.DependencyInjection.Extensions;
using ParusRx.Data.Core;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up data access services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="optionsAction">An <see cref="Action{T}"/> to configure the provided <see cref="IConnection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IConnection>? optionsAction = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDataAccess(optionsAction == null ? null : (_, c) => optionsAction(c));

        return services;
    }

    /// <summary>
    /// Adds the data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="optionsAction">An <see cref="Action{T}"/> to configure the provided <see cref="IConnection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services, Action<IServiceProvider, IConnection>? optionsAction)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.TryAdd(
            new ServiceDescriptor(
                typeof(IConnection),
                c => ConnectionFactory(c, optionsAction),
                ServiceLifetime.Singleton
            )
        );

        return services;
    }

    private static Connection ConnectionFactory(IServiceProvider serviceProvider, Action<IServiceProvider, IConnection>? optionsAction)
    {
        var connection = new Connection();
        optionsAction?.Invoke(serviceProvider, connection);

        return connection;
    }
}
