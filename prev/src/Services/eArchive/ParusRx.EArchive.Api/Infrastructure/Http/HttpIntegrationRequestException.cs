// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace System.Net.Http;

/// <summary>
/// Http Integration Request exception class.
/// </summary>
public class HttpIntegrationRequestException : Exception
{
    internal RequestRetryType AllowRetry { get; } = RequestRetryType.NoRetry;

    /// <summary>
    /// Initializes a new instance of <see cref="HttpIntegrationRequestException"/>.
    /// </summary>
    public HttpIntegrationRequestException()
        : this(null, null)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="HttpIntegrationRequestException"/>.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public HttpIntegrationRequestException(string message)
        : this(message, null)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="HttpIntegrationRequestException"/>.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public HttpIntegrationRequestException(string message, Exception innerException)
        : base(message, innerException)
    {
        if (innerException != null)
        {
            HResult = innerException.HResult;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpIntegrationRequestException" /> class with a specific message that describes the current exception, an inner exception, and an HTTP status code.
    /// </summary>
    /// <param name="message">A message that describes the current exception.</param>
    /// <param name="inner">The inner exception.</param>
    /// <param name="statusCode">The HTTP status code.</param>
    public HttpIntegrationRequestException(string message, Exception inner, HttpStatusCode statusCode)
        : this(message, inner)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets the HTTP status code to be returned with the exception.
    /// </summary>
    /// <value>
    /// An HTTP status code if the exception represents a non-successful result, otherwise <c>null</c>.
    /// </value>
    public HttpStatusCode? StatusCode { get; }

    // This constructor is used internally to indicate that a request was not successfully sent due to an IOException,
    // and the exception occurred early enough so that the request may be retried on another connection.
    internal HttpIntegrationRequestException(string message, Exception inner, RequestRetryType allowRetry)
        : this(message, inner)
    {
        AllowRetry = allowRetry;
    }
}
