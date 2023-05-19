// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Serilog;
global using System.Collections.Generic;
global using System.Reflection;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.OpenApi.Models;
global using ParusRx.ApiGateway;
global using ParusRx.ApiGateway.MqEndpoints;
global using ParusRx.EventBus;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;