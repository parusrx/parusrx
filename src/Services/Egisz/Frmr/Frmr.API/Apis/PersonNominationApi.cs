// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonNominationApi
{
    public static IEndpointRouteBuilder MapPersonNominationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPersonNomination);
        app.MapPost("/", CreatePersonNomination);
        app.MapPut("/", UpdatePersonNomination);
        app.MapDelete("/", DeletePersonNomination);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<PersonNomination>>> ListPersonNomination(HttpRequest request, IPersonNominationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonNomination(HttpRequest request, IPersonNominationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personNomination = await request.ReadFromJsonAsync<PersonNomination>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, personNomination!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonNomination(HttpRequest request, IPersonNominationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personNomination = await request.ReadFromJsonAsync<PersonNomination>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, personNomination!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonNomination(HttpRequest request, IPersonNominationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
