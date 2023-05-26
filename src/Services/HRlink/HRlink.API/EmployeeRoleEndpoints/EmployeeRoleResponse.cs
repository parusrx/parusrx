// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.EmployeeRoleEndpoints;

[XmlRoot("EmployeeRoleResponse")]
public record EmployeeRoleResponse(
    [property: JsonPropertyName("result")] [property: XmlElement("Result")] bool Result,
    [property: JsonPropertyName("employeeRoles")] [property: XmlElement("EmployeeRoles")] IEnumerable<EmployeeRole> EmployeeRoles);