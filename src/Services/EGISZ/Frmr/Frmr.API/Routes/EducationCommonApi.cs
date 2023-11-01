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

    public static async ValueTask<Ok<GetEducationCommonResponse>> GetEducationCommon(HttpRequest request, EducationCommonService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<CreateEducationCommonResponse>> CreateEducationCommon(HttpRequest request, EducationCommonService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCommon = await request.ReadFromJsonAsync<EducationCommon>();
        var response = await service.CreateAsync(queryParameters, educationCommon!);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<UpdateEducationCommonResponse>> UpdateEducationCommon(HttpRequest request, EducationCommonService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCommon = await request.ReadFromJsonAsync<EducationCommon>();
        var response = await service.UpdateAsync(queryParameters, educationCommon!);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DeleteEducationCommonResponse>> DeleteEducationCommon(HttpRequest request, EducationCommonService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters);
        return TypedResults.Ok(response);
    }
}
