﻿// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Frmr.Domain;

public record FullPerson : Person
{
    [XmlArray("personCard")]
    [XmlArrayItem("personCardItem")]
    [JsonPropertyName("personCard")]
    public PersonCard[]? PersonCard { get; init; }

    [XmlElement("educationCommon")]
    [JsonPropertyName("educationCommon")]
    public EducationCommon? EducationCommon { get; init; }

    [XmlElement("personAccreditation")]
    [JsonPropertyName("personAccreditation")]
    public PersonAccreditation? PersonAccreditation { get; init; }

    [XmlArray("educationExt")]
    [XmlArrayItem("educationExtItem")]
    [JsonPropertyName("educationExt")]
    public EducationExt[]? EducationExt { get; init; }

    [XmlArray("educationProf")]
    [XmlArrayItem("educationProfItem")]
    [JsonPropertyName("educationProf")]
    public EducationProf[]? EducationProf { get; init; }

    [XmlArray("educationPostgraduate")]
    [XmlArrayItem("educationPostgraduateItem")]
    [JsonPropertyName("educationPostgraduate")]
    public EducationPostgraduate[]? EducationPostgraduate { get; init; }

    [XmlArray("educationCert")]
    [XmlArrayItem("educationCertItem")]
    [JsonPropertyName("educationCert")]
    public EducationCert[]? EducationCert { get; init; }

    [XmlArray("personQualification")]
    [XmlArrayItem("personQualificationItem")]
    [JsonPropertyName("personQualification")]
    public PersonQualification[]? PersonQualification { get; init; }

    [XmlArray("personNomination")]
    [XmlArrayItem("personNominationItem")]
    [JsonPropertyName("personNomination")]
    public PersonNomination[]? PersonNomination { get; init; }

    [XmlArray("personOrganization")]
    [XmlArrayItem("personOrganizationItem")]
    [JsonPropertyName("personOrganization")]
    public PersonOrganization[]? PersonOrganization { get; init; }
}