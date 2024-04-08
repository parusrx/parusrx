// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Egisz.Frmo.Domain;

public record AdmissionDepart
{
    [XmlElement("admissionDepartId")]
    [JsonPropertyName("admissionDepartId")]
    public string? AdmissionDepartId { get; init; }

    [XmlElement("admissionDepartName")]
    [JsonPropertyName("admissionDepartName")]
    public string? AdmissionDepartName { get; init; }
}
