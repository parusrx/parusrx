// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

using Moq;
using Moq.Protected;

using ParusRx.EventBus.Events;
using ParusRx.Storage;
using ParusRx.Xml;

namespace ParusRx.HRLink.DocumentType.FunctionalTests;

public class DocumentTypeEndpointsTests
{
    [Fact]
    public async void GetHealthCheck_ReturnsOk()
    {
        // Arrange
        await using var application = new DocumentTypeApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync("/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GetLiveCheck_ReturnsOk()
    {
        // Arrange
        await using var application = new DocumentTypeApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync("/liveness");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void SendDocumentTypesRequestOnIntegrationEvent_ReturnsCreated()
    {
        // Arrange
        await using var application = new DocumentTypeApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/documentTypes", new MqIntegrationEvent("XXXXXX"));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    class DocumentTypeApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var documentTypeRequest = new DocumentTypesRequest
            {
                Url = "https://demo.hr-link.ru",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            };

            var documentTypesResponse = new DocumentTypesResponse
            {
                Result = true,
                DocumentTypes = new List<DocumentTypeItem>
                {
                    new DocumentTypeItem("E3027027-0B03-4505-9064-75EFDDED1B23", "Document type 1", true, true, null, 1),
                    new DocumentTypeItem("D2B76838-8DAE-4D22-ABD9-52AB0B056DE7", "Document type 2", true, true, null, 1),
                    new DocumentTypeItem("9340FC1A-1C04-4E13-A1E4-FCF326E45333", "Document type 3", true, true, null, 1),
                    new DocumentTypeItem("A9303F9E-4E2D-487D-80C5-44BD1E408ECE", "Document type 4", true, true, null, 1)
            }
            };

            var mockResponse = new HttpResponseMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(documentTypesResponse)),
                StatusCode = HttpStatusCode.OK
            };

            mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(httpMessageHandler.Object);

            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateClient(string.Empty)).Returns(httpClient);

            var store = new Mock<IParusRxStore>();
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            store.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(XmlSerializerUtility.Serialize(documentTypeRequest));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            store.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);


            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ => store.Object));
                services.Replace(ServiceDescriptor.Scoped(_ => httpClientFactory.Object));
            });

            return base.CreateHost(builder);
        }
    }
}