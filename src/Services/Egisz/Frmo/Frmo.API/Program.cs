// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddHttpResponseExceptionHandler();

builder.Services.AddIpsIdentityProvider(builder.Configuration);
builder.Services.AddFrmo(builder.Configuration["Frmo:Url"] ?? string.Empty);
builder.Services.AddIntegrationEventHandlers();

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
    .WithTags("Organization API")
    .MapOrganizationApi();

app.MapGroup("/org/depart")
    .WithTags("Department API")
    .MapDepartmentApi();

app.MapGroup("/org/building")
    .WithTags("Building API")
    .MapBuildingApi();

app.MapGroup("/org/equipment")
    .WithTags("Equipment API")
    .MapEquipmentApi();

app.MapGroup("/org/staff")
    .WithTags("Staff API")
    .MapStaffApi();

// Dapr pub/sub endpoints
app.MapGroup("/subscribe/org")
    .WithTags("Organization Subscribe API")
    .MapOrganizationSubscribeApi();

app.MapGroup("/subscribe/org/depart")
    .WithTags("Department Subscribe API")
    .MapDepartmentSubscribeApi();

app.MapGroup("/subscribe/org/building")
    .WithTags("Building Subscribe API")
    .MapBuildingSubscribeApi();

app.MapGroup("/subscribe/org/equipment")
    .WithTags("Equipment Subscribe API")
    .MapEquipmentSubscribeApi();

app.MapGroup("/subscribe/org/staff")
    .WithTags("Staff Subscribe API")
    .MapStaffSubscribeApi();

app.Run();