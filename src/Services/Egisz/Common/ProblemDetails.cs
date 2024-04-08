// Copyright (c) Alexander Bocharov.
// Licensed under the MIT License. See the LICENSE file in the project root for more information.

using System.Text.Json.Serialization;

namespace ParusRx.Egisz.Common;

public record ProblemDetails(
    [property: JsonPropertyName("timestamp")] DateTimeOffset Timestamp,
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("reasonPhrase")] string ReasonPhrase,
    [property: JsonPropertyName("message")] string? Message
);
