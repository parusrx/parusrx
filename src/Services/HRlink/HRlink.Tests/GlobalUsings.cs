// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using Microsoft.Extensions.Logging;
global using Moq;
global using Moq.Protected;
global using ParusRx.EventBus;
global using ParusRx.HRlink.API.Authorization;
global using ParusRx.HRlink.API.BulkDataSyncTasks;
global using ParusRx.HRlink.API.Handlers;
global using ParusRx.HRlink.API.Models;
global using ParusRx.HRlink.API.Services;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using System.Net;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text.Json;
global using Xunit;