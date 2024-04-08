// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationPostgraduateApi
{
    public static IEndpointRouteBuilder MapEducationPostgraduateApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListEducationPostgraduate);
        app.MapPost("/", CreateEducationPostgraduate);
        app.MapPut("/", UpdateEducationPostgraduate);
        app.MapDelete("/", DeleteEducationPostgraduate);
        
        return app;
    }

    public static async ValueTask<Ok<ListResponse<EducationPostgraduate>>> ListEducationPostgraduate(HttpRequest request, IEducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.ListAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationPostgraduate(HttpRequest request, IEducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationPostgraduate = await request.ReadFromJsonAsync<EducationPostgraduate>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationPostgraduate!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationPostgraduate(HttpRequest request, IEducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationPostgraduate = await request.ReadFromJsonAsync<EducationPostgraduate>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, educationPostgraduate!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationPostgraduate(HttpRequest request, IEducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }
}
