// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
