// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Xml.Serialization;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Options;
global using ParusRx.DaData.API.Integration;
global using ParusRx.DaData.API.Integration.Handlers;
global using ParusRx.DaData.API.Models;
global using ParusRx.DaData.API.Services;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.EventBus;