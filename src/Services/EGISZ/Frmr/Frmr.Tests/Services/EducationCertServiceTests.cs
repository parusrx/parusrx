// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Tests;

public class EducationCertServiceTests
{
    private readonly Mock<IOptionsSnapshot<FrmrSettings>> _settingsMock;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly EducationCertService _service;

    public EducationCertServiceTests()
    {
        _settingsMock = new Mock<IOptionsSnapshot<FrmrSettings>>();
        _settingsMock.Setup(s => s.Value).Returns(new FrmrSettings { Url = "https://ips.test.egisz.rosminzdrav.ru/4f52d90e921a0" });

        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();

        _service = new EducationCertService(new HttpClient(_httpMessageHandlerMock.Object), _settingsMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnGetAllEducationCertResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new ListResponse<EducationCert>();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.GetAllAsync(queryParameters, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse.RequestId, response.RequestId);
        Assert.Equal(expectedResponse.Message, response.Message);
        Assert.Equal(expectedResponse.Content, response.Content);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreateEducationCertResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var educationCert = new EducationCert();
        var expectedResponse = new SingleResponse<Entity>
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
        var response = await _service.CreateAsync(queryParameters, educationCert, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdateEducationCertResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var educationCert = new EducationCert();
        var expectedResponse = new DefaultResponse
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
        var response = await _service.UpdateAsync(queryParameters, educationCert, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnDeleteEducationCertResponse_WhenRequestIsSuccessful()
    {
        // Arrange
        var queryParameters = new Dictionary<string, string?> { { "key", "value" } };
        var expectedResponse = new DefaultResponse();

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
            });

        // Act
        var response = await _service.DeleteAsync(queryParameters, CancellationToken.None);

        // Assert
        Assert.Equal(expectedResponse, response);
    }
}
