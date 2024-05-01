// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.Astral.API.Services;

public interface IEventService
{
    ValueTask<PublishEventsResponse?> PublishEventsAsync(CreatePublishEventsRequest request, CancellationToken cancellationToken = default);
}
