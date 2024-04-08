// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class HouseGroundApi
{
    public static IEndpointRouteBuilder MapHouseGroundApi(this IEndpointRouteBuilder app) 
    {
        app.MapGet("/", ListHouseGround);
        app.MapGet("/get", GetHouseGround);
        app.MapPost("/", CreateHouseGround);
        app.MapPut("/", UpdateHouseGround);
        app.MapDelete("/", DeleteHouseGround);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<HouseGround>>> ListHouseGround(
        HttpRequest request,
        IHouseGroundService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<HouseGround>>> GetHouseGround(
        HttpRequest request,
        IHouseGroundService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateHouseGround(
        HttpRequest request,
        IHouseGroundService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var houseGround = await request.ReadFromJsonAsync<HouseGround>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, houseGround!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateHouseGround(
        HttpRequest request,
        IHouseGroundService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var houseGround = await request.ReadFromJsonAsync<HouseGround>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, houseGround!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteHouseGround(
        HttpRequest request,
        IHouseGroundService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
