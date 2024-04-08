// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Gateway.FunctionalTests;

public class TestBase : IClassFixture<TestWebApplicationFactory<Program>>
{
    public TestBase(TestWebApplicationFactory<Program> factory)
    {
        Client = factory.CreateClient();
    }

    protected HttpClient Client { get; }
}