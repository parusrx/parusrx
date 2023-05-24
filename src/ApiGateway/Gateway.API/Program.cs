// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default));

builder.Services.AddDaprClient();

builder.Services.AddScoped<IEventBus, DaprEventBus>();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapMq();

app.Run();

[JsonSerializable(typeof(Message[]))]
[JsonSerializable(typeof(IntegrationEvent[]))]
[JsonSerializable(typeof(IntegrationEvent))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }

public partial class Program { }