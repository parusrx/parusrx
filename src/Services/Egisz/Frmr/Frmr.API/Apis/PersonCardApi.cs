// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonCardApi
{
    public static IEndpointRouteBuilder MapPersonCardApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPersonCard);
        app.MapPost("/", CreatePersonCard);
        app.MapPut("/", UpdatePersonCard);
        app.MapDelete("/", DeletePersonCard);

        return app;
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
