// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information..

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default));

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true});
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.Run();

[JsonSerializable(typeof(DocumentType))]
[JsonSerializable(typeof(DocumentTypeResponse))]
[JsonSerializable(typeof(EmployeeRole))]
[JsonSerializable(typeof(EmployeeRoleResponse))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }