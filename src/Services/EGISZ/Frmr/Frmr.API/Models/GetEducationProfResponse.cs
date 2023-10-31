// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API;

[XmlRoot("getEducationProfResponse")]
public record GetEducationProfResponse : BaseResponse
{
    [XmlArray("content")]
    [XmlArrayItem("educationProf")]
    [JsonPropertyName("content")]
    public List<EducationProf>? Content { get; init; }
}
