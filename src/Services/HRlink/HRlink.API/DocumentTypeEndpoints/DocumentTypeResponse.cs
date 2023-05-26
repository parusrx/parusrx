// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.HRlink.API.DocumentTypeEndpoints;

[XmlRoot("DocumentTypeResponse")]
public record DocumentTypeResponse(
    [property: JsonPropertyName("result")] [property: XmlElement("Result")] bool Result,
    [property: JsonPropertyName("documentTypes")] [XmlElement("DocumentTypes")] IEnumerable<DocumentType> DocumentTypes);