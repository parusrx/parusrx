// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System.Net;
global using System.Text.Json;
global using Microsoft.Extensions.Logging;
global using Moq;
global using Moq.Protected;
global using ParusRx.Egisz.Common;
global using ParusRx.Egisz.Frmo.API.Handlers;
global using ParusRx.Egisz.Frmo.Domain;
global using ParusRx.Egisz.Frmo.Services;
global using ParusRx.EventBus;
global using ParusRx.Extensions.Http;
global using ParusRx.Storage;
global using ParusRx.Xml;
global using Xunit;