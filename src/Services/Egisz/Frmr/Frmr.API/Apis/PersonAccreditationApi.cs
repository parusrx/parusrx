// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonAccreditationApi
{
    public static IEndpointRouteBuilder MapPersonAccreditationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetPersonAccreditation);
        app.MapPost("/", CreatePersonAccreditation);
        app.MapPut("/", UpdatePersonAccreditation);
        app.MapDelete("/", DeletePersonAccreditation);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<PersonAccreditation>>> GetPersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personAccreditation = await request.ReadFromJsonAsync<PersonAccreditation>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, personAccreditation!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var personAccreditation = await request.ReadFromJsonAsync<PersonAccreditation>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, personAccreditation!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
