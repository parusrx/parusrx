// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationCommonApi
{
    public static IEndpointRouteBuilder MapEducationCommonApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetEducationCommon);
        app.MapPost("/", CreateEducationCommon);
        app.MapPut("/", UpdateEducationCommon);
        app.MapDelete("/", DeleteEducationCommon);
        
        return app;
    }

    public static async ValueTask<Ok<SingleResponse<EducationCommon>>> GetEducationCommon(HttpRequest request, IEducationCommonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationCommon(HttpRequest request, IEducationCommonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCommon = await request.ReadFromJsonAsync<EducationCommon>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationCommon!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationCommon(HttpRequest request, IEducationCommonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCommon = await request.ReadFromJsonAsync<EducationCommon>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, educationCommon!, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationCommon(HttpRequest request, IEducationCommonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }
}
