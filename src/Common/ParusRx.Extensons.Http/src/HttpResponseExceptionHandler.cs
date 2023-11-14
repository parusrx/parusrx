// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ParusRx.Extensions.Http;

public sealed class HttpResponseExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is HttpResponseException httpResponseException)
        {
            httpContext.Response.StatusCode = httpResponseException.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(httpResponseException.Value, cancellationToken);
            return true;
        }

        return false;
    }
}
