﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

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
