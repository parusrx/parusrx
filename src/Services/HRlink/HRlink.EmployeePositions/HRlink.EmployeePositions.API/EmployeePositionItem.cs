// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.EmployeePositions.API;

/// <summary>
/// Employee position.
/// </summary>
/// <param name="ExternalId">The external identifier.</param>
/// <param name="Name">The name.</param>
public record EmployeePositionItem(string ExternalId, string Name);