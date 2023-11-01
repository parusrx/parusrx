// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Tests.Services;

public class FullPersonServiceTests
{
    private readonly Mock<IOptionsSnapshot<FrmrSettings>> _settingsMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly FullPersonService _service;

    public FullPersonServiceTests()
    {
        _settingsMock = new Mock<IOptionsSnapshot<FrmrSettings>>();
        _settingsMock.Setup(s => s.Value).Returns(new FrmrSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        _service = new FullPersonService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);   
    }

    [Fact]
    public async Task GetAsync_ShouldReturnGetFullPersonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new SingleResponse<FullPerson>();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        CancellationTokenSource cts = new();

        // Act
        var response = await _service.GetAsync(queryParameters, cts.Token);

        // Assert
        Assert.Equal(expectedResponse, response);
    }
}
