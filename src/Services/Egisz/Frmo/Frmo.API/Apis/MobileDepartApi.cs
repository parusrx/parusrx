// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class MobileDepartApi
{
    public static IEndpointRouteBuilder MapMobileDepartApi(this IEndpointRouteBuilder app) 
    {
        app.MapGet("/", ListMobileDepart);
        app.MapGet("/get", GetMobileDepart);
        app.MapPost("/", CreateMobileDepart);
        app.MapPut("/", UpdateMobileDepart);
        app.MapDelete("/", DeleteMobileDepart);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<MobileDepart>>> ListMobileDepart(
        HttpRequest request,
        IMobileDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<MobileDepart>>> GetMobileDepart(
        HttpRequest request,
        IMobileDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateMobileDepart(
        HttpRequest request,
        IMobileDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var mobileDepart = await request.ReadFromJsonAsync<MobileDepart>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, mobileDepart!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateMobileDepart(
        HttpRequest request,
        IMobileDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var mobileDepart = await request.ReadFromJsonAsync<MobileDepart>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, mobileDepart!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteMobileDepart(
        HttpRequest request,
        IMobileDepartService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
