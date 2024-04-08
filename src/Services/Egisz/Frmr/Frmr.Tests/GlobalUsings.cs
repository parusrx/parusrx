// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

global using System.Net;
global using System.Text.Json;
global using Microsoft.Extensions.Logging;
global using Moq;
global using Moq.Protected;
global using ParusRx.Egisz.Common;
global using ParusRx.Egisz.Frmr.API.Handlers;
global using ParusRx.Egisz.Frmr.Domain;
global using ParusRx.Egisz.Frmr.Services;
global using ParusRx.EventBus;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using Xunit;
