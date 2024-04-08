// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class TpggApi
{
    public static IEndpointRouteBuilder MapTpggApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListTpgg);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Tpgg>>> ListTpgg(
        HttpRequest request,
        ITpggService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
