// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace Frmr.Tests.Services;

public class ResolutionClientTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly ResolutionClient _client;

    public ResolutionClientTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        var httpClient = new HttpClient(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new Uri("https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0/")
        };

        _client = new ResolutionClient(httpClient);
    }

    [Fact]
    public async Task ListAsync_ShouldReturnListResolutionResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ListResponse<Resolution>();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        CancellationTokenSource cts = new();

        // Act
        var response = await _client.ListAsync(queryParameters, cts.Token);

        // Assert
        Assert.Equal(expectedResponse.RequestId, response.RequestId);
        Assert.Equal(expectedResponse.Message, response.Message);
        Assert.Equal(expectedResponse.Content, response.Content);
    }
}
