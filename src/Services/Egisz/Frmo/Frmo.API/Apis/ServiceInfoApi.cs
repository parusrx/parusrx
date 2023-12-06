// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class ServiceInfoApi
{
    public static IEndpointRouteBuilder MapServiceInfoApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListServiceInfo);
        app.MapPost("/", CreateServiceInfo);
        app.MapPut("/", UpdateServiceInfo);
        app.MapDelete("/", DeleteServiceInfo);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<ServiceInfo>>> ListServiceInfo(HttpRequest request, IServiceInfoService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateServiceInfo(HttpRequest request, IServiceInfoService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var serviceInfo = await request.ReadFromJsonAsync<ServiceInfo>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, serviceInfo!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateServiceInfo(HttpRequest request, IServiceInfoService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var serviceInfo = await request.ReadFromJsonAsync<ServiceInfo>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, serviceInfo!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteServiceInfo(HttpRequest request, IServiceInfoService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
