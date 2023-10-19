// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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