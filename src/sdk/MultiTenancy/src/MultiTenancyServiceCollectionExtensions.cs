// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions methods for setting up multi-tenancy services in an <see cref="IServiceCollection" />.
/// </summary>
public static class MultiTenancyServiceCollectionExtensions
{
    /// <summary>
    /// Register multi-tenancy services.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <typeparam name="TTenant">Tenant type.</typeparam>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddMultiTenancy<TTenant>(this IServiceCollection services) where TTenant : class, ITenant
    {
        services.AddTransient<ICurrentTenant, TenantService>();
        services.AddTransient<ITenantService, TenantService>();
        services.AddTransient<IConfigureOptions<MultiTenancyOptions>, MultiTenancyConfigureOptions<TTenant>>();
        
        return services;
    }
}