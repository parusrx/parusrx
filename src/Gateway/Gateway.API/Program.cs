// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using ParusRx.EventBus;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPost("api/v1/mq", async (MessageQueue message, [FromServices] IEventBus eventBus) =>
{
    var @event = new MqIntegrationEvent(message.Message);
    await eventBus.PublishAsync(@event);

    return TypedResults.Created();
});

app.Run();

internal sealed record MessageQueue(string Topic, string Message);

[JsonSerializable(typeof(MessageQueue))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }