// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonCardApi
{
    public static RouteGroupBuilder MapPersonCardApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPersonCard);
        group.MapPost("/", CreatePersonCard);
        group.MapPut("/", UpdatePersonCard);
        group.MapDelete("/", DeletePersonCard);

        return group;
    }

    public static async ValueTask<Ok<ListResponse<PersonCard>>> ListPersonCard(HttpRequest request, IPersonCardService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonCard(HttpRequest request, IPersonCardService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personCard = await request.ReadFromJsonAsync<PersonCard>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, personCard!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonCard(HttpRequest request, IPersonCardService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personCard = await request.ReadFromJsonAsync<PersonCard>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, personCard!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonCard(HttpRequest request, IPersonCardService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
