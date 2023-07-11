// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.EmployeePositions.API.BulkDataSync;

[XmlRoot("createEmployeePositionsBulkDataSyncTaskRequest")]
public sealed record CreateEmployeePositionsBulkDataSyncTaskRequest
{
    [XmlElement("authorization")]
    public required Authorization Authorization { get; init; }
    [XmlElement("employeePositions")]
    public required EmployeePositionItemsDto EmployeePositions { get; init; }
}

public sealed record Authorization
{
    [XmlElement("url")]
    public required string Url { get; init; }
    [XmlElement("clientId")]
    public required string ClientId { get; init; }
    [XmlElement("apiToken")]
    public required string ApiToken { get; init; }
}
