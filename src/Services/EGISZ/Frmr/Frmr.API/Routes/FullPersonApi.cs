// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class FullPersonApi
{
    public static RouteGroupBuilder MapFullPersonApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetFullPerson);
        return group;
    }

    public static async ValueTask<Ok<SingleResponse<FullPerson>>> GetFullPerson(HttpRequest request, FullPersonService service)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.GetAsync(queryParameters);
        
        return TypedResults.Ok(response);
    }
}
