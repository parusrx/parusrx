// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.DocumentTypeEndpoints;

[XmlRoot("DocumentType")]
public record DocumentType(
    [property: JsonPropertyName("id")] [property: XmlElement("Id")] string Id,
    [property: JsonPropertyName("name")] [property: XmlElement("Name")] string Name,
    [property: JsonPropertyName("visible")] [property: XmlElement("Visible")] bool Visible,
    [property: JsonPropertyName("system")] [property: XmlElement("System")] bool System,
    [property: JsonPropertyName("externalId")] [property: XmlElement("ExternalId")] string? ExternalId,
    [property: JsonPropertyName("version")] [property: XmlElement("Version")] int Version);