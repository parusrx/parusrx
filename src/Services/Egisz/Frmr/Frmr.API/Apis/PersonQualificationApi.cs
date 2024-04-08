// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonQualificationApi
{
    public static IEndpointRouteBuilder MapPersonQualificationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPersonQualification);
        app.MapPost("/", CreatePersonQualification);
        app.MapPut("/", UpdatePersonQualification);
        app.MapDelete("/", DeletePersonQualification);

        return app;
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
