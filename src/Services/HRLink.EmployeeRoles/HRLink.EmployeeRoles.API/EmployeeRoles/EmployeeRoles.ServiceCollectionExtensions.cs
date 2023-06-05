// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for setting up employee roles services in an <see cref="IServiceCollection"/>.
/// </summary>
internal static class EmployeeRolesServiceCollectionExtensions
{
    /// <summary>
    /// Adds services required for employee roles.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddEmployeeRoles(this IServiceCollection services)
    {
        services.AddHttpClient<IEmployeeRolesClient, EmployeeRolesClient>();
        services.AddScoped<EmployeeRolesIntegrationEventHandler>();

        return services;
    }
}
