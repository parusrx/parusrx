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

namespace ParusRx.HRlink.EmployeeRoles.FunctionalTests;

public class EmployeeRoleEndpointsTests
{
    [Fact]
    public async void GetHealthChecks_ReturnsOk()
    {
        // Arrange
        await using var application = new EmployeeRoleApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync("/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GetLiveness_ReturnsOk()
    {
        // Arrange
        await using var application = new EmployeeRoleApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.GetAsync("/liveness");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void SendEmployeeRolesRequestOnIntegrationEvent_ReturnsCreated()
    {
        // Arrange
        await using var application = new EmployeeRoleApplication();
        var client = application.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/employeeRoles", new MqIntegrationEvent("XXXXXX"));

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    class EmployeeRoleApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var employeeRolesRequest = new EmployeeRolesRequest
            {
                Url = "https://demo.hr-link.ru",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            };

            var employeeRolesResponse = new EmployeeRolesResponse
            {
                Result = true,
                EmployeeRoles = new List<EmployeeRoleItem>
                {
                    new EmployeeRoleItem("7CC0C753-0FE9-4153-9EAE-597582292B1B", "Role 1", "Description 1"),
                    new EmployeeRoleItem("1BB83438-F940-41EA-9E63-806C66CEC566", "Role 2", "Description 2"),
                    new EmployeeRoleItem("46169F2E-5387-4EF7-94E3-88F9CA6ED643", "Role 3", "Description 3"),
                    new EmployeeRoleItem("83F431FD-4CAE-4BE4-B34E-D98C2C195D32", "Role 4", "Description 4")
                }
            };

            var mockResponse = new HttpResponseMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(employeeRolesResponse)),
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
                .ReturnsAsync(mockResponse)
                .Verifiable();

            var httpClient = new HttpClient(httpMessageHandler.Object);

            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory
                .Setup(_ => _.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var store = new Mock<IParusRxStore>();
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            store.Setup(_ => _.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(XmlSerializerUtility.Serialize(employeeRolesRequest));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            store.Setup(_ => _.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);

            builder.ConfigureServices(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ => store.Object));
                services.Replace(ServiceDescriptor.Scoped(_ => httpClientFactory.Object));
            });

            return base.CreateHost(builder);
        }
    }
}