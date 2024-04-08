// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class OrganizationApi
{
    public static IEndpointRouteBuilder MapOrganizationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPagedOrganization);
        app.MapGet("/{oid}", GetOrganization);
        app.MapPut("/", UpdateOrganization);
        app.MapDelete("/", DeleteOrganization);

        return app;
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
