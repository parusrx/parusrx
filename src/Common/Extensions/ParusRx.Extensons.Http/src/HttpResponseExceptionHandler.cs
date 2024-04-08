// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

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
