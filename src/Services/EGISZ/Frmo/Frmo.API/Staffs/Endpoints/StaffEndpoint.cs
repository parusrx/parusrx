// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class StaffEndpoint
{
    public static RouteGroupBuilder MapStaffs(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org/staff");

        group.MapGet("/", async (HttpRequest request, IStaffService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.ListAsync(queryParameters, cancellationToken);

            return Results.Ok(response);
        });

        group.MapGet("/get", async (HttpRequest request, IStaffService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.GetAsync(queryParameters, cancellationToken);

            return Results.Ok(response);
        });

        group.MapPost("/", async (HttpRequest request, IStaffService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
            var staff = await request.ReadFromJsonAsync<Staff>(cancellationToken: cancellationToken);

            var response = await service.CreateAsync(queryParameters, staff!, cancellationToken);

            return Results.Ok(response);
        });

        group.MapPut("/", async (HttpRequest request, IStaffService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
            var staff = await request.ReadFromJsonAsync<Staff>(cancellationToken: cancellationToken);

            var response = await service.UpdateAsync(queryParameters, staff!, cancellationToken);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (HttpRequest request, IStaffService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.DeleteAsync(queryParameters, cancellationToken);

            return Results.Ok(response);
        });

        return group;
    }
}
