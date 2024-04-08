// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class DepartmentApi
{
    public static IEndpointRouteBuilder MapDepartmentApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPagedDepartment);
        app.MapGet("/{departOid}", GetDepartment);
        app.MapPost("/", CreateDepartment);
        app.MapPut("/", UpdateDepartment);
        app.MapDelete("/", DeleteDepartment);

        return app;
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
