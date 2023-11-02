// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Routes;

public static class StaffApi
{
    public static RouteGroupBuilder MapStaffApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListStaff);
        group.MapGet("/get", GetStaff);
        group.MapPost("/", CreateStaff);
        group.MapPut("/", UpdateStaff);
        group.MapDelete("/", DeleteStaff);

        return group;
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
