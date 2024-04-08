// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class AirAmbulanceApi
{
    public static IEndpointRouteBuilder MapAirAmbulanceApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListAirAmbulance);
        app.MapGet("/get", GetAirAmbulance);
        app.MapPost("/", CreateAirAmbulance);
        app.MapPut("/", UpdateAirAmbulance);
        app.MapDelete("/", DeleteAirAmbulance);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<AirAmbulance>>> ListAirAmbulance(
        HttpRequest request,
        IAirAmbulanceService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<AirAmbulance>>> GetAirAmbulance(
        HttpRequest request,
        IAirAmbulanceService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateAirAmbulance(
        HttpRequest request,
        IAirAmbulanceService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var airAmbulance = await request.ReadFromJsonAsync<AirAmbulance>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, airAmbulance!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateAirAmbulance(
        HttpRequest request,
        IAirAmbulanceService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var airAmbulance = await request.ReadFromJsonAsync<AirAmbulance>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, airAmbulance!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteAirAmbulance(
        HttpRequest request,
        IAirAmbulanceService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
