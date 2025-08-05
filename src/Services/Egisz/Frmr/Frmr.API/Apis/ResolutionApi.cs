// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class ResolutionApi
{
    public static IEndpointRouteBuilder MapResolutionApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListEducationCert);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Resolution>>> ListEducationCert(HttpRequest request, IResolutionClient client, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await client.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
