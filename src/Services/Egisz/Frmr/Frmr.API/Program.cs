// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using ParusRx.Frmr.API.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddHttpResponseExceptionHandler();

builder.Services.AddIpsIdentityProvider(builder.Configuration);
builder.Services.AddFrmr(builder.Configuration["Frmr:Url"] ?? string.Empty);
builder.Services.AddIntegrationEventHandlers();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseCloudEvents();
app.MapSubscribeHandler();

app.MapHealthChecks("/health", new HealthCheckOptions { Predicate = _ => true });
app.MapHealthChecks("/liveness", new HealthCheckOptions { Predicate = r => r.Name.Contains("self") });

app.MapGroup("/person")
    .WithTags("Person API")
    .MapPersonApi();

app.MapGroup("/person/common")
    .WithTags("Person Common API")
    .MapEducationCommonApi();

app.MapGroup("/person/prof")
    .WithTags("Person Prof API")
    .MapEducationProfApi();

app.MapGroup("/person/postgraduate")
    .WithTags("Person Postgraduate API")
    .MapEducationPostgraduateApi();

app.MapGroup("/person/ext")
    .WithTags("Person Ext API")
    .MapEducationExtApi();

app.MapGroup("/person/cert")
    .WithTags("Person Cert API")
    .MapEducationCertApi();

app.MapGroup("/person/accreditation")
    .WithTags("Person Accreditation API")
    .MapPersonAccreditationApi();

app.MapGroup("/person/qualification")
    .WithTags("Person Qualification API")
    .MapPersonQualificationApi();

app.MapGroup("/person/card")
    .WithTags("Person Card API")
    .MapPersonCardApi();

app.MapGroup("/person/nomination")
    .WithTags("Person Nomination API")
    .MapPersonNominationApi();

app.MapGroup("/person/organization")
    .WithTags("Person Organization API")
    .MapPersonOrganizationApi();

app.MapGroup("/person/full")
    .WithTags("Full Person API")
    .MapFullPersonApi();


app.MapGroup("/subscribe/person")
    .WithTags("Person Subscribe API")
    .MapPersonSubscribeHandlers();

app.MapGroup("/subscribe/person/common")
    .WithTags("Person Common Subscribe API")
    .MapEducationCommonSubscribeHandlers();

app.MapGroup("/subscribe/person/prof")
    .WithTags("Person Prof Subscribe API")
    .MapEducationProfSubscribeHandlers();

app.MapGroup("/subscribe/person/postgraduate")
    .WithTags("Person Postgraduate Subscribe API")
    .MapEducationPostgraduateSubscribeHandlers();

app.MapGroup("/subscribe/person/ext")
    .WithTags("Person Ext Subscribe API")
    .MapEducationExtSubscribeHandlers();

app.MapGroup("/subscribe/person/cert")
    .WithTags("Person Cert Subscribe API")
    .MapEducationCertSubscribeHandlers();

app.MapGroup("/subscribe/person/accreditation")
    .WithTags("Person Accreditation Subscribe API")
    .MapPersonAccreditationSubscribeHandlers();

app.MapGroup("/subscribe/person/qualification")
    .WithTags("Person Qualification Subscribe API")
    .MapPersonQualificationSubscribeHandlers();

app.MapGroup("/subscribe/person/card")
    .WithTags("Person Card Subscribe API")
    .MapPersonCardSubscribeHandlers();

app.MapGroup("/subscribe/person/nomination")
    .WithTags("Person Nomination Subscribe API")
    .MapPersonNominationSubscribeHandlers();

app.MapGroup("/subscribe/person/organization")
    .WithTags("Person Organization Subscribe API")
    .MapPersonOrganizationSubscribeHandlers();

app.MapGroup("/subscribe/person/full")
    .WithTags("Full Person Subscribe API")
    .MapFullPersonSubscribeHandlers();

app.Run();