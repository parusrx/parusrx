// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.Internal;

[XmlRoot("bulkDataSyncTaskDataItems")]
public sealed record BulkDataSyncTaskDataItems
{
    [XmlElement("data")]
    public List<BulkDataSyncTaskDataItem> Data { get; init; } = new();
}