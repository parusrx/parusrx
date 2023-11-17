// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Extensions.Http;

public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

    public int StatusCode { get; }
    public object? Value { get; }
}
