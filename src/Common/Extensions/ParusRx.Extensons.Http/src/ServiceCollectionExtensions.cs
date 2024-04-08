// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using ParusRx.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHttpResponseExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<HttpResponseExceptionHandler>();

        return services;
    }
}
