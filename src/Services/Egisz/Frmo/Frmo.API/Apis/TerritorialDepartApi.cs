// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class TerritorialDepartApi
{
    public static IEndpointRouteBuilder MapTerritorialDepartApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListTerritorialDepart);
        app.MapGet("/get", GetTerritorialDepart);
        app.MapPost("/", CreateTerritorialDepart);
        app.MapPut("/", UpdateTerritorialDepart);
        app.MapDelete("/", DeleteTerritorialDepart);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<TerritorialDepart>>> ListTerritorialDepart(
        HttpRequest request,
        ITerritorialDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<TerritorialDepart>>> GetTerritorialDepart(
        HttpRequest request,
        ITerritorialDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateTerritorialDepart(
        HttpRequest request,
        ITerritorialDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var territorialDepart = await request.ReadFromJsonAsync<TerritorialDepart>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, territorialDepart!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateTerritorialDepart(
        HttpRequest request,
        ITerritorialDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var territorialDepart = await request.ReadFromJsonAsync<TerritorialDepart>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, territorialDepart!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteTerritorialDepart(
        HttpRequest request,
        ITerritorialDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
