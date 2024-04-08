// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationProfApi
{
    public static IEndpointRouteBuilder MapEducationProfApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetEducationProf);
        app.MapPost("/", CreateEducationProf);
        app.MapPut("/", UpdateEducationProf);
        app.MapDelete("/", DeleteEducationProf);
        
        return app;
    }

    public static async ValueTask<Ok<SingleResponse<EducationProf>>> GetEducationProf(HttpRequest request, IEducationProfService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.GetAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationProf(HttpRequest request, IEducationProfService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationProf = await request.ReadFromJsonAsync<EducationProf>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationProf!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationProf(HttpRequest request, IEducationProfService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationProf = await request.ReadFromJsonAsync<EducationProf>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, educationProf!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationProf(HttpRequest request, IEducationProfService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
