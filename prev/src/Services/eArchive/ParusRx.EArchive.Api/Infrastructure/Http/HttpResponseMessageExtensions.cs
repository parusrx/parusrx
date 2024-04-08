// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace System.Net.Http;

/// <summary>
/// Extensions methods for <see cref="HttpResponseMessage"/>.
/// </summary>
public static class HttpResponseMessageExtensions
{
    /// <summary>
    /// Throws an exception if the System.Net.Http.HttpResponseMessage.IsSuccessStatusCode
    /// property for the HTTP response is false.
    /// </summary>
    /// <param name="httpResponseMessage">The <see cref="HttpResponseMessage"/>.</param>
    /// <returns>The HTTP response message if the call is successful.</returns>
    /// <exception cref="HttpIntegrationRequestException">The HTTP response is unsuccessful.</exception>
    public static HttpResponseMessage IntegrationEnsureSuccessStatusCode(this HttpResponseMessage httpResponseMessage)
    {
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            var message = Task.Run(async () => JsonSerializer.Deserialize<ResponseMessage>(await httpResponseMessage.Content.ReadAsStringAsync()))?.Result;

            throw new HttpIntegrationRequestException(string.Format(
                    System.Globalization.CultureInfo.InvariantCulture,
                    "Response status code does not indicate success: {0} ({1}).",
                    (int)httpResponseMessage.StatusCode,
                    message?.Message ?? httpResponseMessage.ReasonPhrase),
                inner: null,
                httpResponseMessage.StatusCode);
        }

        return httpResponseMessage;
    }
}
