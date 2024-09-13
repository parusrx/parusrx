// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.FunctionalTests;

public class PubSubEndpointsTests
{
    [Fact]
    public async Task Post_DocumentTypesIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/document-types", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_EmployeeRolesIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/employee-roles", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_DepartmentsIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/departments/bulk", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_EmployeePositionsIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/employee-positions/bulk", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_LegalEntitiesIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/legal-entities/bulk", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_UserBulkDataSyncTaskIntegraionEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/users/bulk", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_FilesUploadIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/files", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_CreateDocumentGroupIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/document-groups", @event);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Post_SendToSigningIntegrationEvent_Returns_Created()
    {
        // Arrange
        var application = new HRlinkApplication();
        var client = application.CreateClient();
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());
        // Act
        var response = await client.PostAsJsonAsync("/api/v1/pubsub/document-groups/send-to-signing", @event);
        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
