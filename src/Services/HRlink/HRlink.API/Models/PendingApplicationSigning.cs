// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record PendingApplicationSigning
{
    [XmlElement("signingType")]
    [JsonPropertyName("signingType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SignatureType? SigningType { get; init; }

    [XmlElement("signingRequestId")]
    [JsonPropertyName("signingRequestId")]
    public string? SigningRequestId { get; init; }

    [XmlElement("createdDate")]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; init; }

    [XmlElement("redirectUrl")]
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; init; }
}
