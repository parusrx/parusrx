// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace ParusRX.Api.Gateway.MqEndpoints;

public static class MqEndpoint
{
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

    public static async Task<IResult> PublishMessage([FromHeader(Name = "X-Tenant-Id")]string tenantId, Message message, IEventBus eventBus)
    {
        if (string.IsNullOrWhiteSpace(tenantId))
        {
            return TypedResults.BadRequest();
        }

        if (message is null || string.IsNullOrWhiteSpace(message.Topic) || string.IsNullOrWhiteSpace(message.Payload))
        {
            return TypedResults.BadRequest();
        }

        var @event = new IntegrationEvent
        {
            TenantId = tenantId,
            Payload = message.Payload
        };

        try
        {
            await eventBus.PublishAsync(message.Topic, @event);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "Failed to publish integration event: {Event}", @event);
            return Results.BadRequest();
        }

        return TypedResults.Ok();
    }
}