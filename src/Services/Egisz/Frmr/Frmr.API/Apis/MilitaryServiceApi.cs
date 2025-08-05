// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

/// <summary>
/// Provides extension methods for mapping endpoints related to military service operations in a web application.
/// </summary>
/// <remarks>This static class defines methods to map HTTP endpoints for handling military service-related
/// operations,  such as retrieving, creating, updating, and deleting military service records. These endpoints are
/// designed  to integrate with an implementation of <see cref="IMilitaryClient"/> for processing requests.</remarks>
public static class MilitaryServiceApi
{
    public static IEndpointRouteBuilder MapMilitaryServiceApi(this IEndpointRouteBuilder app) 
    {
        app.MapGet("/", GetMilitaryService);
        app.MapPost("/", CreateMilitaryService);
        app.MapPut("/", UpdateMilitaryService);
        app.MapDelete("/", DeleteMilitaryService);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<MilitaryService>>> GetMilitaryService(HttpRequest request, IMilitaryClient service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateMilitaryService(HttpRequest request, IMilitaryClient service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var military = await request.ReadFromJsonAsync<MilitaryService>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, military!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateMilitaryService(HttpRequest request, IMilitaryClient service, CancellationToken cancellationToken) 
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var military = await request.ReadFromJsonAsync<MilitaryService>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, military!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteMilitaryService(HttpRequest request, IMilitaryClient service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
