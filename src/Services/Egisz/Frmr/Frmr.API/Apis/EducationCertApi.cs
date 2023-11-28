// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class EducationCertApi
{
    public static IEndpointRouteBuilder MapEducationCertApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListEducationCert);
        app.MapPost("/", CreateEducationCert);
        app.MapPut("/", UpdateEducationCert);
        app.MapDelete("/", DeleteEducationCert);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<EducationCert>>> ListEducationCert(HttpRequest request, IEducationCertService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateEducationCert(HttpRequest request, IEducationCertService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCert = await request.ReadFromJsonAsync<EducationCert>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, educationCert!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateEducationCert(HttpRequest request, IEducationCertService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var educationCert = await request.ReadFromJsonAsync<EducationCert>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, educationCert!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteEducationCert(HttpRequest request, IEducationCertService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
