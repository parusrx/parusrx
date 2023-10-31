// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationProfApi
{
    public static RouteGroupBuilder MapEducationProfApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetEducationProf);
        group.MapPost("/", CreateEducationProf);
        group.MapPut("/", UpdateEducationProf);
        group.MapDelete("/", DeleteEducationProf);
        
        return group;
    }

    public static async ValueTask<Ok<GetEducationProfResponse>> GetEducationProf(HttpRequest request, EducationProfService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<CreateEducationProfResponse>> CreateEducationProf(HttpRequest request, EducationProfService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationProf = await request.ReadFromJsonAsync<EducationProf>();
        var response = await service.CreateAsync(queryParameters, educationProf!);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<UpdateEducationProfResponse>> UpdateEducationProf(HttpRequest request, EducationProfService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationProf = await request.ReadFromJsonAsync<EducationProf>();
        var response = await service.UpdateAsync(queryParameters, educationProf!);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DeleteEducationProfResponse>> DeleteEducationProf(HttpRequest request, EducationProfService service)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters);
        return TypedResults.Ok(response);
    }
}
