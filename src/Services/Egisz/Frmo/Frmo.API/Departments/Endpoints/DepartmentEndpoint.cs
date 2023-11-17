// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class DepartmentEndpoint
{
    public static RouteGroupBuilder MapDepartments(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org/depart");

        group.MapGet("/", async (HttpRequest request, IDepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var departments = await service.ListPagedAsync(queryParameters, cancellationToken);

            return Results.Ok(departments);
        });

        group.MapGet("/{departOid}", async (string departOid, HttpRequest request, IDepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var department = await service.GetAsync(departOid, queryParameters, cancellationToken);

            return Results.Ok(department);
        });

        group.MapPost("/", async (HttpRequest request, IDepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
            var department = await request.ReadFromJsonAsync<Department>(cancellationToken: cancellationToken);
            
            var response = await service.CreateAsync(queryParameters, department!, cancellationToken);

            return Results.Ok(response);
        });

        group.MapPut("/", async (HttpRequest request, IDepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
            var department = await request.ReadFromJsonAsync<Department>(cancellationToken: cancellationToken);

            var response = await service.UpdateAsync(queryParameters, department!, cancellationToken);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (HttpRequest request, IDepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.DeleteAsync(queryParameters, cancellationToken);

            return Results.Ok(response);
        });        

        return group;
    }
}
