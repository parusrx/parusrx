﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API;

public static class OrganizationApi
{
    public static IEndpointRouteBuilder MapOrganizationApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{oid}", GetOrganization);
        app.MapGet("/depart", ListPagedDepartment);
        app.MapGet("/depart/{departOid}", GetDepartment);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<Organization>>> GetOrganization(
        string oid,
        IOrganizationService service,
        CancellationToken cancellationToken = default)
    {
        var response = await service.GetAsync(oid, cancellationToken);

        return TypedResults.Ok(response);
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
}