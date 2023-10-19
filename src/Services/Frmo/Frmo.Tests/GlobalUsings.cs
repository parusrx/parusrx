// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System.Net;
global using System.Net.Http.Json;
global using System.Text.Json;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Xunit;
global using Moq;
global using Moq.Protected;
global using ParusRx.EventBus;
global using ParusRx.Frmo.API;
global using ParusRx.Storage;
global using ParusRx.Xml;