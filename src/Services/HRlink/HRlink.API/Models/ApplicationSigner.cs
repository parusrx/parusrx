// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record ApplicationSigner
{
    [XmlElement("id")]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [XmlElement("lastName")]
    [JsonPropertyName("lastName")]
    public string? LastName { get; init; }

    [XmlElement("firstName")]
    [JsonPropertyName("firstName")]
    public string? FirstName { get; init; }

    [XmlElement("patronymic")]
    [JsonPropertyName("patronymic")]
    public string? Patronymic { get; init; }

    [XmlElement("participantId")]
    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; init; }

    [XmlElement("signingOrder")]
    [JsonPropertyName("signingOrder")]
    public long? SigningOrder { get; init; }

    [XmlElement("clientUserId")]
    [JsonPropertyName("clientUserId")]
    public string? ClientUserId { get; init; }

    [XmlElement("employee")]
    [JsonPropertyName("employee")]
    public EmployeeWithPositionAndDepartmentAndNumber? Employee { get; init; }

    [XmlElement("signingAvailabilityDate")]
    [JsonPropertyName("signingAvailabilityDate")]
    public DateTime? SigningAvailabilityDate { get; init; }

    [XmlElement("madeDecision")]
    [JsonPropertyName("madeDecision")]
    public bool? MadeDecision { get; init; }

    [XmlElement("signedDate")]
    [JsonPropertyName("signedDate")]
    public DateTime? SignedDate { get; init; }

    [XmlElement("signingInfo")]
    [JsonPropertyName("signingInfo")]
    public PendingApplicationSigning? SigningInfo { get; init; }

    [XmlElement("rejectedDate")]
    [JsonPropertyName("rejectedDate")]
    public DateTime? RejectedDate { get; init; }

    [XmlElement("rejectionComment")]
    [JsonPropertyName("rejectionComment")]
    public string? RejectionComment { get; init; }

    [XmlElement("substitution")]
    [JsonPropertyName("substitution")]
    public Substitution? Substitution { get; init; }
}
