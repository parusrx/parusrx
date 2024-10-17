// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

namespace ParusRx.HRlink.API.Services;

/// <summary>
/// Provides methods allowing to work with route templates in HRlink.
/// </summary>
public interface IRouteTemplateService
{
    /// <summary>
    /// Gets the route template.
    /// </summary>
    /// <param name="request">The <see cref="RouteTemplateRequest"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The <see cref="RouteTemplateResponse"/>.</returns>
    ValueTask<RouteTemplateResponse?> GetRouteTemplatesAsync(RouteTemplateRequest request, CancellationToken cancellationToken = default);
}
