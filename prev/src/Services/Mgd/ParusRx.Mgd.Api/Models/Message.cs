// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mgd.Api.Models;

/// <summary>
/// Represents a message.
/// </summary>
public class Message
{
    /// <summary>
    /// Gets or sets the tax code of the message.
    /// </summary>
    [JsonPropertyName("Org_Taxcode")]
    public string Taxcode { get; set; }

    /// <summary>
    /// Gets or sets the code of the message.
    /// </summary>
    [JsonPropertyName("Org_Code_FK")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the KPP of the message.
    /// </summary>
    [JsonPropertyName("Org_KPP")]
    public string Kpp { get; set; }

    /// <summary>
    /// Gets or sets the document identifier of the message.
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
    /// Gets or sets the status of the message.
    /// </summary>
    [JsonPropertyName("Status")]
    [JsonConverter(typeof(NumberToStringConverter))]
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the record timestemp of the message.
    /// </summary>
    [JsonPropertyName("RecordTimeStamp")]
    [JsonConverter(typeof(MgdDateTimeConverter))]
    public DateTime? RecordTimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the data of the message.
    /// </summary>
    [JsonPropertyName("Data")]
    public string Data { get; set; }

    /// <summary>
    /// Gets or sets the signature of the message.
    /// </summary>
    [JsonPropertyName("Sign")]
    public string Sign { get; set; }

    /// <inheritdoc/>
    public override string ToString()
        => $"{{\"Org_Taxcode\":\"{Taxcode}\",\"Org_Code_FK\":\"{Code}\",\"Org_KPP\":\"{Kpp}\",\"Document_ID\":{DocumentId},\"Class\":{Class},\"Status\":{Status},\"RecordTimeStamp\":\"{RecordTimeStamp:yyyy-MM-dd HH:mm:ss}\")}}";
}
