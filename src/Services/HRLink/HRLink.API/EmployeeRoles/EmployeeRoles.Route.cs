// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace ParusRx.HRLink.API.EmployeeRoles;

/// <summary>
/// The employee roles API route.
/// </summary>
internal static class EmployeeRolesApi
{
    /// <summary>
    /// Creates a <see cref="RouteGroupBuilder"/> for the employee roles API.
    /// </summary>
    /// <param name="routes">The <see cref="IEndpointRouteBuilder"/> to add the group to.</param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for the employee roles API.</returns>
    public static RouteGroupBuilder MapEmployeeRoles(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("api/v1/employeeRoles");

        group.MapPost("/", [Topic("pubsub", "EmployeeRolesIntegrationEvent")] async (MqIntegrationEvent @event, [FromServices] EmployeeRolesIntegrationEventHandler handler, CancellationToken cancellationToken) =>
        {
            await handler.HandleAsync(@event, cancellationToken);

            return TypedResults.Created();
        });

        return group;
    }
}

[JsonSerializable(typeof(MqIntegrationEvent))]
internal partial class EmployeeRolesJsonSerializerContext : JsonSerializerContext
{
}