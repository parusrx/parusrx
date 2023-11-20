// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationExtApi
{
    public static IEndpointRouteBuilder MapEducationExtApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPagedEducationExt);
        app.MapPost("/", CreateEducationExt);
        app.MapPut("/", UpdateEducationExt);
        app.MapDelete("/", DeleteEducationExt);

        return app;
    }

    public static async ValueTask<Ok<ListPagedResponse<EducationExt>>> ListPagedEducationExt(HttpRequest request, IEducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.ListPagedAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationExt(HttpRequest request, IEducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationExt = await request.ReadFromJsonAsync<EducationExt>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationExt!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationExt(HttpRequest request, IEducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationExt = await request.ReadFromJsonAsync<EducationExt>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, educationExt!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationExt(HttpRequest request, IEducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
