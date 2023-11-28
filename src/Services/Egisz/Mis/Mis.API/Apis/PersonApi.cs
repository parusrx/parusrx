// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Mis.API;

public static class PersonApi
{
    public static IEndpointRouteBuilder MapPersonApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/full", GetFullPerson);
        app.MapGet("/cert", ListEducationCert);
        app.MapGet("/accreditation", GetPersonAccreditation);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<FullPerson>>> GetFullPerson(HttpRequest request, IFullPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<ListResponse<EducationCert>>> ListEducationCert(HttpRequest request, IEducationCertService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<PersonAccreditation>>> GetPersonAccreditation(HttpRequest request, IPersonAccreditationService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
