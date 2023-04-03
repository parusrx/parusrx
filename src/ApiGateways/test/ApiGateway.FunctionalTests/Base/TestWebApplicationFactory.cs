// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

using ParusRX.EventBus.Abstractions;

namespace ParusRX.ApiGateway.FunctionalTests.Base;

/// Test web application factory.
/// </summary>
/// <typeparam name="TProgram">The program.</typeparam>
public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    /// <inheritdoc/>
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => services.AddSingleton<IEventBus, FakeEventBus>());

        return base.CreateHost(builder);
    }
}