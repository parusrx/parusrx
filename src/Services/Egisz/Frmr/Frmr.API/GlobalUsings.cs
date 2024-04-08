// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using Dapr;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.Egisz.Common;
global using ParusRx.Egisz.Frmr.API;
global using ParusRx.Egisz.Frmr.API.Handlers;
global using ParusRx.Egisz.Frmr.Domain;
global using ParusRx.Egisz.Frmr.Services;
global using ParusRx.EventBus;
global using ParusRx.Extensions.Http;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using ProblemDetails = ParusRx.Egisz.Common.ProblemDetails;