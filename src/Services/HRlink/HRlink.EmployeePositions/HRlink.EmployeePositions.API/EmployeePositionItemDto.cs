// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml.Serialization;

namespace ParusRx.HRlink.EmployeePositions.API;

/// <summary>
/// Employee position DTO.
/// </summary>
/// <param name="ExternalId">The external identifier.</param>
/// <param name="Name">The name.</param>
public sealed record EmployeePositionItemDto(
    [property: XmlAttribute("externalId")] string ExternalId,
    [property: XmlAttribute("name")] string Name);

/// <summary>
/// Employee positions DTO.
/// </summary>
/// <param name="EmployeePositionItems">The employee position items.</param>
[XmlRoot("employeePositions")]
public sealed record EmployeePositionItemsDto(
    [property: XmlElement("employeePosition")] List<EmployeePositionItemDto> EmployeePositionItems);
