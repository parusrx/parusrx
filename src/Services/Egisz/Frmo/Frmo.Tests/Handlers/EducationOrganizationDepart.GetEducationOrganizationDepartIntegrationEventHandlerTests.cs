﻿// // Copyright (c) Alexander Bocharov.
// // Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Tests.Handlers;

public class GetEducationOrganizationDepartIntegrationEventHandlerTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<IEducationOrganizationDepartService> _serviceMock;
    private readonly Mock<ILogger<GetEducationOrganizationDepartIntegrationEventHandler>> _loggerMock;

    public GetEducationOrganizationDepartIntegrationEventHandlerTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _serviceMock = new Mock<IEducationOrganizationDepartService>();
        _loggerMock = new Mock<ILogger<GetEducationOrganizationDepartIntegrationEventHandler>>();
    }

    [Fact]
    public async Task HandleAsync_WithValidRequest_SaveDataResponse()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        DefaultRequest request = new()
        {
            Parameters = new()
            {
                { "eoDepartOid", "1" },
                { "key", "value" }
            }
        };

        var response = new SingleResponse<EducationOrganizationDepart>()
        {
            RequestId = Guid.NewGuid().ToString(),
            Content = new EducationOrganizationDepart
            {
                EoDepartOid = Guid.NewGuid().ToString()
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.GetAsync(It.IsAny<string>(), It.IsAny<SerializableDictionary>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

        var handler = new GetEducationOrganizationDepartIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.SaveDataResponseAsync(@event.Body, It.IsAny<byte[]>()), Times.Once());
        _serviceMock.Verify(s => s.GetAsync(It.IsAny<string>(), It.IsAny<SerializableDictionary>(), It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task HandleAsync_WithException_SaveErrorAndLogError()
    {
        // Arrange
        MqIntegrationEvent @event = new(Guid.NewGuid().ToString());

        DefaultRequest request = new()
        {
            Parameters = new()
            {
                { "key", "value" }
            }
        };

        _storeMock.Setup(s => s.ReadDataRequestAsync(@event.Body)).ReturnsAsync(XmlSerializerUtility.Serialize(request)!);
        _storeMock.Setup(s => s.ErrorAsync(@event.Body, It.IsAny<string>())).Returns(Task.CompletedTask);
        _serviceMock.Setup(s => s.GetAsync(It.IsAny<string>(), request.Parameters, It.IsAny<CancellationToken>())).ThrowsAsync(new Exception());

        var handler = new GetEducationOrganizationDepartIntegrationEventHandler(_storeMock.Object, _serviceMock.Object, _loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        _storeMock.Verify(s => s.ReadDataRequestAsync(@event.Body), Times.Once());
        _storeMock.Verify(s => s.ErrorAsync(@event.Body, It.IsAny<string>()), Times.Once());
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((o, t) => o.ToString()!.Contains($"Error handling integration event: {@event.Id} - {@event}")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()),
            Times.Once);
    }
}
