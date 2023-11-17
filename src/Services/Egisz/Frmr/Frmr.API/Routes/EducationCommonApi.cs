// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationCommonApi
{
    public static RouteGroupBuilder MapEducationCommonApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetEducationCommon);
        group.MapPost("/", CreateEducationCommon);
        group.MapPut("/", UpdateEducationCommon);
        group.MapDelete("/", DeleteEducationCommon);
        
        return group;
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
