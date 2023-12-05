// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class SiteApi
{
    public static IEndpointRouteBuilder MapSiteApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListSite);
        app.MapGet("/get", GetSite);
        app.MapPost("/", CreateSite);
        app.MapPut("/", UpdateSite);
        app.MapDelete("/", DeleteSite);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Site>>> ListSite(
        HttpRequest request,
        ISiteService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Site>>> GetSite(
        HttpRequest request,
        ISiteService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateSite(
        HttpRequest request,
        ISiteService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var site = await request.ReadFromJsonAsync<Site>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, site!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateSite(
        HttpRequest request,
        ISiteService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var site = await request.ReadFromJsonAsync<Site>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, site!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteSite(
        HttpRequest request,
        ISiteService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
