// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
