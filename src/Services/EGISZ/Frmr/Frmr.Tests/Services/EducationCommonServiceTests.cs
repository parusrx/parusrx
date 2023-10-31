// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.Frmr.API.Services;

namespace ParusRx.Frmr.Tests;

public class EducationCommonServiceTests
{
    private readonly Mock<IOptionsSnapshot<FrmrSettings>> _settingsMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly EducationCommonService _service;

    public EducationCommonServiceTests()
    {
        _settingsMock = new Mock<IOptionsSnapshot<FrmrSettings>>();
        _settingsMock.Setup(s => s.Value).Returns(new FrmrSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        _service = new EducationCommonService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnGetEducationCommonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new GetEducationCommonResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.GetAsync(queryParameters);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreateEducationCommonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var educationCommon = new EducationCommon();
        var expectedResponse = new CreateEducationCommonResponse
        {
            RequestId = Guid.NewGuid().ToString(),
            Content = new Entity { EntityId = Guid.NewGuid().ToString() }
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.CreateAsync(queryParameters, educationCommon);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdateEducationCommonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var educationCommon = new EducationCommon();
        var expectedResponse = new UpdateEducationCommonResponse
        {
            RequestId = Guid.NewGuid().ToString()
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.UpdateAsync(queryParameters, educationCommon);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnDeleteEducationCommonResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new DeleteEducationCommonResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.DeleteAsync(queryParameters);

        // Assert
        Assert.Equal(expectedResponse, response);
    }
}
