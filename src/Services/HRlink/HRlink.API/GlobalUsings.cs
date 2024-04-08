// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using System.Text.Json.Serialization;
global using System.Xml.Serialization;
global using Dapr;
global using Microsoft.AspNetCore.Mvc;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.EventBus;
global using ParusRx.HRlink.API.Authorization;
global using ParusRx.HRlink.API.Handlers;
global using ParusRx.HRlink.API.Models;
global using ParusRx.HRlink.API.BulkDataSyncTasks;
global using ParusRx.HRlink.API.Services;
global using ParusRx.Storage;
global using ParusRx.Xml;
