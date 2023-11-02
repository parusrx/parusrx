// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class OrganizationEndpoint
{
    public static RouteGroupBuilder MapOrganizations(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org");
        
        group.MapGet("/", async (HttpRequest request, IOrganizationService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var organizations = await service.ListPagedAsync(queryParameters, cancellationToken);

            return Results.Ok(organizations);
        });

        group.MapGet("/{oid}", async (string oid, IOrganizationService service, CancellationToken cancellationToken) =>
        {
            var organization = await service.GetAsync(oid, cancellationToken);

            return Results.Ok(organization);
        });

        group.MapPut("/", async (HttpRequest request, Organization organization, IOrganizationService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.UpdateAsync(queryParameters, organization, cancellationToken);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (HttpRequest request, IOrganizationService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

            var response = await service.DeleteAsync(queryParameters, cancellationToken);

            return Results.Ok(response);
        });

        return group;
    }
}
