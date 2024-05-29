// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;
using HealthChecks.UI.Client;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ParusRx.EventBus;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default));

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapPost("api/v1/mq", async (MessageQueue message, [FromServices] IEventBus eventBus) =>
{
    var @event = new MqIntegrationEvent(message.Message);
    await eventBus.PublishAsync(message.Topic, @event);

    return TypedResults.Created();
});

app.Run();

internal sealed record MessageQueue(string Topic, string Message);

[JsonSerializable(typeof(MessageQueue))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }