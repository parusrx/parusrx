// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmo.Domain;

public record AdmissionDepartment
{
    [XmlElement("admissionDepartId")]
    [JsonPropertyName("admissionDepartId")]
    public string? AdmissionDepartId { get; init; }

    [XmlElement("admissionDepartName")]
    [JsonPropertyName("admissionDepartName")]
    public string? AdmissionDepartName { get; init; }
}
