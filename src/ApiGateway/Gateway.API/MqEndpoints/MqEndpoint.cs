// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace ParusRx.Gateway.API.MqEndpoints;

/// <summary>
/// Represents MQ endpoint.
/// </summary>
public static class MqEndpoint
{
    /// <summary>
    /// Map MQ endpoint.
    /// </summary>
    /// <param name="group">The route group builder.</param>
    /// <returns>The route group builder.</returns>
    public static RouteGroupBuilder MapMqEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", PublishMessage)
            .WithName("PublishIntegrationEvent")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithOpenApi(operation => new(operation)
            {
                Description = "Publish integration event",
                Parameters = new List<OpenApiParameter>
                {
                    new()
                    {
                        Name = "X-Tenant-Id",
                        In = ParameterLocation.Header,
                        Required = true,
                        Description = "Tenant identifier",
                        Schema = new OpenApiSchema
                        {
                            Type = "string"
                        }
                    }
                },
                RequestBody = new OpenApiRequestBody
                {
                    Description = "Message",
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new()
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    ["topic"] = new()
                                    {
                                        Type = "string"
                                    },
                                    ["payload"] = new()
                                    {
                                        Type = "string"
                                    }
                                }
                            }
                        }
                    }
                }
            });

        return group;
    }

    /// <summary>
    /// Publish integration event.
    /// </summary>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="message">The message.</param>
    /// <param name="eventBus">The event bus.</param>
    /// <returns>The result.</returns>
    public static async Task<IResult> PublishMessage(
        [FromHeader(Name = "X-Tenant-Id")]string tenantId, 
        Message message, 
        [FromServices]IEventBus eventBus)
    {
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            return TypedResults.BadRequest();
        }

        if (message is null)
        {
            return TypedResults.BadRequest();
        }

        var @event = new IntegrationEvent
        {
            //TenantId = tenantId,
            Payload = message.Payload
        };

        try
        {
            await eventBus.PublishAsync(message.Topic, @event);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "Failed to publish integration event: {Event}", @event);
            return Results.BadRequest();
        }
    }
}