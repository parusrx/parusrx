// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class OrganizationOmsApi
{
    public static IEndpointRouteBuilder MapOrganizationOmsApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPagedOrganizationOms);
        app.MapGet("/get", GetOrganizationOms);
        app.MapPut("/", UpdateOrganizationOms);

        return app;
    }

    public static async ValueTask<Ok<ListPagedResponse<OrganizationOms>>> ListPagedOrganizationOms(
        HttpRequest request,
        IOrganizationOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListPagedAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<OrganizationOms>>> GetOrganizationOms(
        HttpRequest request,
        IOrganizationOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateOrganizationOms(
        HttpRequest request,
        IOrganizationOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var organizationOms = await request.ReadFromJsonAsync<OrganizationOms>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, organizationOms!, cancellationToken);
        return TypedResults.Ok(response);
    }
}
