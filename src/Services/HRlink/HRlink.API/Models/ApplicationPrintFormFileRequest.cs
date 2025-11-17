// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

[XmlRoot("printFormFileRequest")]
public sealed record ApplicationPrintFormFileRequest
{
    [XmlElement("authorization")]
    public required AuthorizationContext Authorization { get; init; }

    [XmlElement("applicationId")]
    public required string ApplicationId { get; init; }
}
