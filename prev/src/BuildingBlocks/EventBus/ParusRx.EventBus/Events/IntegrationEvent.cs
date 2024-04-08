// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.EventBus.Events;

/// <summary>
/// Represents the integration event.
/// </summary>
public record IntegrationEvent
{
    /// <summary>
    /// Initializaes a new instance of <see cref="IntegrationEvent"/>.
    /// </summary>
    public IntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the Id.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets the creation date.
    /// </summary>
    public DateTime CreationDate { get; private set; }

    /// <summary>
    /// Gets or sets the metadata.
    /// </summary>
    public string Metadata { get; set; }
}
