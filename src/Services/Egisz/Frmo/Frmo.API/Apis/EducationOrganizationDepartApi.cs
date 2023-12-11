// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class EducationOrganizationDepartApi
{
    public static IEndpointRouteBuilder MapEducationOrganizationDepartApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListEducationOrganizationDepart);
        app.MapGet("/{eoDepartOid}", GetEducationOrganizationDepart);
        app.MapPost("/", CreateEducationOrganizationDepart);
        app.MapPut("/", UpdateEducationOrganizationDepart);
        app.MapDelete("/", DeleteEducationOrganizationDepart);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<EducationOrganizationDepart>>> ListEducationOrganizationDepart(HttpRequest request, IEducationOrganizationDepartService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<EducationOrganizationDepart>>> GetEducationOrganizationDepart(string eoDepartOid, HttpRequest request, IEducationOrganizationDepartService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(eoDepartOid, queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationOrganizationDepart(HttpRequest request, IEducationOrganizationDepartService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationOrganizationDepart = await request.ReadFromJsonAsync<EducationOrganizationDepart>(cancellationToken: cancellationToken);
        var response = await service.CreateAsync(queryParameters, educationOrganizationDepart!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationOrganizationDepart(HttpRequest request, IEducationOrganizationDepartService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationOrganizationDepart = await request.ReadFromJsonAsync<EducationOrganizationDepart>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, educationOrganizationDepart!, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationOrganizationDepart(HttpRequest request, IEducationOrganizationDepartService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.DeleteAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
