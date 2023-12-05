// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmo.API;

public static class LicenseApi
{
    public static IEndpointRouteBuilder MapLicenseApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListLicense);
        app.MapGet("/get", GetLicense);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<License>>> ListLicense(HttpRequest request, ILicenseService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<License>>> GetLicense(HttpRequest request, ILicenseService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }
}
