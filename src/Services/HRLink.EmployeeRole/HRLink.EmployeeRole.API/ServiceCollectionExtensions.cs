// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRLink.EmployeeRole.API;

/// <summary>
/// Extension methods for setting up employee role services in an <see cref="IServiceCollection"/>.
/// </summary>
internal static class EmployeeRoleServiceCollectionExtensions
{
    /// <summary>
    /// Adds services required for employee role.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEmployeeRoleServices(this IServiceCollection services)
    {
        services.AddHttpClient<IEmployeeRoleClient, EmployeeRoleClient>();
        services.AddScoped<EmployeeRoleIntegrationEventHandler>();

        return services;
    }
}
