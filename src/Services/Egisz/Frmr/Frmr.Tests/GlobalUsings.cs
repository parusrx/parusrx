// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using Xunit;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Moq;
global using Moq.Protected;
global using ParusRx.EventBus;
global using ParusRx.Frmr.Domain;
global using ParusRx.Frmr.API;
global using ParusRx.Frmr.API.DataContracts;
global using ParusRx.Frmr.API.Handlers;
global using ParusRx.Frmr.API.Services;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using System.Net;
global using System.Text.Json;