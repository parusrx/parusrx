// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.API.Routes;

public static class DepartmentApi
{
    public static RouteGroupBuilder MapDepartmentApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ListPagedDepartment);
        group.MapGet("/{departOid}", GetDepartment);
        group.MapPost("/", CreateDepartment);
        group.MapPut("/", UpdateDepartment);
        group.MapDelete("/", DeleteDepartment);

        return group;
    }

    public static async ValueTask<Ok<ListPagedResponse<Department>>> ListPagedDepartment(
        HttpRequest request,
        IDepartmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.ListPagedAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Department>>> GetDepartment(
        string departOid,
        HttpRequest request,
        IDepartmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.GetAsync(departOid, queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreateDepartment(
        HttpRequest request,
        IDepartmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var department = await request.ReadFromJsonAsync<Department>(cancellationToken: cancellationToken);

        var response = await service.CreateAsync(queryParameters, department!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateDepartment(
        HttpRequest request,
        IDepartmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var department = await request.ReadFromJsonAsync<Department>(cancellationToken: cancellationToken);

        var response = await service.UpdateAsync(queryParameters, department!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeleteDepartment(
        HttpRequest request,
        IDepartmentService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());

        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
