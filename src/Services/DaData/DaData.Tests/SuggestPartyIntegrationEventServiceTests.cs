// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Text;
using Microsoft.Extensions.Logging;
using ParusRx.DaData.API.Integration;
using ParusRx.EventBus;
using ParusRx.Storage;

namespace ParusRx.DaData.UnitTests;

public class SuggestPartyIntegrationEventServiceTests
{
    private readonly Mock<IParusRxStore> _storeMock;
    private readonly Mock<ISuggestPartyService> _suggestPartyServiceMock;
    private readonly Mock<ILogger<SuggestPartyIntegrationEventService>> _loggerMock;
    private readonly SuggestPartyIntegrationEventService _service;

    public SuggestPartyIntegrationEventServiceTests()
    {
        _storeMock = new Mock<IParusRxStore>();
        _suggestPartyServiceMock = new Mock<ISuggestPartyService>();
        _loggerMock = new Mock<ILogger<SuggestPartyIntegrationEventService>>();

        _service = new SuggestPartyIntegrationEventService(_storeMock.Object, _suggestPartyServiceMock.Object, _loggerMock.Object);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallStoreReadDataRequestAsync_WhenInvoked()
    {
        // Arrange
        const string id = "B1B09433-AFC3-4981-96A6-6CB9A552F5EF";
        var integrationEvent = new MqIntegrationEvent(id);
        var cancellationToken = new CancellationToken();

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _storeMock.Verify(x => x.ReadDataRequestAsync(id), Times.Once);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallSuggestPartyServiceFindByIdAsync_WhenInvoked()
    {
        // Arrange
        const string id = "B1B09433-AFC3-4981-96A6-6CB9A552F5EF";
        var integrationEvent = new MqIntegrationEvent(id);
        var cancellationToken = new CancellationToken();
        var data = "<DaDataSuggestPartyRequest><Name>Test Company</Name></DaDataSuggestPartyRequest>";
        _storeMock.Setup(x => x.ReadDataRequestAsync(id)).ReturnsAsync(Encoding.UTF8.GetBytes(data));

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _suggestPartyServiceMock.Verify(x => x.FindByIdAsync(It.IsAny<DaDataSuggestPartyRequest>(), cancellationToken), Times.Once);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallStoreSaveDataResponseAsync_WhenInvoked()
    {
        // Arrange
        const string id = "B1B09433-AFC3-4981-96A6-6CB9A552F5EF";
        var integrationEvent = new MqIntegrationEvent(id);
        var cancellationToken = new CancellationToken();
        var data = "<DaDataSuggestPartyRequest><Name>Test Company</Name></DaDataSuggestPartyRequest>";
        var response = "<DaDataSuggestPartyResponse><Suggestions><Item><Value>Test Company</Value></Item></Suggestions></DaDataSuggestPartyResponse>";
        _storeMock.Setup(x => x.ReadDataRequestAsync(id)).ReturnsAsync(Encoding.UTF8.GetBytes(data));
        _suggestPartyServiceMock.Setup(x => x.FindByIdAsync(It.IsAny<DaDataSuggestPartyRequest>(), cancellationToken)).ReturnsAsync(Encoding.UTF8.GetBytes(response));

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _storeMock.Verify(x => x.SaveDataResponseAsync(id, Encoding.UTF8.GetBytes(response)), Times.Once);
    }

    [Fact]
    public async Task FindPartyByIdAsync_ShouldCallStoreErrorAsync_WhenExceptionThrown()
    {
        // Arrange
        const string id = "B1B09433-AFC3-4981-96A6-6CB9A552F5EF";
        var integrationEvent = new MqIntegrationEvent(id);
        var cancellationToken = new CancellationToken();
        var exception = new Exception("Test exception");
        _storeMock.Setup(x => x.ReadDataRequestAsync(id)).ThrowsAsync(exception);

        // Act
        await _service.FindPartyByIdAsync(integrationEvent, cancellationToken);

        // Assert
        _storeMock.Verify(x => x.ErrorAsync(id, "Test exception"), Times.Once);
        _loggerMock.Verify(x => x.Log(
            It.Is<LogLevel>(l => l == LogLevel.Information),
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Test exception"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never);
    }
}
