// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

[XmlRoot("getEducationPostgraduateResponse")]
public record GetEducationPostgraduateResponse : BaseResponse
{
    [XmlArray("content")]
    [XmlArrayItem("educationPostgraduate")]
    [JsonPropertyName("content")]
    public List<EducationPostgraduate>? Content { get; init; }
}
