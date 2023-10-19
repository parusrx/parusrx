// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

internal static class OrganizationEndpoint
{
    public static RouteGroupBuilder MapOrganizations(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("api/v1/org");
        
        group.MapGet("/", async (IOrganizationService organizationService, int orgTypeId, int offset = 0, int limit = 10) =>
        {
            var organizations = await organizationService.ListPagedAsync(orgTypeId, offset, limit);

            return Results.Ok(organizations);
        });

        group.MapGet("/{oid}", async (IOrganizationService organizationService, string oid) =>
        {
            var organization = await organizationService.GetByOidAsync(oid);

            return Results.Ok(organization);
        });

        group.MapPut("/", async (IOrganizationService organizationService, string oid, Organization organization) =>
        {
            var response = await organizationService.UpdateAsync(oid, organization);

            return Results.Ok(response);
        });

        group.MapDelete("/", async (IOrganizationService organizationService, string oid, int deleteReason) =>
        {
            var response = await organizationService.DeleteAsync(oid, deleteReason);

            return Results.Ok(response);
        });

        return group;
    }
}
