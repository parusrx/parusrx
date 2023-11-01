// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationPostgraduateApi
{
    public static RouteGroupBuilder MapEducationPostgraduateApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetEducationPostgraduate);
        group.MapPost("/", CreateEducationPostgraduate);
        group.MapPut("/", UpdateEducationPostgraduate);
        group.MapDelete("/", DeleteEducationPostgraduate);
        
        return group;
    }

    public static async ValueTask<Ok<GetEducationPostgraduateResponse>> GetEducationPostgraduate(HttpRequest request, EducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<CreateEducationPostgraduateResponse>> CreateEducationPostgraduate(HttpRequest request, EducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationPostgraduate = await request.ReadFromJsonAsync<EducationPostgraduate>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, educationPostgraduate!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<UpdateEducationPostgraduateResponse>> UpdateEducationPostgraduate(HttpRequest request, EducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationPostgraduate = await request.ReadFromJsonAsync<EducationPostgraduate>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, educationPostgraduate!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DeleteEducationPostgraduateResponse>> DeleteEducationPostgraduate(HttpRequest request, EducationPostgraduateService service, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string?> queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
