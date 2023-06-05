// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http.Headers;

using Moq.Protected;

using Newtonsoft.Json;

namespace ParusRx.HRLink.EmployeeRole.UnitTests.Helpers;

public class HttpClientHelper
{
    public static Mock<HttpMessageHandler> GetResults<T>(T response)
    {
        var mockResponse = new HttpResponseMessage()
        {
            Content = new StringContent(JsonConvert.SerializeObject(response)),
            StatusCode = HttpStatusCode.OK
        };

        mockResponse.Content.Headers.ContentType =
        new MediaTypeHeaderValue("application/json");

        var mockHandler = new Mock<HttpMessageHandler>();

        mockHandler
        .Protected()
        .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
        .ReturnsAsync(mockResponse);

        return mockHandler;
    }
}
