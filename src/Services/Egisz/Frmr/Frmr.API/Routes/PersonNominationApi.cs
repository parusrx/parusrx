// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonNominationApi
{
    public static RouteGroupBuilder MapPersonNominationApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPersonNomination);
        group.MapPost("/", CreatePersonNomination);
        group.MapPut("/", UpdatePersonNomination);
        group.MapDelete("/", DeletePersonNomination);

        return group;
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
