﻿// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

global using System;
global using System.Collections.Generic;
global using System.Data;
global using System.Globalization;
global using System.IO;
global using System.Net;
global using System.Net.Http;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;
global using System.Xml;
global using System.Xml.Serialization;
global using System.Xml.XPath;
global using Dapper;
global using Dapr;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Oracle.ManagedDataAccess.Client;
global using Parus.Data.Abstractions;
global using Parus.Data.Core;
global using Parus.Data.Oracle;
global using Parus.Data.PostgreSql;
global using ParusRx.EventBus.Abstractions;
global using ParusRx.EventBus.Events;
global using ParusRx.Extensions;
global using ParusRx.Mgd.Api;
global using ParusRx.Mgd.Api.Infrastructure.Handlers;
global using ParusRx.Mgd.Api.Infrastructure.Internal;
global using ParusRx.Mgd.Api.Infrastructure.Services;
global using ParusRx.Mgd.Api.Infrastructure.Stores;
global using ParusRx.Mgd.Api.Infrastructure.Xml;
global using ParusRx.Mgd.Api.Integration;
global using ParusRx.Mgd.Api.Integration.Handlers;
global using ParusRx.Mgd.Api.Models;
global using ParusRx.Stores.Abstractions;
global using Serilog.Context;
