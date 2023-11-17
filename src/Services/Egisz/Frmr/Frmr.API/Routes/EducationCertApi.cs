// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.Routes;

public static class EducationCertApi
{
    public static RouteGroupBuilder MapEducationCertApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListEducationCert);
        group.MapPost("/", CreateEducationCert);
        group.MapPut("/", UpdateEducationCert);
        group.MapDelete("/", DeleteEducationCert);

        return group;
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
