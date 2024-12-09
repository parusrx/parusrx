// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Models;

public record DocumentGroupRegistry
{
    public string? Id { get; init; }
    public required string Name { get; init; }
    public required Document[] Documents { get; init; }
}

public record Document
{
    public string? Id { get; init; }
    public string? ExternalId { get; init; }
    public DocumentGroup? DocumentGroup { get; init; }
    public string? BaseDocumentId { get; init; }
    public string? BaseDocumentExternalId { get; init; }
    public string? FileName { get; init; }
    public string? Number { get; init; }
    public DateTime? Date { get; init; }
    public bool Draft { get; init; }
    public bool Deleted { get; init; }
    public bool Signed { get; init; }
    public bool Rejected { get; init; }
    public DateTime? CreatedDate { get; init; }
    public string? SigningOrder { get; init; }
    public DocumentSigner? HeadManager { get; init; }
    public DocumentSigner[]? Employees { get; init; }
    public DocumentSigner[]? Participants { get; init; }
    public DateTime? DocflowFinishedDate { get; init; }
    public DateTime? AnnulledDate { get; init; }
}

public record DocumentGroup
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public long? Version { get; init; }
}

public record DocumentSigner 
{
    public string? Id { get; init; }
    public string? EmployeeId { get; init; }
    public string? ExternalId { get; init; }
    public string? LastName { get; init; }
    public string? FirstName { get; init; }
    public string? Patronymic { get; init; }
    public DocumentSignerPosition? Position { get; init; }
    public string? ParticipantId { get; init; }
    public string? SignerType { get; init; }
    public long? SigningOrder { get; init; }
    public DateTime? SeenDate { get; init; }
    public DateTime? SignedDate { get; init; }
    public DateTime? RejectedDate { get; init; }
    public DateTime? SigningAvailabilityDate { get; init; }
    public string? RejectionComment { get; init; }
}

public record DocumentSignerPosition
{
    public string? Id { get; init; }
    public string? Name { get; init; }
}