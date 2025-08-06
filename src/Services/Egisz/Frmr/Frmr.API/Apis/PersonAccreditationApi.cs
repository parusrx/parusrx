// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonAccreditationApi
{
    public static IEndpointRouteBuilder MapPersonAccreditationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetPersonAccreditation);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<PersonAccreditation>>> GetPersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
