// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class TelemedicineApi
{
    public static IEndpointRouteBuilder MapTelemedicineApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListTelemedicine);
        app.MapGet("/get", GetTelemedicine);
        app.MapPost("/", CreateTelemedicine);
        app.MapPut("/", UpdateTelemedicine);
        app.MapDelete("/", DeleteTelemedicine);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Telemedicine>>> ListTelemedicine(HttpRequest request, ITelemedicineService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Telemedicine>>> GetTelemedicine(HttpRequest request, ITelemedicineService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateTelemedicine(HttpRequest request, ITelemedicineService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var telemedicine = await request.ReadFromJsonAsync<Telemedicine>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, telemedicine!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateTelemedicine(HttpRequest request, ITelemedicineService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var telemedicine = await request.ReadFromJsonAsync<Telemedicine>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, telemedicine!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteTelemedicine(HttpRequest request, ITelemedicineService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
