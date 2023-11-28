// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Egisz.Frmr.API;

public static class PersonApi
{
    public static IEndpointRouteBuilder MapPersonApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", GetPerson);
        app.MapGet("/list", ListPagedPerson);
        app.MapPost("/", CreatePerson);
        app.MapPut("/", UpdatePerson);
        app.MapDelete("/", DeletePerson);

        return app;
    }

    public static async ValueTask<Ok<SingleResponse<Person>>> GetPerson(HttpRequest request, IPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.GetAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<ListPagedResponse<Person>>> ListPagedPerson(HttpRequest request, IPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.ListAsync(queryParameters, cancellationToken);
        
        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<SingleResponse<Entity>>> CreatePerson(HttpRequest request, IPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var person = await request.ReadFromJsonAsync<Person>(cancellationToken: cancellationToken);
        
        var response = await service.CreateAsync(queryParameters, person!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> UpdatePerson(HttpRequest request, IPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        var person = await request.ReadFromJsonAsync<Person>(cancellationToken: cancellationToken);
        
        var response = await service.UpdateAsync(queryParameters, person!, cancellationToken);

        return TypedResults.Ok(response);
    }

    public static async ValueTask<Ok<DefaultResponse>> DeletePerson(HttpRequest request, IPersonService service, CancellationToken cancellationToken)
    {
        var queryParameters = request.Query.ToDictionary(x => x.Key, x => (string?)x.Value.ToString());
        
        var response = await service.DeleteAsync(queryParameters, cancellationToken);

        return TypedResults.Ok(response);
    }
}
