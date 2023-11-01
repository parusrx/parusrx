// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonAccreditationApi
{
    public static RouteGroupBuilder MapPersonAccreditationApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetPersonAccreditation);
        group.MapPost("/", CreatePersonAccreditation);
        group.MapPut("/", UpdatePersonAccreditation);
        group.MapDelete("/", DeletePersonAccreditation);

        return group;
    }

    public static async ValueTask<Ok<SingleResponse<PersonAccreditation>>> GetPersonAccreditation(HttpRequest request, PersonAccreditationService personAccreditationService, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await personAccreditationService.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonAccreditation(HttpRequest request, PersonAccreditationService personAccreditationService, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var personAccreditation = await request.ReadFromJsonAsync<PersonAccreditation>(cancellationToken: cancellationToken);
        var response = await personAccreditationService.CreateAsync(queryParameters, personAccreditation!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonAccreditation(HttpRequest request, PersonAccreditationService personAccreditationService, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var personAccreditation = await request.ReadFromJsonAsync<PersonAccreditation>(cancellationToken: cancellationToken);
        var response = await personAccreditationService.UpdateAsync(queryParameters, personAccreditation!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonAccreditation(HttpRequest request, PersonAccreditationService personAccreditationService, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await personAccreditationService.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
