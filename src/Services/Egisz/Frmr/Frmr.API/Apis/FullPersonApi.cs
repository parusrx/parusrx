// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class FullPersonApi
{
    public static IEndpointRouteBuilder MapFullPersonApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetFullPerson);
        
        return app;
    }

    public static async ValueTask<Ok<SingleResponse<FullPerson>>> GetFullPerson(HttpRequest request, IFullPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.GetAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }
}
