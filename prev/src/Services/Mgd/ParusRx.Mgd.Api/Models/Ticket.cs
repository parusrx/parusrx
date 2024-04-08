// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a ticket.
/// </summary>
public class Ticket
{
    /// <summary>
    /// Gets or sest the tax code of the ticket.
    /// </summary>
    [JsonPropertyName("Org_Taxcode")]
    public string TaxCode { get; set; }

    /// <summary>
    /// Gets or sets the code of the ticket.
    /// </summary>
    [JsonPropertyName("Org_Code_FK")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the KPP of the ticket.
    /// </summary>
    [JsonPropertyName("Org_KPP")]
    public string Kpp { get; set; }

    /// <summary>
    /// Gets or sets the document identifier of the ticket.
    /// </summary>
    [JsonPropertyName("Document_ID")]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string DocumentId { get; set; }

    /// <summary>
    /// Gets or sets the class of the message.
    /// </summary>
    [JsonPropertyName("Class")]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string Class { get; set; }

    /// <summary>
    /// Gets or sets the status of the ticket.
    /// </summary>
    [JsonPropertyName("Status")]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the record timestamp of the ticket.
    /// </summary>
    [JsonPropertyName("RecordTimeStamp")]
    [JsonConverter(typeof(MgdDateTimeConverter))]
    public DateTime? RecordTimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the result of validation sign of the ticket.
    /// </summary>
    [JsonPropertyName("ResultValidationSign")]
    public bool ResultValidationSign { get; set; }

    /// <summary>
    /// Gets or sets the signature of the ticket.
    /// </summary>
    [JsonPropertyName("Sign")]
    public string Sign { get; set; }
}
