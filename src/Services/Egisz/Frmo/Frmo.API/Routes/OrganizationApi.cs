// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Routes;

public static class OrganizationApi
{
    public static RouteGroupBuilder MapOrganizationApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPagedOrganization);
        group.MapGet("/{oid}", GetOrganization);
        group.MapPut("/", UpdateOrganization);
        group.MapDelete("/", DeleteOrganization);

        return group;
    }

    public static async ValueTask<Ok<ListPagedResponse<Organization>>> ListPagedOrganization(
        HttpRequest request,
        IOrganizationService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListPagedAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Organization>>> GetOrganization(
        string oid,
        IOrganizationService service,
        CancellationToken cancellationToken)
    {
        var response = await service.GetAsync(oid, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateOrganization(
        HttpRequest request,
        IOrganizationService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var organization = await request.ReadFromJsonAsync<Organization>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, organization!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteOrganization(
        HttpRequest request,
        IOrganizationService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
