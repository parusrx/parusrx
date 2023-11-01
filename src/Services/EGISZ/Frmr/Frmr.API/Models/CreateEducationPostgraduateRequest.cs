// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

[XmlRoot("createEducationPostgraduateRequest")]
public record CreateEducationPostgraduateRequest : BaseRequest
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public EducationPostgraduate? Content { get; init; }
}
