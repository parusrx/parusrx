// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using ParusRx.Frmo.API.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthorizationHttpClient();

builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddHttpResponseExceptionHandler();

builder.Services.AddIpsIdentityProvider();
builder.Services.AddOrganization();
builder.Services.AddDepartment();
builder.Services.AddStaff();

builder.Services.AddDaprClient();
builder.Services.AddDaprEventBus();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapGroup("/org")
    .MapOrganizationApi();

app.MapGroup("/org/depart")
    .MapDepartmentApi();

app.MapGroup("/org/staff")
    .MapStaffApi();

// Dapr pub/sub endpoints
app.MapPubSubOrganizations();
app.MapPubSubDepartments();
app.MapPubSubStaffs();

app.Run();