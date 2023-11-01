// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.API.DataContracts;

[XmlRoot("updateEducationProfRequest")]
public record UpdateEducationProfRequest : BaseRequest
{
    [XmlElement("content")]
    [JsonPropertyName("content")]
    public EducationProf? Content { get; init; }
}
