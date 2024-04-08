// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.Tests;

internal class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly object _response;

    public MockHttpMessageHandler(object response)
    {
        _response = response;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(JsonSerializer.Serialize(_response))
        };

        return Task.FromResult(response);
    }
}
