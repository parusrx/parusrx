// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.EmployeeRoleEndpoints;

[XmlRoot("EmployeeRole")]
public record EmployeeRole(
    [property: JsonPropertyName("id")] [XmlElement("Id")] string Id,
    [property: JsonPropertyName("name")] [XmlElement("Name")] string Name,
    [property: JsonPropertyName("description")] [XmlElement("Description")] string Description);
