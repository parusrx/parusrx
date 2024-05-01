// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using System.Text.Json.Serialization;
global using System.Xml.Serialization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Dapr;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.Astral.API.Models;
global using ParusRx.Astral.API.Handlers;
global using ParusRx.Astral.API.Services;
global using ParusRx.Astral.Domain;
global using ParusRx.EventBus;
global using ParusRx.Storage;
global using ParusRx.Xml;