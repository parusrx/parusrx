// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.EmployeePositions.API.Entities;

/// <summary>
/// Employee position.
/// </summary>
/// <param name="Id">The identifier.</param>
/// <param name="Name">The name.</param>
/// <param name="ExternalId">The external identifier.</param>
/// <param name="Version">The version.</param>
public record EmployeePosition(string Id, string Name, string ExternalId, int Version);
