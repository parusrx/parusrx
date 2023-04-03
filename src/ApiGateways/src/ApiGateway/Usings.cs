// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Serilog;
global using System.Collections.Generic;
global using System.Reflection;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.OpenApi.Models;
global using ParusRX.Api.Gateway;
global using ParusRX.EventBus;
global using ParusRX.EventBus.Abstractions;
global using ParusRX.EventBus.Events;