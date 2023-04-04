// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Xunit;
global using System.Collections.Generic;
global using System.Net;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using ParusRX.ApiGateway.MqEndpoints;
global using ParusRX.ApiGateway.FunctionalTests.Base;
global using ParusRX.EventBus.Abstractions;
global using ParusRX.EventBus.Events;