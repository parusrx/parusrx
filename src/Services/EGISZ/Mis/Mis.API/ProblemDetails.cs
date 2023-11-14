// Copyright (c) The Parus RX Authors. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ParusRx.Mis.API;

public record ProblemDetails(
    [property: JsonPropertyName("timestamp")] DateTimeOffset Timestamp,
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("reasonPhrase")] string ReasonPhrase,
    [property: JsonPropertyName("message")] string? Message
);
