// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API.Persons;

public static class PersonApi
{
    public static RouteGroupBuilder MapPersons(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/person");

        group.MapGet("/full", async (HttpRequest request, FullPersonService service, CancellationToken cancellationToken) =>
        {
            var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value);

            var response = await service.GetAsync(queryParameters, cancellationToken);

            return TypedResults.Ok(response);
        });

        return group;
    }
}
