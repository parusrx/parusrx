// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class PersonQualificationApi
{
    public static RouteGroupBuilder MapPersonQualificationApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPersonQualification);
        group.MapPost("/", CreatePersonQualification);
        group.MapPut("/", UpdatePersonQualification);
        group.MapDelete("/", DeletePersonQualification);

        return group;
    }

    public static async ValueTask<Ok<ListResponse<PersonQualification>>> ListPersonQualification(HttpRequest request, IPersonQualificationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonQualification(HttpRequest request, IPersonQualificationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personQualification = await request.ReadFromJsonAsync<PersonQualification>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, personQualification!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonQualification(HttpRequest request, IPersonQualificationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personQualification = await request.ReadFromJsonAsync<PersonQualification>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, personQualification!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonQualification(HttpRequest request, IPersonQualificationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
