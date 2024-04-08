// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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

app.MapGroup("/org/tpgg")
    .WithTags("Tpgg API")
    .MapTpggApi();

app.MapGroup("/org/territorialDepart")
    .WithTags("Territorial Department API")
    .MapTerritorialDepartApi();

app.MapGroup("/org/airAmbulance")
    .WithTags("Air Ambulance API")
    .MapAirAmbulanceApi();

app.MapGroup("/org/equipment")
    .WithTags("Equipment API")
    .MapEquipmentApi();

app.MapGroup("/org/mobileDeparts")
    .WithTags("Mobile Department API")
    .MapMobileDepartApi();

app.MapGroup("/org/houseGround")
    .WithTags("House Ground API")
    .MapHouseGroundApi();

app.MapGroup("/org/sites")
    .WithTags("Site API")
    .MapSiteApi();

app.MapGroup("/org/staff")
    .WithTags("Staff API")
    .MapStaffApi();

app.MapGroup("/org/licenses")
    .WithTags("License API")
    .MapLicenseApi();

app.MapGroup("/org/servicesInfo")
    .WithTags("Service Info API")
    .MapServiceInfoApi();

app.MapGroup("/org/telemedicine")
    .WithTags("Telemedicine API")
    .MapTelemedicineApi();

app.MapGroup("/eoDepart")
    .WithTags("Education Organization Department API")
    .MapEducationOrganizationDepartApi();

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

app.MapGroup("/subscribe/org/tpgg")
    .WithTags("Tpgg Subscribe API")
    .MapTpggSubscribeApi();

app.MapGroup("/subscribe/org/territorialDepart")
    .WithTags("Territorial Department Subscribe API")
    .MapTerritorialDepartSubscribeApi();

app.MapGroup("/subscribe/org/airAmbulance")
    .WithTags("Air Ambulance Subscribe API")
    .MapAirAmbulanceSubscribeApi();

app.MapGroup("/subscribe/org/equipment")
    .WithTags("Equipment Subscribe API")
    .MapEquipmentSubscribeApi();

app.MapGroup("/subscribe/org/mobileDeparts")
    .WithTags("Mobile Department Subscribe API")
    .MapMobileDepartSubscribeApi();

app.MapGroup("/subscribe/org/houseGround")
    .WithTags("House Ground Subscribe API")
    .MapHouseGroundSubscribeApi();

app.MapGroup("/subscribe/org/sites")
    .WithTags("Site Subscribe API")
    .MapSiteSubscribeApi();

app.MapGroup("/subscribe/org/staff")
    .WithTags("Staff Subscribe API")
    .MapStaffSubscribeApi();

app.MapGroup("/subscribe/org/licenses")
    .WithTags("License Subscribe API")
    .MapLicenseSubscribeApi();

app.MapGroup("/subscribe/org/servicesInfo")
    .WithTags("Service Info Subscribe API")
    .MapServiceInfoSubscribeApi();

app.MapGroup("/subscribe/org/telemedicine")
    .WithTags("Telemedicine Subscribe API")
    .MapTelemedicineSubscribeApi();

app.MapGroup("/subscribe/eoDepart")
    .WithTags("Education Organization Department Subscribe API")
    .MapEducationOrganizationDepartSubscribeApi();

app.Run();