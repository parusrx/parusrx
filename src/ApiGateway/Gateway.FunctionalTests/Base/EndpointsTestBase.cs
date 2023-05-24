// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Gateway.API.FunctionalTests.Base;

public class EndpointsTestBase : IClassFixture<TestWebApplicationFactory<Program>>
{
    public EndpointsTestBase(TestWebApplicationFactory<Program> factory)
    {
        Client = factory.CreateClient();
    }

    protected HttpClient Client { get; }
}