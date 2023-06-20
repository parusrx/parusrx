// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Xml.Serialization;

namespace ParusRx.HRlink.EmployeePositions.API;

/// <summary>
/// Employee position DTO.
/// </summary>
/// <param name="ExternalId">The external identifier.</param>
/// <param name="Name">The name.</param>
public sealed record EmployeePositionItemDto 
{
    [XmlAttribute("externalId")]
    public required string ExternalId { get; init; }

    [XmlAttribute("name")]
    public required string Name { get; init; }
}

/// <summary>
/// Employee positions DTO.
/// </summary>
/// <param name="EmployeePositionItems">The employee position items.</param>
[XmlRoot("employeePositions")]
public sealed record EmployeePositionItemsDto 
{
    [XmlElement("employeePosition")]
    public List<EmployeePositionItemDto> EmployeePositionItems { get; init; } = new();
}

internal static class EmployeePositionItemDtoExtensions
{
    public static EmployeePositionItem ToEmployeePositionItem(this EmployeePositionItemDto dto)
        => new(dto.ExternalId, dto.Name);
}

internal static class EmployeePositionItemsDtoExtensions
{
    public static IEnumerable<EmployeePositionItem> ToEmployeePositionItems(this EmployeePositionItemsDto dto)
        => dto.EmployeePositionItems.Select(x => x.ToEmployeePositionItem());
}