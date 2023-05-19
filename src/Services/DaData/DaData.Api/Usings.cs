// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Serilog;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Xml.Serialization;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using ParusRx.DaData.Api;
global using ParusRx.DaData.Api.Models;
global using ParusRx.DaData.Api.Services;
global using ParusRx.EventBus;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;
global using ParusRx.Storage.Abstractions;