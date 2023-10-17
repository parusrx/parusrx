// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Gateway.FunctionalTests;

public class TestBase : IClassFixture<TestWebApplicationFactory<Program>>
{
    public TestBase(TestWebApplicationFactory<Program> factory)
    {
        Client = factory.CreateClient();
    }

    protected HttpClient Client { get; }
}