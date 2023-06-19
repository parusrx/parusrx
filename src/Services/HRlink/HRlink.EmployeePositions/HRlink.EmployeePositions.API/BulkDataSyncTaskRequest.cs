// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using ParusRx.HRlink.BulkDataSync;

namespace ParusRx.HRlink.EmployeePositions.API;

public record BulkDataSyncTaskRequest
{
    public BulkDataSyncTaskType Type { get; } = BulkDataSyncTaskType.EMPLOYEE_POSITIONS;
    public required IEnumerable<EmployeePositionItem> Data { get; init; }
}
