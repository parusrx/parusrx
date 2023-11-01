// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationExtApi
{
    public static RouteGroupBuilder MapEducationExtApi(this RouteGroupBuilder group)
    {
        return group;
    }

    public static async ValueTask<Ok<ListPagedResponse<EducationExt>>> GetEducationExt(HttpRequest request, EducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationExt(HttpRequest request, EducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationExt = await request.ReadFromJsonAsync<EducationExt>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationExt!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationExt(HttpRequest request, EducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationExt = await request.ReadFromJsonAsync<EducationExt>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, educationExt!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationExt(HttpRequest request, EducationExtService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
