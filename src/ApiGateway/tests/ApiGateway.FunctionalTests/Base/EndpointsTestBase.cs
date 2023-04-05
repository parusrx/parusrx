// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.ApiGateway.FunctionalTests.Base;

public class EndpointsTestBase : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _factory;

    public EndpointsTestBase(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
    }

    protected HttpClient Client { get; }
}