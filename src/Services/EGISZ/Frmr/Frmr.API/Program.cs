// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using ParusRx.Frmr.API.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthorizationHttpClient();

builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddIpsIdentityProvider();
builder.Services.AddApplicationServices();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapGroup("/person")
    .MapPersonApi();

app.MapGroup("/person/full")
    .MapFullPersonApi();

app.Run();