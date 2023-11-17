// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Organizations;

public static class OrganizationApi
{
    public static RouteGroupBuilder MapOrganizations(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/org");

        group.MapGet("/{oid}", async (string oid, OrganizationService service, CancellationToken cancellationToken) =>
        {
            var response = await service.GetAsync(oid, cancellationToken);

            return TypedResults.Ok(response);
        });

        group.MapGet("/depart", async (HttpRequest request, DepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.ListPagedAsync(queryParameters, cancellationToken);

            return TypedResults.Ok(response);
        });

        group.MapGet("/depart/{departOid}", async (string departOid, HttpRequest request, DepartmentService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(departOid, queryParameters, cancellationToken);

        return TypedResults.Ok(response);
        });

        return group;
    }
}
