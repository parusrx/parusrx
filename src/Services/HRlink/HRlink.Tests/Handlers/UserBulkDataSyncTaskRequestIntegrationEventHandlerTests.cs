// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Tests.Handlers;

public class UserBulkDataSyncTaskRequestIntegrationEventHandlerTests
{
    [Fact]
    public async Task HandleAsync_ShouldSaveResponseToStore()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());

        var userBulkDataSyncTaskRequest = new CreateUserListBulkDataSyncTaskRequest 
        {
            Authorization = new AuthorizationContext
            {
                Url = "https://demo.hr-link.ru",
                ClientId = "78DB35C3-64E4-4D06-B34D-793070E970C6",
                ApiToken = "81255B76-7F18-46E2-93C0-7ED60BE814F9"
            },
            Users = new[] 
            {
                new User {
                    ExternalId = "1",
                    LastName = "Dou",
                    FirstName = "John",
                    Gender = Gender.MALE,
                    BirthDate = new DateTime(1980, 1, 1),
                    Phone = "+7 (999) 999-99-99",
                    Email = "john.dou@example.com",
                    PersonalDocuments = new List<PersonalDocument> 
                    {
                        new PersonalDocument 
                        {
                            Type = PersonalDocumentType.PASSPORT,
                            Number = "123456",
                            SerialNumber = "1234",
                            Citizenship = "RUS",
                            IssuedDate = new DateTime(2000, 1, 1),
                            IssuingAuthorityCode = "000-000",
                            IssuingAuthority = "IssuingAuthority",
                            BirthPlace = "BirthPlace"
                        }
                    },
                    Employees = new List<Employee>
                    {
                        new Employee 
                        {
                            ExternalId = "2",
                            LegalEntityExternalId = "3",
                            DepartmentExternalId = "4",
                            PositionExternalId = "5"
                        }
                    }
                }
            }
        };

        string taskId = "12F75F90-6E2E-4872-B1B1-70AE28449526";
        var createBulkDataSyncTaskResponse = new CreateBulkDataSyncTaskResponse(true, new BulkDataSyncTaskItem(taskId));
        var bulkDataSyncTaskResponse = new BulkDataSyncTaskResponse
        {
            Result = true,
            BulkDataSyncTask = new BulkDataSyncTask 
            {
                Id = taskId,
                Type = BulkDataSyncTaskType.CLIENT_USERS,
                State = BulkDataSyncTaskState.FINISHED,
                Counts = new BulkDataSyncTaskCounts
                {
                    Total = 1,
                    Processed = 0,
                    Succeeded = 1,
                    Failed = 0
                },
                Data = new List<BulkDataSyncTaskDataItem>
                {
                    new()
                    {
                        Id = "AB144D31-E79B-4F6A-9EDE-EDE40C607AF6",
                        ExternalId = "1",
                        State = BulkDataSyncTaskDataItemState.SYNCED,
                        Result = BulkDataSyncTaskDataItemResult.UPDATED
                    }
                },
                CreatedDate = DateTime.UtcNow
            }
        };

        var clientMock = new Mock<IBulkDataSyncTaskClient>();
        clientMock.Setup(x => x.CreateBulkDataSyncTaskAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CreateBulkDataSyncTaskRequest<User>>(), It.IsAny<CancellationToken>())).ReturnsAsync(createBulkDataSyncTaskResponse);
        clientMock.Setup(x => x.GetFullStatusBulkDataSyncTaskByIdAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(bulkDataSyncTaskResponse);

        var storeMock = new Mock<IParusRxStore>();
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        storeMock.Setup(x => x.ReadDataRequestAsync(It.IsAny<string>())).ReturnsAsync(XmlSerializerUtility.Serialize(userBulkDataSyncTaskRequest));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        storeMock.Setup(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>())).Returns(Task.CompletedTask);

        var loggerMock = new Mock<ILogger<UserBulkDataSyncTaskRequestIntegrationEventHandler>>();

        var handler = new UserBulkDataSyncTaskRequestIntegrationEventHandler(storeMock.Object, clientMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.SaveDataResponseAsync(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once);
    }

    [Fact]
    public async Task HandleAsync_ShouldLogErrorAndSaveErrorToStore()
    {
        // Arrange
        var @event = new MqIntegrationEvent(Guid.NewGuid().ToString());
        var exception = new Exception("Test exception");

        var storeMock = new Mock<IParusRxStore>();
        storeMock.Setup(x => x.ReadDataRequestAsync(@event.Body)).ThrowsAsync(exception);

        var clientMock = new Mock<IBulkDataSyncTaskClient>();
        var loggerMock = new Mock<ILogger<UserBulkDataSyncTaskRequestIntegrationEventHandler>>();

        var handler = new UserBulkDataSyncTaskRequestIntegrationEventHandler(storeMock.Object, clientMock.Object, loggerMock.Object);

        // Act
        await handler.HandleAsync(@event);

        // Assert
        storeMock.Verify(x => x.ErrorAsync(@event.Body, exception.Message), Times.Once);
        loggerMock.Verify(x => x.Log(
            LogLevel.Error,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString() == "Test exception"),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)), Times.Never);
    }
}
