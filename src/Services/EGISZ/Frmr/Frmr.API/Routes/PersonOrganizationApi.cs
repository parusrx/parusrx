// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonOrganizationApi
{
    public static RouteGroupBuilder MapPersonOrganizationApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPersonOrganization);
        group.MapPost("/", CreatePersonOrganization);
        group.MapPut("/", UpdatePersonOrganization);
        group.MapDelete("/", DeletePersonOrganization);

        return group;
    }

    public static async ValueTask<Ok<ListResponse<PersonOrganization>>> ListPersonOrganization(HttpRequest request, PersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonOrganization(HttpRequest request, PersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personOrganization = await request.ReadFromJsonAsync<PersonOrganization>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, personOrganization!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonOrganization(HttpRequest request, PersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personOrganization = await request.ReadFromJsonAsync<PersonOrganization>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, personOrganization!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonOrganization(HttpRequest request, PersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
