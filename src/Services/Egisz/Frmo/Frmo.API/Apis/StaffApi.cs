// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class StaffApi
{
    public static IEndpointRouteBuilder MapStaffApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListStaff);
        app.MapGet("/get", GetStaff);
        app.MapPost("/", CreateStaff);
        app.MapPut("/", UpdateStaff);
        app.MapDelete("/", DeleteStaff);

        return app;
    }

    public static async ValueTask<Ok<ListResponse<Staff>>> ListStaff(
        HttpRequest request,
        IStaffService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Staff>>> GetStaff(
        HttpRequest request,
        IStaffService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateStaff(
        HttpRequest request,
        IStaffService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var staff = await request.ReadFromJsonAsync<Staff>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, staff!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateStaff(
        HttpRequest request,
        IStaffService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var staff = await request.ReadFromJsonAsync<Staff>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, staff!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteStaff(
        HttpRequest request,
        IStaffService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
