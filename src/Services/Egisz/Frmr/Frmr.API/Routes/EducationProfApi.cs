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
