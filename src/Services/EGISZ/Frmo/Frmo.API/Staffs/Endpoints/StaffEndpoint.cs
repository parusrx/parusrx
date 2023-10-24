// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class StaffEndpoint
{
    public static RouteGroupBuilder MapStaffs(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org/staff");

        group.MapGet("/", async (IStaffService staffService, string oid, string? entity) =>
        {
            if (entity is null)
            {
                var staffs = await staffService.GetAsync(oid);
                return Results.Ok(staffs);
            }
            
            var staff = await staffService.GetByEntityAsync(oid, entity);
            return Results.Ok(staff);
        });

        group.MapPost("/", async (IStaffService staffService, string oid, Staff staff) =>
        {
            var response = await staffService.CreateAsync(oid, staff);

            return Results.Ok(response);
        });

        group.MapPut("/", async (IStaffService staffService, string oid, string entityId, Staff staff) =>
        {
            var response = await staffService.UpdateAsync(oid, entityId, staff);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (IStaffService staffService, string oid, string entityId) =>
        {
            var response = await staffService.DeleteAsync(oid, entityId);

            return Results.Ok(response);
        });

        return group;
    }
}
