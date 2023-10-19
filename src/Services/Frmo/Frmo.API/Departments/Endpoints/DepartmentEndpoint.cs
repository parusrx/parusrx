// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class DepartmentEndpoint
{
    public static RouteGroupBuilder MapDepartments(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org/depart");

        group.MapGet("/", async (IDepartmentService departmentService, int departTypeId, string oid, int offset = 0, int limit = 10) =>
        {
            var departments = await departmentService.ListPagedAsync(departTypeId, oid, offset, limit);

            return Results.Ok(departments);
        });

        group.MapGet("/{departOid}", async (IDepartmentService departmentService, string departOid, string oid) =>
        {
            var department = await departmentService.GetByOidAsync(departOid, oid);

            return Results.Ok(department);
        });

        group.MapPost("/", async (IDepartmentService departmentService, string oid, Department department) =>
        {
            var response = await departmentService.CreateAsync(oid, department);

            return Results.Ok(response);
        });

        group.MapPut("/", async (IDepartmentService departmentService, string oid, string entityId, Department department) =>
        {
            var response = await departmentService.UpdateAsync(oid, entityId, department);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (IDepartmentService departmentService, string oid, string entityId) =>
        {
            var response = await departmentService.DeleteAsync(oid, entityId);

            return Results.Ok(response);
        });        

        return group;
    }
}
