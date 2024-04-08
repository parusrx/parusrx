// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class EquipmentApi
{
    public static IEndpointRouteBuilder MapEquipmentApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListEquipment);
        app.MapGet("/get", GetEquipment);
        app.MapPost("/", CreateEquipment);
        app.MapPut("/", UpdateEquipment);
        app.MapDelete("/", DeleteEquipment);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Equipment>>> ListEquipment(
        HttpRequest request,
        IEquipmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Equipment>>> GetEquipment(
        HttpRequest request,
        IEquipmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEquipment(
        HttpRequest request,
        IEquipmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var equipment = await request.ReadFromJsonAsync<Equipment>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, equipment!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEquipment(
        HttpRequest request,
        IEquipmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var equipment = await request.ReadFromJsonAsync<Equipment>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, equipment!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEquipment(
        HttpRequest request,
        IEquipmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
