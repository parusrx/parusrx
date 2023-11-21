// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API;

public static class BuildingApi
{
    public static IEndpointRouteBuilder MapBuildingApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListBuilding);
        app.MapGet("/get", GetBuilding);
        app.MapPost("/", CreateBuilding);
        app.MapPut("/", UpdateBuilding);
        app.MapDelete("/", DeleteBuilding);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Building>>> ListBuilding(
        HttpRequest request,
        IBuildingService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Building>>> GetBuilding(
        HttpRequest request,
        IBuildingService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateBuilding(
        HttpRequest request,
        IBuildingService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var building = await request.ReadFromJsonAsync<Building>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, building!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateBuilding(
        HttpRequest request,
        IBuildingService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var building = await request.ReadFromJsonAsync<Building>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, building!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteBuilding(
        HttpRequest request,
        IBuildingService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
