// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
