// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace ParusRx.HRLink.EmployeeRole.API;

/// <summary>
/// The employee role API routes.
/// </summary>
internal static class EmployeeRoleRoutes
{
    /// <summary>
    /// Creates a <see cref="RouteGroupBuilder"/> for the employee roles API.
    /// </summary>
    /// <param name="routes">The <see cref="IEndpointRouteBuilder"/> to add the group to.</param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for the employee roles API.</returns>
    public static RouteGroupBuilder MapEmployeeRoles(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/v1/employeeRoles");

        group.MapPost("/", [Topic("pubsub", "EmployeeRolesIntegrationEvent")] async (MqIntegrationEvent @event, [FromServices] EmployeeRoleIntegrationEventHandler handler, CancellationToken cancellationToken) =>
        {
            await handler.HandleAsync(@event, cancellationToken);

            return TypedResults.Created();
        });

        return group;
    }
}

[JsonSerializable(typeof(MqIntegrationEvent))]
internal partial class EmployeeRoleJsonSerializerContext : JsonSerializerContext
{
}