// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System;
global using System.Net;
global using System.Threading.Tasks;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.OpenApi.Models;
global using ParusRx.EventBus;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;
global using ParusRx.WebProxy.Models;
