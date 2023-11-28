// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonOrganizationApi
{
    public static IEndpointRouteBuilder MapPersonOrganizationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPersonOrganization);
        app.MapPost("/", CreatePersonOrganization);
        app.MapPut("/", UpdatePersonOrganization);
        app.MapDelete("/", DeletePersonOrganization);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<PersonOrganization>>> ListPersonOrganization(HttpRequest request, IPersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonOrganization(HttpRequest request, IPersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personOrganization = await request.ReadFromJsonAsync<PersonOrganization>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, personOrganization!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonOrganization(HttpRequest request, IPersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personOrganization = await request.ReadFromJsonAsync<PersonOrganization>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, personOrganization!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonOrganization(HttpRequest request, IPersonOrganizationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
