// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;
global using System.Xml.Serialization;
global using Dapr;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Parus.Data.Core;
global using Parus.Data.Oracle;
global using Parus.Data.PostgreSql;
global using ParusRx.DaData.Api;
global using ParusRx.DaData.Api.Integration;
global using ParusRx.DaData.Api.Integration.Handlers;
global using ParusRx.DaData.Api.Models;
global using ParusRx.DaData.Api.Services;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;
global using ParusRx.Extensions;
global using ParusRx.Stores.Abstractions;
global using Serilog.Context;
