// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Tests.BulkDataSyncTasks;

public class BulkDataSyncTaskClientTests
{
    [Fact]
    public async Task CreateBulkDataSyncTaskAsync_ShouldReturnCreateBulkDataSyncTaskResponse_WhenRequestIsValid()
    {
        // Arrange
        var baseUri = "https://demo.hr-link.ru";
        var clientId = "78DB35C3-64E4-4D06-B34D-793070E970C6";
        var apiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9";

        var request = new CreateBulkDataSyncTaskRequest<string>(BulkDataSyncTaskType.EMPLOYEE_POSITIONS, new List<string>());

        var responseMock = new HttpResponseMessage()
        {
            Content = new StringContent(JsonSerializer.Serialize(new CreateBulkDataSyncTaskResponse(true, new BulkDataSyncTaskItem(Guid.NewGuid().ToString())))),
            StatusCode = HttpStatusCode.OK
        };

        responseMock.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        httpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(responseMock)
            .Verifiable();

        var httpClient = new HttpClient(httpMessageHandler.Object);
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(_ => _.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        var bulkDataSyncTaskClient = new BulkDataSyncTaskClient(httpClientFactoryMock.Object);

        // Act
        var result = await bulkDataSyncTaskClient.CreateBulkDataSyncTaskAsync(baseUri, clientId, apiToken, request, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreateBulkDataSyncTaskResponse>(result);
    }

    [Fact]
    public async Task GetFullStatusBulkDataSyncTaskByIdAsync_ShouldReturnBulkDataSyncTaskResponse_WhenRequestIsValid()
    {
        // Arrange
        var baseUri = "https://demo.hr-link.ru";
        var clientId = "78DB35C3-64E4-4D06-B34D-793070E970C6";
        var apiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9";
        var id = "4198FE1F-6E76-4F84-AB56-D6FA6A9C7610";

        var bulkDataSyncTaskResponseMock = new Mock<BulkDataSyncTaskResponse>();

        var responseMock = new HttpResponseMessage()
        {
            Content = new StringContent(JsonSerializer.Serialize(bulkDataSyncTaskResponseMock.Object)),
            StatusCode = HttpStatusCode.OK
        };

        responseMock.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        httpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(responseMock)
            .Verifiable();

        var httpClient = new HttpClient(httpMessageHandler.Object);
        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        httpClientFactoryMock
            .Setup(_ => _.CreateClient(It.IsAny<string>()))
            .Returns(httpClient);

        var bulkDataSyncTaskClient = new BulkDataSyncTaskClient(httpClientFactoryMock.Object);

        // Act
        var result = await bulkDataSyncTaskClient.GetFullStatusBulkDataSyncTaskByIdAsync(baseUri, clientId, apiToken, id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BulkDataSyncTaskResponse>(result);
    }
}