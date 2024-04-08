// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.EventBus;
using ParusRx.EventBus.Dapr;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up Dapr Event Bus related services in an <see cref="IServiceCollection" />.
/// </summary>
public static class DaprEventBusServiceCollectionExtensions
{
    /// <summary>
    /// Adds Dapr Event Bus related services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>An <see cref="IServiceCollection"/> that can be used to further configure the Dapr Event Bus services.</returns>
    public static IServiceCollection AddDaprEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IEventBus, DaprEventBus>();

        return services;
    }
}