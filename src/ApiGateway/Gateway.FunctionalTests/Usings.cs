// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Xunit;
global using System.Net;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using ParusRx.Gateway.API.MqEndpoints;
global using ParusRx.Gateway.API.FunctionalTests.Base;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;