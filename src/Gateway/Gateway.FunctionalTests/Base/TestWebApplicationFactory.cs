// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ParusRx.Gateway.FunctionalTests;

/// <summary>
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