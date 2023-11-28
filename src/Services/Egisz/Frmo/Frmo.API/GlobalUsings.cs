// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System.Net.Http.Json;
global using Dapr;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.Egisz.Common;
global using ParusRx.Egisz.Frmo.API;
global using ParusRx.Egisz.Frmo.API.Handlers;
global using ParusRx.Egisz.Frmo.Domain;
global using ParusRx.Egisz.Frmo.Services;
global using ParusRx.EventBus;
global using ParusRx.Extensions.Http;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using ProblemDetails = ParusRx.Egisz.Common.ProblemDetails;