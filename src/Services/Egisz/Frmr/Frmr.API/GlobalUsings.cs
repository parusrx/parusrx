﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Dapr;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.Extensions.Options;
global using ParusRx.Data.Oracle;
global using ParusRx.Data.PostgreSQL;
global using ParusRx.EventBus;
global using ParusRx.Extensions.Http;
global using ParusRx.Storage;
global using ParusRx.Frmr.API;
global using ParusRx.Frmr.API.DataContracts;
global using ParusRx.Frmr.API.Handlers;
global using ParusRx.Frmr.API.Services;
global using ParusRx.Frmr.Domain;
global using ParusRx.Xml;
global using System.Text.Json.Serialization;
global using System.Xml.Serialization;