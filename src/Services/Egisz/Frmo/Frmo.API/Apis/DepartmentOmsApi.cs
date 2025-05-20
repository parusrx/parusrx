// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.API;

public static class DepartmentOmsApi
{
    public static IEndpointRouteBuilder MapDepartmentOmsApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", ListPagedDepartmentOms);
        app.MapGet("/get", GetDepartmentOms);
        app.MapPut("/", UpdateDepartmentOms);
        return app;
    }

    public static async ValueTask<Ok<ListPagedResponse<DepartOms>>> ListPagedDepartmentOms(
        HttpRequest request,
        IDepartmentOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.ListPagedAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<DepartOms>>> GetDepartmentOms(
        HttpRequest request,
        IDepartmentOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var response = await service.GetAsync(queryParameters, cancellationToken);
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdateDepartmentOms(
        HttpRequest request,
        IDepartmentOmsService service,
        CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var departmentOms = await request.ReadFromJsonAsync<DepartOms>(cancellationToken: cancellationToken);
        var response = await service.UpdateAsync(queryParameters, departmentOms!, cancellationToken);
        return TypedResults.Ok(response);
    }
}
